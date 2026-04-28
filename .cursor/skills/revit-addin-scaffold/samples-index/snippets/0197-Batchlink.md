# Sample Snippet: Batchlink

Source project: `existingCodes\饶昌锋插件源代码\322批量添加链接\Batchlink`

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

namespace Batchlink
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

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择一个文件";
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "rvt文件|*.rvt|所有文件|*.*";
            List<string> rvtList = new List<string>();
            Add:
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> list = new List<string>();
                //foreach (string fileName in openFileDialog.FileNames)
                //{
                //    TaskDialog.Show("已选择文件：",  fileName);
                //}
                list = openFileDialog.FileNames.ToList();
                rvtList.AddRange(list);
            }
            DialogResult result= MessageBox.Show("是否继续添加","确认对话框",MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                goto Add;
            }
            doc.NewTransaction("批量插入链接", () =>
            {
                foreach (string item in rvtList)
                {
                    ModelPath mp = ModelPathUtils.ConvertUserVisiblePathToModelPath(item);
                    RevitLinkOptions rlo = new RevitLinkOptions(true);
                    var linkType = RevitLinkType.Create(doc, mp, rlo);
                    var instance = RevitLinkInstance.Create(doc, linkType.ElementId);
                }
            });
            return Result.Succeeded;
        }
    }
}

```

## DocumentExtension.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batchlink
{
    public static class DocumentExtension
    {
        public static void NewTransaction(this Document doc, string name, Action action)
        {
            using (Transaction tran = new Transaction(doc, name))
            {
                tran.Start();
                action();
                tran.Commit();
            }
        }
    }
}

```

