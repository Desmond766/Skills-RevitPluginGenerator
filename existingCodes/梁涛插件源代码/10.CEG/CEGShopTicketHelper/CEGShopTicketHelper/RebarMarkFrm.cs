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
    public partial class RebarMarkFrm : Form
    {
        public string _scope;
        public string _prefix;
        public string _paramName;
        public RebarMarkFrm()
        {
            InitializeComponent();
        }


        private void RebarMarkFrm_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rbtn_Selected.Checked) { _scope = "Selected"; }
            if (rbtn_ActiveView.Checked) { _scope = "ActiveView"; }
            if (rbtn_Document.Checked) { _scope = "Document"; }
            if (rbtn_NonePre.Checked) { _prefix = "NonePre"; }
            if (rbtn_BarDia.Checked) { _prefix = "BarDiameter"; }
            if (rbtn_CustomPre.Checked) { _prefix = tbx_CustomPre.Text; }
            if (rbtn_CM.Checked) { _paramName = "CONTROL_MARK"; }
            if (rbtn_IDC.Checked) { _paramName = "IDENTITY_COMMENT"; }
            if (rbtn_Comments.Checked) { _paramName = "Comments"; }
            if (rbtn_Others.Checked) { _paramName = tbx_CustomParam.Text; }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
