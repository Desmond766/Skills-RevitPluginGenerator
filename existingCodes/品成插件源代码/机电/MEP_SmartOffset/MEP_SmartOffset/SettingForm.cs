using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_SmartOffset
{
    public partial class SettingForm : Form
    {
        List<double> disList = new List<double>() { 50, 150, 200,250, 300, 350, 
            400, 500, -50,-100, -150, -200, -250, -300, -350, -400, -500 };
        List<double> disListHor = new List<double>() { 50, 150, 200,250, 300, 350, 
            400, 500 };
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
          
            disList.Insert(0, Command.cbx_Distance);
            disListHor.Insert(0, Command.cbx_DistanceHor);
            //爬升距离
            cbx_Dis.DataSource = disList;
            //水平间距
            cbx_Dis_h.DataSource = disListHor;
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

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //爬升距离
            Resolver.Distance = double.Parse(cbx_Dis.Text);
            Command.cbx_Distance = double.Parse(cbx_Dis.Text);
            //水平间距
            Resolver.DistanceHor = double.Parse(cbx_Dis_h.Text);
            Command.cbx_DistanceHor = double.Parse(cbx_Dis_h.Text);
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

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
