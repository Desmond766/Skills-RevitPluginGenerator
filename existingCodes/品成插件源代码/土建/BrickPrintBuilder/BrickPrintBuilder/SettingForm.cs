using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickPrintBuilder
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Command.unRegularBrick = rbtn_DirectShape.Checked ? "DirectShape" : "Floor";
            Command.tickness = double.Parse(this.tbx_tickness.Text) / 304.8;
            Command.grouped = this.cbx_Grouped.Checked;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
