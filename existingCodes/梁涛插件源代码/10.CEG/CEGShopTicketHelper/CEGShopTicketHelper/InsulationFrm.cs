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
    public partial class InsulationFrm : Form
    {
        public string m_thicknessStr = string.Empty;
        public InsulationFrm(string thicknessStr)
        {
            InitializeComponent();
            m_thicknessStr = thicknessStr;
        }

        private void InsulationFrm_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            m_thicknessStr = tbx_Thickness.Text;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
