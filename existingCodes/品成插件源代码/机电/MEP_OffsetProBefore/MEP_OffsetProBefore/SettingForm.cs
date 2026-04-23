using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_OffsetProBefore
{
    public partial class SettingForm : Form
    {
        List<double> disList = new List<double>() { 200,250, 300, 350, 400, 500, 
            -200, -250, -300, -350, -400, -500 };

        public SettingForm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            // 距离
            Command.distance = double.Parse(cbx_Dis.Text.ToString());
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //距离

            cbx_Dis.DataSource = disList;
            cbx_Dis.Text = Command.distance.ToString();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }





    }
}

