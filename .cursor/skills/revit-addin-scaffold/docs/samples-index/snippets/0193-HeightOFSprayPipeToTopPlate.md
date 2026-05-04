# Sample Snippet: HeightOFSprayPipeToTopPlate

Source project: `existingCodes\饶昌锋插件源代码\259判断喷淋支管和顶板的高差\HeightOFSprayPipeToTopPlate`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Data.Common;
using System.Xml.Linq;

namespace HeightOFSprayPipeToTopPlate
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]

    public class Command : IExternalCommand 
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            View view = uidoc.ActiveView;

            //打开窗口
            UserWindow window = new UserWindow();
            window.Show();
            // 从WPF窗口中获取参数
            string heightDifference = window.HeightDifference.Text;
            ClickEvent clickEvent = new ClickEvent(view, window.ElemCategory);
            ExternalEvent myClickEvent = ExternalEvent.Create(clickEvent);
            // 在WPF窗口中注册确认按钮的点击事件处理程序
            window.ConfirmButton.Click += (sender, e) =>
            {
                heightDifference = window.HeightDifference.Text;
                clickEvent.InputValue = heightDifference;
                // 在Revit事务中使用参数执行操作
                myClickEvent.Raise();
            };
            return Result.Succeeded;
        }
    }
}

```

## CalculatedHeightDifference.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HeightOFSprayPipeToTopPlate
{
    public class CalculatedHeightDifference
    {
        /// <summary>
        /// 获取高差
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="view"></param>
        /// <param name="inputValue"></param>
        public static void GetHeightDifference(Document doc, View view, string inputValue, List<string> elemCategory)
        {
            if (elemCategory.Count == 0) return;
            //TaskDialog.Show("sadas","开始运行");
            //获取所有水管
            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves);
            FilteredElementCollector collector = new FilteredElementCollector(doc, view.Id);
            List<Element> pipes = collector.WherePasses(categoryFilter).ToList();

            //支管中心射线向上获取楼板地面
            View3D view3D = null;
            FilteredElementCollector viewCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (Element element in viewCollector)
            {
                View3D view3 = element as View3D;

                if (view3.Name.Equals("3D 支吊架"))
                {
                    // 将获取到的3D视图添加到列表中
                    view3D = view3;
                }
            }

            if (!elemCategory.Contains("喷淋支管")) goto Next;
            //过滤喷淋支管 直径小于65
            List<MEPCurve> targetPipes = new List<MEPCurve>();
            foreach (Element elem in pipes)
            {
                MEPCurve pipe = elem as MEPCurve;
                if (Util.VerticalOHorizontal(pipe))
                {
                    continue;
                }
                if (IsSprayPipe(pipe) && (pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 304.8) <= 65)
                {
                    targetPipes.Add(pipe);
                }
            }
            if (targetPipes.Count==0)
            {
                TaskDialog.Show("提示", "没有喷淋支管");
            }

            //Transform transform = Util.CoordinateTransformation(doc);
            foreach (MEPCurve pipe in targetPipes)
            {
                XYZ centerPoint = Util.GetMEPCurveCentrePoint(pipe);
                //centerPoint=transform.OfPoint(centerPoint);
                ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Floors);
                // 使用ReferenceIntersector进行射线与模型元素的交互检测
                ReferenceIntersector referenceIntersector = new ReferenceIntersector(filter, FindReferenceTarget.Face, view3D);
                referenceIntersector.FindReferencesInRevitLinks = true;
                ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(centerPoint, XYZ.BasisZ);
                double actualHeightDifference = 0;
                if (referenceWithContext != null)
                {

                    actualHeightDifference = referenceWithContext.Proximity;

                    JudgingHeightDifference(doc,view,inputValue, Math.Round(actualHeightDifference * 304.8, 1), pipe);
                }
            }
        Next:
            if (!elemCategory.Contains("套管")) return;
            using (FilteredElementCollector bushCol = new FilteredElementCollector(doc, doc.ActiveView.Id))
            {
                bushCol.OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance));
                var bushs = bushCol.Cast<FamilyInstance>().Where(b => b.Symbol.Name.Contains("套管")).ToList();
// ... truncated ...
```

## ClickEvent.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HeightOFSprayPipeToTopPlate
{
    public class ClickEvent : IExternalEventHandler
    {
        private  View view;
        private  string inputValue;
        List<string> ELemCategorys = new List<string>();
        public ClickEvent(View view, List<string> elemCategorys)
        {
            this.view = view;
            this.ELemCategorys = elemCategorys;
        }

        public string InputValue { get => inputValue; set => inputValue = value; }

        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            if (ELemCategorys.Count == 0) return;
            string trName = ELemCategorys.Aggregate((a, b) => a + "/" + b);
            //string trName = "ss";
            using (Transaction transaction = new Transaction(doc, $"{trName}与顶板的高差"))
            {

                try
                {
                    transaction.Start();
                    CalculatedHeightDifference.DelAllTextNote(doc);
                    CalculatedHeightDifference.GetHeightDifference(doc, view, InputValue, ELemCategorys);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    TaskDialog.Show("报错", ex.ToString());
                }
            }
        }

        public string GetName()
        {
            return "";
        }
    }
}

```

