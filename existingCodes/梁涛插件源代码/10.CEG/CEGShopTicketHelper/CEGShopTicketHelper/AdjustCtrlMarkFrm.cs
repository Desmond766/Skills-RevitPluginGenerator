using Autodesk.Revit.UI;
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
    public partial class AdjustCtrlMarkFrm : Form
    {
        public string _parameter;
        public string _prefix;
        public int _beginMark;
        public int _endMark;
        public string _operation;
        public int _integerStep;

        public AdjustCtrlMarkFrm()
        {
            InitializeComponent();
        }

        private void AdjustCtrlMarkFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            _parameter = cbx_Param.Text;
            _beginMark = int.Parse(Utils.GetInteger(tbx_BeginMark.Text));
            _endMark = int.Parse(Utils.GetInteger(tbx_EndMark.Text));
            string s1 = Utils.RemoveInteger(tbx_BeginMark.Text);
            string s2 = Utils.RemoveInteger(tbx_EndMark.Text);
            if (s1 == s2)
            {
                _prefix = s1;
            }
            else
            {
                TaskDialog.Show("R", "Invaid Input!");
                return;
            }
            _operation = cbx_Operation.Text;
            _integerStep = int.Parse(tbx_Integer.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
