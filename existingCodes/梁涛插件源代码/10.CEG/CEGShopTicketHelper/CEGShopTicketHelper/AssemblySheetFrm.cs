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
    public partial class AssemblySheetFrm : System.Windows.Forms.Form
    {
        Document _doc;
        private Dictionary<string, ElementId> _viewDict//key:assemblyName + sheet Number
            = new Dictionary<string, ElementId>();
        private FilteredElementCollector _collector;
        private TreeView tv;
        public List<ElementId> selectedSheetList= new List<ElementId>();

        public AssemblySheetFrm(Document doc)
        {
            InitializeComponent();
            _doc = doc;
        }

        private void AssemblySheetFrm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            _collector = new FilteredElementCollector(_doc);
            _collector.OfClass(typeof(Autodesk.Revit.DB.View));

            tv = CollectAssemblySheet();
            tabControl.TabPages[0].Text = "Assembly";
            tabControl.TabPages[0].Controls.Add(tv);
            tv.Size = tabControl.TabPages[0].Size;

        }

        private TreeView CollectAssemblySheet()
        {
            List<string> strTree = new List<string>();
            foreach (ElementId id in _collector.ToElementIds())
            {
                Autodesk.Revit.DB.ViewSheet sheet = (_doc.GetElement(id) as Autodesk.Revit.DB.ViewSheet);
                if (null != sheet)
                {
                    if (sheet.IsAssemblyView)
                    {
                        strTree.Add(string.Format("{0}\\{1}", GetLetters(sheet.Title), sheet.Title));
                        if (!_viewDict.ContainsKey(sheet.Title))
                        {
                            _viewDict.Add(sheet.Title, id);
                        }
                    }
                }
            }
            strTree.Sort(new StringComparer(true));

            TreeView tv = DiectoryStrToTreeView(strTree);
            tv.CheckBoxes = true;
            //tv.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            //tv.DrawNode += new DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            return tv;
        }

        #region TreeView: Enable checkboxes but hide checkbox for childnodes.
        //https://social.msdn.microsoft.com/Forums/windows/en-US/947aaded-6372-4253-8799-2b595f4a39b9/treeview-enable-checkboxes-but-hide-checkbox-for-childnodes?forum=winformsdatacontrols
        //private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        //{
        //    if (IsFirstLevel(e.Node))
        //    {
        //        System.Drawing.Color backColor, foreColor;
        //        if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
        //        {
        //            backColor = SystemColors.Highlight;
        //            foreColor = SystemColors.HighlightText;
        //        }
        //        else if ((e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
        //        {
        //            backColor = SystemColors.HotTrack;
        //            foreColor = SystemColors.HighlightText;
        //        }
        //        else
        //        {
        //            backColor = e.Node.BackColor;
        //            foreColor = e.Node.ForeColor;
        //        }

        //        System.Drawing.Rectangle newBounds = e.Node.Bounds;

        //        newBounds.X = 60;

        //        using (SolidBrush brush = new SolidBrush(backColor))
        //        {
        //            e.Graphics.FillRectangle(brush, e.Node.Bounds);
        //        }
        //        e.Graphics.DrawImage(DatabaseTree.ImageList.Images[2], new Point(e.Bounds.X + 42, e.Bounds.Y));
        //        TextRenderer.DrawText(e.Graphics, e.Node.Text, this.tv.Font, e.Node.Bounds, foreColor, backColor);
        //        e.DrawDefault = false;
        //    }
        //    else
        //    {
        //        e.DrawDefault = true;
        //    }
        //}

        //private static bool IsFirstLevel(TreeNode node)
        //{
        //    return node.Parent == null;
        //}
        #endregion

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

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TreeNode tn in tv.Nodes)
                {
                    foreach (TreeNode tnn in tn.Nodes)
                    {
                        if (tnn.Checked)
                        {
                            //MessageBox.Show(tnn.Text + "a");
                            selectedSheetList.Add(_viewDict[tnn.Text]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
            
            //MessageBox.Show(selectViewId.Count.ToString());
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
