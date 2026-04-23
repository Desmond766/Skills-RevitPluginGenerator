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
using static System.Windows.Forms.AxHost;

namespace CEGShopTicketHelper
{
    public partial class QuickPrintCmd3Frm : System.Windows.Forms.Form
    {
        Document _doc;
        private Dictionary<string, ElementId> _printSettingDict//key:printerSetting
            = new Dictionary<string, ElementId>();
        private FilteredElementCollector _collector;
        private TreeView tv;
        private Dictionary<string, ElementId> _viewDict
            = new Dictionary<string, ElementId>();
        FilteredElementCollector _collector2;
        ListBox lb;
        List<ViewSheetSet> vssList = new List<ViewSheetSet>();
        public ViewSet selectedSheetSet = new ViewSet();
        public PrintSetting selectedPrintSetting = null;
        public string selectedPrinter = null;
        int levelNum = 0;//indicate level of the view path

        public QuickPrintCmd3Frm(Document doc)
        {
            InitializeComponent();
            _doc = doc;
        }

        private void QuickPrintCmd3Frm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            _collector = new FilteredElementCollector(_doc);
            _collector.OfClass(typeof(ViewSheet));

            tv = CollectSheet();
            tabControl1.TabPages[0].Text = "in-session sheets";
            tabControl1.TabPages[0].Controls.Add(tv);
            tv.Size = tabControl1.TabPages[0].Size;

            //get all the existing viewsheetset
            _collector2 = new FilteredElementCollector(_doc);
            vssList = _collector2.OfClass(typeof(ViewSheetSet))
                .ToElements().Cast<ViewSheetSet>().ToList();
            lb = new ListBox();
            lb.DataSource = vssList.Select(u=>u.Name).ToList();
            tabControl1.TabPages[1].Text = "print sets";
            tabControl1.TabPages[1].Controls.Add(lb);
            lb.Size = tabControl1.TabPages[1].Size;

            //collect printer
            List<string> printerNames = new List<string>();
            foreach (string item in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                printerNames.Add(item);
            }
            cbx_PrinterList.DataSource = printerNames;
            cbx_PrinterList.Text = _doc.PrintManager.PrinterName;

            //collect printSetting
            foreach (var item in _doc.GetPrintSettingIds())
            {
                if (!_printSettingDict.ContainsKey(_doc.GetElement(item).Name))
                {
                    _printSettingDict.Add(_doc.GetElement(item).Name, item);
                }
            }
            cbx_SettingList.DataSource = _printSettingDict.Keys.ToList();
            cbx_SettingList.Text = (_doc.PrintManager.PrintSetup.CurrentPrintSetting as PrintSetting).Name;
        }

        private TreeView CollectSheet()
        {
            BrowserOrganization org
                = BrowserOrganization.GetCurrentBrowserOrganizationForSheets(_doc);

            List<string> strTree = new List<string>();
            foreach (ElementId id in _collector.ToElementIds())
            {

                Autodesk.Revit.DB.ViewSheet sheet = (_doc.GetElement(id) as Autodesk.Revit.DB.ViewSheet);
                if (null != sheet)
                {
                    if (!sheet.IsAssemblyView)
                    {
                        strTree.Add(string.Join("\\", org.GetFolderItems(id).Select(u => u.Name))
                                        + "\\" + sheet.Title);
                        if (!_viewDict.ContainsKey(sheet.Title))
                        {
                            _viewDict.Add(sheet.Title, id);
                        }
                    }
                }
            }
            strTree.Sort(new StringComparer(true));
            if (strTree.Count > 0)
            {
                string[] arr = strTree[0].Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                levelNum = arr.Length;
            }
            TreeView tv = DiectoryStrToTreeView(strTree);
            tv.CheckBoxes = true;
            tv.AfterCheck += Tv_AfterCheck;

            return tv;
        }

        private void Tv_AfterCheck(object sender, TreeViewEventArgs e)
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
                if (tabControl1.SelectedIndex == 0)
                {
                    if (levelNum == 2)
                    {
                        foreach (TreeNode tn in tv.Nodes)
                        {
                            foreach (TreeNode tnn in tn.Nodes)
                            {
                                if (tnn.Checked)
                                {
                                    selectedSheetSet.Insert(_doc.GetElement(_viewDict[tnn.Text]) as ViewSheet);
                                }
                            }
                        }
                    }
                    if (levelNum == 3)
                    {
                        foreach (TreeNode tn in tv.Nodes)
                        {
                            foreach (TreeNode tnn in tn.Nodes)
                            {
                                foreach (TreeNode tnnn in tnn.Nodes)
                                {
                                    if (tnnn.Checked)
                                    {
                                        selectedSheetSet.Insert(_doc.GetElement(_viewDict[tnnn.Text]) as ViewSheet);
                                    }
                                }
                            }
                        }
                    }
                }
                else// selectedIndex = 1
                {
                    //TaskDialog.Show("r", vssList[lb.SelectedIndex].Name);
                    selectedSheetSet = vssList[lb.SelectedIndex].Views;
                }
                selectedPrinter = cbx_PrinterList.Text;
                selectedPrintSetting = _doc.GetElement(_printSettingDict[cbx_SettingList.Text]) as PrintSetting;
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
