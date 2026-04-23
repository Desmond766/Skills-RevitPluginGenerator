using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_MEPNETH
{
    public partial class Form1 : Form
    {
        List<double> disList = new List<double>() { 1000 };
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button_OK_Click(object sender, EventArgs e)
        {
            Command.d = double.Parse(cbx_Dis.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disList.Insert(0, Command.d);
            cbx_Dis.DataSource = disList;
        }
    }
}
