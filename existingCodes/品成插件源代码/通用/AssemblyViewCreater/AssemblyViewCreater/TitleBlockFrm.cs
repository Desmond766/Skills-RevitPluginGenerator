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

namespace AssemblyViewCreater
{
    public partial class TitleBlockFrm : System.Windows.Forms.Form
    {
        Document _doc;
        private List<string> _titleblockNameList = new List<string>();
        private List<FamilyInstance> _titleblockList = new List<FamilyInstance>();

        public TitleBlockFrm(Document doc)
        {
            _doc = doc;
            // collect TitleBlockNameList
            FilteredElementCollector collector = new FilteredElementCollector(_doc);
            _titleblockList = collector.OfCategory(BuiltInCategory.OST_TitleBlocks)
                .Cast<FamilyInstance>().OrderBy(u => u.Name).ToList();

            foreach (var item in _titleblockList)
            {
                _titleblockNameList.Add(item.Name);
            }

            InitializeComponent();
        }

        private void TitleBlockFrm_Load(object sender, EventArgs e)
        {
            cbx_TitleBlockList.DataSource = _titleblockNameList;
        }
    }
}
