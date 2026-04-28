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
