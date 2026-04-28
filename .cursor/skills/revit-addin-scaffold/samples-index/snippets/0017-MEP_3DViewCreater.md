# Sample Snippet: MEP_3DViewCreater

Source project: `existingCodes\品成插件源代码\机电\MEP_3DViewCreater\MEP_3DViewCreater`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.IO;
using System.Windows.Forms;

namespace MEP_3DViewCreater
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        //剖面视图list         listSectionView
        //剖面视图名称list      listSectionViewStr
        public static List<Autodesk.Revit.DB.View> listSectionView = new List<Autodesk.Revit.DB.View>();
        public static List<string> listSectionViewStr = new List<string>();

        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            #region 判断加密

            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            //收集项目中所有视图      listAllviews
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IList<Element> listAllviews = collector.OfClass(typeof(Autodesk.Revit.DB.View)).ToElements();

            //收集项目中所有剖面视图
            foreach (Element ele in listAllviews)
            {
                Autodesk.Revit.DB.View view = ele as Autodesk.Revit.DB.View;
                if (view != null)
                {
                    if (view.ViewType == ViewType.Section)
                    {
                        if (view.ViewName != null)
                        {
                            listSectionView.Add(view);
                            listSectionViewStr.Add(view.ViewName);
                        }
                    }
                }
            }

            //弹出对话框，收集要生成局部三维的剖面
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }

            //已收集到用户勾选的要生成三维的剖面名称，在所有剖面中找到用户勾选的这些名称的剖面
            //实际要生成局部三维的剖面的范围框 list     listBox

            List<Autodesk.Revit.DB.View> list = new List<Autodesk.Revit.DB.View>();
            foreach (var item in listSectionView)
            {
                foreach (var itemStr in listSectionViewStr)
                {
                    if (item.ViewName == itemStr)
                    {
                        list.Add(item);
                    }
                }
            }

            //提醒已经存在的局部三维,在listBox中去除
            //收集项目中所有三维视图
            List<Autodesk.Revit.DB.View> list3DView = new List<Autodesk.Revit.DB.View>();
            foreach (Element ele in listAllviews)
            {
                Autodesk.Revit.DB.View view = ele as Autodesk.Revit.DB.View;
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_3DViewCreater
{

    class Utils
    {
       #region 将复选框选中的项，生成List

       public static List<string> CollectedOptionsToList(CheckedListBox clbx)
       {
           List<string> list = new List<string>();
           for (int i = 0; i < clbx.Items.Count; i++)
           {
               if (clbx.GetItemChecked(i))
               {
                   list.Add(clbx.GetItemText(clbx.Items[i]));
               }
           }
           return list;
       }

       #endregion
    }
}

```

