using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//tag所有埋件
namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    internal class Command03 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc,uIDoc.ActiveView.Id).OfCategory(BuiltInCategory.OST_SpecialityEquipment).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().ToList();
            //double count = 0;
            using (Transaction t = new Transaction(doc, "Create Dedicated Device Annotations"))
            {
                t.Start();
                foreach (FamilyInstance familyInstance in familyInstances)
                {
                    //if (!("L3 P2 P100 - MiniV_Angle".Contains(familyInstance.Name)))
                    //{
                    //    continue;
                    //} 
                    XYZ p1 = null;
                    XYZ p2 = null;
                    if (familyInstance.Name.Equals("L3"))
                    {
                        p1 = new XYZ(0.6, 1, 0);
                        p2 = new XYZ(2.1, 1, 0);
                    }
                    else if (familyInstance.Name.Equals("P2"))
                    {
                        p1 = new XYZ(1, -1, 0);
                        p2 = new XYZ(3, -1, 0);
                    }
                    else if (familyInstance.Name.Equals("P100 - MiniV_Angle"))
                    {
                        p1 = new XYZ(-0.5, 0.5, 0);
                        p2 = new XYZ(-1.5, 0.5, 0);
                    }
                    //count += 0.5;
                    Reference reference = new Reference(familyInstance);
                    XYZ p = (familyInstance.Location as LocationPoint).Point;
                    IndependentTag independentTag = IndependentTag.Create(doc, uIDoc.ActiveView.Id, reference, true, TagMode.TM_ADDBY_CATEGORY, TagOrientation.Horizontal, p);
                    independentTag.LeaderEndCondition = LeaderEndCondition.Free;
                    independentTag.LeaderEnd = p;
                    if (p1 != null)
                    {
                        independentTag.LeaderElbow = p + p1;
                        independentTag.TagHeadPosition = p + p2;
                    }
                    else
                    {
                        independentTag.LeaderElbow = p - new XYZ(0.5, 1, 0);
                        independentTag.TagHeadPosition = p - new XYZ(1, 1, 0);
                    }
                }
                t.Commit();
            }


            return Result.Succeeded;
        }
    }
}
