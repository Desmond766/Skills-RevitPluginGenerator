using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper.ShopTicketChecking
{
    public partial class DimensionCheckingSettingFrm : Form
    {
        public string _titleContain = "";
        public DimensionCheckingSettingFrm()
        {
            InitializeComponent();
        }

        private void DimensionCheckingSettingFrm_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rbtn_CheckTitleContain.Checked)
            {
                if (string.IsNullOrEmpty(tbx_TitleContain.Text))
                {
                    return;
                }
                else
                {
                    _titleContain = tbx_TitleContain.Text;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
