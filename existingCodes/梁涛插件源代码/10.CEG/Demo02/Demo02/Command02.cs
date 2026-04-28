using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

//tag所有选定的板块
namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    internal class Command02 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            List<FamilyInstance> elements1 = new FilteredElementCollector(doc,uIDoc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().ToList();
            ViewPlan viewPlan = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).OfClass(typeof(ViewPlan)).Cast<ViewPlan>().ToList().FirstOrDefault();
            HashSet<string> familyNames = new HashSet<string>();

            UserControl02 userControl02 = new UserControl02();
            foreach (FamilyInstance item in elements1)
            {
                if (!familyNames.Contains(item.Symbol.FamilyName))
                {
                    familyNames.Add(item.Symbol.FamilyName);
                    userControl02.comboBox.Items.Add(item.Symbol.FamilyName);
                }
            }
            
            userControl02.ShowDialog();
            if (userControl02.cancel)
            {
                return Result.Cancelled;
            }
            //XYZ point = uIDoc.Selection.PickPoint();
            //TaskDialog.Show("tips", userControl02.value);
            // 在立面视图上创建与当前视图平行的工作平面
            using (Transaction transaction = new Transaction(doc, "Create Sketch Plane"))
            {
                transaction.Start();

                // 获取当前视图的方向
                XYZ viewDirection = uIDoc.ActiveView.ViewDirection;

                // 创建平面的位置（这里假设在Z轴方向上移动10个单位）
                XYZ planeLocation = new XYZ(0, 0, 10);

                // 创建平面
                Plane plane = Plane.CreateByNormalAndOrigin(viewDirection, planeLocation);

                // 在文档中创建平面
                SketchPlane sketchPlane = SketchPlane.Create(doc, plane);

                // 将新创建的平面设置为当前视图的工作平面
                uIDoc.ActiveView.SketchPlane = sketchPlane;

                transaction.Commit();
            }


            XYZ point = uIDoc.Selection.PickPoint();

            using (Transaction t = new Transaction(doc, "Create Tags"))
            {
                t.Start();
                foreach (FamilyInstance element in elements1)
                {
                    if (element.Symbol.FamilyName.Equals(userControl02.value))
                    {
                        Reference reference = new Reference(element);
                        XYZ p = (element.Location as LocationPoint).Point;
                        p = new XYZ(p.X, p.Y, point.Z);
                        IndependentTag independentTag = IndependentTag.Create(doc, uIDoc.ActiveView.Id, reference, false, TagMode.TM_ADDBY_CATEGORY, TagOrientation.Horizontal, p);
                    }
                }
                t.Commit();
            }
            return Result.Succeeded;
        }
    }
}
