using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetHeightDim
{
    public partial class SettingForm : Form
    {
        public bool ActivePickMode = false;
        public List<string> settingUpdate = new List<string>();
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            Initalize();
        }

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initalize()
        {
            string path = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, "txt");
            List<string> setting = Utils.TxtToList(path);
            if (null == setting)
            {
                MessageBox.Show("未找到净高插件设置，将使用默认设置！");
                return;
            }
            //选择设置
            if (setting[0] == "SelectCurrent")
            {
                rbtn_SelectCurrent.Checked = true;
            }
            if (setting[0] == "SelectLink")
            {
                rbtn_SelectLink.Checked = true;
            }
            //管中管底设置
            if (setting[1] == "Middle")
            {
                rbtn_middleStart.Checked = true;
            }
            if (setting[1] == "Bottom")
            {
                rbtn_bottomStart.Checked = true;
            }
            //基准设置
            if (setting[2] == "SlabDatum")
            {
                rbtn_SlabDatum.Checked = true;
                btn_PickDatum.Enabled = false;
            }
            if (setting[2] == "PickDatum")
            {
                rbtn_PickDatum.Checked = true;
                btn_PickDatum.Enabled = true;
                lbl_PickedDatumVaule.Text = setting[2];
            }
            lbl_PickedDatumVaule.Text = setting[3];
            //标注设置
            if (setting[4] == "DeleteNote")
            {
                rbtn_DeleteNote.Checked = true;
            }
            if (setting[4] == "KeepNote")
            {
                rbtn_KeepNote.Checked = true;
            }
        }
        #endregion

        #region 更新设置信息集合
        /// <summary>
        /// 更新设置信息集合
        /// </summary>
        private void UpdateSettingList()
        {
            List<string> setting = new List<string>();
            //选择设置
            if (rbtn_SelectCurrent.Checked)
            {
                setting.Add("SelectCurrent");
            }
            if (rbtn_SelectLink.Checked)
            {
                setting.Add("SelectLink");
            }
            //选择起点:陈清添加
            if (rbtn_middleStart.Checked)
            {
                setting.Add("Middle");
            }
            if (rbtn_bottomStart.Checked)
            {
                setting.Add("Bottom");
            }
            //基准设置
            if (rbtn_SlabDatum.Checked)
            {
                setting.Add("SlabDatum");
                setting.Add("-");
            }
            if (rbtn_PickDatum.Checked)
            {
                setting.Add("PickDatum");
                setting.Add(lbl_PickedDatumVaule.Text);
            }
            //标注设置
            if (rbtn_DeleteNote.Checked)
            {
                setting.Add("DeleteNote");
            }
            if (rbtn_KeepNote.Checked)
            {
                setting.Add("KeepNote");
            }
            settingUpdate = setting;
        }
        #endregion

        #region OK
        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            UpdateSettingList();
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region Cancel
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region rbtn_PickDatum_Checked
        /// <summary>
        /// rbtn_PickDatum_Checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtn_PickDatum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_PickDatum.Checked)
            {
                btn_PickDatum.Enabled = true;
            }
            else
            {
                btn_PickDatum.Enabled = false;
            }
        }
        #endregion
        
        #region 拾取基点
        /// <summary>
        /// 拾取基点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_PickDatum_Click(object sender, EventArgs e)
        {
            UpdateSettingList();
            ActivePickMode = true;
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

     

      

    }
}
