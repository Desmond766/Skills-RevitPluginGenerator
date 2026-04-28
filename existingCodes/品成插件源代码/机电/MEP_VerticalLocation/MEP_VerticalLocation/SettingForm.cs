using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_VerticalLocation
{
    public partial class SettingForm : System.Windows.Forms.Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            if (rbtn_Top.Checked)
            {
                Command.Direction = XYZ.BasisZ;
            }
            else
            {
                Command.Direction = XYZ.BasisZ.Negate();
            }
            Command.Distance = tbx_Distance.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
