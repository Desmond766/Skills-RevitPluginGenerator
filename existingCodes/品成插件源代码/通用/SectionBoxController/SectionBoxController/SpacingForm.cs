using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SectionBoxController
{
    public partial class SpacingForm : Form
    {
        public SpacingForm()
        {
            InitializeComponent();
        }

        private void SpacingForm_Load(object sender, EventArgs e)
        {
            tbx_Spacing.Text = GlobalVaule.SPACING.ToString();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            GlobalVaule.SPACING = double.Parse(tbx_Spacing.Text);
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
