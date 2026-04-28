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

namespace ExportSchedule
{
    public partial class SettingForm :System.Windows.Forms.Form
    {
        Document _doc;
        List<ViewSchedule> projectSchedules;
        List<ViewSchedule> assemblySchedules;
        List<string> projectScheduleNames;
        List<string> assemblyScheduleNames;
        Dictionary<string, ViewSchedule> assemblyScheduleDict;
        TreeView tree;
        public List<ViewSchedule> _selectedSchedules;
        public ScheduleExportMode _exportMode;
        public List<string> _assemblyNameList;
        public List<string> _scheduleNameList;
        public string _scheduleName;
        public bool _isExportTitle;
        public SettingForm(Document doc)
        {
            InitializeComponent();
            _doc = doc;
            _selectedSchedules = new List<ViewSchedule>();
            _assemblyNameList = new List<string>();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //export mode
            if (rbtn_1FileMulitSheet.Checked)
            {
                _exportMode = ScheduleExportMode.OneFileMulitSheet;
            }
            if (rbtn_1File1Sheet.Checked)
            {
                _exportMode = ScheduleExportMode.OneFileOneSheet;
                _scheduleName = tbx_ScheduleName.Text;
            }
            if (rbtn_MulitFileMulitSheet.Checked)
            {
                _exportMode = ScheduleExportMode.MulitFileMulitSheet;
                _scheduleNameList = tbx_ScheduleNameList.Lines
                    .Where(u => !string.IsNullOrEmpty(u))//排除不小心换行
                    .ToList();
            }
            //export setting
            _isExportTitle = cbx_ExportTitle.Checked;
            //projectSchedule
            for (int i = 0; i < projectSchedules.Count; i++)
            {
                if (cbx_ProjectSchedule.GetItemChecked(i))
                {
                    //MessageBox.Show(projectScheduleNames[i]);
                    _selectedSchedules.Add(projectSchedules[i]);
                }
            }
            //assemblySchedule
            foreach (TreeNode tn in tree.Nodes)
            {
                if (tn.Checked)//assembly
                {
                    _assemblyNameList.Add(tn.Text);
                }
                foreach (TreeNode tnn in tn.Nodes)//schedule
                {
                    if (tnn.Checked)
                    {
                        //MessageBox.Show(tn.Text + "\\" + tnn.Text);
                        _selectedSchedules.Add(assemblyScheduleDict[tn.Text + "\\" + tnn.Text]);
                    }
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CollectProjectSchedules()
        {
            FilteredElementCollector col = new FilteredElementCollector(_doc);
            var list = col.OfCategory(BuiltInCategory.OST_Schedules)
                .Cast<ViewSchedule>()
                .Where(u => !u.IsAssemblyView && !u.IsTemplate)
                .ToList();
            list.Sort(new ScheduleCompaper());
            projectSchedules = list;
            projectScheduleNames = list.Select(u => u.Name).ToList();
            foreach (var item in projectScheduleNames)
            {
                cbx_ProjectSchedule.Items.Add(item);
            }
        }

        private void CollectAssemblySchedules()
        {
            FilteredElementCollector col = new FilteredElementCollector(_doc);
            var list = col.OfCategory(BuiltInCategory.OST_Schedules)
                .Cast<ViewSchedule>()
                .Where(u => u.IsAssemblyView && !u.IsTemplate)
                .ToList();
            assemblySchedules = list;
            // fill data
            assemblyScheduleNames = new List<string>();
            assemblyScheduleDict = new Dictionary<string, ViewSchedule>();
            foreach (var item in assemblySchedules)
            {
                var name = _doc.GetElement(item.AssociatedAssemblyInstanceId).Name + "\\" + item.Name;
                assemblyScheduleNames.Add(name);
                if (!assemblyScheduleDict.ContainsKey(name))
                {
                    assemblyScheduleDict.Add(name, item);
                }
            }
            // sort
            assemblyScheduleNames.Sort(new StringComparer(true));
            // tree
            tree = DiectoryStrToTreeView(assemblyScheduleNames);
            tabPage2.Controls.Add(tree);
            tree.Size = tabPage2.Size;
            tree.CheckBoxes = true;

            // right click event
            tree.NodeMouseClick +=
                new TreeNodeMouseClickEventHandler(treeView_TreeNodeMouseClick);
        }

        private void treeView_TreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView tv = sender as TreeView;
            if (e.Button != MouseButtons.Right) return;
            if (e.Node == null) return;
            tv.SelectedNode = e.Node;
            contextMenuStrip1.Show(tv.Parent, e.X, e.Y);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            CollectProjectSchedules();
            CollectAssemblySchedules();
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(tree.SelectedNode.Text);
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

        private void rbtn_1FileMulitSheet_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_1File1Sheet.Checked)
            {
                tbx_ScheduleName.Enabled = true;
            }
            else
            {
                tbx_ScheduleName.Enabled = false;
            }
        }

        private void rbtn_1File1Sheet_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtn_MulitFileMulitSheet_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_MulitFileMulitSheet.Checked)
            {
                tbx_ScheduleNameList.Enabled = true;
            }
            else
            {
                tbx_ScheduleNameList.Enabled = false;
            }
        }
    }

    class ScheduleCompaper : IComparer<ViewSchedule>
    {
        public int Compare(ViewSchedule x, ViewSchedule y)
        {
            var c = new StringComparer(true);
            if (x.IsAssemblyView)
            {
                return c.Compare(
                    x.Document.GetElement(x.AssociatedAssemblyInstanceId).Name + "\\" + x.Name,
                    y.Document.GetElement(y.AssociatedAssemblyInstanceId).Name + "\\" + y.Name);
            }
            else
            {
                return c.Compare(x.Name, y.Name);
            }
        }
    }

}
