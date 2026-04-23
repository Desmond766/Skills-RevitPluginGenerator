using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    public partial class OpenAssemblySheetFrm : Form
    {
        public string _selectedAssembly = "";
        public OpenAssemblySheetFrm()
        {
            InitializeComponent();
        }

        private void OpenAssemblySheetFrm_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            _selectedAssembly = tbx_Assembly.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
