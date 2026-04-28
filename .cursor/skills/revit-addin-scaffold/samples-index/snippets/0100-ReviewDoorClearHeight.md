# Sample Snippet: ReviewDoorClearHeight

Source project: `existingCodes\梁涛插件源代码\1.土建\ReviewDoorClearHeight\ReviewDoorClearHeight`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Navigation;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;
using Transform = Autodesk.Revit.DB.Transform;

namespace ReviewDoorClearHeight
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        Document Doc = null;
        string HtmlRed = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(255, 0, 0));
        string HtmlBlue = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(0, 0, 255));
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Doc = doc;
            Selection sel = uidoc.Selection;
            IntPtr intPtr = commandData.Application.MainWindowHandle;

            //sel.PickObjects(ObjectType.LinkedElement, new LinkDoorFilter());
            //return Result.Succeeded;

            SelWindow selWindow = new SelWindow();
            WindowInteropHelper windowInteropHelper2 = new WindowInteropHelper(selWindow);
            windowInteropHelper2.Owner = intPtr;
            selWindow.ShowDialog();
            if (selWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            int findType = Properties.Settings.Default.FindType;
            //TaskDialog taskDialog = new TaskDialog("梁板所在位置");
            //taskDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "链接模型");
            //taskDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "本地模型");
            //taskDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink3, "同时存在");
            //taskDialog.CommonButtons = TaskDialogCommonButtons.Cancel;
            //var result = taskDialog.Show();
            //if (result == TaskDialogResult.Cancel)
            //{
            //    //message = "已取消";
            //    return Result.Cancelled;
            //}
            List<ClearHeightInfo> clearHeightInfos = new List<ClearHeightInfo>();
            List<DoorInfo> doorInfos = new List<DoorInfo>();
            //ElementMulticategoryFilter multicategoryFilter = new ElementMulticategoryFilter(new List<BuiltInCategory>() { BuiltInCategory.OST_Floors, BuiltInCategory.OST_StructuralFraming });

            ListenUtils listenUtils = new ListenUtils();

            if (Properties.Settings.Default.IsLinkDoor)
            {
                IList<Reference> linkDoorRefers;
                try
                {
                    listenUtils.startListen();
                    linkDoorRefers = sel.PickObjects(ObjectType.LinkedElement, new LinkDoorFilter(), "框选门(空格键确定 ESC键取消)");
                    listenUtils.stopListen();
                }
                catch (OperationCanceledException)
                {
                    listenUtils.stopListen();
                    return Result.Cancelled;
                }
                foreach (var linkRefer in linkDoorRefers)
                {
                    RevitLinkInstance revitLinkInstance = doc.GetElement(linkRefer) as RevitLinkInstance;
                    Transform transform = revitLinkInstance.GetTransform();
                    Document linkDoc = revitLinkInstance.GetLinkDocument();
                    FamilyInstance door = linkDoc.GetElement(linkRefer.LinkedElementId) as FamilyInstance;
                    XYZ doorDir = transform.OfVector(door.FacingOrientation);
                    double addLength = 1.0 / 304.8;
                    if (door.Host != null && door.Host is Wall wall)
                    {
                        addLength += wall.WallType.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM).AsDouble() / 2.0;
                    }
// ... truncated ...
```

## ClearHeightInfo.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReviewDoorClearHeight
{
    public class ClearHeightInfo
    {
        public double OpenClearHeight { get; set; }
        public string OpenClearHeightInScope { get; set; }
        public string OpenColor { get; set; }
        public string OpenFontColor { get; set; } = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.Black);
        public FontWeight OpenFontWeight { get; set; } = FontWeights.Normal;
        public double InstallClearHeight { get; set; }
        public string InstallClearHeightInScope { get; set; }
        public string InstallColor { get; set; }
        public string InstallFontColor { get; set; } = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.Black);
        public FontWeight InstallFontWeight { get; set; } = FontWeights.Normal;
        public FamilyInstance Door { get; set; }
        public ElementId DoorId { get; set; }
        public XYZ Point { get; set; }
        public ClearHeightInfo(double openClearHeight, string openClearHeightInScope, string openColor, double installClearHeight, string installClearHeightInScope, string installColor)
        {
            OpenClearHeight = openClearHeight;
            OpenClearHeightInScope = openClearHeightInScope;
            OpenColor = openColor;
            InstallClearHeight = installClearHeight;
            InstallClearHeightInScope = installClearHeightInScope;
            InstallColor = installColor;
        }
        public ClearHeightInfo() { }
    }
}

```

