using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_3DViewCreater
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            foreach (var item in Command.listSectionViewStr)
            {
                clbx_viewName.Items.Add(item);
            }
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //收集复选框中用户勾选的项
            Command.listSectionViewStr = Utils.CollectedOptionsToList(clbx_viewName);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_AllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <clbx_viewName.Items.Count; i++)
            {
                clbx_viewName.SetItemChecked(i,true);
            }
        }

        private void btn_AllCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbx_viewName.Items.Count; i++)
            {
                clbx_viewName.SetItemChecked(i, false);
            }
        }
    }
}
