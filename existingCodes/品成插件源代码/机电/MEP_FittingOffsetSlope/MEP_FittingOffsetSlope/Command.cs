using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using System.IO;

namespace MEP_FittingOffsetSlope
{
     [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //try
            //{
            //    while (true)
            //    {
            //选择三通
            Reference r0 = null;
            r0 = sel.PickObject(ObjectType.Element, new FamilyinstanceSelectionFilter(), "请选择要旋转的三通");
                    //选择机电管线
                    Reference r1 = null;
                    Reference r2 = null;
                    Reference r3 = null;

                    r1 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");
                    r2 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");
                    r3 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");

                    Resolver resolver = new Resolver(commandData);
                    //try
                    //{
                        using (Transaction t = new Transaction(doc, "机电管线避让"))
                        {
                            t.Start();
                            resolver.Resolve(r0, r1, r2, r3);
                            if (!string.IsNullOrEmpty(Resolver.Message))
                            {
                                message = Resolver.Message;
                                return Result.Failed;
                            }
                            else
                            {
                                t.Commit();
                            }
                        }
                    //}
                    //catch (Exception e)
                    //{
                    //    message = e.Message;
                    //    return Result.Failed;
                    //}
            //    }
            //}
            //catch
            //{
            //}

            return Result.Succeeded;
        }
    }
}
