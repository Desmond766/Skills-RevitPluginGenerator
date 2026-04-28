# Sample Snippet: MulitLink

Source project: `existingCodes\品成插件源代码\通用\MulitLink\MulitLink`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using System.IO;

namespace MulitLink
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
    //        string licFile = string.Format("{0}\\Key.lic",
    //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    //        if (!BTAddInHelper.Utils.CheckReg(licFile))
    //        {
    //            return Result.Cancelled;
    //        }

            #endregion
          

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            List<string> fileNameList = SelectFiles();
            foreach (string path in fileNameList)
            {
                LinkModel(doc, path);
            }

            return Result.Succeeded;
        }

        #region 选择模型
        /// <summary>
        /// 选择模型
        /// </summary>
        /// <returns></returns>
        private List<string> SelectFiles()
        {
            List<string> fileNameList = new List<string>();
            while (true)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "选择要链接的模型文件";
                ofd.Filter = "Revit文件|*.rvt;|所有文件|*.*";
                ofd.Multiselect = true;
                ofd.RestoreDirectory = true;
                if (DialogResult.OK == ofd.ShowDialog())
                {
                    fileNameList.AddRange(ofd.FileNames);
                }
                if (DialogResult.No == MessageBox.Show("是否继续选择？", "多重链接", MessageBoxButtons.YesNo))
                {
                    break;
                }
            }
            return fileNameList;
        }
        #endregion

        #region 链接模型
        /// <summary>
        /// 链接模型
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="path"></param>
        private void LinkModel(Document doc, string path)
        {
            //RevitAPI： 如何插入链接文件
            //http://blog.csdn.net/lushibi/article/details/43410475
            using (Transaction t = new Transaction(doc, "链接模型"))
            {
                t.Start();
                ModelPath mp = ModelPathUtils.ConvertUserVisiblePathToModelPath(path);
                RevitLinkOptions rlo = new RevitLinkOptions(true);
// ... truncated ...
```

## Properties\AssemblyInfo.cs

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("MulitLink")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("MS")]
[assembly: AssemblyProduct("MulitLink")]
[assembly: AssemblyCopyright("Copyright © MS 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("d7331883-e199-4c55-873f-4bf96ccf3887")]

// 程序集的版本信息由下面四个值组成: 
//
//      主版本
//      次版本 
//      生成号
//      修订号
//
// 可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”: 
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

```

