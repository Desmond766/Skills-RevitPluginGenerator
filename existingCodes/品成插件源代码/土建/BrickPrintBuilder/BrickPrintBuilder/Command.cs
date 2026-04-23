using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace BrickPrintBuilder
{
	public enum BuildMode
    {
        Horizontal = 0,
        Vertical = 1,
        Unknow = -1
    }

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
		string verticalSymbolName = "标准砖";
		string horizontalSymbolName = "平面标准砖";
		public static double tickness { get; set; }
		public static bool grouped { get; set; }
		public static string unRegularBrick { get; set; }
		BuildMode mode;
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
			UIApplication application = commandData.Application;
            Document document = application.ActiveUIDocument.Document;
            Selection selection = application.ActiveUIDocument.Selection;

            if (new FilteredElementCollector(document).OfClass(typeof(Level)).Count() == 0)
            {
				message = "至少需要一个标高!";
				return Result.Cancelled;
            }
            var m = new FilteredElementCollector(document).OfClass(typeof(FloorType));

            MessageBox.Show(string.Join("\n", m.Select(u => u.Name)));
            //if (new FilteredElementCollector(document).OfClass(typeof(WallType)).Count() == 0)
            //         {
            //	message = "至少需要一个墙类型!";
            //	return Result.Cancelled;
            //}

            //显示对话框
            using (SettingForm settingForm = new SettingForm())
			{
				if (settingForm.ShowDialog() != DialogResult.OK)
                {
                    return Result.Cancelled;
                }
            }

			//选择底图
            Reference reference = selection.PickObject(ObjectType.Element);
            Element element = document.GetElement(reference.ElementId);

			if (!(element is Instance))
			{
				message = "请指定排砖图DWG!";
				return Result.Cancelled;
			}
			//判断排砖方向
			//XYZ max = element.get_BoundingBox(document.ActiveView).Max;
			//XYZ min = element.get_BoundingBox(document.ActiveView).Min;
			if (element.get_BoundingBox(document.ActiveView).Max.Z - element.get_BoundingBox(document.ActiveView).Min.Z < 0.001)
            {
				mode = BuildMode.Horizontal;
            }
			else//TODO
            {
				mode = BuildMode.Vertical;
			}

			//读取实体
			GeometryElement geometryElement = element.get_Geometry(new Options
			{
				View = document.ActiveView
			});
			Transform transform = (element as Instance).GetTransform();
			List<GeometryInstance> list = new List<GeometryInstance>();//块
			List<PolyLine> list2 = new List<PolyLine>();//标准矩形多段线
			List<PolyLine> list3 = new List<PolyLine>();//未知多段线，创建内建模型
			foreach (GeometryObject geometryObject in geometryElement)
			{
				GeometryInstance geometryInstance = geometryObject as GeometryInstance;
				if (null != geometryInstance)
				{
					foreach (GeometryObject geometryObject2 in geometryInstance.SymbolGeometry)
					{
						GraphicsStyle graphicsStyle = document.GetElement(geometryObject2.GraphicsStyleId) as GraphicsStyle;
						if (null != graphicsStyle)
						{
							if (graphicsStyle.GraphicsStyleCategory.get_Visible(document.ActiveView))
							{
								GeometryInstance geometryInstance2 = geometryObject2 as GeometryInstance;
								if (null != geometryInstance2)
								{
									list.Add(geometryInstance2);
								}
								PolyLine polyLine = geometryObject2 as PolyLine;
								if (null != polyLine)
								{
									if (this.IsStandardRet2(polyLine))
									{
										list2.Add(polyLine);
									}
									else
									{
										list3.Add(polyLine);
									}
								}
							}
						}
					}
				}
				if (list.Count == 0 && list2.Count == 0 && list3.Count == 0)
				{
					message = "未找到符合的块及多段线！";
					return Result.Cancelled;
				}
				else
				{
					List<PolyLine> list4 = new List<PolyLine>();//块里的多段线
					foreach (GeometryInstance geometryInstance3 in list)
					{
						foreach (GeometryObject geometryObject2 in geometryInstance3.SymbolGeometry)
						{
							GraphicsStyle graphicsStyle = document.GetElement(geometryObject2.GraphicsStyleId) as GraphicsStyle;
							if (null != graphicsStyle)
							{
								if (graphicsStyle.GraphicsStyleCategory.get_Visible(document.ActiveView))
								{
									PolyLine polyLine = geometryObject2 as PolyLine;
									if (null != polyLine)
									{
										if (this.IsStandardRet2(polyLine))
										{
											list4.Add(polyLine.GetTransformed(geometryInstance3.Transform));
										}
										else
										{
											list3.Add(polyLine.GetTransformed(geometryInstance3.Transform));
										}
									}
								}
							}
						}
					}
					//多段线准备完毕

					//找到砖
					string symbolName = "";
					if (mode == BuildMode.Horizontal)
                    {
						symbolName = horizontalSymbolName;
                    }
					else if(mode == BuildMode.Vertical)
                    {
						symbolName = verticalSymbolName;

					}
					Family family = this.FindFamilyByName(document, symbolName);
					if (null == family)
					{
						message = string.Format("未找到名为【{0}】的族！", symbolName);
						return Result.Cancelled;
					}
					else
					{
						List<ElementId> list5 = new List<ElementId>();//创建出来的砖
						FamilyInstance familyInstance = null;
						using (Transaction transaction = new Transaction(document, "砖翻模"))
						{
							transaction.Start();
							for (int i = 0; i < list2.Count; i++)
							{
								if (mode == BuildMode.Vertical)
                                {
									familyInstance = this.BuildBrick(document, family, list2[i], transform);
								}
								else
                                {
									familyInstance = this.BuildBrick2(document, family, list2[i], transform);
								}
								if (null != familyInstance)
								{
									list5.Add(familyInstance.Id);
								}
							}
							for (int i = 0; i < list4.Count; i++)
							{
								if (mode == BuildMode.Vertical)
								{
									familyInstance = this.BuildBrick(document, family, list4[i], transform);
								}
								else
								{
									familyInstance = this.BuildBrick2(document, family, list4[i], transform);
								}
								if (null != familyInstance)
								{
									list5.Add(familyInstance.Id);
								}
							}
							for (int i = 0; i < list3.Count; i++)
							{
								Element element2 = null;
								if (Command.unRegularBrick == "DirectShape")
                                {
									element2 = this.CreatDirectShape(document, list3[i], transform, mode);
								}
								else//wall floor
                                {
									element2 = this.CreatWallFloor(document, list3[i], transform, mode);
								}
								if (null != element2)
								{
									list5.Add(element2.Id);
								}
							}
							if (Command.grouped)
							{
								if (list5.Count > 1)
								{
									Group group = document.Create.NewGroup(list5);
								}
							}
							transaction.Commit();
						}
						//return Result.Succeeded;
					}
				}
			}
			return Result.Succeeded;
		}
		public Family FindFamilyByName(Document doc, string familyName)
		{
			FilteredElementCollector filteredElementCollector = new FilteredElementCollector(doc);
			ICollection<ElementId> collection = filteredElementCollector.OfClass(typeof(Family)).ToElementIds();
			foreach (ElementId elementId in collection)
			{
				if (doc.GetElement(elementId).Name == familyName)
				{
					return doc.GetElement(elementId) as Family;
				}
			}
			return null;
		}

		private FamilySymbol GetBrickSymbol(Document doc, Family brickFamily, double length, double width, double tickness)
		{
			FamilySymbol result;
			if (length < 0.001 || width < 0.001 || tickness < 0.001)
			{
				result = null;
			}
			else
			{
				string text = string.Format("{0}*{1}*{2}", (length * 304.8).ToString("0"), (width * 304.8).ToString("0"), (tickness * 304.8).ToString("0"));
				foreach (ElementId elementId in brickFamily.GetFamilySymbolIds())
				{
					if (doc.GetElement(elementId).Name == text)
					{
						return doc.GetElement(elementId) as FamilySymbol;
					}
				}
				FamilySymbol familySymbol = doc.GetElement(brickFamily.GetFamilySymbolIds().First<ElementId>()) as FamilySymbol;
				FamilySymbol familySymbol2 = familySymbol.Duplicate(text) as FamilySymbol;
				IList<Parameter> parameters = familySymbol2.GetParameters("长");
				if (parameters.Count == 0)
				{
					result = null;
				}
				else
				{
					parameters[0].Set(length);
					IList<Parameter> parameters2 = familySymbol2.GetParameters("宽");
					if (parameters2.Count == 0)
					{
						result = null;
					}
					else
					{
						parameters2[0].Set(width);
						IList<Parameter> parameters3 = familySymbol2.GetParameters("厚");
						if (parameters3.Count == 0)
						{
							result = null;
						}
						else
						{
							parameters3[0].Set(tickness);
							result = familySymbol2;
						}
					}
				}
			}
			return result;
		}

		//垂直砖翻模
		private FamilyInstance BuildBrick(Document doc, Family family, PolyLine pline, Transform tran)
		{
			Outline outline = pline.GetOutline();
			XYZ max = tran.OfPoint(outline.MaximumPoint);
			XYZ min = tran.OfPoint(outline.MinimumPoint);
			XYZ dir = new XYZ(max.X, max.Y, 0.0) - new XYZ(min.X, min.Y, 0.0);
			double length = new XYZ(max.X, max.Y, 0.0).DistanceTo(new XYZ(min.X, min.Y, 0.0));
			double width = max.Z - min.Z;
			FamilySymbol brickSymbol = this.GetBrickSymbol(doc, family, length, width, Command.tickness);
			FamilyInstance result;
			if (null == brickSymbol)
			{
				result = null;
			}
			else
			{
				if (!brickSymbol.IsActive)
				{
					brickSymbol.Activate();
				}
				XYZ xyz4 = min;
				FamilyInstance familyInstance = doc.Create.NewFamilyInstance(xyz4, brickSymbol, 0);
				Transform transform = Transform.CreateRotation(XYZ.BasisZ, XYZ.BasisX.AngleTo(dir));
				XYZ xyz5 = transform.OfVector(XYZ.BasisX);
				if (xyz5.AngleTo(dir) < 0.001)
				{
					ElementTransformUtils.RotateElement(doc, familyInstance.Id, Line.CreateBound(xyz4, xyz4 + XYZ.BasisZ), XYZ.BasisX.AngleTo(dir));
				}
				else
				{
					ElementTransformUtils.RotateElement(doc, familyInstance.Id, Line.CreateBound(xyz4, xyz4 + XYZ.BasisZ), -XYZ.BasisX.AngleTo(dir));
				}
				result = familyInstance;
			}
			return result;
		}

		//水平砖翻模
		private FamilyInstance BuildBrick2(Document doc, Family family, PolyLine pline, Transform tran)
        {
			Outline outline = pline.GetOutline();
			XYZ max = tran.OfPoint(outline.MaximumPoint);
			XYZ min = tran.OfPoint(outline.MinimumPoint);
			XYZ dir = new XYZ(max.X, max.Y, 0.0) - new XYZ(min.X, min.Y, 0.0);
			double length = max.X - min.X;
			double width = max.Y - min.Y;
			FamilySymbol brickSymbol = this.GetBrickSymbol(doc, family, length, width, Command.tickness);
			FamilyInstance result;
			if (null == brickSymbol)
			{
                result = null;
            }
            else
            {
                if (!brickSymbol.IsActive)
                {
					brickSymbol.Activate();
				}
                FamilyInstance familyInstance = doc.Create.NewFamilyInstance(min, brickSymbol, 0);
                result = familyInstance;
            }
            return result;
        }

		public void CreateModelLine(Document doc, XYZ p1, XYZ p2)
		{
			using (Line line = Line.CreateBound(p1, p2))
			{
				using (SketchPlane sketchPlane = SketchPlane.Create(doc, this.ToPlane(p1, p2)))
				{
					if (doc.IsFamilyDocument)
					{
						doc.FamilyCreate.NewModelCurve(line, sketchPlane);
					}
					else
					{
						doc.Create.NewModelCurve(line, sketchPlane);
					}
				}
			}
		}

		public Plane ToPlane(XYZ point, XYZ other)
		{
			XYZ xyz = other - point;
			double num = xyz.AngleTo(XYZ.BasisX);
			XYZ xyz2 = xyz.CrossProduct(XYZ.BasisX).Normalize();
			if (Math.Abs(num - 0.0) < 0.0001)
			{
				num = xyz.AngleTo(XYZ.BasisY);
				xyz2 = xyz.CrossProduct(XYZ.BasisY).Normalize();
			}
			if (Math.Abs(num - 0.0) < 0.0001)
			{
				num = xyz.AngleTo(XYZ.BasisZ);
				xyz2 = xyz.CrossProduct(XYZ.BasisZ).Normalize();
			}
			//return new Plane(xyz2, point);//2016
			return Plane.CreateByNormalAndOrigin(xyz2, point);
		}

		private bool IsStandardRet(PolyLine pline)
		{
			IList<XYZ> coordinates = pline.GetCoordinates();
			Outline outline = pline.GetOutline();
			bool flag = false;
			bool flag2 = false;
			foreach (XYZ xyz in coordinates)
			{
				if (xyz.IsAlmostEqualTo(outline.MaximumPoint))
				{
					flag = true;
				}
				if (xyz.IsAlmostEqualTo(outline.MinimumPoint))
				{
					flag2 = true;
				}
			}
			return flag && flag2;
		}

		private bool IsStandardRet2(PolyLine pline)
		{
			IList<XYZ> coordinates = pline.GetCoordinates();
			bool result;
			if (coordinates.Count != 5)
			{
				result = false;
			}
			else
			{
				CurveLoop curveLoop = null;
				try
				{
					List<Curve> list = new List<Curve>();
					for (int i = 0; i < coordinates.Count - 1; i++)
					{
						list.Add(Line.CreateBound(coordinates[i], coordinates[i + 1]));
					}
					curveLoop = CurveLoop.Create(list);
				}
				catch
				{
					return false;
				}
				if (null != curveLoop)
				{
					if (null != curveLoop.GetPlane())
					{
						return curveLoop.IsRectangular(curveLoop.GetPlane());
					}
				}
				result = false;
			}
			return result;
		}

		//内建模型-两个方向
		private Element CreatDirectShape(Document doc, PolyLine pline, Transform tran, BuildMode mode)
		{
			Element result;
			try
			{
				IList<XYZ> coordinates = pline.GetCoordinates();
				List<XYZ> list = new List<XYZ>();
				list.Add(coordinates[0]);
				for (int i = 1; i < coordinates.Count; i++)
				{
					if (!coordinates[i].IsAlmostEqualTo(coordinates[i - 1]))
					{
						list.Add(coordinates[i]);
					}
				}
				List<Curve> list2 = new List<Curve>();
				for (int i = 0; i < list.Count - 1; i++)
				{
					list2.Add(Line.CreateBound(tran.OfPoint(list[i]), tran.OfPoint(list[i + 1])));
				}
				CurveLoop item = CurveLoop.Create(list2);
				List<CurveLoop> list3 = new List<CurveLoop>();
				list3.Add(item);
				Outline outline = pline.GetOutline();
				XYZ dir = null;
				if (mode == BuildMode.Vertical)
                {
					dir = (outline.MaximumPoint - outline.MinimumPoint).CrossProduct(XYZ.BasisZ);
				}
				else
                {
                    dir = XYZ.BasisZ.Negate();
                }
                Solid item2 = GeometryCreationUtilities.CreateExtrusionGeometry(list3, dir, Command.tickness);
     //           DirectShape directShape = DirectShape.CreateElement(
					//doc, 
					//new ElementId((int)BuiltInCategory.OST_DataDevices),
					//Guid.NewGuid().ToString(),
					//Guid.NewGuid().ToString()); //2016
				DirectShape directShape = DirectShape.CreateElement(
					doc,
					new ElementId((int)BuiltInCategory.OST_DataDevices));
				directShape.AppendShape(new List<GeometryObject>
                {
                    item2
                });
                result = directShape;
			}
			catch
			{
				result = null;
			}
			return result;
		}


		//创建楼板
		private Element CreatWallFloor(Document doc, PolyLine pline, Transform tran, BuildMode mode)
        {
			Element result;
			Level le = new FilteredElementCollector(doc).OfClass(typeof(Level)).First() as Level;
			try
			{
				IList<XYZ> coordinates = pline.GetCoordinates();
				List<XYZ> list = new List<XYZ>();
				list.Add(coordinates[0]);
				for (int i = 1; i < coordinates.Count; i++)
				{
					if (!coordinates[i].IsAlmostEqualTo(coordinates[i - 1]))
					{
						list.Add(coordinates[i]);
					}
				}
				IList<Curve> curveList = new List<Curve>();
				CurveArray array = new CurveArray();
				for (int i = 0; i < list.Count - 1; i++)
				{
					Line line = Line.CreateBound(tran.OfPoint(list[i]), tran.OfPoint(list[i + 1]));
					array.Append(line);
					curveList.Add(line);
				}

				if (mode == BuildMode.Vertical)
                {
					WallType wallType = null;
					string wallTypeName = "立面异形砖" + (tickness * 304.8).ToString("0");
					//create wall
					var typeList = new FilteredElementCollector(doc)
						.OfClass(typeof(WallType));
					foreach (var item in typeList)
					{
						if (item.Name == wallTypeName)
						{
							wallType = item as WallType;
							break;
						}
					}
					if (null == wallType)
					{
						wallType = (typeList.First() as WallType)
                            .Duplicate(wallTypeName)
                            as WallType;
                        CompoundStructure compound = wallType.GetCompoundStructure();
                        compound.SetLayerWidth(0, tickness);
                        wallType.SetCompoundStructure(compound);
                    }
                    result = Wall.Create(doc, curveList, wallType.Id, le.Id, false);
                    double baseOffset = result.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble();
                    double zOffset = tran.OfPoint(pline.GetOutline().MinimumPoint).Z;
                    result.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).Set(zOffset - baseOffset);
                    //ElementTransformUtils.MoveElement(doc, result.Id, new XYZ(0.0, 0.0, zOffset));
                }
                else
                {
					FloorType floorType = null;
                    string floorTypeName = "平面异形砖" + (tickness * 304.8).ToString("0");
                    //create floor
                    var typeList = new FilteredElementCollector(doc)
                        .OfClass(typeof(FloorType)).Cast<FloorType>()
                        .Where(u => !u.IsFoundationSlab);
                    foreach (var item in typeList)
                    {
						if (item.Name == floorTypeName)
                        {
							floorType = item as FloorType;
							break;
                        }
                    }
					if (null == floorType)
                    {
						floorType =(typeList.First() as FloorType)
							.Duplicate(floorTypeName)
                            as FloorType;
                        CompoundStructure compound = floorType.GetCompoundStructure();
                        compound.SetLayerWidth(0, tickness);
                        floorType.SetCompoundStructure(compound);
                    }
                    result = doc.Create.NewFloor(array,floorType,le, false);
                    //result = doc.Create.NewFloor(array, false);
                }
			}
			catch(Exception ex)
			{
				//MessageBox.Show(ex.Message + ex.StackTrace);
				result = null;
			}
			return result;
		}

	}
}
