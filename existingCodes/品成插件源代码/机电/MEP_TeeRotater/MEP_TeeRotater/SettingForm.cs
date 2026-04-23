using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_TeeRotater
{
    public partial class SettingForm : Form
    {
        List<double> disList = new List<double>() { 5, 10, 15 };
        public SettingForm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            // 方向
            if (rbtn_B.Checked)
            {
                Command.rbtn_Direction = "向下";
            }
            else
            {
                Command.rbtn_Direction = "向上";
            }

            // 角度
            if (rbtn_30.Checked)
            {
                
                Command.rbtn_Angle = "30";
            }
            else if (rbtn_45.Checked)
            {
               
                Command.rbtn_Angle = "45";
            }
            else if (rbtn_60.Checked)
            {
                
                Command.rbtn_Angle = "60";
            }
            else if (rbtn_90.Checked)
            {
                
                Command.rbtn_Angle = "90";
            }
            else if (rbtn_0.Checked)
            {

                Command.rbtn_Angle = "0";
            }
            else if (rbtn_x.Checked)
            {

                Command.rbtn_Angle = cbx_Angle.Text;
            }


            DialogResult = DialogResult.OK;
            Close();

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //方向
            if (Command.rbtn_Direction == "向上")
            {
                rbtn_T.Checked = true;
            }
            else
            {
                rbtn_B.Checked = true;
            }

            //角度
            cbx_Angle.DataSource = disList;

             if (Command.rbtn_Angle == "30")
            {
                rbtn_30.Checked = true;
            }
            else if (Command.rbtn_Angle == "45")
            {
                rbtn_45.Checked = true;
            }
            else if (Command.rbtn_Angle == "60")
            {
                rbtn_60.Checked = true;
            }
             else if (Command.rbtn_Angle == "90")
             {
                 rbtn_90.Checked = true;
             }
             else if (Command.rbtn_Angle == "0")
             {
                 rbtn_0.Checked = true;
             }
             else 
             {
                 rbtn_x.Checked = true;
             }
        }

        private void gbx_Angle_Enter(object sender, EventArgs e)
        {

        }

        private void gbx_Dir_Enter(object sender, EventArgs e)
        {

        }
    }
}
