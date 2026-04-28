using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayoutByDwg
{
    public partial class SettingForm : Form
    {
        public List<string> nameList;
        public string selectName;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            cbx_Name.DataSource = nameList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectName = nameList[cbx_Name.SelectedIndex];
            Close();
        }
    }
}
