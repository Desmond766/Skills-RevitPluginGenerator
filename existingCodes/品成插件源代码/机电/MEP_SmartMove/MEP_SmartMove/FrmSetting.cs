using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_SmartMove
{
    public partial class FrmSetting : Form
    {
        public double Distance { get; set; }

        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                Distance = double.Parse(tbx_Distance.Text) / 304.8;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("请输入合法的数字！");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
