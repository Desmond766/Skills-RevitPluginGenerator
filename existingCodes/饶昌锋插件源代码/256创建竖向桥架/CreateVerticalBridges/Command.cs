using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace CreateVerticalBridges
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            //var uiView = uidoc.GetOpenUIViews().FirstOrDefault(uv => uv.ViewId == doc.ActiveView.Id);
            //if (uiView != null)
            //{
            //    uiView.ZoomToFit();
            //}

            //return Result.Succeeded;

            int createType=1;
            CreateControl createControl = new CreateControl();
            createControl.ShowDialog();
            if (createControl.ConfirmButtonFlag)
            {
                if ((bool)createControl.LineCreate.IsChecked)
                {
                    createType = 1;
                }
                if ((bool)createControl.TTypeCreate.IsChecked)
                {
                    createType = 2;
                }
                if ((bool)createControl.LTypeCreate.IsChecked)
                {
                    createType = 3;
                }
            Next:
                bool flag;
                if (createControl.rb_create_both.IsChecked == true)
                {
                    flag = CreateBridges.CreateStart2(commandData.Application, doc, createType);
                }
                else
                {
                    flag = CreateBridges.CreateStart(commandData.Application, doc, createType);
                }
                if (flag)
                {
                    //return Result.Succeeded;
                    goto Next;
                }
                else return Result.Succeeded;
            }
            return Result.Cancelled;
        }
    }
}
