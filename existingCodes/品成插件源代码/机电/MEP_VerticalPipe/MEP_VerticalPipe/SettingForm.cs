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
            Command.LevelList = levelList;
        }
        #endregion

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            Command.SelectPipeType = pipeTypeList[cbx_PipeType.SelectedIndex];
            Command.SelectPipeSystem = pipeSystemList[cbx_SystemType.SelectedIndex];
            Command.Diam = double.Parse(tbx_Diameter.Text) / 304.8;
            if (chebx_Level1.Checked)
            {
                Command.SelectLevel1 = levelList[cbx_Level1.SelectedIndex];
            }
            Command.Offset1 = double.Parse(tbx_Level1Offset.Text) / 304.8;
            if (chebx_Level2.Checked)
            {
                Command.SelectLevel2 = levelList[cbx_Level2.SelectedIndex];
            }
            Command.Offset2 = double.Parse(tbx_Level2Offset.Text) / 304.8;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Chebx_Level1_CheckedChanged(object sender, EventArgs e)
        {
            if (chebx_Level1.Checked)
            {
                cbx_Level1.Enabled = true;
            }
            else
            {
                cbx_Level1.Enabled = false;
            }
        }

        private void Chebx_Level2_CheckedChanged(object sender, EventArgs e)
        {
            if (chebx_Level2.Checked)
            {
                cbx_Level2.Enabled = true;
            }
            else
            {
                cbx_Level2.Enabled = false;
            }
        }
    }
}
