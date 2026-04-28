
namespace ExportSchedule
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbx_ExportTitle = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_ScheduleName = new System.Windows.Forms.TextBox();
            this.tbx_ScheduleNameList = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtn_MulitFileMulitSheet = new System.Windows.Forms.RadioButton();
            this.rbtn_1FileMulitSheet = new System.Windows.Forms.RadioButton();
            this.rbtn_1File1Sheet = new System.Windows.Forms.RadioButton();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbx_ProjectSchedule = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbx_ExportTitle);
            this.groupBox2.Location = new System.Drawing.Point(405, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 101);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ExprotSetting";
            // 
            // cbx_ExportTitle
            // 
            this.cbx_ExportTitle.AutoSize = true;
            this.cbx_ExportTitle.Checked = true;
            this.cbx_ExportTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_ExportTitle.Location = new System.Drawing.Point(10, 20);
            this.cbx_ExportTitle.Name = "cbx_ExportTitle";
            this.cbx_ExportTitle.Size = new System.Drawing.Size(90, 16);
            this.cbx_ExportTitle.TabIndex = 0;
            this.cbx_ExportTitle.Text = "ExportTitle";
            this.cbx_ExportTitle.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbx_ScheduleName);
            this.groupBox1.Controls.Add(this.tbx_ScheduleNameList);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbtn_MulitFileMulitSheet);
            this.groupBox1.Controls.Add(this.rbtn_1FileMulitSheet);
            this.groupBox1.Controls.Add(this.rbtn_1File1Sheet);
            this.groupBox1.Location = new System.Drawing.Point(403, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 269);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ExportMode";
            // 
            // tbx_ScheduleName
            // 
            this.tbx_ScheduleName.Enabled = false;
            this.tbx_ScheduleName.Location = new System.Drawing.Point(26, 95);
            this.tbx_ScheduleName.Name = "tbx_ScheduleName";
            this.tbx_ScheduleName.Size = new System.Drawing.Size(147, 21);
            this.tbx_ScheduleName.TabIndex = 7;
            // 
            // tbx_ScheduleNameList
            // 
            this.tbx_ScheduleNameList.Enabled = false;
            this.tbx_ScheduleNameList.Location = new System.Drawing.Point(26, 179);
            this.tbx_ScheduleNameList.Multiline = true;
            this.tbx_ScheduleNameList.Name = "tbx_ScheduleNameList";
            this.tbx_ScheduleNameList.Size = new System.Drawing.Size(147, 75);
            this.tbx_ScheduleNameList.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Schedule name contains";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Schedule name contains";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "(Assembly Only)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "(Assembly Only)";
            // 
            // rbtn_MulitFileMulitSheet
            // 
            this.rbtn_MulitFileMulitSheet.AutoSize = true;
            this.rbtn_MulitFileMulitSheet.Location = new System.Drawing.Point(10, 121);
            this.rbtn_MulitFileMulitSheet.Name = "rbtn_MulitFileMulitSheet";
            this.rbtn_MulitFileMulitSheet.Size = new System.Drawing.Size(155, 16);
            this.rbtn_MulitFileMulitSheet.TabIndex = 4;
            this.rbtn_MulitFileMulitSheet.TabStop = true;
            this.rbtn_MulitFileMulitSheet.Text = "Mulit File Mulit Sheet";
            this.rbtn_MulitFileMulitSheet.UseVisualStyleBackColor = true;
            this.rbtn_MulitFileMulitSheet.CheckedChanged += new System.EventHandler(this.rbtn_MulitFileMulitSheet_CheckedChanged);
            // 
            // rbtn_1FileMulitSheet
            // 
            this.rbtn_1FileMulitSheet.AutoSize = true;
            this.rbtn_1FileMulitSheet.Checked = true;
            this.rbtn_1FileMulitSheet.Location = new System.Drawing.Point(10, 22);
            this.rbtn_1FileMulitSheet.Name = "rbtn_1FileMulitSheet";
            this.rbtn_1FileMulitSheet.Size = new System.Drawing.Size(131, 16);
            this.rbtn_1FileMulitSheet.TabIndex = 2;
            this.rbtn_1FileMulitSheet.TabStop = true;
            this.rbtn_1FileMulitSheet.Text = "1 File Mulit Sheet";
            this.rbtn_1FileMulitSheet.UseVisualStyleBackColor = true;
            this.rbtn_1FileMulitSheet.CheckedChanged += new System.EventHandler(this.rbtn_1FileMulitSheet_CheckedChanged);
            // 
            // rbtn_1File1Sheet
            // 
            this.rbtn_1File1Sheet.AutoSize = true;
            this.rbtn_1File1Sheet.Location = new System.Drawing.Point(10, 44);
            this.rbtn_1File1Sheet.Name = "rbtn_1File1Sheet";
            this.rbtn_1File1Sheet.Size = new System.Drawing.Size(107, 16);
            this.rbtn_1File1Sheet.TabIndex = 3;
            this.rbtn_1File1Sheet.TabStop = true;
            this.rbtn_1File1Sheet.Text = "1 File 1 Sheet";
            this.rbtn_1File1Sheet.UseVisualStyleBackColor = true;
            this.rbtn_1File1Sheet.CheckedChanged += new System.EventHandler(this.rbtn_1File1Sheet_CheckedChanged);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(447, 394);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(528, 394);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(385, 376);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbx_ProjectSchedule);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(377, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Project";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbx_ProjectSchedule
            // 
            this.cbx_ProjectSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_ProjectSchedule.CheckOnClick = true;
            this.cbx_ProjectSchedule.FormattingEnabled = true;
            this.cbx_ProjectSchedule.Location = new System.Drawing.Point(6, 6);
            this.cbx_ProjectSchedule.Name = "cbx_ProjectSchedule";
            this.cbx_ProjectSchedule.Size = new System.Drawing.Size(365, 340);
            this.cbx_ProjectSchedule.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(377, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Assembly";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 26);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(613, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导出明细表";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbx_ExportTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_ScheduleName;
        private System.Windows.Forms.TextBox tbx_ScheduleNameList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtn_MulitFileMulitSheet;
        private System.Windows.Forms.RadioButton rbtn_1FileMulitSheet;
        private System.Windows.Forms.RadioButton rbtn_1File1Sheet;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox cbx_ProjectSchedule;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    }
}