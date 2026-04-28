using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_OffsetPro
{
    public partial class SettingForm : Form
    {
        List<double> disList = new List<double>() { 200,250, 300, 350, 400, 500, 
            -200, -250, -300, -350, -400, -500 };
        List<double> diaList = new List<double>() { 50,65 };

        //public string type;
        //public double distance;
        //public double diameter;

        public SettingForm()
        {
            InitializeComponent();
        }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            // 类型
            if (rbtn_OneSide.Checked)
            {
                //type = "单侧";
                Command.type = "单侧";
            }
            else
            {
                //type = "双侧";
                Command.type = "双侧";
            }
            // 距离
            //distance = double.Parse(cbx_Dis.Text);
            Command.distance = double.Parse(cbx_Dis.Text.ToString());
            ResolverOne.Distance = double.Parse(cbx_Dis.Text.ToString());
            ResolverTwo.Distance = double.Parse(cbx_Dis.Text.ToString());
            
            // 选择两侧时，立管直径
            Command.diameter = double.Parse(cbx_Dia.Text);
            ResolverTwo.Diameter = double.Parse(cbx_Dia.Text);

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
            
            cbx_Dis.DataSource = disList;
            cbx_Dis.Text = Command.distance.ToString();

            //选择两侧时，立管直径
            
            cbx_Dia.DataSource = diaList;
            cbx_Dia.Text = Command.diameter.ToString();

            //类型
            if (Command.type == "单侧")
            {
                rbtn_OneSide.Checked = true;
            }
            else
            {
                rbtn_TwoSide.Checked = true;
            }
        }


    }
}
