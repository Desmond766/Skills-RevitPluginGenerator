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
    public partial class CamberLineFrm : Form
    {
        public double camber = 0.0;
        public string gsName = "";
        public CamberLineFrm()
        {
            InitializeComponent();
        }

        private void CamberLineFrm_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            camber = double.Parse(tbx_Camber.Text) / 12.0;
            gsName = tbx_LineStyle.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
