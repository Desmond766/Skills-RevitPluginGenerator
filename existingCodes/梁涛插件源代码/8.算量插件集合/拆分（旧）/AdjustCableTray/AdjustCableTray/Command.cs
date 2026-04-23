using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustCableTray
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            Selection sel = uIDoc.Selection;


            //Application app = commandData.Application.Application;
            ////创建对话框
            //TaskDialog mainDialog = new TaskDialog("isBIM模术师");//对话框的名称
            //mainDialog.MainInstruction = "产品使用说明";//对话框标题
            //mainDialog.MainContent = "isBIM模术师是基于Autodesk Revit软件的本地化功能插件集";//对话框的主要内容
            //mainDialog.ExpandedContent = "可用于建筑、结构、水电以及暖通等专业中";//对话框的扩展内容
            ////添加命令链接
            //mainDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "查看当前Revit版本信息", "Command1");
            //mainDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "查看模术师产品信息");
            //mainDialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel | TaskDialogCommonButtons.Retry;
            //mainDialog.VerificationText = "不再显示该信息";
            //mainDialog.MainIcon = TaskDialogIcon.TaskDialogIconInformation;
            ////mainDialog.ExtraCheckBoxText = "测试";
            ////添加文字超链接
            //mainDialog.FooterText = "<a href=\"http://www.bimcheng.com\">" + "点此处了解更多信息</a>";

            ////显示对话框并取得返回值
            //TaskDialogResult tResult = mainDialog.Show();

            ////使用对话框返回结果
            //if (TaskDialogResult.CommandLink1 == tResult)
            //{
            //    //链接一的扩展的对话框内容
            //    TaskDialog dialog_CommandLink1 = new TaskDialog("版本信息");
            //    dialog_CommandLink1.MainInstruction = "版本名:" + app.VersionNumber + "\n" + "版本号:"
            //        + app.VersionNumber;
            //    dialog_CommandLink1.Show();
            //}
            //else if (TaskDialogResult.CommandLink2 == tResult)
            //{
            //    //链接二的扩展的对话框内容
            //    TaskDialog.Show("模术师产品介绍", "isBIM模术师是一个全过程、全专业的高效解决方案");
            //}
            //else if (tResult == TaskDialogResult.Retry)
            //{
            //    TaskDialog.Show("模术师产品介绍", "retry");
            //}

            //return Result.Succeeded;



            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }
            double currentDis = window.Dis / 304.8;


            //Reference reference = sel.PickObject(ObjectType.Element);
            //CableTray cableTray = doc.GetElement(reference) as CableTray;
            //Transaction t = new Transaction(doc, "move");
            //t.Start();
            //cableTray.Location.Move(XYZ.BasisY.Negate() * 100 / 304.8);
            //t.Commit();
            //return Result.Succeeded;

            Reference refer = sel.PickObject(ObjectType.LinkedElement, "选择一个链接模型");
            RevitLinkInstance linkInstance = doc.GetElement(refer) as RevitLinkInstance;
            Transform transform = linkInstance.GetTransform();
            Document linkDoc = linkInstance.GetLinkDocument();
            FilteredElementCollector collector = new FilteredElementCollector(linkDoc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_StairsRailing);
            List<Railing> rails = collector.Cast<Railing>().ToList();

            Transaction tran = new Transaction(doc, "调整照明线槽");
            tran.Start();
            foreach (var item in rails)
            {
                //Railing item = linkDoc.GetElement(refer.LinkedElementId) as Railing;
                foreach (var path in item.GetPath())
                {
                    if (path is Line line)
                    {
                        XYZ p1 = transform.OfPoint(line.GetEndPoint(0));
                        XYZ p2 = transform.OfPoint(line.GetEndPoint(1));
                        Line newLine = Line.CreateBound(p1, p2);
                        XYZ cp = p1.Add(p2) / 2;
                        Outline outline = GetOutline(p1, p2);
                        ElementIntersectsSolidFilter solidFilter = GetSolidFilter(cp, newLine, 10000);
                        BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                        List<CableTray> cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray)
                            .WhereElementIsNotElementType().WherePasses(intersectsFilter).WherePasses(solidFilter).Cast<CableTray>().Where(x => x.Name.Contains("照明") && IsParallel(x, line)).ToList();
                        foreach (var t in cableTrays)
                        {
                            Line cableLine = (t.Location as LocationCurve).Curve as Line;
                            cableLine.MakeUnbound();
                            XYZ pp = cableLine.Project(cp).XYZPoint;
                            XYZ cpp = new XYZ(cp.X, cp.Y, pp.Z);

                            //XYZ pointOnRail = line.Project(pp).XYZPoint;
                            //pointOnRail = new XYZ(pointOnRail.X, pointOnRail.Y, pp.Z);
                            double dis = pp.DistanceTo(cpp);
                            if (dis != currentDis)
                            {
                                XYZ moveDir = (cpp - pp).Normalize();
                                double moveDis = dis - currentDis;
                                t.Location.Move(moveDir * moveDis);
                                //if (t.Id.IntegerValue == 3635910)
                                //{
                                //    TaskDialog.Show("revit", pp + "\n" + cpp + "\n" + moveDis + "\n" + moveDir);
                                //}
                            }

                        }
                    }
                }
            }
            tran.Commit();

            return Result.Succeeded;
        }

        private bool IsParallel(CableTray cableTray, Line line)
        {
            XYZ dirLine = line.Direction;
            Line cableLine = (cableTray.Location as LocationCurve).Curve as Line;
            XYZ dirCable = cableLine.Direction;
            if (dirLine.IsAlmostEqualTo(dirCable) || dirLine.IsAlmostEqualTo(dirCable.Negate())) return true;
            return false;
        }

        private Outline GetOutline(XYZ p1, XYZ p2)
        {
            XYZ min = new XYZ(p1.X < p2.X ? p1.X : p2.X, p1.Y < p2.Y ? p1.Y : p2.Y, -100000);
            XYZ max = new XYZ(p1.X > p2.X ? p1.X : p2.X, p1.Y > p2.Y ? p1.Y : p2.Y, 100000);
            Outline outline = new Outline(min - XYZ.BasisX * 2500 / 304.8 - XYZ.BasisY * 2500 / 304.8, max + XYZ.BasisX * 2500 / 304.8 + XYZ.BasisY * 2500 / 304.8);
            return outline;
        }
        public ElementIntersectsSolidFilter GetSolidFilter(XYZ centerP, Line line, double height)
        {
            XYZ verDir = GetPerpendicularVector(line.Direction);
            XYZ dir = line.Direction;
            double halfLen = line.Length / 2;

            XYZ p1 = centerP - dir * (halfLen + 2500 / 304.8) - verDir * 2500 / 304.8 - XYZ.BasisZ * height;
            XYZ p2 = centerP - dir * (halfLen + 2500 / 304.8) + verDir * 2500 / 304.8 - XYZ.BasisZ * height;
            XYZ p3 = centerP + dir * (halfLen + 2500 / 304.8) + verDir * 2500 / 304.8 - XYZ.BasisZ * height;
            XYZ p4 = centerP + dir * (halfLen + 2500 / 304.8) - verDir * 2500 / 304.8 - XYZ.BasisZ * height;
            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //拉伸
            Solid solid1 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, height * 2);
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid1);
            return filter;
        }
        // 获取垂直向量
        private XYZ GetPerpendicularVector(XYZ direction)
        {
            // 计算垂直向量，这里简单地使用直线方向向量的法向量
            XYZ perpendicularVector = new XYZ(-direction.Y, direction.X, 0);
            return perpendicularVector;
        }
    }
}
