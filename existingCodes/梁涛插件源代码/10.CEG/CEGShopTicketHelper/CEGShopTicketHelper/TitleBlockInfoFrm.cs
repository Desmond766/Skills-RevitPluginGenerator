using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    public partial class TitleBlockInfoFrm : Form
    {
        public string drawBy = null;
        public string checkBy = null;
        public string designBy = null;
        public string p1 = null;
        public string v1 = null;
        public string p2 = null;
        public string v2 = null;
        public string p3 = null;
        public string v3 = null;
        public TitleBlockInfoFrm()
        {
            InitializeComponent();
        }

        private void TitleBlockInfoFrm_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (cbx_DrawBy.Checked)
            {
                drawBy = tbx_DrawBy.Text;
            }
            if (cbx_CheckBy.Checked)
            {
                checkBy = tbx_CheckBy.Text;
            }
            if (cbx_DesignBy.Checked)
            {
                designBy = tbx_DesignBy.Text;
            }
            p1 = tbx_P1.Text;
            p2 = tbx_P2.Text;
            p3 = tbx_P3.Text;
            v1 = tbx_V1.Text;
            v2 = tbx_V2.Text;
            v3 = tbx_V3.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
