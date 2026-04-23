using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CreateDimensionsForVerticalPoleHanger
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            
            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance)).Where(x => x.Name.Equals("PM-多拉杆槽钢吊架（一层）")).Cast<FamilyInstance>().ToList();

            using (Transaction t = new Transaction(doc, "创建尺寸标注"))
            {
                t.Start();
                foreach (var item in familyInstances)
                {
                    Transform transform = item.GetTransform();
                    XYZ direction = transform.OfVector(XYZ.BasisX);
                    XYZ p = (item.Location as LocationPoint).Point;
                    //XYZ verticesEnd0 = p - direction * 20;
                    //XYZ verticesEnd1 = p + direction * 20;
                    //XYZ vertical1 = verticesEnd0.CrossProduct(verticesEnd1);
                    //XYZ verticalVector = new XYZ(vertical1.X, vertical1.Y, direction.Z).Normalize();
                    XYZ verticalVector = GetPerpendicularVector(direction);
                    p = p + verticalVector * (1000 / 304.8);
                    Line line = Line.CreateBound(p + direction * 2, p - direction * 2);
                    ReferenceArray referenceArray = new ReferenceArray();
                    int para1 = item.LookupParameter("水平端板1").AsInteger();
                    int para2 = item.LookupParameter("水平端板2").AsInteger();
                    int para3 = item.LookupParameter("水平端板3").AsInteger();
                    List<Reference> references = new List<Reference>();
                    references = item.GetReferences(FamilyInstanceReferenceType.WeakReference).ToList();
                    referenceArray.Append(references.First(x => x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 12) == ":482:SURFACE"));
                    referenceArray.Append(references.First(x => x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 12) == ":483:SURFACE"));
                    if (para1 == 1)
                    {
                        referenceArray.Append(references.First(x => x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 12) == ":488:SURFACE"));
                    }
                    if (para2 == 1)
                    {
                        referenceArray.Append(references.First(x => x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 12) == ":491:SURFACE"));
                    }
                    if (para3 == 1)
                    {
                        referenceArray.Append(references.First(x => x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 12) == ":492:SURFACE"));
                    }
                    doc.Create.NewDimension(uIDoc.ActiveView, line, referenceArray);
                }
                t.Commit();
            }
            return Result.Succeeded;
        }
        // 获取垂直向量
        private XYZ GetPerpendicularVector(XYZ direction)
        {
            // 计算垂直向量，这里简单地使用直线方向向量的法向量
            XYZ perpendicularVector = new XYZ(-direction.Y, direction.X, 0);
            return perpendicularVector;
        }
    }
}
