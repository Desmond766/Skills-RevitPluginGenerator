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
    public partial class TicketCheckerFrm : Form
    {
        public TicketCheckerFrm()
        {
            InitializeComponent();
        }

        public List<CheckingItem> _checkingItems = new List<CheckingItem>();
        TreeView _checkItemTV;
        private void TicketCheckerFrm_Load(object sender, EventArgs e)
        {
            tabControl.TabPages[0].Text = "Checking Items";
            List<string> checkItemTree = new List<string>() 
            {
                "All\\Interfere Checking\\panel",
                "All\\Interfere Checking\\rebar/strand",
                "All\\Interfere Checking\\embed/lifter",
                "All\\Rebar Checking\\rebar list",
                "All\\Rebar Checking\\bent bar length",
                "All\\Rebar Checking\\bent bar sketch",
                "All\\Embed Checking\\embed list",
                "All\\Embed Checking\\embed drawing",
                "All\\Lifter Checking\\Lifter capacity",
                "All\\Lifter Checking\\Lifter Location",
                "All\\Model Checking\\Workset"
            };
            _checkItemTV = DiectoryStrToTreeView(checkItemTree);
            tabControl.TabPages[0].Controls.Add(_checkItemTV);
            _checkItemTV.Size = tabControl.TabPages[0].Size;
            _checkItemTV.Anchor = (System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right);
            _checkItemTV.CheckBoxes = true;
            _checkItemTV.AfterCheck += _checkItemTV_AfterCheck;
            _checkItemTV.ExpandAll();
        }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            //_checkingItems
            foreach (TreeNode tn1 in _checkItemTV.Nodes)
            {
                foreach (TreeNode tn2 in tn1.Nodes)
                {
                    foreach (TreeNode tn3 in tn2.Nodes)
                    {
                        if(tn3.Checked)
                        {
                            switch (tn3.Text)
                            {
                                case "panel":
                                    _checkingItems.Add(CheckingItem.PanelInterfere);
                                    break;
                                case "rebar/strand":
                                    _checkingItems.Add(CheckingItem.RebarStrandInterfere);
                                    break;
                                case "embed/lifter":
                                    _checkingItems.Add(CheckingItem.EmbedLifterInterfere);
                                    break;
                                case "rebar list":
                                    _checkingItems.Add(CheckingItem.RebarList);
                                    break;
                                case "bent bar length":
                                    _checkingItems.Add(CheckingItem.BentBarLength);
                                    break;
                                case "bent bar sketch":
                                    _checkingItems.Add(CheckingItem.BentBarSketch);
                                    break;
                                case "embed list":
                                    _checkingItems.Add(CheckingItem.EmbedList);
                                    break;
                                case "embed drawing":
                                    _checkingItems.Add(CheckingItem.EmbedDrawing);
                                    break;
                                case "Lifter capacity":
                                    _checkingItems.Add(CheckingItem.LifterCapacity);
                                    break;
                                case "Lifter Location":
                                    _checkingItems.Add(CheckingItem.LifterLocation);
                                    break;
                                case "Workset":
                                    _checkingItems.Add(CheckingItem.Workset);
                                    break;
                            }
                        }
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

        private void _checkItemTV_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Checked == true)
                {
                    //选中节点之后，选中该节点所有的子节点
                    setChildNodeCheckedState(e.Node, true);
                }
                else if (e.Node.Checked == false)
                {
                    //取消节点选中状态之后，取消该节点所有子节点选中状态
                    setChildNodeCheckedState(e.Node, false);
                    //如果节点存在父节点，取消父节点的选中状态
                    if (e.Node.Parent != null)
                    {
                        setParentNodeCheckedState(e.Node, false);
                    }
                }
            }
        }

        //取消节点选中状态之后，取消所有父节点的选中状态
        private void setParentNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNode parentNode = currNode.Parent;
            parentNode.Checked = state;
            if (currNode.Parent.Parent != null)
            {
                setParentNodeCheckedState(currNode.Parent, state);
            }
        }
        //选中节点之后，选中节点的所有子节点
        private void setChildNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNodeCollection nodes = currNode.Nodes;
            if (nodes.Count > 0)
            {
                foreach (TreeNode tn in nodes)
                {
                    tn.Checked = state;
                    setChildNodeCheckedState(tn, state);
                }
            }
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
            return tv;
        }
    }
}
