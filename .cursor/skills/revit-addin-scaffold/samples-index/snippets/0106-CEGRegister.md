# Sample Snippet: CEGRegister

Source project: `existingCodes\梁涛插件源代码\10.CEG\CEGRegister\CEGRegister`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//注册
namespace CEGRegister
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            using (Form1 form = new Form1())
            {
                if (DialogResult.OK != form.ShowDialog())
                {
                    return Result.Failed;
                }
            }

            return Result.Succeeded;
        }
    }
}

```

## Command02.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGRegister
{
    [Transaction(TransactionMode.Manual)]
    public class Command02 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //if (!BTAddInHelper.Utils.CheckReg(licFile))
            //{
            //    return Result.Cancelled;
            //}
            if (!CheckRegClass.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection selection = uiapp.ActiveUIDocument.Selection;
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;

            //判断视图————————————————————————————————————————————————————————————————————————————————————————————————————————————————
            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            Autodesk.Revit.DB.View view = doc.ActiveView;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
            View3D view3D = null;
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 支吊架".Equals(view3.Name))
                {
                    default3Dview = view3;
                }
                if (string.Format("3D {0}", doc.ActiveView.Name).Equals(view3.Name))
                {
                    target3Dview = view3;
                }
            }
            if (null != target3Dview)
            {
                view3D = target3Dview;
            }
            else
            {
                if (null != default3Dview)
                {
                    view3D = default3Dview;
                }
                else
                {
                    message = string.Format("未找到3D视图： 3D 支吊架 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }



            //定义几个变量———————————————————————————————————————————————————————————————————————————————————
            Reference ref_mep = null;
            Reference ref_Hanger = null;




            //选择吊架进行参考布置———————————————————————————————————————————————————————————————————————————————————
            ref_Hanger = selection.PickObject(ObjectType.Element, new SelectionFilter4MechEquip(), "请选择要布置的吊架");
            Element hanger = doc.GetElement(ref_Hanger);
// ... truncated ...
```

## Command03.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGRegister
{
    [Transaction(TransactionMode.Manual)]
    public class Command03 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //if (!BTAddInHelper.Utils.CheckReg(licFile))
            //{
            //    return Result.Cancelled;
            //}
            if (!CheckRegClass.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection selection = uiapp.ActiveUIDocument.Selection;
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;

            //判断视图————————————————————————————————————————————————————————————————————————————————————————————————————————————————
            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            Autodesk.Revit.DB.View view = doc.ActiveView;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
            View3D view3D = null;
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 支吊架".Equals(view3.Name))
                {
                    default3Dview = view3;
                }
                if (string.Format("3D {0}", doc.ActiveView.Name).Equals(view3.Name))
                {
                    target3Dview = view3;
                }
            }
            if (null != target3Dview)
            {
                view3D = target3Dview;
            }
            else
            {
                if (null != default3Dview)
                {
                    view3D = default3Dview;
                }
                else
                {
                    message = string.Format("未找到3D视图： 3D 支吊架 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }

            //定义几个变量———————————————————————————————————————————————————————————————————————————————————
            Reference ref_mepxc = null;
            Reference ref_meppl = null;
            Reference ref_Hanger = null;

            //选择吊架进行参考布置———————————————————————————————————————————————————————————————————————————————————
            ref_Hanger = selection.PickObject(ObjectType.Element, new SelectionFilter4MechEquip(), "请选择要布置的吊架");
            Element hanger = doc.GetElement(ref_Hanger);
            if (!hanger.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains("吊架"))
            {
                TaskDialog.Show("revit", "选择的构件不是吊架, 程序结束");
                return Result.Failed;
// ... truncated ...
```

