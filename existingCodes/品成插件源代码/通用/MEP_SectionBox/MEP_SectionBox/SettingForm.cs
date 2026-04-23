using Autodesk.Revit.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_SectionBox
{
    public partial class SettingForm : System.Windows.Forms.Form
    {
        Document m_doc;
        List<Level> levelList;
        List<Grid> gridDirX;
        List<Grid> gridDirY;
        public SettingForm(Document doc)
        {
            InitializeComponent();
            m_doc = doc;
            levelList = GetLevelList(m_doc);
            gridDirX = GetGridList(m_doc,XYZ.BasisX);
            gridDirY = GetGridList(m_doc, XYZ.BasisY);

        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            List<string> levelData = new List<string>();
            foreach (Level le in levelList)
            {
                levelData.Add(le.Name + " => " + (le.Elevation * 0.3048).ToString("0.000"));
            }
            cbx_TopLevel.DataSource = levelData;
            cbx_BottomLevel.DataSource = CopyList(levelData);
            List<string> girdDirXData = new List<string>();
            foreach (Grid gi in gridDirX)
            {
                girdDirXData.Add(gi.Name + "轴 => " + ((gi.Curve as Line).Origin.Y * 0.3048).ToString("0.000"));
            }
            cbx_FrontGird.DataSource = girdDirXData;
            cbx_BackGird.DataSource = CopyList(girdDirXData);
            List<string> girdDirYData = new List<string>();
            foreach (Grid gi in gridDirY)
            {
                girdDirYData.Add(gi.Name + "轴 => " + ((gi.Curve as Line).Origin.X * 0.3048).ToString("0.000"));
            }
            cbx_LeftGird.DataSource = girdDirYData;
            cbx_RightGird.DataSource = CopyList(girdDirYData);
        } 

        private void btn_OK_Click(object sender, EventArgs e)
        {
            View3D view3D = m_doc.ActiveView as View3D;
            //if (null == view3D)
            //{
            //    MessageBox.Show("请切换至三维视图运行！");
            //    return;
            //}
            BoundingBoxXYZ box = view3D.GetSectionBox();
            XYZ max = box.Transform.OfPoint(box.Max);
            XYZ min = box.Transform.OfPoint(box.Min);
            double maxX = max.X;
            double maxY = max.Y;
            double maxZ = max.Z;
            double minX = min.X;
            double minY = min.Y;
            double minZ = min.Z;
            if (checkbx_Top.Checked)
            {
                maxZ = levelList[cbx_TopLevel.SelectedIndex].ProjectElevation + double.Parse(tbx_TopOffset.Text) / 304.8;
            }
            if (checkbx_Bottom.Checked)
            {
                minZ = levelList[cbx_BottomLevel.SelectedIndex].ProjectElevation + double.Parse(tbx_BottomOffset.Text) / 304.8;
            }
            if (checkbx_Front.Checked)
            {
                minY = (gridDirX[cbx_FrontGird.SelectedIndex].Curve as Line).Origin.Y + double.Parse(tbx_FrontOffset.Text) / 304.8;
            }
            if (checkbx_Back.Checked)
            {
                maxY = (gridDirX[cbx_BackGird.SelectedIndex].Curve as Line).Origin.Y + double.Parse(tbx_BackOffset.Text) / 304.8;
            }
            if (checkbx_Left.Checked)
            {
                minX = (gridDirY[cbx_LeftGird.SelectedIndex].Curve as Line).Origin.X + double.Parse(tbx_LeftOffset.Text) / 304.8;
            }
            if (checkbx_Right.Checked)
            {
                maxX = (gridDirY[cbx_RightGird.SelectedIndex].Curve as Line).Origin.X + double.Parse(tbx_RightOffset.Text) / 304.8;
            }
            if (maxX <= minX || maxY <= minY || maxZ <= minZ)
            {
                if ((checkbx_Top.Checked && !checkbx_Bottom.Checked || !checkbx_Top.Checked && checkbx_Bottom.Checked) ||
                    (checkbx_Front.Checked && !checkbx_Back.Checked || !checkbx_Front.Checked && checkbx_Back.Checked) ||
                    (checkbx_Left.Checked && !checkbx_Right.Checked || !checkbx_Left.Checked && checkbx_Right.Checked))
                {
                    MessageBox.Show("当前设置与已存在的剖面框冲突，请成对设置！");
                }
                else
                {
                    MessageBox.Show("设置错误，无法生成范围框！");
                }
            }
            else
            {
                BoundingBoxXYZ newBox = new BoundingBoxXYZ();
                newBox.Max = new XYZ(maxX, maxY, maxZ);
                newBox.Min = new XYZ(minX, minY, minZ);
                Command.Box = newBox;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region CheckBoxEvent
        private void checkbx_Top_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbx_Top.Checked)
            {
                cbx_TopLevel.Enabled = true;
                tbx_TopOffset.Enabled = true;
            }
            else
            {
                cbx_TopLevel.Enabled = false;
                tbx_TopOffset.Enabled = false;
            }
        }

        private void checkbx_Bottom_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbx_Bottom.Checked)
            {
                cbx_BottomLevel.Enabled = true;
                tbx_BottomOffset.Enabled = true;
            }
            else
            {
                cbx_BottomLevel.Enabled = false;
                tbx_BottomOffset.Enabled = false;
            }
        }

        private void checkbx_Front_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbx_Front.Checked)
            {
                cbx_FrontGird.Enabled = true;
                tbx_FrontOffset.Enabled = true;
            }
            else
            {
                cbx_FrontGird.Enabled = false;
                tbx_FrontOffset.Enabled = false;
            }
        }

        private void checkbx_Back_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbx_Back.Checked)
            {
                cbx_BackGird.Enabled = true;
                tbx_BackOffset.Enabled = true;
            }
            else
            {
                cbx_BackGird.Enabled = false;
                tbx_BackOffset.Enabled = false;
            }
        }

        private void checkbx_Left_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbx_Left.Checked)
            {
                cbx_LeftGird.Enabled = true;
                tbx_LeftOffset.Enabled = true;
            }
            else
            {
                cbx_LeftGird.Enabled = false;
                tbx_LeftOffset.Enabled = false;
            }
        }

        private void checkbx_Right_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbx_Right.Checked)
            {
                cbx_RightGird.Enabled = true;
                tbx_RightOffset.Enabled = true;
            }
            else
            {
                cbx_RightGird.Enabled = false;
                tbx_RightOffset.Enabled = false;
            }
        }
        #endregion

        #region GetLevelList
        /// <summary>
        /// GetLevelList
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private List<Level> GetLevelList(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(Level));
            List<Level> levelList = new List<Level>();
            List<double> elevationList = new List<double>();
            Hashtable levelHash = new Hashtable();
            foreach (Level le in collector)
            {
                elevationList.Add(le.Elevation);
                levelHash.Add(le.Elevation, le);
            }
            elevationList.Sort();
            foreach (double ele in elevationList)
            {
                levelList.Add((Level)levelHash[ele]);
            }
            return levelList;
        }
        #endregion

        #region GetGridList
        /// <summary>
        /// GetGridList
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private List<Grid> GetGridList(Document doc, XYZ direction)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(Grid));
            List<Grid> girdList = new List<Grid>();
            XYZ dir;
            foreach (Grid gi in collector)
            {
                if (!gi.IsCurved)
                {
                    dir = (gi.Curve as Line).Direction;
                    if (dir.IsAlmostEqualTo(direction) || dir.IsAlmostEqualTo(direction.Negate()))
                    {
                        girdList.Add(gi);
                    }
                }
            }
            return girdList;
        }




        #endregion

        #region CopyList
        /// <summary>
        /// CopyList
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private List<string> CopyList(List<string> source)
        {
            List<string> traget = new List<string>();
            foreach (string item in source)
            {
                traget.Add(item);
            }
            return traget;
        }
        #endregion

       
    }
}
