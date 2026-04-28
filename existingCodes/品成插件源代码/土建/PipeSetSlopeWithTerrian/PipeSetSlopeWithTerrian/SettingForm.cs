using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipeSetSlopeWithTerrian
{
    public partial class SettingForm : Form
    {
        public bool _autoMode = false;
        public double _offset = 0.0;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rbtn_Auto.Checked)
            {
                _autoMode = true;
            }
            if (rbtn_Custom.Checked)
            {
                _autoMode = false;
            }
            _offset = double.Parse(tbx_Offset.Text) / 304.8;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
