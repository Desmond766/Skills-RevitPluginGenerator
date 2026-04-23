using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace CreateThresholdStone
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        // 创建门槛石
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            if (!(doc.ActiveView is View3D))
            {
                message = "请在三维视图中运行该插件!";
                return Result.Failed;
            }

            MainWindow window = new MainWindow();
            // 获取运行该插件的进程的句柄(两种方法)
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            // 一个提供WPF窗体和win32之间互相操作的类，允许开发者获取WPF窗体的hwnd和设置WPF窗体的所有者
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(window);
            windowInteropHelper.Owner = intPtr;
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }
            double thickness = window.thickness / 304.8;

            Next:
            Reference reference;
            try
            {
                reference = sel.PickObject(ObjectType.Element, new WallOrDoorFilter(), "选择要创建门槛石的幕墙或门(按ESC键结束创建)");
            }
            catch (OperationCanceledException)
            {
                TaskDialog.Show("BIMTRANS", "结束创建！");
                return Result.Succeeded;
            }

            Element element = doc.GetElement(reference);
            CurveArray cu = new CurveArray();
            if (element is Wall wall)
            {
                Line line = (wall.Location as LocationCurve).Curve as Line;
                XYZ dir = line.Direction;
                XYZ verDir = dir.CrossProduct(XYZ.BasisZ).Normalize();
                XYZ p0 = line.GetEndPoint(0);
                XYZ p1 = line.GetEndPoint(1);

                double defaultHalfWidth = 50 / 304.8;
                double halfWidth = GetHalfStoneWidth(p0.Add(p1) / 2, verDir, doc.ActiveView as View3D);
                if (halfWidth != -1) defaultHalfWidth = halfWidth;

                XYZ cp1 = p0 + verDir * defaultHalfWidth;
                XYZ cp2 = p0 - verDir * defaultHalfWidth;
                XYZ cp3 = p1 - verDir * defaultHalfWidth;
                XYZ cp4 = p1 + verDir * defaultHalfWidth;
                cu.Append(Line.CreateBound(cp1, cp2));
                cu.Append(Line.CreateBound(cp2, cp3));
                cu.Append(Line.CreateBound(cp3, cp4));
                cu.Append(Line.CreateBound(cp4, cp1));
            }
            else if (element is FamilyInstance familyInstance)
            {
                XYZ dir = familyInstance.GetTransform().OfVector(XYZ.BasisX);
                XYZ verDir = dir.CrossProduct(XYZ.BasisZ).Normalize();
                XYZ point = (familyInstance.Location as LocationPoint).Point;
                FamilySymbol familySymbol = doc.GetElement(familyInstance.GetTypeId()) as FamilySymbol;
                // 门槛石长度 = 门宽度
                double length = familySymbol.LookupParameter("宽度").AsDouble();
                double halfLength = length / 2;

                double defaultHalfWidth = 50 / 304.8;
                double halfWidth = GetHalfStoneWidth(point, verDir, doc.ActiveView as View3D);
                if (halfWidth != -1) defaultHalfWidth = halfWidth;

                XYZ cp1 = point + dir * halfLength + verDir * defaultHalfWidth;
                XYZ cp2 = point + dir * halfLength - verDir * defaultHalfWidth;
                XYZ cp3 = point - dir * halfLength - verDir * defaultHalfWidth;
                XYZ cp4 = point - dir * halfLength + verDir * defaultHalfWidth;
                cu.Append(Line.CreateBound(cp1, cp2));
                cu.Append(Line.CreateBound(cp2, cp3));
                cu.Append(Line.CreateBound(cp3, cp4));
                cu.Append(Line.CreateBound(cp4, cp1));
            }

            var floorTypes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Where(ft => ft.Name.Contains("门槛石"))
                    .Cast<FloorType>();
            if (floorTypes.Count() == 0)
            {
                message = "未找到门槛石族类型";
                return Result.Failed;
            }

            using (Transaction t = new Transaction(doc, "创建门槛石"))
            {
                t.Start();

                FloorType newFloorType;
                FloorType floorType = floorTypes.FirstOrDefault(ft => Math.Abs(ft.get_Parameter(BuiltInParameter.FLOOR_ATTR_DEFAULT_THICKNESS_PARAM).AsDouble() - thickness) < 0.001);
                if (floorType != null)
                {
                    newFloorType = floorType;
                }
                else
                {
                    newFloorType = floorTypes.First().Duplicate($"A-门槛石-{window.thickness}mm") as FloorType;
                    SetFloorTypeThickness(newFloorType, thickness);
                }

                doc.Create.NewFloor(cu, newFloorType, doc.GetElement(element.LevelId) as Level, false);

                t.Commit();
            }
            goto Next;

            return Result.Succeeded;
        }
        private void SetFloorTypeThickness(FloorType floorType, double thicknessFeet)
        {
            // 获取楼板类型的复合结构
            CompoundStructure compoundStruct = floorType.GetCompoundStructure();

            // 获取所有结构层
            IList<CompoundStructureLayer> layers = compoundStruct.GetLayers();

            // 遍历所有层，找到结构层并修改其厚度
            for (int i = 0; i < layers.Count; i++)
            {
                // 判断层的功能是否为结构层
                if (layers[i].Function == MaterialFunctionAssignment.Structure)
                {
                    // 设置结构层的新厚度
                    compoundStruct.SetLayerWidth(i, thicknessFeet);
                    break; // 通常只有一个结构层，修改后即可退出循环
                }
            }

            // 将修改后的复合结构重新设置回楼板类型
            floorType.SetCompoundStructure(compoundStruct);
        }
        private double GetHalfStoneWidth(XYZ point, XYZ dir, View3D view3D)
        {
            double result = -1;
            point = point - XYZ.BasisZ * (10 / 304.8);

            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Floors);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(categoryFilter, FindReferenceTarget.All, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext rw = referenceIntersector.FindNearest(point, dir);
            if (rw != null)
            {
                double halfWidth = rw.GetReference().GlobalPoint.DistanceTo(point);
                if (halfWidth < 1000 / 304.8) result = halfWidth;
            }

            return result;
        }
    }
    // 幕墙与门过滤
    public class WallOrDoorFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Wall wall && (wall.WallType.Name.Contains("幕墙") || wall.WallType.FamilyName.Contains("幕墙")))
            {
                return true;
            }
            else if (elem is FamilyInstance familyInstance && elem.Category.Id.IntegerValue == -2000023 && (familyInstance.Symbol.Name.Contains("门") || familyInstance.Symbol.FamilyName.Contains("门")))
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
}
