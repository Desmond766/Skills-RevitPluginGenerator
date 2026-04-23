using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View = Autodesk.Revit.DB.View;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Windows.Markup;
using Reference = Autodesk.Revit.DB.Reference;

namespace CEGRegister
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command05 : IExternalCommand
    {
        UIDocument uidoc = null;
        int failedCount = 0;
        int insCount = 0;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!CheckRegClass.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion
            UIApplication uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            IList<Reference> references = uidoc.Selection.PickObjects(ObjectType.Element, new HangerFilter());

            UserControl1 userControl = new UserControl1();
            userControl.ShowDialog();
            if (userControl.cancel) return Result.Cancelled;

            View3D view3D = null;
            FilteredElementCollector viewCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (Element element in viewCollector)
            {
                View3D view3 = element as View3D;

                if (view3.Name.Equals("{三维}"))
                {
                    // 将获取到的3D视图添加到列表中
                    view3D = view3;
                }
            }
            if (view3D == null)
            {
                foreach (Element element in viewCollector)
                {
                    View3D view3 = element as View3D;

                    if (view3.Name.Equals("{3D}"))
                    {
                        // 将获取到的3D视图添加到列表中
                        view3D = view3;
                    }
                }
            }
            //TransactionGroup group = new TransactionGroup(doc, "创建吊架文字注释");
            //group.Start();
            //using (Transaction t = new Transaction(doc, "创建文字注释类型"))
            //{
            //    t.Start();
            //    textNoteType = GetTextNoteType(doc);
            //    t.Commit();
            //}
            using (Transaction t = new Transaction(doc, "创建吊架文字注释"))
            {
                t.Start();
                foreach (var item in references)
                {
                    //AddMethod(doc, item, userControl, view3D);
                    try
                    {
                        AddMethod(doc, item, userControl, view3D);

                    }
                    catch (Exception e)
                    {
                        //TaskDialog.Show("ll", e.Message);
                        failedCount++;
                        continue;
                    }
                }
                t.Commit();
            }
            //group.Assimilate();
            TaskDialog.Show("提示", $"选中{references.Count}个吊架\n成功生成{references.Count - failedCount - insCount}个文字注释\n未找到指定管线的吊架{insCount}个\n异常跳过{failedCount}个");
            return Result.Succeeded;
        }
        private void AddMethod(Document doc, Reference reference, UserControl1 userControl, View3D view3D)
        {
            FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
            Transform transform = familyInstance.GetTransform();
            XYZ direction = transform.OfVector(XYZ.BasisX);
            BoundingBoxXYZ boundingBox = familyInstance.get_BoundingBox(view3D);
            Outline outline = new Outline(boundingBox.Min, boundingBox.Max);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);

            XYZ centerP = (familyInstance.Location as LocationPoint).Point;
            if (familyInstance.Symbol.FamilyName.Contains("单管道"))
            {
                string sinInfo = "S" + "-" + familyInstance.LookupParameter("管夹尺寸").AsString() + "-" + familyInstance.LookupParameter("T/TL").AsString();
                CreateTextNote(doc, sinInfo, centerP, reference);
                return;
            }
            else if (familyInstance.Name.Contains("风管法兰抗震吊架"))
            {
                string ductHigh = familyInstance.LookupParameter("风管高度").AsValueString();
                string ductWidth = familyInstance.LookupParameter("风管宽度").AsValueString();
                string ductTTL = familyInstance.LookupParameter("T/TL").AsString();
                string ductInfo = $"F-{ductWidth}*{ductHigh}-{ductTTL}";
                CreateTextNote(doc,ductInfo,centerP, reference);
                return;
            }
            double elev = 0;
            double b_ = 0;
            foreach (Parameter item in familyInstance.Parameters)
                if (item.Definition.Name == "标高中的高程") elev = item.AsDouble();
            foreach (Parameter item in familyInstance.Parameters)
                if (item.Definition.Name == "b_底层管道底高") b_ = item.AsDouble();
            centerP = new XYZ(centerP.X, centerP.Y, centerP.Z + b_);
            //double length = familyInstance.LookupParameter("c_桥架宽").AsDouble();
            double length = 0;
            foreach (Parameter item in familyInstance.Parameters)
                if (item.Definition.Name == "c_桥架宽" || item.Definition.Name == "c_风管宽") length = item.AsDouble();
            //double length = familyInstance.LookupParameter("c_管线宽").AsDouble();
            XYZ verticesEnd0 = centerP - direction * (length / 2);
            XYZ verticesEnd1 = centerP + direction * (length / 2);
            XYZ vertical1 = verticesEnd0.CrossProduct(verticesEnd1);
            XYZ verticalVector = new XYZ(vertical1.X, vertical1.Y, direction.Z).Normalize();
            //XYZ verticalVector = XYZ.BasisY;
            XYZ vertices0 = centerP - direction * (length / 2) + verticalVector * (16 / 304.8);
            XYZ vertices1 = centerP - direction * (length / 2) - verticalVector * (16 / 304.8);
            XYZ vertices2 = centerP + direction * (length / 2) - verticalVector * (16 / 304.8);
            XYZ vertices3 = centerP + direction * (length / 2) + verticalVector * (16 / 304.8);

            Line line0 = Line.CreateBound(vertices0, vertices1);
            Line line1 = Line.CreateBound(vertices1, vertices2);
            Line line2 = Line.CreateBound(vertices2, vertices3);
            Line line3 = Line.CreateBound(vertices3, vertices0);



            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { line0, line1, line2, line3 };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //string width = familyInstance.LookupParameter("注释").AsValueString();
            //Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, boundingBox.Max.Z - boundingBox.Min.Z);
            double high;
            if(userControl.Insulation_Layer.IsChecked == true)
            {
                high = 150 / 304.8;
            }
            else
            {
                high = 100 / 304.8;
            }
            Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, high);

            List<Product8> colist = new List<Product8>();

            //ElementIntersectsElementFilter elementFilter = new ElementIntersectsElementFilter(familyInstance);

            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_DuctCurves));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_CableTray));
            LogicalOrFilter logicalOrFilter = new LogicalOrFilter(filterList);

            LogicalAndFilter logicalAndFilter = new LogicalAndFilter(logicalOrFilter, filter);
            //Outline outline = new Outline(vertices1, vertices3 + XYZ.BasisZ * high);
            //BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IEnumerable<Element> intersectingElements = collector.WherePasses(intersectsFilter).WherePasses(logicalAndFilter).ToElements();
            //IEnumerable<Element> intersectingElements = collector.WherePasses(elementFilter).ToElements();
            foreach (Element mep in intersectingElements)
            {
                double wide = 0;
                double height = 0;
                double lowHeight = 100;
                double hangerGC = 0;
                foreach (Parameter item in mep.Parameters)
                    if (item.Definition.Name == "底部高程") lowHeight = item.AsDouble();
                foreach (Parameter item in familyInstance.Parameters)
                    if (item.Definition.Name == "标高中的高程") hangerGC = item.AsDouble();
                //double spacing = lowHeight - (familyInstance.LookupParameter("b_底层管道底高").AsDouble() + familyInstance.LookupParameter("标高中的高程").AsDouble());
                double spacing = lowHeight - hangerGC - familyInstance.LookupParameter("b_底层管道底高").AsDouble();
                if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
                {
                    wide = mep.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).AsDouble();
                    height = mep.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).AsDouble();
                }
                //水管
                if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves)
                {
                    wide = mep.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
                }
                //线槽
                if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
                {
                    wide = mep.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble();
                }
                Product8 pro18 = new Product8()
                {
                    Cname = mep.Category.Name,
                    MEPwidth = wide * 304.8,
                    MEPheight = height * 304.8,
                    eId = mep.Id,
                    MEPCount = 1,
                    spacing = spacing * 304.8
                };
                colist.Add(pro18);
            }
            string info = "";
            if (colist.Count == 0)
            {
                insCount++;
                return;
            }
            if (colist.FirstOrDefault().Cname.Contains("风管"))
            {
                var curv = colist.FirstOrDefault();
                info = "F-" + curv.MEPwidth.ToString() + "*" + curv.MEPheight.ToString() + "-" + familyInstance.LookupParameter("T/TL").AsString();
                //familyInstance.LookupParameter("桥架平面标注").Set(info);
                //创建文字注释
                CreateTextNote(doc, info.Trim(), centerP, reference);
            }
            else
            {
                var query0 = from a in colist where a.Cname.Contains("桥架") select a;
                //var query = from a in query0 where a.spacing <= 100 select a;

                var b = from a1 in query0
                        group a1 by a1.MEPwidth into g
                        select new
                        {
                            width = g.Max(itm => itm.MEPwidth),
                            name = g.Max(itm => itm.Cname),
                            num = g.Sum(itm => itm.MEPCount),
                            coun = g.Count()
                        };
                if (b.Count() != 0)
                {
                    info += "Q-";
                }
                foreach (var item in b)
                {
                    info += item.width + "*" + item.coun + "+";
                }

                var query20 = from a in colist where a.Cname.Contains("管道") select a;
                //var query2 = from a in query20 where a.spacing <= 100 select a;

                var b2 = from a1 in query20
                         group a1 by a1.MEPwidth into g
                         select new
                         {
                             width = g.Max(itm => itm.MEPwidth),
                             name = g.Max(itm => itm.Cname),
                             num = g.Sum(itm => itm.MEPCount),
                             coun = g.Count()
                         };

                var b3 = from a in b2 where a.width > 0 select a;
                var b4 = from a in b2 where a.width > 50 select a;
                var b5 = from a in b2 where a.width > 0 && a.width <= 50 select a;
                if (b3.Count() != 0 && b.Count() == 0)
                {
                    info += "S-";
                }
                //foreach (var item in b3)
                //{
                //    info += "DN" + item.width + "*" + item.coun + "+";
                //}
                foreach (var item in b4)
                {
                    info += "DN" + item.width + "*" + item.coun + "+";
                }
                if (userControl.add.IsChecked == true)
                {
                    if (b4.Count() != 0 && b5.Count() != 0) info += "\n";
                    foreach (var item in b5)
                    {
                        info += "DN" + item.width + "*" + item.coun + "+";
                    }
                }
                if (b3.Count() + b.Count() != 0) info = info.Remove(info.LastIndexOf("+"), 1);
                info = info.Replace("*1", "");
                foreach (Parameter item in familyInstance.Parameters)
                {
                    if (item.Definition.Name == "T/TL") info += "-" + item.AsString();
                }
                info = info.Trim();
                string text = info;
                //创建文字注释
                CreateTextNote(doc, text, centerP, reference);
            }
        }

        public void CreateTextNote(Document doc,string text,XYZ centerP,Reference reference)
        {
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements();
            TextNoteType textNoteType = null;
            foreach (TextNoteType textType in textNoteTypes)
            {
                if (textType?.FamilyName == "文字")
                {
                    textNoteType = textType;
                    break;
                }
            }
            View view = uidoc.ActiveView;
            TextNote textNote = TextNote.Create(doc, view.Id, centerP, text, textNoteType.Id);

            //移动文本 使得文本下边中心对其元素中点
            textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
            textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).SetValueString("1.5 mm");
            view.Document.Regenerate();
            double scale = view.Scale;
            double textNoteWidth = textNote.Width * scale;

            // 计算偏移量，使对齐点为文本的下边中心
            XYZ offset = new XYZ(-textNoteWidth / 2, 1.25, 0);

            // 移动文本注释的位置
            ElementTransformUtils.MoveElement(doc, textNote.Id, offset);

            Element elem = doc.GetElement(reference);

            LocationPoint locationPoint = elem.Location as LocationPoint;
            double rota = locationPoint.Rotation;

            Line axis = Line.CreateBound(centerP, centerP + new XYZ(0, 0, 1));
            if (elem.Name == "风管法兰吊架-上固定" || elem.Name == "风管法兰吊架-下固定" || elem.Name.Contains("风管法兰抗震吊架"))
            {

                ElementTransformUtils.RotateElement(doc, textNote.Id, axis, rota + (Math.PI / 2));
            }
            else
            {
                ElementTransformUtils.RotateElement(doc, textNote.Id, axis, rota);
            }
            while (true)
            {
                if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).Y > centerP.Y)
                {
                    break;
                }
                else if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).Y == centerP.Y)
                {
                    if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).X < centerP.X)
                    {
                        break;
                    }
                }
                ElementTransformUtils.RotateElement(doc, textNote.Id, axis, Math.PI);
            }
        }
        public TextNoteType GetTextNoteType(Document doc)
        {
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements();
            TextNoteType textNoteType = null;
            foreach (TextNoteType textType in textNoteTypes)
            {
                if (textType?.FamilyName == "文字")
                {
                    textNoteType = textType;
                    break;
                }
            }
            textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
            textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).SetValueString("1.5 mm");
            return textNoteType;
        }
    }
    class Product8
    {
        /// <summary>
        /// 管道id
        /// </summary>
        public string Cname { set; get; }
        /// <summary>
        /// 管道射线距离
        /// </summary>
        public double MEPwidth { set; get; }
        public double MEPheight { set; get; }
        public int MEPCount { set; get; }

        public ElementId eId { set; get; }

        public double spacing { set; get; }


    }
    class HangerFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if ((elem.Category.Id.IntegerValue.Equals(-2001140) || elem.Category.Id.IntegerValue.Equals(-2008010) ) && ((elem as FamilyInstance).Symbol.Family.Name.Contains("抗震吊架")/* || (elem as FamilyInstance).Symbol.Family.Name.Contains("C型钢") */|| (elem as FamilyInstance).Symbol.Family.Name.Contains("抗震支吊架")))
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
