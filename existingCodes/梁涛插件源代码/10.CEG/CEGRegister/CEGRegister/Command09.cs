using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGRegister
{
    //270单管吊架注释
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command09 : IExternalCommand
    {
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
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            SingleFilter filter = new SingleFilter();
            IList<Reference> references = uidoc.Selection.PickObjects(ObjectType.Element, filter);

            View view = uidoc.ActiveView;
            using (Transaction tran = new Transaction(doc, "添加标记"))
            {
                tran.Start();
                foreach (Reference refs in references)
                {
                    Element elem = doc.GetElement(refs);
                    AddIndependentTag.Add(doc, elem, view);
                }
                tran.Commit();
            }
            return Result.Succeeded;
        }
    }
    public class SingleFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem.Name == "单管吊架";
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
