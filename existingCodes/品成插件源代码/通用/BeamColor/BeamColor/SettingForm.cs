using Autodesk.Revit.UI;
using BeamColor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeamColor
{
    public partial class SettingForm : Form
    {
        public bool IsShowBeamSize { get; set; }
        public double errorBeamHigh { get; set; }
        public SettingForm()
        {
            InitializeComponent();
            textBox1.Text = Settings.Default.ErrorBeamHigh.ToString();
            if (textBox1.Text == "0") textBox1.Text = "";
        }

        private void SettingFrom_Load(object sender, EventArgs e)
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
            string pattern = @"\d+(\.\d+)?";
            MatchCollection matches = Regex.Matches(textBox1.Text, pattern);
            if (matches.Count == 1)
            {
                errorBeamHigh = Convert.ToDouble(matches[0].Value);
                Settings.Default.ErrorBeamHigh = errorBeamHigh;
                Settings.Default.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Hide();
                TaskDialog.Show("提示", "输入的数字不合法，请重新输入");
                textBox1.Text = "";
                Show();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
