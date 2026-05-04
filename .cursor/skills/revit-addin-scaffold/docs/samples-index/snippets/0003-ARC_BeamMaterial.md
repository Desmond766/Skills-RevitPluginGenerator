# Sample Snippet: ARC_BeamMaterial

Source project: `existingCodes\品成插件源代码\土建\ARC_BeamMaterial\ARC_BeamMaterial`

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
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace ARC_BeamMaterial
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        private static string _function;
        public static string Function
        {
            get { return Command._function; }
            set { Command._function = value; }
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            using (BeamMaterialForm main_Dialog = new BeamMaterialForm())
            {
                if (main_Dialog.ShowDialog() != DialogResult.OK)
                {
                    return Result.Failed;
                }
            }
            // 计时开始
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int num_Pass_SymbolParameter = 0;
            int num_Pass_InstanceParameter = 0;
            int num_Done = 0;
            // 过滤材质
            FilteredElementCollector matCollector = new FilteredElementCollector(doc);
            IList<Element> materialList = matCollector.OfCategory(BuiltInCategory.OST_Materials).ToElements();
            // 过滤结构梁
            FilteredElementCollector beamCollector = new FilteredElementCollector(doc);
            IList<Element> beamList = beamCollector.OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).ToElements();
            if (Function == "Add")
            {
                // 【1】判断当前文档中是否存在用于替换的材质
                Hashtable ht_Material = new Hashtable();
                foreach (Element mat in materialList)
                {
                    if (mat.Name.Length > 8)
                    {
                        if (mat.Name.Substring(0, 7) == "S-结构梁材质")
                        {
                            ht_Material.Add(mat.Name, mat.Id);
                        }
                    }
                }
                if (ht_Material.Count == 0)
                {
                    message = "错误：未发现结构梁材质！";
                    return Result.Failed;
                }
                // 【2】根据梁高替换梁材质
                using (Transaction t = new Transaction(doc, "PaintBeamByHeight"))
                {
                    t.Start();
                    foreach (Element beam in beamList)
                    {
                        //获得梁高，组合成结构梁材质名
                        string matName = null;
                        ParameterSet symbolParms = (beam as FamilyInstance).Symbol.Parameters;
                        foreach (Parameter parm in symbolParms)
                        {
                            //"h"参数无BuiltInParameter
                            if (parm.Definition.Name == "h")
// ... truncated ...
```

## BeamMaterialForm.cs

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

namespace ARC_BeamMaterial
{
    public partial class BeamMaterialForm : Form
    {
        public BeamMaterialForm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rbtn_Add.Checked)
            {
                Command.Function = "Add";
            }
            else
            {
                Command.Function = "Clear";
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

```

