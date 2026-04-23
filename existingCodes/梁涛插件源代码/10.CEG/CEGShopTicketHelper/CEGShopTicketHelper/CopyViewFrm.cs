using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
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
    public partial class CopyViewFrm : System.Windows.Forms.Form
    {
        TreeView _tv;
        Autodesk.Revit.DB.Document _doc;
        public List<AssemblyInstance> _assemblyInstList;
        public List<Autodesk.Revit.DB.View> _assemblyViewList;
        public List<Autodesk.Revit.DB.View> _viewList;
        public Autodesk.Revit.DB.View _selectedView;
        public bool _copyAnnotations;
        public bool _copyTags;
        public bool _copyDimensions;
        public string _annotationRotation;
        public CopyViewFrm(Autodesk.Revit.DB.Document doc)
        {
            InitializeComponent();
            _doc = doc;
        }

        private void CopyTicketFrm_Load(object sender, EventArgs e)
        {
            tbx_CurrentAssembly.Text = _doc.GetElement(_doc.ActiveView.AssociatedAssemblyInstanceId).Name;
            tbx_CurrentView.Text = _doc.ActiveView.Name;

            FilteredElementCollector viewCol = new FilteredElementCollector(_doc);
            _assemblyViewList = viewCol.OfClass(typeof(Autodesk.Revit.DB.View))
                .ToElements().Cast<Autodesk.Revit.DB.View>()
                .Where(u => u.IsAssemblyView).ToList();


            //树状结构
            List<string> strTree = new List<string>();
            foreach (Autodesk.Revit.DB.View view in _assemblyViewList)
            {
                string assemblyName = _doc.GetElement(view.AssociatedAssemblyInstanceId).Name;
                string info = string.Format("{0}\\{1}\\{2}", GetLetters(assemblyName), assemblyName, view.Name);
                strTree.Add(info);
            }
            strTree.Sort(new StringComparer(true));//排序//字符串太长会报错

            _tv = DiectoryStrToTreeView(strTree);
            _tv.Size = gbx_Assembly.Size;
            _tv.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            gbx_Assembly.Controls.Add(_tv);
            //_tv.ExpandAll();
            _tv.HideSelection = false;
            //_tv.CheckBoxes = true;

        }

        private string GetLetters(string str)
        {
            int index = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsLetter(str[i]))
                {
                    index = i;
                    break;
                }
            }
            if (index == 0)
            {
                return "???";
            }
            return str.Substring(0, index);
        }

        private TreeView DiectoryStrToTreeView(List<string> strTree)
        {
            TreeView tv = new TreeView();
            foreach (var path in strTree)
            {
                var nodes = tv.Nodes;
                var pathsplit = path.Split('\\');
                foreach (var splitname in pathsplit)
                {
                    var isexist = false;
                    foreach (TreeNode tvn in nodes)
                    {
                        if (tvn.Text != splitname) continue;
                        nodes = tvn.Nodes;
                        isexist = true;
                    }
                    if (isexist) continue;
                    var tvnadd = new TreeNode { Text = splitname };
                    nodes.Add(tvnadd);
                    nodes = tvnadd.Nodes;
                }
            }
            //tv.Sort();
            return tv;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //_selectedView = _viewList.Where(u => u.Name == cbx_ViewName.Text).First();

            if (_tv.SelectedNode.Parent == null)
            {
                MessageBox.Show("please select a view under assembly");
                return;
            }
            if (_tv.SelectedNode.Parent.Parent == null)
            {
                MessageBox.Show("please select a view under assembly");
                return;
            }

            string selectedViewName = _tv.SelectedNode.Text;
            string selectedAssemblyName = _tv.SelectedNode.Parent.Text;
            _selectedView = _assemblyViewList.Where(u =>
            _doc.GetElement(u.AssociatedAssemblyInstanceId).Name == selectedAssemblyName 
            && u.Name == selectedViewName).ToList().First();
            _copyAnnotations = cbx_CopyAnnotations.Checked;
            _copyTags = cbx_CopyTags.Checked;
            _copyDimensions = cbx_CopyDimensions.Checked;
            _annotationRotation = rbtn_NoRotation.Checked ? "0" : (rbtn_90.Checked ? "90" : (rbtn_90negative.Checked ? "-90" : null));
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
