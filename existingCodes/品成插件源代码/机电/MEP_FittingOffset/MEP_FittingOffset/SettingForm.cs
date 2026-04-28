using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_FittingOffset
{
    public partial class SettingForm : Form
    {
        List<double> disList = new List<double>() { 100, 150, 200,250, 300, 350, 
            400, 500, -100, -150, -200, -250, -300, -350, -400, -500 };
        public SettingForm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
           
            Command.rbtn_Direction = "升降";
           
            // 角度
            if (rbtn_15.Checked)
            {
                Resolver.Angle = 15.0;
                Command.rbtn_Angle = "15度";
            }
            else if (rbtn_30.Checked)
            {
                Resolver.Angle = 30.0;
                Command.rbtn_Angle = "30度";
            }
            else if (rbtn_45.Checked)
            {
                Resolver.Angle = 45.0;
                Command.rbtn_Angle = "45度";
            }
            else if (rbtn_60.Checked)
            {
                Resolver.Angle = 60.0;
                Command.rbtn_Angle = "60度";
            }
            else
            {
                Resolver.Angle = 90.0;
                Command.rbtn_Angle = "90度";
            }
            // 距离
            Resolver.Distance = double.Parse(cbx_Dis.Text);
            Command.cbx_Distance = double.Parse(cbx_Dis.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //距离
            disList.Insert(0, Command.cbx_Distance);
            cbx_Dis.DataSource = disList;
           
            //角度
            if (Command.rbtn_Angle == "15度")
            {
                rbtn_15.Checked = true;
            }
            else if (Command.rbtn_Angle == "30度")
            {
                rbtn_30.Checked = true;
            }
            else if (Command.rbtn_Angle == "45度")
            {
                rbtn_45.Checked = true;
            }
            else if (Command.rbtn_Angle == "60度")
            {
                rbtn_60.Checked = true;
            }
            else if (Command.rbtn_Angle == "90度")
            {
                rbtn_90.Checked = true;
            }
        
        }


    }
}
