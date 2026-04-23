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

namespace CEGShopTicketHelper
{
    public partial class Create3dFrm : System.Windows.Forms.Form
    {
        List<View3D> _assembly3dTemplates;
        public ElementId _templateId;
        public List<string> _assemblyNameContains;
        public Create3dFrm(List<View3D> assembly3dTemplates)
        {
            InitializeComponent();
            _assembly3dTemplates = assembly3dTemplates;
        }

        private void Create3dFrm_Load(object sender, EventArgs e)
        {
            cbx_Template.DataSource = _assembly3dTemplates.Select(u => u.Name).ToList();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            _templateId = _assembly3dTemplates[cbx_Template.SelectedIndex].Id;
            _assemblyNameContains = tbx_NameContain.Text.Split(',').ToList();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
