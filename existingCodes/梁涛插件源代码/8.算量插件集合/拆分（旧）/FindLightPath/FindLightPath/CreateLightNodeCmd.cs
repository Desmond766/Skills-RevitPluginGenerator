using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace FindLightPath
{
    // 根据视图中的灯具在拓扑线上生成相对应的灯具拓扑节点
    [Transaction(TransactionMode.Manual)]
    public class CreateLightNodeCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            FamilySymbol familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericModel)
                .WhereElementIsElementType().Where(x => x.Name == "品成-拓扑节点")
                .Cast<FamilySymbol>().FirstOrDefault();

            var lights = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_LightingFixtures).WhereElementIsNotElementType();
            // 在灯具节点上添加参数“灯具编号”
            Utils.AddProjectParameterToSystemFamily(doc, "灯具编号", ParameterType.Text, BuiltInCategory.OST_GenericModel);

            using (TransactionGroup TG = new TransactionGroup(doc, "创建灯具拓扑节点"))
            {
                TG.Start();

                using (Transaction t = new Transaction(doc, "激活族类型"))
                {
                    t.Start();

                    if (!familySymbol.IsActive)
                    {
                        familySymbol.Activate();
                    }

                    t.Commit();
                }
                
                foreach (var light in lights)
                {
                    XYZ max = light.get_BoundingBox(doc.ActiveView).Max;
                    XYZ min = light.get_BoundingBox(doc.ActiveView).Min;

                    XYZ point = max.Add(min) / 2;
                    point = new XYZ(point.X, point.Y, (light.Location as LocationPoint).Point.Z);

                    var boxFilter = ConnectAllCableTrayCmd.CreateIntersectsFilter(point, 400 / 304.8);
                    var solidFilter = ConnectAllCableTrayCmd.GetSolidFilter(point, null, 20 / 304.8, 400 / 304.8);
                    var cateFilter = new ElementCategoryFilter(BuiltInCategory.OST_Conduit);

                    // 创建一个过滤器过滤出存在参数“类型”且值为“品成-拓扑线”的元素
                    ElementId ruleParamId = new ElementId(BuiltInParameter.ELEM_TYPE_PARAM);
                    FilterRule filteRule = ParameterFilterRuleFactory.CreateEqualsRule(ruleParamId, "品成-拓扑线", true);
                    ElementParameterFilter paramFilter = new ElementParameterFilter(filteRule);

                    LogicalAndFilter andFilter = new LogicalAndFilter(new List<ElementFilter>() { boxFilter, solidFilter, cateFilter, paramFilter });
                    using (var conduitCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(andFilter))
                    {
                        if (conduitCol.Count() > 0)
                        {
                            Element elem = conduitCol.FirstOrDefault();
                            Line line = (elem.Location as LocationCurve).Curve as Line;
                            point = line.Project(point).XYZPoint;

                            // 断开拓扑线
                            Element copyElem = null;
                            Element copyElem2 = null;


                            using (Transaction t = new Transaction(doc, "复制拓扑线"))
                            {
                                t.Start();

                                ElementId id = ElementTransformUtils.CopyElement(doc, elem.Id, XYZ.Zero).First();
                                ElementId id2 = ElementTransformUtils.CopyElement(doc, elem.Id, XYZ.Zero).First();
                                copyElem = doc.GetElement(id);
                                copyElem2 = doc.GetElement(id2);

                                t.Commit();
                            }

                            try
                            {
                                Line newLine1 = Line.CreateBound(line.GetEndPoint(0), point);
                                Line newLine2 = Line.CreateBound(point, line.GetEndPoint(1));

                                using (Transaction t = new Transaction(doc, "断开拓扑线"))
                                {
                                    t.Start();
                                    (copyElem.Location as LocationCurve).Curve = newLine1;
                                    (copyElem2.Location as LocationCurve).Curve = newLine2;
                                    t.Commit();
                                }
                                //(elem.Location as LocationCurve).Curve = newLine1;

                            }
                            catch (Exception)
                            {
                                uidoc.ShowElements(elem);
                                sel.SetElementIds(new ElementId[] { elem.Id });
                                //TaskDialog.Show("revit", elem.Id.ToString() + "\n" + light.Id + "\n" + line.GetEndPoint(0) + "\n" + line.GetEndPoint(1) + "\n" + point);
                                return Result.Failed;
                            }
                            //doc.Delete(elem.Id);
                            using (Transaction t = new Transaction(doc, "删除多余线管"))
                            {
                                t.Start();
                                doc.Delete(elem.Id);
                                t.Commit();
                            }
                        }
                    }


                    using (Transaction t = new Transaction(doc, "创建灯具节点"))
                    {
                        t.Start();
                        FamilyInstance familyInstance = doc.Create.NewFamilyInstance(point, familySymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                        familyInstance.LookupParameter("灯具编号").Set(light.LookupParameter("灯具编号").AsString());
                        t.Commit();
                    }
                    
                }

                TG.Assimilate();
            }

            return Result.Succeeded;
        }
    }
}
