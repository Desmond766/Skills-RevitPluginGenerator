using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;

namespace BrickBuilder
{
    [Transaction(TransactionMode.Manual)]
    class IsolateCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //选择墙
            Reference reference = null;
            try
            {
                reference = sel.PickObject(ObjectType.Element, new WallSelectFilter());
            }
            catch
            {
                MessageBox.Show("取消选择，程序结束！");
                return Result.Failed;
            }

            //碰撞过滤器
            var intersectFilter = new ElementIntersectsElementFilter(doc.GetElement(reference));

            //收集找到的砖
            var collector = new FilteredElementCollector(doc).WherePasses(intersectFilter).OfClass(typeof(FamilyInstance));
            var ids = new List<ElementId>();
            foreach (var id in collector.ToElementIds())
            {
                var e = doc.GetElement(id);

                //if (e.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString() == "PC_普通砖_水平")
                //{
                //    ids.Add(id);
                //}

                ids.Add(id);
            }
            ids.Add(reference.ElementId);

            //隔离
            using (Transaction t = new Transaction(doc, "Isloate"))
            {
                t.Start();
                uiapp.ActiveUIDocument.ActiveView.IsolateElementsTemporary(ids);
                t.Commit();
            }  

            return Result.Succeeded;
        }
    }
}
