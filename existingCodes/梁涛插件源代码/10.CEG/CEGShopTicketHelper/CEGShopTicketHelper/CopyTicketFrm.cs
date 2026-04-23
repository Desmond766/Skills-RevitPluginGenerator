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
    public partial class CopyTicketFrm : System.Windows.Forms.Form
    {
        TreeView _tv;
        Autodesk.Revit.DB.Document _doc;
        public List<AssemblyInstance> _assemblyInstList;
        //public AssemblyInstance _selectedAssembly;
        public List<AssemblyInstance> _selectedAssemblyList;
        public CopyTicketFrm(Autodesk.Revit.DB.Document doc)
        {
            InitializeComponent();
            _doc = doc;
            _selectedAssemblyList = new List<AssemblyInstance>();
        }

        private void CopyTicketFrm_Load(object sender, EventArgs e)
        {
            tbx_CurrentAssembly.Text = _doc.GetElement(_doc.ActiveView.AssociatedAssemblyInstanceId).Name;

            FilteredElementCollector assemblyCol = new FilteredElementCollector(_doc);
            _assemblyInstList = assemblyCol.OfClass(typeof(AssemblyInstance))
                .ToElements().Cast<AssemblyInstance>().ToList();

            //List<string> assemblyNameList = _assemblyInstList.Select(u => u.Name).ToList();
            //assemblyNameList.Sort(new StringComparer(true));
            //cbx_AssemblyName.DataSource = assemblyNameList;

            //树状结构
            List<string> strTree = _assemblyInstList.Select(u => 
            string.Format("{0}\\{1}", GetLetters(u.Name), u.Name)).ToList();
            strTree.Sort(new StringComparer(true));//排序//字符串太长会报错

            _tv = DiectoryStrToTreeView(strTree);
            _tv.Size = gbx_Assembly.Size;
            _tv.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            gbx_Assembly.Controls.Add(_tv);
            //_tv.ExpandAll();
            _tv.HideSelection = false;
            _tv.CheckBoxes = true;
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
            //if (_tv.SelectedNode.Parent == null)
            //{
            //    MessageBox.Show("please select a assembly");
            //    return;
            //}

            //_selectedAssembly = _assemblyInstList.Where(u => u.Name == _tv.SelectedNode.Text).First();

            try
            {
                foreach (TreeNode tn in _tv.Nodes)
                {
                    foreach (TreeNode tnn in tn.Nodes)
                    {
                        if (tnn.Checked)
                        {
                            //MessageBox.Show(tnn.Text + "a");
                            _selectedAssemblyList.Add(_assemblyInstList.Where(u => u.Name == tnn.Text).First());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
