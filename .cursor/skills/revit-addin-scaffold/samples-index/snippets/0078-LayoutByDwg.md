# Sample Snippet: LayoutByDwg

Source project: `existingCodes\品成插件源代码\通用\LayoutByDwg\LayoutByDwg`

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
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using System.IO;

namespace LayoutByDwg
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }


            var doc = commandData.Application.ActiveUIDocument.Document;
            var uiSel = commandData.Application.ActiveUIDocument.Selection;

            using (Transaction t = new Transaction(doc, "批量布置构件"))
            {
                t.Start();
                //try
                //{
                //选择底图
                var reference = uiSel.PickObject(ObjectType.Element, "选择DWG底图");
                var element = doc.GetElement(reference);
                //弹出对话框
                SettingForm sf = new SettingForm();
                sf.nameList = GetGeomInstNameList(element);//获得DWG中的块名集合
                sf.ShowDialog();
                var transList = GetGeomInstTransByName(element, sf.selectName);//根据块名获得DWG中块的Transform
                //选择构件
                var referenceToLayOut = uiSel.PickObject(ObjectType.Element, "选择要布置的构件");
                var elementToLayOut = doc.GetElement(referenceToLayOut);
                if (!(elementToLayOut is FamilyInstance))
                {
                    MessageBox.Show("请选择点型、非系统族实例！");
                    return Result.Failed;
                }
                foreach (var item in transList)
                {
                    //在底图块的位置生成族
                    FamilyInstance fi = doc.Create.NewFamilyInstance(item.Origin, (elementToLayOut as FamilyInstance).Symbol,
                        Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                    // 利用XYZ.BasisX预旋转
                    Transform tran = Transform.CreateRotation(XYZ.BasisZ, XYZ.BasisX.AngleTo(item.BasisX));
                    XYZ preRotate = tran.OfVector(XYZ.BasisX);
                    if (preRotate.IsAlmostEqualTo(item.BasisX))
                    {
                        ElementTransformUtils.RotateElement(doc, fi.Id,
                        Line.CreateBound(item.Origin, item.Origin + XYZ.BasisZ), XYZ.BasisX.AngleTo(item.BasisX));
                    }
                    else
                    {
                        ElementTransformUtils.RotateElement(doc, fi.Id,
                        Line.CreateBound(item.Origin, item.Origin + XYZ.BasisZ), XYZ.BasisX.AngleTo(item.BasisX) * -1.0);
                    }
                }
                //}
                //catch (Exception)
                //{
                //    //CODE HERE
                //}

                t.Commit();
            }

            return Result.Succeeded;
        }

        #region 绘制模型线
        /// <summary>
// ... truncated ...
```

## SettingForm.cs

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayoutByDwg
{
    public partial class SettingForm : Form
    {
        public List<string> nameList;
        public string selectName;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            cbx_Name.DataSource = nameList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectName = nameList[cbx_Name.SelectedIndex];
            Close();
        }
    }
}

```

