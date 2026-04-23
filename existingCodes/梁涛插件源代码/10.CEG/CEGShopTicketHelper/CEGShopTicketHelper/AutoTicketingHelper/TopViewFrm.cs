using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper.AutoTicketingHelper
{
    public partial class TopViewFrm : Form
    {
        public string _pickItem = "";
        public bool _autoIdentify = false;
        public TopViewFrm()
        {
            InitializeComponent();
        }

        private void TopViewFrm_Load(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _autoIdentify = rbtn_AutoIdent.Checked;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_pickEdge_Click(object sender, EventArgs e)
        {
            _pickItem = "pickEdge";
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btn_pickGeom_Click(object sender, EventArgs e)
        {
            _pickItem = "pickGeom";
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btn_pickGeom2_Click(object sender, EventArgs e)
        {
            _pickItem = "pickGeom2";
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btn_pickSA_Click(object sender, EventArgs e)
        {
            _pickItem = "pickSideA";
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btn_pickSB_Click(object sender, EventArgs e)
        {
            _pickItem = "pickSideB";
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btn_pickE1_Click(object sender, EventArgs e)
        {
            _pickItem = "pickEnd1";
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btn_pickE2_Click(object sender, EventArgs e)
        {
            _pickItem = "pickEnd2";
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btn_pickTop_Click(object sender, EventArgs e)
        {
            _pickItem = "pickTop";
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btn_pickBot_Click(object sender, EventArgs e)
        {
            _pickItem = "pickSoffit";
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void rbtn_UserPick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void rbtn_AutoIdent_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            if(rbtn_AutoIdent.Checked)
            {
                btn_pickEdge.Enabled = false;
                btn_pickGeom.Enabled = false;
                btn_pickGeom2.Enabled = false;
                btn_pickSA.Enabled = false;
                btn_pickSB.Enabled = false;
                btn_pickE1.Enabled = false;
                btn_pickE2.Enabled = false;
                btn_pickTop.Enabled = false;
                btn_pickBot.Enabled = false;
            }
            else
            {
                btn_pickEdge.Enabled = true;
                btn_pickGeom.Enabled = true;
                btn_pickGeom2.Enabled = true;
                btn_pickSA.Enabled = true;
                btn_pickSB.Enabled = true;
                btn_pickE1.Enabled = true;
                btn_pickE2.Enabled = true;
                btn_pickTop.Enabled = true;
                btn_pickBot.Enabled = true;
            }
        }

        
    }
}
