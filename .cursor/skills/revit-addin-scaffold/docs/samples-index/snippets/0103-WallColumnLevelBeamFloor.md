# Sample Snippet: WallColumnLevelBeamFloor

Source project: `existingCodes\梁涛插件源代码\1.土建\WallColumnLevelBeamFloor\WallColumnLevelBeamFloor`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;
using Transform = Autodesk.Revit.DB.Transform;

namespace WallColumnLevelBeamFloor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        View3D view3D = null;
        bool LevelStruct;
        bool UpLevel;
        bool DownLevel;
        bool LevelBeam;
        bool LevelFloor;
        ElementParameterFilter ParamFilter;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //Element element = doc.GetElement(sel.PickObject(ObjectType.Element));
            //Element element2 = doc.GetElement(sel.PickObject(ObjectType.Element));
            //var reds = JoinGeometryUtils.AreElementsJoined(doc, element, element2);
            //var res = JoinGeometryUtils.IsCuttingElementInJoin(doc, element, element2);
            //TaskDialog.Show("d", reds.ToString()+"\n"+res);
            //return Result.Succeeded;

            //XYZ point = sel.PickPoint();
            //point = new XYZ(point.X, point.Y, 200000);
            //Transform transform = null;
            //Element elem = GetLinkFloorByRay(doc, doc.ActiveView as View3D, point, XYZ.BasisZ.Negate(), BuiltInCategory.OST_Floors, true, ref transform);
            //if (elem != null && elem.Document.IsLinked == true)
            //{
            //    TaskDialog.Show("revit", elem.Id.ToString());
            //    uidoc.ShowElements(elem);
            //    sel.SetElementIds(new ElementId[] { elem.Id });
            //}
            //return Result.Succeeded;

            //MainWindow mainWindow = new MainWindow();
            //mainWindow.ShowDialog();
            //return Result.Succeeded;

            //SelViewWindow selViewWindow = new SelViewWindow(doc);
            //selViewWindow.ShowDialog();
            //if (selViewWindow.DialogResult == true)
            //{
            //    MessageBox.Show((selViewWindow.list.SelectedItem as ViewInfo).View3D.Title);
            //}
            //return Result.Succeeded;

            //Assembly assembly = Assembly.LoadFrom(@"C:\Users\Administrator\Desktop\25.5.15后续新插件\RevitUtils\RevitUtils\bin\Debug\RevitUtils.dll");
            //Type type = assembly.GetType("RevitUtils.ViewUtils");
            //var flag = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.InvokeMethod;
            //View re = (View)assembly.GetType("RevitUtils.ViewUtils").InvokeMember("SelectView3D", flag, Type.DefaultBinder, null, new object[] {doc });
            //string info = "";
            //foreach (var item in assembly.GetType("RevitUtils.ViewUtils").GetMethods())
            //{
            //    info += item.Name + ":" + item.GetParameters() + "\n";

            //}
            //TaskDialog.Show("rei", info);
            //TaskDialog.Show("reid", re.Name);
            //var instance = Activator.CreateInstance(type);
            //var method = type.GetMethod("SelectView3D", new Type[] { typeof(Document) });
            //View viewss = (View)method?.Invoke(instance, new object[] { doc });
            //TaskDialog.Show("rei", viewss.Name);

            //return Result.Succeeded;


            if (doc.ActiveView is View3D) view3D = (View3D)doc.ActiveView;
            else
            {
// ... truncated ...
```

## CutUtils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace WallColumnLevelBeamFloor
{
    public class CutUtils
    {
        bool LevelBeam;
        bool LevelFloor;
        View3D View3D;
        ElementParameterFilter ParamFilter;

        public CutUtils(bool levelBeam, bool levelFloor, View3D view3D, ElementParameterFilter parameterFilter)
        {
            LevelBeam = levelBeam;
            LevelFloor = levelFloor;
            View3D = view3D;
            ParamFilter = parameterFilter;
        }
        public void LevelWall(Document doc, List<Element> walls, ref int count)
        {
            ElementFilter elementFilter = GetFilter();
            if (elementFilter == null) return;


            foreach (Element wall in walls)
            {
                // 25.7.10 墙中点坐标超过梁导致计算结果错误 || 楼板/梁被墙剪切导致射线结果出现问题
                //double dis = GetDistanceByRay(doc, wall, elementFilter, View3D, FindDirection.BasisZ, out string elemName);
                double dis = GetUpDistanceByRay(doc, wall, elementFilter, View3D, out string elemName);
                //TaskDialog.Show("revit", (dis*304.8).ToString());
                if (dis.Equals(double.NaN)) continue;
                using (Transaction t = new Transaction(doc, $"{elemName}切墙(上齐)"))
                {
                    t.Start();

                    if (null == doc.GetElement(wall.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId()) as Level)
                    {
                        //墙无连接高度
                        wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble() + dis);

                    }
                    else
                    {
                        //墙顶部偏移
                        wall.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).Set(wall.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).AsDouble() + dis);
                    }


                    t.Commit();
                }
                count++;
            }

        }
        public void LevelColumns(Document doc, List<Element> columns, ref int count)
        {
            ElementFilter elementFilter = GetFilter();
            if (elementFilter == null) return;

            foreach (Element column in columns)
            {

                double dis = GetUpDistanceByRay(doc, column, elementFilter, View3D, out string elemName);
                if (dis.Equals(double.NaN)) continue;

                using (Transaction t = new Transaction(doc, $"{elemName}切柱(上齐)"))
                {
                    t.Start();

                    column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).Set(column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).AsDouble() + dis);

                    t.Commit();
                }
                count++;
            }
        }
        public void DownLevelWall(Document doc, List<Element> walls, ref int count)
        {
            ElementFilter elementFilter = GetFilter();
            if (elementFilter == null) return;

// ... truncated ...
```

