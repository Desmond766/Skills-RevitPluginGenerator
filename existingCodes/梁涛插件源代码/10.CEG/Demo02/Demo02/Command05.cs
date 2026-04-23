using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Reference = Autodesk.Revit.DB.Reference;
//画出坡度布置的埋件work point
namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    public class Command05 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            IList<Reference> references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new SpecializedEquipmentFilter(), "Select at least three embedded parts to compare");
            int count = 0;
            Line line3 = null;
            double length = double.MinValue;
            CurveArray curveArray = new CurveArray();
            for (int i = 0; i < references.Count() - 1; i++)
            {
                XYZ p1 = (doc.GetElement(references[i]).Location as LocationPoint).Point;
                for (int j = i + 1; j < references.Count(); j++)
                {
                    XYZ p2 = (doc.GetElement(references[j]).Location as LocationPoint).Point;
                    Line line = Line.CreateBound(p1,p2);
                    if (p1.DistanceTo(p2) > length)
                    {
                        length = p1.DistanceTo(p2);
                        line3 = Line.CreateBound(p1,p2);
                    }
                    curveArray.Append(line);
                }
            }
            //foreach (Reference reference in references)
            //{
            //    count++;
            //    if (count == 1)
            //    {
            //        p1 = (doc.GetElement(reference).Location as LocationPoint).Point;
            //    }
            //    if (count > 1)
            //    {
            //        XYZ p2 = (doc.GetElement(reference).Location as LocationPoint).Point;
            //        Line line = Line.CreateBound(p1, p2);
            //        curveArray.Append(line);
            //    }
            //}

            // 获取 CurveArray 中的线数量
            int numberOfLines = curveArray.Size;

            // 两两比较线
            for (int i = 0; i < numberOfLines - 1; i++)
            {
                Line line1 = curveArray.get_Item(i) as Line;

                for (int j = i + 1; j < numberOfLines; j++)
                {
                    Line line2 = curveArray.get_Item(j) as Line;
                    count++;
                    if (!(line1.Direction.Normalize().IsAlmostEqualTo(line2.Direction.Normalize()) || line1.Direction.Normalize().IsAlmostEqualTo(line2.Direction.Normalize().Negate())))
                    {
                        TaskDialog.Show("tip", "The Embedded Parts Are Not On The Same Straight Line");
                        return Result.Failed;
                    }
                    //line3 = line1.Length > line2.Length ? line1 : line2;
                }
            }
            // 使用过滤器获取所有线样式元素
            FilteredElementCollector collector = new FilteredElementCollector(doc)
                .OfClass(typeof(GraphicsStyle));

            // 使用 LINQ 查询查找匹配名称的线样式
            GraphicsStyle graphicsStyle = collector
                .Cast<GraphicsStyle>()
                .FirstOrDefault(pattern => pattern.GraphicsStyleCategory.Name.Equals("20-PTAC Dashed 1/16\""));
            // 开始事务
            using (Transaction transaction = new Transaction(doc, "Create Detail Line"))
            {
                transaction.Start();

                // 创建详图线
                DetailCurve detailCurve = doc.Create.NewDetailCurve(doc.ActiveView, line3);
                detailCurve.LineStyle = graphicsStyle;
                //doc.Create.NewDetailCurve(doc.ActiveView, line2);

                // 结束事务
                transaction.Commit();
            }
            return Result.Succeeded;
        }
    }
}
