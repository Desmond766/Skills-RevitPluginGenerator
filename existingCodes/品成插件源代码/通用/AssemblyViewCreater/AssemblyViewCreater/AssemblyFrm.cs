using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyViewCreater
{
    public partial class AssemblyFrm : System.Windows.Forms.Form
    {
        private Document _doc;
        private List<string> _assemblyNameList = new List<string>();
        private List<AssemblyInstance> _assemblyList = new List<AssemblyInstance>();

        public List<AssemblyInstance> selectedList = new List<AssemblyInstance>();
        public AssemblyFrm(Document doc)
        {
            _doc = doc;
            // collect assemblyNameList
            FilteredElementCollector collector = new FilteredElementCollector(_doc);
            _assemblyList = collector.OfClass(typeof(AssemblyInstance))
                .Cast<AssemblyInstance>().OrderBy(u => u.Name).ToList();
            foreach (var item in _assemblyList)
            {
                _assemblyNameList.Add(item.Name);
            }

            InitializeComponent();
        }

        private void AssemblyFrm_Load(object sender, EventArgs e)
        {
            cbx_AssemblyList.DataSource = _assemblyNameList;
            //Init();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            selectedList = CollectApplyToAssemblys();
            DialogResult = DialogResult.OK;
            Close();
        }

        private List<AssemblyInstance> CollectApplyToAssemblys()
        {
            List<AssemblyInstance> applyToAssemblys = new List<AssemblyInstance>();
            for (int i = 0; i < cbx_AssemblyList.Items.Count; i++)
            {
                if (cbx_AssemblyList.GetItemChecked(i))
                {
                    applyToAssemblys.Add(_assemblyList[i]);
                }
            }
            return applyToAssemblys;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //private void Init()
        //{
        //    // collect title bolck Info
        //    FamilySymbol titleBlockSymbol
        //        = Utils.GetTitleOnSheet(_doc, _doc.ActiveView as ViewSheet);

        //    List<Autodesk.Revit.DB.View> views =
        //        Utils.GetViewOnSheet(_doc, _doc.ActiveView as ViewSheet);

        //    // collect assembly view on sheets
        //    foreach (Autodesk.Revit.DB.View v in views)
        //    {
        //        if (v.IsAssemblyView)
        //        {
        //            _assemblyViewList.Add(v);
        //            int index = dataGridView1.Rows.Add();
        //            dataGridView1.Rows[index].Cells["AssemblyView"].Value = v.Name;
        //        }
        //    }

        //}

    }
}
