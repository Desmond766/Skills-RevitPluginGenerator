using BeamColorInLink.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeamColorInLink
{
    public partial class SettingForm : Form
    {
        public bool IsShowBeamSize { get; set; }
        public SettingForm()
        {
            InitializeComponent();
            tb_error_high.Text = Settings.Default.ErrorBeamHigh.ToString();
            if (tb_error_high.Text == "0") tb_error_high.Text = "";
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rbtn_ShowBeamSize.Checked)
            {
                IsShowBeamSize = true;
            }
            else
            {
                IsShowBeamSize = false;
            }
            try
            {
                Settings.Default.ErrorBeamHigh = Convert.ToDouble(tb_error_high.Text);
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
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
