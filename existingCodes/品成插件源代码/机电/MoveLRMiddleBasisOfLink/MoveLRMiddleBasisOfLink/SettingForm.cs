using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveLRMiddleBasisOfLink
{
    public partial class SettingForm : Form
    {
        List<double> disList = new List<double>() { 100, 150, 200,250, 300, 350, 
            400, 500, -100, -150, -200, -250, -300, -350, -400, -500 };
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            disList.Insert(0, Command.distance);
            cbx_Dis.DataSource = disList;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Command.distance = double.Parse(cbx_Dis.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
