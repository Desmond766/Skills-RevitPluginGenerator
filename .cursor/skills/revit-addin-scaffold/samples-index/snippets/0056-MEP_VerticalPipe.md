# Sample Snippet: MEP_VerticalPipe

Source project: `existingCodes\品成插件源代码\机电\MEP_VerticalPipe\MEP_VerticalPipe`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Selection;

namespace MEP_VerticalPipe
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        #region 字段属性
        private static PipeType _selectPipeType;
        public static PipeType SelectPipeType
        {
            get { return Command._selectPipeType; }
            set { Command._selectPipeType = value; }
        }

        private static Element _selectPipeSystem;
        public static Element SelectPipeSystem
        {
            get { return Command._selectPipeSystem; }
            set { Command._selectPipeSystem = value; }
        }

        private static double _diam;
        public static double Diam
        {
            get { return Command._diam; }
            set { Command._diam = value; }
        }

        private static Level _selectLevel1;
        public static Level SelectLevel1
        {
            get { return Command._selectLevel1; }
            set { Command._selectLevel1 = value; }
        }

        private static double _offset1;
        public static double Offset1
        {
            get { return Command._offset1; }
            set { Command._offset1 = value; }
        }

        private static Level _selectLevel2;
        public static Level SelectLevel2
        {
            get { return Command._selectLevel2; }
            set { Command._selectLevel2 = value; }
        }

        private static double _offset2;
        public static double Offset2
        {
            get { return Command._offset2; }
            set { Command._offset2 = value; }
        }

        private static List<Level> _levelList;
        public static List<Level> LevelList
        {
            get { return Command._levelList; }
            set { Command._levelList = value; }
        }

        #endregion

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
            Selection sel = uiapp.ActiveUIDocument.Selection;
            // 弹出对话框
// ... truncated ...
```

## SettingForm.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_VerticalPipe
{
    public partial class SettingForm : System.Windows.Forms.Form
    {
        UIApplication m_uiapp;
        Document m_doc;
        List<PipeType> pipeTypeList = new List<PipeType>();
        List<string> pipeTypeNameList = new List<string>();
        List<Element> pipeSystemList = new List<Element>();
        List<string> pipeSystemNameList = new List<string>();
        List<Level> levelList = new List<Level>();
        List<string> levelNameList = new List<string>();

        public SettingForm(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            Initialize();
            cbx_PipeType.DataSource = pipeTypeNameList;
            cbx_SystemType.DataSource = pipeSystemNameList;
            cbx_Level1.DataSource = levelNameList;
            List<string> levelNameListCopy = new List<string>();
            foreach (string leName in levelNameList)
            {
                levelNameListCopy.Add(leName);
            }
            cbx_Level2.DataSource = levelNameListCopy;
        }

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            // 管道类型
            FilteredElementCollector col_PipeType = new FilteredElementCollector(m_doc).OfClass(typeof(PipeType));
            foreach (PipeType pt in col_PipeType)
            {
                pipeTypeList.Add(pt);
                pipeTypeNameList.Add(pt.Name);
            }
            // 管道系统
            FilteredElementCollector col_PipeSystem = new FilteredElementCollector(m_doc).OfCategory(BuiltInCategory.OST_PipingSystem);
            foreach (Element ps in col_PipeSystem)
            {
                if (ps.Name.Substring(0, 2) == "G-" || ps.Name.Substring(0, 2) == "N-")
                {
                    pipeSystemList.Add(ps);
                    pipeSystemNameList.Add(ps.Name);
                }
            }
            // 参照标高
            List<Level> levelListTemp = new List<Level>();
            FilteredElementCollector col_Level = new FilteredElementCollector(m_doc).OfClass(typeof(Level));
            foreach (Level le in col_Level)
            {
                levelListTemp.Add(le);
                levelNameList.Add(le.Name);
            }
            levelNameList.Sort();
            foreach (string leName in levelNameList)
            {
                foreach (Level le in levelListTemp)
                {
                    if (le.Name == leName)
                    {
                        levelList.Add(le);
                        break;
                    }
                }
            }
// ... truncated ...
```

