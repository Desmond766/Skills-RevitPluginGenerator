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

namespace SectionBoxController
{
    public partial class SettingForm : Form
    {
        ExternalEvent topUpEvent = null;
        ExternalEvent topDownEvent = null;
        ExternalEvent bottomUpEvent = null;
        ExternalEvent bottomDownEvent = null;
        ExternalEvent northPlusEvent = null;
        ExternalEvent northMinusEvent = null;
        ExternalEvent southPlusEvent = null;
        ExternalEvent southMinusEvent = null;
        ExternalEvent westPlusEvent = null;
        ExternalEvent westMinusEvent = null;
        ExternalEvent eastPlusEvent = null;
        ExternalEvent eastMinusEvent = null;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            lbl_Tip.Text = string.Format("提示：当前步距{0}mm，重新启动以更改步距。", GlobalVaule.SPACING.ToString());
            InitEvents();
        }

        private void InitEvents()
        {
            topUpEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.TopUp));
            topDownEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.TopDown));
            bottomUpEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.BottomUp));
            bottomDownEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.BottomDown));
            northPlusEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.NorthPlus));
            northMinusEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.NorthMinus));
            southPlusEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.SouthPlus));
            southMinusEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.SouthMinus));
            westPlusEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.WestPlus));
            westMinusEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.WestMinus));
            eastPlusEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.EastPlus));
            eastMinusEvent = ExternalEvent.Create(new BoxUpdateHandler(BoxUpdateCmd.EastMinus));
        }

        private void btn_TopUp_Click(object sender, EventArgs e)
        {
            topUpEvent.Raise();
        }

        private void btn_TopDown_Click(object sender, EventArgs e)
        {
            topDownEvent.Raise();
        }

        private void btn_BottomUp_Click(object sender, EventArgs e)
        {
            bottomUpEvent.Raise();
        }

        private void btn_BottomDown_Click(object sender, EventArgs e)
        {
            bottomDownEvent.Raise();
        }

        private void btn_NorthPlus_Click(object sender, EventArgs e)
        {
            northPlusEvent.Raise();
        }

        private void btn_NorthMinus_Click(object sender, EventArgs e)
        {
            northMinusEvent.Raise();
        }

        private void btn_SouthMinus_Click(object sender, EventArgs e)
        {
            southMinusEvent.Raise();
        }

        private void btn_SouthPlus_Click(object sender, EventArgs e)
        {
            southPlusEvent.Raise();
        }

        private void btn_WestPlus_Click(object sender, EventArgs e)
        {
            westPlusEvent.Raise();
        }

        private void btn_WestMinus_Click(object sender, EventArgs e)
        {
            westMinusEvent.Raise();
        }

        private void btn_EastMinus_Click(object sender, EventArgs e)
        {
            eastMinusEvent.Raise();
        }

        private void btn_EastPuls_Click(object sender, EventArgs e)
        {
            eastPlusEvent.Raise();
        }

    }
}
