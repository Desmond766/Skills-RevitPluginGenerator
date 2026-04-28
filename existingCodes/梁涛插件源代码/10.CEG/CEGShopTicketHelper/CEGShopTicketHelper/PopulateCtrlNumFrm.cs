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
    public partial class PopulateCtrlNumFrm : Form
    {
        public string paramName;
        public int startNum;
        public string format;
        public PopulateCtrlNumFrm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            paramName = tbx_ParamName.Text;
            startNum = int.Parse(tbx_StartNum.Text);
            for (int i = 0; i < tbx_StartNum.Text.Length; i++)
            {
                format += "0";
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PopulateCtrlNumFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
