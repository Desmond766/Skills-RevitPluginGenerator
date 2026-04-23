using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARC_BeamMaterial
{
    public partial class BeamMaterialForm : Form
    {
        public BeamMaterialForm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rbtn_Add.Checked)
            {
                Command.Function = "Add";
            }
            else
            {
                Command.Function = "Clear";
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
