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
                    XYZ p = (door.Location as LocationPoint).Point;
                    doorInfos.Add(new DoorInfo() { Door = door, Point = transform.OfPoint(p) + addLength * doorDir });
                }
            }
            else
            {
                IList<Reference> doorRefers;
                try
                {
                    listenUtils.startListen();
                    doorRefers = sel.PickObjects(ObjectType.Element, new DoorFilter(), "框选门(空格键确定 ESC键取消)");
                    listenUtils.stopListen();
                }
                catch (OperationCanceledException)
                {
                    listenUtils.stopListen();
                    return Result.Cancelled;
                }
                List<FamilyInstance> doors = doorRefers.Select(r => (FamilyInstance)doc.GetElement(r)).ToList();
                foreach (var door in doors)
                {
                    XYZ doorDir = door.FacingOrientation;
                    double addLength = 1.0 / 304.8;

                    var hostElem = door.Host;
                    if (hostElem != null && hostElem is Wall wall)
                    {
                        addLength += wall.WallType.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM).AsDouble() / 2.0;
                    }
                    doorInfos.Add(new DoorInfo() { Door = door, Point = (door.Location as LocationPoint).Point + doorDir * addLength });
                }
            }



            switch (findType)
            {
                case 0:
                    RevitLinkInstance revitLinkInstance = (RevitLinkInstance)doc.GetElement(sel.PickObject(ObjectType.LinkedElement, "选择链接模型"));
                    Document linkDoc = revitLinkInstance.GetLinkDocument();
                    clearHeightInfos = ReviewDoorHeightByLinkModel(linkDoc, doorInfos);
                    break;
                case 1:
                    clearHeightInfos = ReviewDoorHeightByLocalModel(doc, doorInfos);
                    break;
                case 2:
                    RevitLinkInstance revitLinkInstance2 = (RevitLinkInstance)doc.GetElement(sel.PickObject(ObjectType.LinkedElement, "选择链接模型"));
                    Document linkDoc2 = revitLinkInstance2.GetLinkDocument();
                    clearHeightInfos = ReviewDoorHeightByBoth(doc, linkDoc2, doorInfos);
                    break;
                default:
                    break;
            }

            clearHeightInfos = clearHeightInfos.OrderByDescending(chi => chi.InstallClearHeightInScope == "不满足" && chi.OpenClearHeightInScope == "不满足")
                .ThenByDescending(chi => chi.InstallClearHeightInScope == "不满足").ThenByDescending(chi => chi.OpenClearHeightInScope == "不满足").ToList();

            MainWindow mainWindow = new MainWindow(uidoc, clearHeightInfos);
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(mainWindow);
            windowInteropHelper.Owner = intPtr;
            mainWindow.Show();

            return Result.Succeeded;
        }
        public string ConvertToHtmlColor(Autodesk.Revit.DB.Color color)
        {
            string htmlColor = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(color.Red, color.Green, color.Blue));
            return htmlColor;
        }
        private List<ClearHeightInfo> ReviewDoorHeightByBoth(Document doc, Document linkDoc, List<DoorInfo> doors)
        {
            List<ClearHeightInfo> clearHeightInfos = new List<ClearHeightInfo>();

            ElementMulticategoryFilter multicategoryFilter = new ElementMulticategoryFilter(new List<BuiltInCategory>() { BuiltInCategory.OST_Floors, BuiltInCategory.OST_StructuralFraming });
            foreach (var doorInfo in doors)
            {
                XYZ p = doorInfo.Point;
                FamilyInstance door = doorInfo.Door;

                ClearHeightInfo clearHeightInfo = new ClearHeightInfo() { DoorId = door.Id, Point = p };



                FamilySymbol doorSymbol = door.Symbol;
                // 门洞宽
                double doorWidth = doorSymbol.get_Parameter(BuiltInParameter.FURNITURE_WIDTH).AsDouble();
                double doorHeight = doorSymbol.get_Parameter(BuiltInParameter.FAMILY_HEIGHT_PARAM).AsDouble();
                XYZ doorDir = door.FacingOrientation;
                XYZ doorWidthDir = door.HandOrientation;

                // 安装平面范围
                double reviewLength = doorWidth / 3.0 + (350 / 304.8);
                double reviewWidth = doorWidth + (700 / 304.8);
                // 开启平面范围
                double reviewLength2 = doorWidth / 2.0 + (800 / 304.8);
                double reviewWidth2 = 2.0 * doorWidth;

                // 安装净高检测
                var andFilter = CreateMixFilter(p, doorDir, reviewLength, doorWidthDir, reviewWidth, doorHeight + 600 / 304.8);
                using (FilteredElementCollector elemCol = new FilteredElementCollector(doc).WherePasses(multicategoryFilter).WherePasses(andFilter))
                {
                    if (elemCol.Count(e => e is Floor || (e is FamilyInstance familyInstance && !familyInstance.Symbol.Name.Contains("明梁") && familyInstance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)) > 0)
                    {
                        clearHeightInfo.InstallClearHeightInScope = "不满足";
                        clearHeightInfo.InstallColor = HtmlBlue;
                        clearHeightInfo.InstallFontColor = HtmlRed;
                        clearHeightInfo.InstallFontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        using (FilteredElementCollector linkElemCol = new FilteredElementCollector(linkDoc).WherePasses(multicategoryFilter).WherePasses(andFilter))
                        {
                            if (linkElemCol.Count(e => e is Floor || (e is FamilyInstance familyInstance && !familyInstance.Symbol.Name.Contains("明梁") && familyInstance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)) > 0)
                            {
                                clearHeightInfo.InstallClearHeightInScope = "不满足";
                                clearHeightInfo.InstallColor = HtmlBlue;
                                clearHeightInfo.InstallFontColor= HtmlRed;
                                clearHeightInfo.InstallFontWeight = FontWeights.Bold;
                            }
                            else
                            {
                                clearHeightInfo.InstallClearHeightInScope = "满足";
                            }
                        }

                    }
                }

                // 开启净高检测
                var andFilter2 = CreateMixFilter(p, doorDir, reviewLength2, doorWidthDir, reviewWidth2, doorHeight + 300 / 304.8);
                using (FilteredElementCollector elemCol = new FilteredElementCollector(doc).WherePasses(multicategoryFilter).WherePasses(andFilter2))
                {
                    if (elemCol.Count(e => e is Floor || (e is FamilyInstance familyInstance && !familyInstance.Symbol.Name.Contains("明梁") && familyInstance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)) > 0)
                    {
                        clearHeightInfo.OpenClearHeightInScope = "不满足";
                        clearHeightInfo.OpenColor = HtmlBlue;
                        clearHeightInfo.OpenFontColor = HtmlRed;
                        clearHeightInfo.OpenFontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        using (FilteredElementCollector linkElemCol = new FilteredElementCollector(linkDoc).WherePasses(multicategoryFilter).WherePasses(andFilter2))
                        {
                            if (linkElemCol.Count(e => e is Floor || (e is FamilyInstance familyInstance && !familyInstance.Symbol.Name.Contains("明梁") && familyInstance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)) > 0)
                            {
                                clearHeightInfo.OpenClearHeightInScope = "不满足";
                                clearHeightInfo.OpenColor = HtmlBlue;
                                clearHeightInfo.OpenFontColor= HtmlRed;
                                clearHeightInfo.OpenFontWeight= FontWeights.Bold;
                            }
                            else
                            {
                                clearHeightInfo.OpenClearHeightInScope = "满足";
                            }
                        }
                    }
                }
                clearHeightInfos.Add(clearHeightInfo);
            }
            return clearHeightInfos;
        }
        private List<ClearHeightInfo> ReviewDoorHeightByLocalModel(Document doc, List<DoorInfo> doors)
        {
            List<ClearHeightInfo> clearHeightInfos = new List<ClearHeightInfo>();

            ElementMulticategoryFilter multicategoryFilter = new ElementMulticategoryFilter(new List<BuiltInCategory>() { BuiltInCategory.OST_Floors, BuiltInCategory.OST_StructuralFraming });
            foreach (var doorInfo in doors)
            {
                XYZ p = doorInfo.Point;
                FamilyInstance door = doorInfo.Door;

                ClearHeightInfo clearHeightInfo = new ClearHeightInfo() { DoorId = door.Id, Point = p };

                FamilySymbol doorSymbol = door.Symbol;
                // 门洞宽
                double doorWidth = doorSymbol.get_Parameter(BuiltInParameter.FURNITURE_WIDTH).AsDouble();
                double doorHeight = doorSymbol.get_Parameter(BuiltInParameter.FAMILY_HEIGHT_PARAM).AsDouble();
                XYZ doorDir = door.FacingOrientation;
                XYZ doorWidthDir = door.HandOrientation;

                // 安装平面范围
                double reviewLength = doorWidth / 3.0 + (350 / 304.8);
                double reviewWidth = doorWidth + (700 / 304.8);
                // 开启平面范围
                double reviewLength2 = doorWidth / 2.0 + (800 / 304.8);
                double reviewWidth2 = 2.0 * doorWidth;

                // 安装净高检测
                var andFilter = CreateMixFilter(p, doorDir, reviewLength, doorWidthDir, reviewWidth, doorHeight + 600 / 304.8);
                using (FilteredElementCollector elemCol = new FilteredElementCollector(doc).WherePasses(multicategoryFilter).WherePasses(andFilter))
                {
                    if (elemCol.Count(e => e is Floor || (e is FamilyInstance familyInstance && !familyInstance.Symbol.Name.Contains("明梁") && familyInstance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)) > 0)
                    {
                        clearHeightInfo.InstallClearHeightInScope = "不满足";
                        clearHeightInfo.InstallColor = HtmlBlue;
                        clearHeightInfo.InstallFontColor = HtmlRed;
                        clearHeightInfo.InstallFontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        clearHeightInfo.InstallClearHeightInScope = "满足";
                    }
                }

                // 开启净高检测
                var andFilter2 = CreateMixFilter(p, doorDir, reviewLength2, doorWidthDir, reviewWidth2, doorHeight + 300 / 304.8);
                using (FilteredElementCollector elemCol = new FilteredElementCollector(doc).WherePasses(multicategoryFilter).WherePasses(andFilter2))
                {
                    if (elemCol.Count(e => e is Floor || (e is FamilyInstance familyInstance && !familyInstance.Symbol.Name.Contains("明梁") && familyInstance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)) > 0)
                    {
                        clearHeightInfo.OpenClearHeightInScope = "不满足";
                        clearHeightInfo.OpenColor = HtmlBlue;
                        clearHeightInfo.OpenFontColor = HtmlRed;
                        clearHeightInfo.OpenFontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        clearHeightInfo.OpenClearHeightInScope = "满足";
                    }
                }
                clearHeightInfos.Add(clearHeightInfo);
            }
            return clearHeightInfos;
        }
        private List<ClearHeightInfo> ReviewDoorHeightByLinkModel(Document linkDoc, List<DoorInfo> doors)
        {
            List<ClearHeightInfo> clearHeightInfos = new List<ClearHeightInfo>();

            ElementMulticategoryFilter multicategoryFilter = new ElementMulticategoryFilter(new List<BuiltInCategory>() { BuiltInCategory.OST_Floors, BuiltInCategory.OST_StructuralFraming });
            foreach (var doorInfo in doors)
            {
                XYZ p = doorInfo.Point;
                FamilyInstance door = doorInfo.Door;

                ClearHeightInfo clearHeightInfo = new ClearHeightInfo() { DoorId = door.Id, Point = p };

                FamilySymbol doorSymbol = door.Symbol;
                // 门洞宽
                double doorWidth = doorSymbol.get_Parameter(BuiltInParameter.FURNITURE_WIDTH).AsDouble();
                double doorHeight = doorSymbol.get_Parameter(BuiltInParameter.FAMILY_HEIGHT_PARAM).AsDouble();
                XYZ doorDir = door.FacingOrientation;
                XYZ doorWidthDir = door.HandOrientation;

                // 安装平面范围
                double reviewLength = doorWidth / 3.0 + (350 / 304.8);
                double reviewWidth = doorWidth + (700 / 304.8);
                // 开启平面范围
                double reviewLength2 = doorWidth / 2.0 + (800 / 304.8);
                double reviewWidth2 = 2.0 * doorWidth;

                // 安装净高检测
                var andFilter = CreateMixFilter(p, doorDir, reviewLength, doorWidthDir, reviewWidth, doorHeight + 600 / 304.8);
                using (FilteredElementCollector elemCol = new FilteredElementCollector(linkDoc).WherePasses(multicategoryFilter).WherePasses(andFilter))
                {
                    if (elemCol.Count(e => e is Floor || (e is FamilyInstance familyInstance && !familyInstance.Symbol.Name.Contains("明梁") && familyInstance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)) > 0)
                    {
                        clearHeightInfo.InstallClearHeightInScope = "不满足";
                        clearHeightInfo.InstallColor = HtmlBlue;
                        clearHeightInfo.InstallFontColor = HtmlRed;
                        clearHeightInfo.InstallFontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        clearHeightInfo.InstallClearHeightInScope = "满足";
                    }
                }

                // 开启净高检测
                var andFilter2 = CreateMixFilter(p, doorDir, reviewLength2, doorWidthDir, reviewWidth2, doorHeight + 300 / 304.8);
                using (FilteredElementCollector elemCol = new FilteredElementCollector(linkDoc).WherePasses(multicategoryFilter).WherePasses(andFilter2))
                {
                    if (elemCol.Count(e => e is Floor || (e is FamilyInstance familyInstance && !familyInstance.Symbol.Name.Contains("明梁") && familyInstance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)) > 0)
                    {
                        clearHeightInfo.OpenClearHeightInScope = "不满足";
                        clearHeightInfo.OpenColor = HtmlBlue;
                        clearHeightInfo.OpenFontColor = HtmlRed;
                        clearHeightInfo.OpenFontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        clearHeightInfo.OpenClearHeightInScope = "满足";
                    }
                }
                clearHeightInfos.Add(clearHeightInfo);
            }
            return clearHeightInfos;
        }
        private LogicalAndFilter CreateMixFilter(XYZ p, XYZ lengthDir, double length, XYZ widthDir, double width, double height)
        {
            List<ElementFilter> elementFilters = new List<ElementFilter>();

            ElementIntersectsSolidFilter solidFilter = GetSolidFilter(p, lengthDir, length, widthDir, width, out var solid, height);
            elementFilters.Add(solidFilter);
            var box = solid.GetBoundingBox();
            XYZ min = box.Min + p + lengthDir * (length / 2.0) + XYZ.BasisZ * height;
            var max = box.Max + p + lengthDir * (length / 2.0) + XYZ.BasisZ * height;

            //using (Transaction t = new Transaction(Doc, "创建solid实体"))
            //{
            //    t.Start();

            //    //需在事务中进行
            //    DirectShape shape = DirectShape.CreateElement(Doc, new ElementId(BuiltInCategory.OST_StructuralFoundation));
            //    shape.AppendShape(new List<GeometryObject>() { solid });

            //    t.Commit();
            //}

            //TaskDialog.Show("revit", min + "\n" + max + "\n" + p +"\n"  + lengthDir + "\n" + length);

            Outline outline = new Outline(min, max);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
            elementFilters.Add(intersectsFilter);

            return new LogicalAndFilter(elementFilters);
        }
        private ElementIntersectsSolidFilter GetSolidFilter(XYZ p, XYZ lengthDir, double length, XYZ widthDir, double width, out Solid solid, double height)
        {
            XYZ upDir = XYZ.BasisZ;
            XYZ downP = p;
            XYZ p1 = downP + widthDir * (width / 2);
            XYZ p2 = downP + widthDir * (width / 2) + lengthDir * length;
            XYZ p3 = downP - widthDir * (width / 2) + lengthDir * length;
            XYZ p4 = downP - widthDir * (width / 2);
            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //拉伸
            solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, upDir, height);
            ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);

            return solidFilter;
        }
    }
    public class DoorFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is FamilyInstance door && door.Symbol.FamilyName.Contains("人防门") && elem.Category.Id.IntegerValue == -2000023)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
    public class LinkDoorFilter : ISelectionFilter
    {
        public RevitLinkInstance RevitLinkInstance = null;
        public bool AllowElement(Element elem)
        {
            RevitLinkInstance = elem as RevitLinkInstance;
            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            Document linkDoc = RevitLinkInstance.GetLinkDocument();
            Element linkElem = linkDoc.GetElement(reference.LinkedElementId);
            if (linkElem is FamilyInstance door && door.Symbol.FamilyName.Contains("人防门") && linkElem.Category.Id.IntegerValue == -2000023)
            {
                return true;
            }
            return false;
        }
    }
}
