using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_SmartConnect
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            // 对齐
            if (rbtn_FirstPick.Checked)
            {
                Command.Datum = "FirstPick";
            }
            if (rbtn_SecondPick.Checked)
            {
                Command.Datum = "SecondPick";
            }
            if (rbtn_Center.Checked)
            {
                Command.Datum = "Center";
            }
            // 角度
            if (rbtn_15.Checked)
            {
                Command.Angle = 15.0;
            }
            if (rbtn_30.Checked)
            {
                Command.Angle = 30.0;
            }
            if (rbtn_45.Checked)
            {
                Command.Angle = 45.0;
            }
            if (rbtn_60.Checked)
            {
                Command.Angle = 60.0;
            }
            if (rbtn_90.Checked)
            {
                Command.Angle = 90.0;
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
