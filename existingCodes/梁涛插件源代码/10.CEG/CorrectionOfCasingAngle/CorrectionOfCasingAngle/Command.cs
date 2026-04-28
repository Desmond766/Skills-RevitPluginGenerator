using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;

namespace CorrectionOfCasingAngle
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_PipeFitting);
            ElementCategoryFilter elementCategoryFilter2 = new ElementCategoryFilter(BuiltInCategory.OST_MechanicalEquipment);
            LogicalOrFilter logicalOrFilter = new LogicalOrFilter(elementCategoryFilter2, elementCategoryFilter);
            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(logicalOrFilter).OfClass(typeof(FamilyInstance)).Where(x => x.Name.Contains("HW-普通钢套管-水平") || x.Name.Equals("钢套管") || x.Name.Equals("HW-普通钢套管")).Cast<FamilyInstance>().ToList();
            //List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(logicalOrFilter).OfClass(typeof(FamilyInstance)).Where(x => x.Name.Equals("钢套管")).Cast<FamilyInstance>().ToList();
            //HashSet<string> names = new HashSet<string>();
            //string info = "";
            //foreach (FamilyInstance familyInstance in familyInstances)
            //{
            //    names.Add(familyInstance.Name);
            //}
            //foreach (string item in names)
            //{
            //    info += item + "\n";
            //}
            //TaskDialog.Show("sd", info);
            int count = 0;
            int notFind = 0;
            int rightDir = 0;
            using (Transaction t = new Transaction(doc,"修正套筒角度"))
            {
                t.Start();
                foreach (FamilyInstance familyInstance in familyInstances)
                {
                    ElementIntersectsElementFilter elementFilter = new ElementIntersectsElementFilter(familyInstance);
                    FilteredElementCollector pipes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_PipeCurves).OfClass(typeof(Pipe));
                    FilteredElementCollector cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray));
                    List<Pipe> pipes1 = pipes.WherePasses(elementFilter).Cast<Pipe>().ToList();
                    List<CableTray> cableTrays1 = cableTrays.WherePasses(elementFilter).Cast<CableTray>().ToList();
                    if (pipes1.Count == 0 && cableTrays1.Count == 0)
                    {
                        notFind++;
                        continue;
                    }
                    //if (pipes1.Count == 0) continue;
                    //Pipe pipe = pipes1.First();
                    Pipe pipe = null;
                    if (pipes1.Count == 1)
                    {
                        XYZ dir = ((pipes1.First().Location as LocationCurve).Curve as Line).Direction.Normalize();
                        if (dir.IsAlmostEqualTo(XYZ.BasisZ) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate())) continue;
                        pipe = pipes1.First();
                    }
                    if (pipes1.Count > 1)
                    {
                        foreach (Pipe item in pipes1)
                        {
                            XYZ dir = ((item.Location as LocationCurve).Curve as Line).Direction.Normalize();
                            if (!(dir.IsAlmostEqualTo(XYZ.BasisZ) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate()))) pipe = item;
                        }
                    }
                    CableTray cableTray = null;
                    if (cableTrays1.Count == 1)
                    {
                        XYZ dir = ((cableTrays1.First().Location as LocationCurve).Curve as Line).Direction.Normalize();
                        if (dir.IsAlmostEqualTo(XYZ.BasisZ) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate())) continue;
                        cableTray = cableTrays1.First();
                    }
                    if (cableTrays1.Count > 1)
                    {
                        foreach (CableTray item in cableTrays1)
                        {
                            XYZ dir = ((item.Location as LocationCurve).Curve as Line).Direction.Normalize();
                            if (!(dir.IsAlmostEqualTo(XYZ.BasisZ) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate()))) cableTray = item;
                        }
                    }
                    Transform transform = familyInstance.GetTransform();
                    XYZ pipeLineDir;
                    XYZ sleeveDir = transform.OfVector(XYZ.BasisX).Normalize();
                    if (pipe != null)
                    {
                        pipeLineDir = ((pipe.Location as LocationCurve).Curve as Line).Direction.Normalize();
                    }
                    else
                    {
                        pipeLineDir = ((cableTray.Location as LocationCurve).Curve as Line).Direction.Normalize();

                    }
                    if (sleeveDir.IsAlmostEqualTo(pipeLineDir) || sleeveDir.IsAlmostEqualTo(pipeLineDir.Negate()))
                    {
                        rightDir++;
                        continue;
                    }
                    //if (sleeveDir.IsAlmostEqualTo(pipeDir) || sleeveDir.IsAlmostEqualTo(pipeDir.Negate())) continue;
                    count++;
                    double angle = sleeveDir.AngleTo(pipeLineDir);
                    XYZ cPoint = (familyInstance.Location as LocationPoint).Point;
                    Line axis = Line.CreateBound(cPoint, new XYZ(cPoint.X, cPoint.Y, cPoint.Z + 1));
                    //TaskDialog.Show("qqq", ((angle / Math.PI) * 180).ToString());
                    if (angle > 0.5 * Math.PI)
                    {
                        angle = Math.PI - angle;
                    }
                    ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, - angle);
                    XYZ afterSleeveDir = familyInstance.GetTransform().OfVector(XYZ.BasisX).Normalize();
                    if (afterSleeveDir.IsAlmostEqualTo(pipeLineDir) || afterSleeveDir.IsAlmostEqualTo(pipeLineDir.Negate())) continue;
                    //TaskDialog.Show("qqq", "1111");
                    if (Math.Abs(sleeveDir.AngleTo(pipeLineDir) - 0.5 * Math.PI) > 0.001)
                    {
                        //TaskDialog.Show("qqq", "2222");
                        ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, -2 * (-angle));
                        //ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, 0.5 * Math.PI);
                    }
                }
                t.Commit();
            }
            //TaskDialog.Show("提示", "\n修正的套筒数量：" + count);
            //TaskDialog.Show("提示", "当前视图'HW-普通钢套管-水平'数量：" + familyInstances.Count() + "\n修正的套筒数量：" + count + "\n不需要修改的套筒数量：" + rightDir + "\n未识别到管道的套筒数量：" + notFind);
            TaskDialog.Show("提示", "当前视图'HW-普通钢套管-水平和钢套管'的数量：" + familyInstances.Count() + "\n修正的套管数量：" + count + "\n不需要修改的套管数量：" + (familyInstances.Count() - count));
            //if (count != 0) TaskDialog.Show("提示", "成功"); 
            return Result.Succeeded;
        }
    }
}
