# Sample Snippet: NewMepOffset

Source project: `existingCodes\梁涛插件源代码\3.管综\NewMepOffset\NewMepOffset`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 成排管线翻弯点对齐
namespace NewMepOffset
{
    // 框选管线进行批量翻弯
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //var reference = sel.PickObject(ObjectType.Element, new MEPCurveFilter());
            //var selres = doc.GetElement(reference) as MEPCurve;
            //Line line1 = (selres.Location as LocationCurve).Curve as Line;
            //XYZ sel1 = sel.PickPoint();
            //sel1 = line1.Project(sel1).XYZPoint;
            
            //XYZ sel2 = sel.PickPoint();
            //sel2 = line1.Project(sel2).XYZPoint;
            //using (Transaction t = new Transaction(doc, "Create"))
            //{
            //    t.Start();

            //    BreakMEPCurves(doc, selres, sel1, sel2);

            //    t.Commit();
            //}
            //return Result.Succeeded;

            KeyBoardEvent keyBoardEvent = new KeyBoardEvent();
            keyBoardEvent.startListen();

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                keyBoardEvent.stopListen();
                return Result.Cancelled;
            }

            double offset = mainWindow.Dis; // 偏移高度
            double angle = Properties.Settings.Default.Angle; // 弯通角度
            bool upDown = Properties.Settings.Default.UpDown; // 升降偏移
            bool singleSide = Properties.Settings.Default.SingleSide; // 单侧两侧
            XYZ upDir;


        Next:
            List<Reference> references;
            XYZ point1;
            XYZ point2;
            try
            {
                references = sel.PickObjects(ObjectType.Element, new MEPCurveFilter(), "框选管线(按下空格键以完成框选)").ToList();
                point1 = sel.PickPoint("选择翻弯点");
                point2 = sel.PickPoint(singleSide == true ? "选择翻弯方向" : "选择翻弯点2");
            }
            catch (Exception)
            {
                keyBoardEvent.stopListen();
                TaskDialog.Show("Revit", "结束布置");
                return Result.Succeeded;
            }
            List<MEPCurve> mEPCurves = references.Select(x => doc.GetElement(x) as MEPCurve).ToList();
            using (Transaction t = new Transaction(doc, "管线避让"))
            {
                t.Start();

                foreach (var mep in mEPCurves)
                {

                    Line mepLine = mep.GetLine();
                    Line ubMepLine = mepLine.Clone() as Line;
                    ubMepLine.MakeUnbound();

                    // 获取选择的管道的方向
                    XYZ newPoint1 = mepLine.Project(point1).XYZPoint;
// ... truncated ...
```

## Extension.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMepOffset
{
    public static class Extension
    {
        /// <summary>
        /// 获取创建管线的中心线
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        public static Line GetLine(this MEPCurve mEPCurve)
        {
            Line line;
            line = (mEPCurve.Location as LocationCurve).Curve as Line;
            return line;
        }
        /// <summary>
        /// 获取管线的连接器
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Connector GetConnector(this Element elem, int i)
        {
            Connector connector = null;

            if (elem is MEPCurve mEPCurve)
            {
                foreach (Connector con in mEPCurve.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }
            else if (elem is FamilyInstance familyInstance)
            {
                foreach (Connector con in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }

            
            return connector;
        }
        public static Connector GetConnector(this Element elem, int? i)
        {
            Connector connector = null;

            if (elem is MEPCurve mEPCurve)
            {
                foreach (Connector con in mEPCurve.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }
            else if (elem is FamilyInstance familyInstance)
            {
                foreach (Connector con in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }


            return connector;
        }
        /// <summary>
        /// 判断管线连接器是否与其他元素的连接器相连，若存在则返回相连元素与其连接器ID
// ... truncated ...
```

