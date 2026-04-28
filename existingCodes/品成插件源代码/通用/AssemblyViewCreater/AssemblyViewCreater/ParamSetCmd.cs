using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyViewCreater
{
    [Transaction(TransactionMode.Manual)]
    class ParamSetCmd:IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            ////执行命令前多选
            //ICollection<ElementId> collection = sel.GetElementIds();
            IList<Reference> collection=sel.PickObjects(ObjectType.Element);

            //给所选构件添加参数
            string param = "備考";
            using (Transaction t = new Transaction(doc, "修改参数"))
            {
                t.Start();
                Utils.ParameterSet(collection, param, doc);
                t.Commit();
            }
          


            return Result.Succeeded;
        }
    }
}
