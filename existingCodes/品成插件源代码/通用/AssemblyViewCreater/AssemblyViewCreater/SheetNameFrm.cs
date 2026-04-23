using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyViewCreater
{
    public partial class SheetNameFrm : Form
    {
        public SheetNameFrm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            SheetNameCmd.SheetName =cbx_Name.Text;
            SheetNameCmd.SheetNameNo = double.Parse(cbx_No.Text);
            SheetNameCmd.Space = double.Parse(cbx_space.Text);
            
            SheetNameCmd.NumText=cbx_NumText.Text;
            SheetNameCmd.Number = double.Parse(cbx_Number.Text);
            SheetNameCmd.Numspace = double.Parse(cbx_Numspace.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
