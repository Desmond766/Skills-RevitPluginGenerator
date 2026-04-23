using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_SplitByLine
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void btn_Plane_Click(object sender, EventArgs e)
        {
            Command.SplitType = SplitTypeList.Plane;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Vertical_Click(object sender, EventArgs e)
        {
            Command.SplitType = SplitTypeList.Vertical;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
