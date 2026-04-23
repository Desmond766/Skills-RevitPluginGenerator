using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_Replaycer
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void button_offset_Click(object sender, EventArgs e)
        {
            Command.type = "标高刷";

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_system_Click(object sender, EventArgs e)
        {
            Command.type = "系统刷";

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_size_Click(object sender, EventArgs e)
        {
            Command.type = "管径刷";

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
