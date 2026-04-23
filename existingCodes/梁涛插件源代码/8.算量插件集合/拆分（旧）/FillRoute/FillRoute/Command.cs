using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Macros;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace FillRoute
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            MainWindow window = new MainWindow();
            window.ShowDialog();

            if (window.DialogResult == false) return Result.Cancelled;

            IList<Reference> references;
            try
            {
                references = sel.PickObjects(ObjectType.Element, "框选需要填充路由的MEP实例");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("已取消操作");
                return Result.Cancelled;
            }
            using (Transaction t = new Transaction(doc, "填充路由"))
            {
                t.Start();

                foreach (var refer in references)
                {
                    Element element = doc.GetElement(refer);
                    var routePara = element.LookupParameter("路由");
                    if (routePara == null || routePara.IsReadOnly == true || routePara.StorageType != StorageType.String) continue;

                    if (string.IsNullOrEmpty(routePara.AsString()))
                    {
                        routePara.Set(window.AddRouteInfo);
                    }
                    else
                    {
                        routePara.Set(routePara.AsString() + "|" + window.AddRouteInfo);
                    }
                }

                t.Commit();
            }


            return Result.Succeeded;
        }
    }
    public class RouteInfo : INotifyPropertyChanged
    {
        private string _routeName;
        public string RouteName { get => _routeName; set { _routeName = value; OnPropertyChanged(nameof(RouteName)); } }
        private string _routeState = "+";
        public string RouteState { get => _routeState; set { _routeState = value; OnPropertyChanged(nameof(RouteState)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // 展示数据变化
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }

    public class MepCurveFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            if (element is CableTray || element is Conduit || element is FlexPipe || element is FamilyInstance)
            {
                return true;
            }
            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }
}
