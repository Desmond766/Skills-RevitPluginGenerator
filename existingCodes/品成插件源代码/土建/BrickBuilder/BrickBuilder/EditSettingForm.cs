using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBuilder
{
    public partial class EditSettingForm : Form
    {
        public double HOffsetVaule { get; set; }
        public double VOffsetVaule { get; set; }
        public EditSettingForm()
        {
            InitializeComponent();
        }

        private void EditSettingForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            HOffsetVaule = double.Parse(tbx_hOffset.Text) / 304.8;
            VOffsetVaule = double.Parse(tbx_vOffset.Text) / 304.8;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
