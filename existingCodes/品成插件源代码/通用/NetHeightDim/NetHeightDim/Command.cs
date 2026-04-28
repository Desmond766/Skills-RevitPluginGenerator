//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
//20171122
//添加可选择查看管中的净高选项
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Reflection;
using System.IO;

namespace NetHeightDim
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //#region 判断加密
            ////注册验证
            //string licFile = string.Format("{0}\\Key.lic",
            //     System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //if (!BTAddInHelper.Utils.CheckReg(licFile))
            //{
            //    return Result.Cancelled;
            //}

            //#endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //获得三维视图
            if (!(doc.ActiveView is View3D))
            {
                message = "请在三维视图中使用该功能！";
                return Result.Failed;
            }
            View3D view3d = doc.ActiveView as View3D;

            //标注图元ID
            List<ElementId> ids = new List<ElementId>();

            //读取设置
            string path = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, "txt");
            List<string> setting = Utils.TxtToList(path);
            if (null == setting)
            {
                //setting = new List<string>() { "SelectCurrent","SlabDatum", "-", "DeleteNote" };
                setting = new List<string>()
                { "SelectCurrent", "Bottom", "SlabDatum", "-", "DeleteNote" };//陈清修改。还有以下的索引值[1][2][4]
            }

            //循环选择
            while (true)
            {
                try
                {
                    Reference reference;
                    XYZ pickedPoint;
                    //选择设置
                    if (setting[0] == "SelectCurrent")
                    {
                        reference = sel.PickObject(ObjectType.Element);
                        Element element = doc.GetElement(reference);
                        BoundingBoxXYZ bbox = element.get_BoundingBox(doc.ActiveView);
                        pickedPoint = new XYZ(reference.GlobalPoint.X, reference.GlobalPoint.Y, bbox.Min.Z);
                        //管底、管中：陈清添加
                        if (setting[1] == "Middle")
                        {
                            double d = bbox.Max.Z - bbox.Min.Z;
                            pickedPoint = new XYZ(reference.GlobalPoint.X, reference.GlobalPoint.Y, bbox.Min.Z + d * 0.5);
                        }
                        else//Bottom
                        {
                            pickedPoint = new XYZ(reference.GlobalPoint.X, reference.GlobalPoint.Y, bbox.Min.Z);
                        }
                    }
                    else//Link
                    {
                        reference = sel.PickObject(ObjectType.LinkedElement);
                        //链接模型
                        Element elementLink = doc.GetElement(reference);
                        Transform trans = (elementLink as Instance).GetTransform();
                        //选中的链接模型中的构件
                        RevitLinkInstance linkIns = doc.GetElement(reference) as RevitLinkInstance;
                        Element element = linkIns.GetLinkDocument().GetElement(reference.LinkedElementId);

                        BoundingBoxXYZ bbox = element.get_BoundingBox(doc.ActiveView);
                        pickedPoint = new XYZ(reference.GlobalPoint.X, reference.GlobalPoint.Y, trans.OfPoint(bbox.Min).Z);
                        //管底、管中：陈清添加
                        if (setting[1] == "Middle")
                        {
                            double d = trans.OfPoint(bbox.Max).Z - trans.OfPoint(bbox.Min).Z;
                            pickedPoint = new XYZ(reference.GlobalPoint.X, reference.GlobalPoint.Y, trans.OfPoint(bbox.Min).Z + d * 0.5);
                        }
                        else//Bottom
                        {
                            pickedPoint = new XYZ(reference.GlobalPoint.X, reference.GlobalPoint.Y, trans.OfPoint(bbox.Min).Z);
                        }
                    }

                    //基准设置
                    List<ElementId> dimElement;
                    if (setting[2] == "SlabDatum")
                    {
                        dimElement = DimByRay(doc, view3d, pickedPoint);
                    }
                    else//PickDatum
                    {
                        dimElement = DimByDatum(doc, reference, pickedPoint, double.Parse(setting[3]));
                    }
                    if (null != dimElement)
                    {
                        ids.AddRange(dimElement);
                    }
                }
                catch(Exception ex)
                {
                    //用户取消选择退出
                    if (ex.GetType().ToString()
                        == "Autodesk.Revit.Exceptions.OperationCanceledException")
                    {
                        //标注设置
                        if (setting[4] == "DeleteNote")
                        {
                            using (Transaction t = new Transaction(doc, "删除标注"))
                            {
                                t.Start();
                                doc.Delete(ids);
                                t.Commit();
                            }
                        }
                        break;
                    }
                    //其他异常
                    else
                    {
                        TaskDialog.Show("r", ex.Message + ex.StackTrace);
                    }
                }
            }
            return Result.Succeeded;
        }

        #region 绘制模型线
        /// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private ModelCurve DrawModelCurve(Document doc, XYZ p1, XYZ p2)
        {
            SketchPlane sketchPlane = SketchPlane.Create(doc, new Plane((p1 - p2).CrossProduct(p1), p2));
            return doc.Create.NewModelCurve(Line.CreateBound(p1, p2), sketchPlane);
        }
        #endregion

        #region 获得三维视图
        /// <summary>
        /// 获得三维视图
        /// </summary>
        /// <param name="doc">当前文档</param>
        /// <returns>三维视图</returns>
        public View3D Get3DView(Document doc)
        {
            View3D view = null;
            List<Element> list = new List<Element>();
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            list.AddRange(collector.OfClass(typeof(View3D)).ToElements());
            foreach (Autodesk.Revit.DB.View3D v in list)
            {
                if (v != null && !v.IsTemplate && v.Name == "{三维}")
                {
                    view = v as View3D;
                    break;
                }
            }
            return view;
        }
        #endregion

        #region 指定一个点及方向，返回反射点
        /// <summary>
        /// 指定一个点及方向，返回反射点
        /// </summary>
        /// <param name="view">当前文档</param>
        /// <param name="point">指定点</param>
        /// <param name="direction">指定方向</param>
        /// <returns>反射点</returns>
        private XYZ GetReflectPoint(View3D view, XYZ point, XYZ direction)
        {
            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));
            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            //此处存在BUG，仅仅将RvtLink当做一类构件进行判断，而不是进入RvtLink去判断文件中的各个类
            //详见Using ReferenceIntersector in Linked Files
            //http://thebuildingcoder.typepad.com/blog/2015/07/using-referenceintersector-in-linked-files.html
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, direction);
            return null == referenceWithContext ? new XYZ(point.X, point.Y, 0.0) : referenceWithContext.GetReference().GlobalPoint;
        }
        #endregion

        #region 创建标注
        /// <summary>
        /// 创建标注
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="startPt"></param>
        /// <param name="endPt"></param>
        /// <returns></returns>
        private List<ElementId> CreatNote(Document doc, XYZ startPt, XYZ endPt)
        {
            if (startPt.IsAlmostEqualTo(endPt))
                return null;
            XYZ origin = (startPt + endPt) / 2.0;
            double netHeight = startPt.DistanceTo(endPt);
            string strText = (netHeight * 304.8).ToString("0.0") + "mm";
            XYZ baseVec = XYZ.BasisZ;
            XYZ upVec = XYZ.BasisX;
            TextNote tn;
            ModelCurve curve;
            using (Transaction t = new Transaction(doc, "创建标注"))
            {
                t.Start();
                curve = DrawModelCurve(doc, startPt, endPt);
                tn = doc.Create.NewTextNote(doc.ActiveView, origin, baseVec, upVec, 0.01, TextAlignFlags.TEF_ALIGN_CENTER, strText);
                tn.Width = 10.0;
                t.Commit();
            }
            BoundingBoxXYZ bbTT = tn.get_BoundingBox(doc.ActiveView);
            XYZ bbCenter = (bbTT.Max + bbTT.Min) / 2.0;
            using (Transaction t = new Transaction(doc, "标注居中"))
            {
                t.Start();
                ElementTransformUtils.MoveElement(doc, tn.Id, tn.Coord - bbCenter);
                t.Commit();
            }
            return new List<ElementId>() { tn.Id, curve.Id };
        }
        #endregion

        #region 射线净高
        /// <summary>
        /// 射线净高
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="view3d"></param>
        /// <param name="startPt"></param>
        /// <returns></returns>
        private List<ElementId> DimByRay(Document doc, View3D view3d, XYZ startPt)
        {
            XYZ endPt = GetReflectPoint(view3d, startPt + XYZ.BasisZ.Negate() * 0.001, XYZ.BasisZ.Negate());
            return CreatNote(doc, startPt, endPt);
        }
        #endregion

        #region 基点净高
        /// <summary>
        /// 基点净高
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="reference"></param>
        /// <param name="startPt"></param>
        /// <param name="datum"></param>
        /// <returns></returns>
        private List<ElementId> DimByDatum(Document doc, Reference reference, XYZ startPt, double datum)
        {
            XYZ endPt = new XYZ(reference.GlobalPoint.X, reference.GlobalPoint.Y, datum / 0.3048);
            return CreatNote(doc, startPt, endPt);
        }
        #endregion

        #region 找到不同盘符的共享盘
        /// <summary>
        /// 找到不同盘符的共享盘
        /// </summary>
        /// <param name="specifiedPath">指定的路径</param>
        /// <returns>大家电脑上可以识别到的路径</returns>
        public static string SharedPath(string path)
        {
            //列出用户共享盘可能的盘符
            List<string> strList = new List<string>()
        {
            "A", "B", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", 
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
            for (int i = 0; i < strList.Count; i++)
            {
                string SharePath = path.Replace("X", strList[i]);
                if (Directory.Exists(SharePath))
                {
                    path = SharePath;
                    break;
                }
            }
            return path;
        }

        #endregion

    }
}
