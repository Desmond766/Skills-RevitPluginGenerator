namespace MEP_SectionBox
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
            this.gbx_Top = new System.Windows.Forms.GroupBox();
            this.tbx_TopOffset = new System.Windows.Forms.TextBox();
            this.lbl_TopOffset = new System.Windows.Forms.Label();
            this.lbl_TopLevel = new System.Windows.Forms.Label();
            this.cbx_TopLevel = new System.Windows.Forms.ComboBox();
            this.checkbx_Top = new System.Windows.Forms.CheckBox();
            this.gbx_Bottom = new System.Windows.Forms.GroupBox();
            this.tbx_BottomOffset = new System.Windows.Forms.TextBox();
            this.lbl_BottomOffset = new System.Windows.Forms.Label();
            this.lbl_BottomLevel = new System.Windows.Forms.Label();
            this.cbx_BottomLevel = new System.Windows.Forms.ComboBox();
            this.checkbx_Bottom = new System.Windows.Forms.CheckBox();
            this.gbx_Front = new System.Windows.Forms.GroupBox();
            this.tbx_FrontOffset = new System.Windows.Forms.TextBox();
            this.lbl_FrontOffset = new System.Windows.Forms.Label();
            this.lbl_FrontGird = new System.Windows.Forms.Label();
            this.cbx_FrontGird = new System.Windows.Forms.ComboBox();
            this.checkbx_Front = new System.Windows.Forms.CheckBox();
            this.gbx_Back = new System.Windows.Forms.GroupBox();
            this.tbx_BackOffset = new System.Windows.Forms.TextBox();
            this.lbl_BackOffset = new System.Windows.Forms.Label();
            this.lbl_BackGird = new System.Windows.Forms.Label();
            this.cbx_BackGird = new System.Windows.Forms.ComboBox();
            this.checkbx_Back = new System.Windows.Forms.CheckBox();
            this.gbx_Left = new System.Windows.Forms.GroupBox();
            this.tbx_LeftOffset = new System.Windows.Forms.TextBox();
            this.lbl_LeftOffset = new System.Windows.Forms.Label();
            this.lbl_LeftGird = new System.Windows.Forms.Label();
            this.cbx_LeftGird = new System.Windows.Forms.ComboBox();
            this.checkbx_Left = new System.Windows.Forms.CheckBox();
            this.gbx_Right = new System.Windows.Forms.GroupBox();
            this.tbx_RightOffset = new System.Windows.Forms.TextBox();
            this.lbl_RightOffset = new System.Windows.Forms.Label();
            this.lbl_RightGird = new System.Windows.Forms.Label();
            this.cbx_RightGird = new System.Windows.Forms.ComboBox();
            this.checkbx_Right = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.gbx_Top.SuspendLayout();
            this.gbx_Bottom.SuspendLayout();
            this.gbx_Front.SuspendLayout();
            this.gbx_Back.SuspendLayout();
            this.gbx_Left.SuspendLayout();
            this.gbx_Right.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_Top
            // 
            this.gbx_Top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Top.Controls.Add(this.tbx_TopOffset);
            this.gbx_Top.Controls.Add(this.lbl_TopOffset);
            this.gbx_Top.Controls.Add(this.lbl_TopLevel);
            this.gbx_Top.Controls.Add(this.cbx_TopLevel);
            this.gbx_Top.Controls.Add(this.checkbx_Top);
            this.gbx_Top.Location = new System.Drawing.Point(12, 12);
            this.gbx_Top.Name = "gbx_Top";
            this.gbx_Top.Size = new System.Drawing.Size(325, 84);
            this.gbx_Top.TabIndex = 11;
            this.gbx_Top.TabStop = false;
            this.gbx_Top.Text = "上";
            // 
            // tbx_TopOffset
            // 
            this.tbx_TopOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_TopOffset.Enabled = false;
            this.tbx_TopOffset.Location = new System.Drawing.Point(127, 47);
            this.tbx_TopOffset.Name = "tbx_TopOffset";
            this.tbx_TopOffset.Size = new System.Drawing.Size(181, 21);
            this.tbx_TopOffset.TabIndex = 3;
            this.tbx_TopOffset.Text = "0";
            // 
            // lbl_TopOffset
            // 
            this.lbl_TopOffset.AutoSize = true;
            this.lbl_TopOffset.Location = new System.Drawing.Point(81, 50);
            this.lbl_TopOffset.Name = "lbl_TopOffset";
            this.lbl_TopOffset.Size = new System.Drawing.Size(41, 12);
            this.lbl_TopOffset.TabIndex = 2;
            this.lbl_TopOffset.Text = "偏移量";
            // 
            // lbl_TopLevel
            // 
            this.lbl_TopLevel.AutoSize = true;
            this.lbl_TopLevel.Location = new System.Drawing.Point(92, 22);
            this.lbl_TopLevel.Name = "lbl_TopLevel";
            this.lbl_TopLevel.Size = new System.Drawing.Size(29, 12);
            this.lbl_TopLevel.TabIndex = 2;
            this.lbl_TopLevel.Text = "标高";
            // 
            // cbx_TopLevel
            // 
            this.cbx_TopLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_TopLevel.Enabled = false;
            this.cbx_TopLevel.FormattingEnabled = true;
            this.cbx_TopLevel.Location = new System.Drawing.Point(127, 18);
            this.cbx_TopLevel.Name = "cbx_TopLevel";
            this.cbx_TopLevel.Size = new System.Drawing.Size(181, 20);
            this.cbx_TopLevel.TabIndex = 1;
            // 
            // checkbx_Top
            // 
            this.checkbx_Top.AutoSize = true;
            this.checkbx_Top.Location = new System.Drawing.Point(6, 22);
            this.checkbx_Top.Name = "checkbx_Top";
            this.checkbx_Top.Size = new System.Drawing.Size(48, 16);
            this.checkbx_Top.TabIndex = 0;
            this.checkbx_Top.Text = "修改";
            this.checkbx_Top.UseVisualStyleBackColor = true;
            this.checkbx_Top.CheckedChanged += new System.EventHandler(this.checkbx_Top_CheckedChanged);
            // 
            // gbx_Bottom
            // 
            this.gbx_Bottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Bottom.Controls.Add(this.tbx_BottomOffset);
            this.gbx_Bottom.Controls.Add(this.lbl_BottomOffset);
            this.gbx_Bottom.Controls.Add(this.lbl_BottomLevel);
            this.gbx_Bottom.Controls.Add(this.cbx_BottomLevel);
            this.gbx_Bottom.Controls.Add(this.checkbx_Bottom);
            this.gbx_Bottom.Location = new System.Drawing.Point(12, 102);
            this.gbx_Bottom.Name = "gbx_Bottom";
            this.gbx_Bottom.Size = new System.Drawing.Size(325, 84);
            this.gbx_Bottom.TabIndex = 12;
            this.gbx_Bottom.TabStop = false;
            this.gbx_Bottom.Text = "下";
            // 
            // tbx_BottomOffset
            // 
            this.tbx_BottomOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_BottomOffset.Enabled = false;
            this.tbx_BottomOffset.Location = new System.Drawing.Point(127, 47);
            this.tbx_BottomOffset.Name = "tbx_BottomOffset";
            this.tbx_BottomOffset.Size = new System.Drawing.Size(181, 21);
            this.tbx_BottomOffset.TabIndex = 3;
            this.tbx_BottomOffset.Text = "0";
            // 
            // lbl_BottomOffset
            // 
            this.lbl_BottomOffset.AutoSize = true;
            this.lbl_BottomOffset.Location = new System.Drawing.Point(80, 50);
            this.lbl_BottomOffset.Name = "lbl_BottomOffset";
            this.lbl_BottomOffset.Size = new System.Drawing.Size(41, 12);
            this.lbl_BottomOffset.TabIndex = 2;
            this.lbl_BottomOffset.Text = "偏移量";
            // 
            // lbl_BottomLevel
            // 
            this.lbl_BottomLevel.AutoSize = true;
            this.lbl_BottomLevel.Location = new System.Drawing.Point(92, 22);
            this.lbl_BottomLevel.Name = "lbl_BottomLevel";
            this.lbl_BottomLevel.Size = new System.Drawing.Size(29, 12);
            this.lbl_BottomLevel.TabIndex = 2;
            this.lbl_BottomLevel.Text = "标高";
            // 
            // cbx_BottomLevel
            // 
            this.cbx_BottomLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_BottomLevel.Enabled = false;
            this.cbx_BottomLevel.FormattingEnabled = true;
            this.cbx_BottomLevel.Location = new System.Drawing.Point(127, 18);
            this.cbx_BottomLevel.Name = "cbx_BottomLevel";
            this.cbx_BottomLevel.Size = new System.Drawing.Size(181, 20);
            this.cbx_BottomLevel.TabIndex = 1;
            // 
            // checkbx_Bottom
            // 
            this.checkbx_Bottom.AutoSize = true;
            this.checkbx_Bottom.Location = new System.Drawing.Point(6, 22);
            this.checkbx_Bottom.Name = "checkbx_Bottom";
            this.checkbx_Bottom.Size = new System.Drawing.Size(48, 16);
            this.checkbx_Bottom.TabIndex = 0;
            this.checkbx_Bottom.Text = "修改";
            this.checkbx_Bottom.UseVisualStyleBackColor = true;
            this.checkbx_Bottom.CheckedChanged += new System.EventHandler(this.checkbx_Bottom_CheckedChanged);
            // 
            // gbx_Front
            // 
            this.gbx_Front.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Front.Controls.Add(this.tbx_FrontOffset);
            this.gbx_Front.Controls.Add(this.lbl_FrontOffset);
            this.gbx_Front.Controls.Add(this.lbl_FrontGird);
            this.gbx_Front.Controls.Add(this.cbx_FrontGird);
            this.gbx_Front.Controls.Add(this.checkbx_Front);
            this.gbx_Front.Location = new System.Drawing.Point(12, 192);
            this.gbx_Front.Name = "gbx_Front";
            this.gbx_Front.Size = new System.Drawing.Size(325, 84);
            this.gbx_Front.TabIndex = 13;
            this.gbx_Front.TabStop = false;
            this.gbx_Front.Text = "前";
            // 
            // tbx_FrontOffset
            // 
            this.tbx_FrontOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_FrontOffset.Enabled = false;
            this.tbx_FrontOffset.Location = new System.Drawing.Point(127, 47);
            this.tbx_FrontOffset.Name = "tbx_FrontOffset";
            this.tbx_FrontOffset.Size = new System.Drawing.Size(181, 21);
            this.tbx_FrontOffset.TabIndex = 3;
            this.tbx_FrontOffset.Text = "0";
            // 
            // lbl_FrontOffset
            // 
            this.lbl_FrontOffset.AutoSize = true;
            this.lbl_FrontOffset.Location = new System.Drawing.Point(80, 50);
            this.lbl_FrontOffset.Name = "lbl_FrontOffset";
            this.lbl_FrontOffset.Size = new System.Drawing.Size(41, 12);
            this.lbl_FrontOffset.TabIndex = 2;
            this.lbl_FrontOffset.Text = "偏移量";
            // 
            // lbl_FrontGird
            // 
            this.lbl_FrontGird.AutoSize = true;
            this.lbl_FrontGird.Location = new System.Drawing.Point(92, 22);
            this.lbl_FrontGird.Name = "lbl_FrontGird";
            this.lbl_FrontGird.Size = new System.Drawing.Size(29, 12);
            this.lbl_FrontGird.TabIndex = 2;
            this.lbl_FrontGird.Text = "轴网";
            // 
            // cbx_FrontGird
            // 
            this.cbx_FrontGird.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_FrontGird.Enabled = false;
            this.cbx_FrontGird.FormattingEnabled = true;
            this.cbx_FrontGird.Location = new System.Drawing.Point(127, 18);
            this.cbx_FrontGird.Name = "cbx_FrontGird";
            this.cbx_FrontGird.Size = new System.Drawing.Size(181, 20);
            this.cbx_FrontGird.TabIndex = 1;
            // 
            // checkbx_Front
            // 
            this.checkbx_Front.AutoSize = true;
            this.checkbx_Front.Location = new System.Drawing.Point(6, 22);
            this.checkbx_Front.Name = "checkbx_Front";
            this.checkbx_Front.Size = new System.Drawing.Size(48, 16);
            this.checkbx_Front.TabIndex = 0;
            this.checkbx_Front.Text = "修改";
            this.checkbx_Front.UseVisualStyleBackColor = true;
            this.checkbx_Front.CheckedChanged += new System.EventHandler(this.checkbx_Front_CheckedChanged);
            // 
            // gbx_Back
            // 
            this.gbx_Back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Back.Controls.Add(this.tbx_BackOffset);
            this.gbx_Back.Controls.Add(this.lbl_BackOffset);
            this.gbx_Back.Controls.Add(this.lbl_BackGird);
            this.gbx_Back.Controls.Add(this.cbx_BackGird);
            this.gbx_Back.Controls.Add(this.checkbx_Back);
            this.gbx_Back.Location = new System.Drawing.Point(12, 282);
            this.gbx_Back.Name = "gbx_Back";
            this.gbx_Back.Size = new System.Drawing.Size(325, 84);
            this.gbx_Back.TabIndex = 14;
            this.gbx_Back.TabStop = false;
            this.gbx_Back.Text = "后";
            // 
            // tbx_BackOffset
            // 
            this.tbx_BackOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_BackOffset.Enabled = false;
            this.tbx_BackOffset.Location = new System.Drawing.Point(127, 47);
            this.tbx_BackOffset.Name = "tbx_BackOffset";
            this.tbx_BackOffset.Size = new System.Drawing.Size(181, 21);
            this.tbx_BackOffset.TabIndex = 3;
            this.tbx_BackOffset.Text = "0";
            // 
            // lbl_BackOffset
            // 
            this.lbl_BackOffset.AutoSize = true;
            this.lbl_BackOffset.Location = new System.Drawing.Point(80, 50);
            this.lbl_BackOffset.Name = "lbl_BackOffset";
            this.lbl_BackOffset.Size = new System.Drawing.Size(41, 12);
            this.lbl_BackOffset.TabIndex = 2;
            this.lbl_BackOffset.Text = "偏移量";
            // 
            // lbl_BackGird
            // 
            this.lbl_BackGird.AutoSize = true;
            this.lbl_BackGird.Location = new System.Drawing.Point(92, 22);
            this.lbl_BackGird.Name = "lbl_BackGird";
            this.lbl_BackGird.Size = new System.Drawing.Size(29, 12);
            this.lbl_BackGird.TabIndex = 2;
            this.lbl_BackGird.Text = "轴网";
            // 
            // cbx_BackGird
            // 
            this.cbx_BackGird.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_BackGird.Enabled = false;
            this.cbx_BackGird.FormattingEnabled = true;
            this.cbx_BackGird.Location = new System.Drawing.Point(127, 18);
            this.cbx_BackGird.Name = "cbx_BackGird";
            this.cbx_BackGird.Size = new System.Drawing.Size(181, 20);
            this.cbx_BackGird.TabIndex = 1;
            // 
            // checkbx_Back
            // 
            this.checkbx_Back.AutoSize = true;
            this.checkbx_Back.Location = new System.Drawing.Point(6, 22);
            this.checkbx_Back.Name = "checkbx_Back";
            this.checkbx_Back.Size = new System.Drawing.Size(48, 16);
            this.checkbx_Back.TabIndex = 0;
            this.checkbx_Back.Text = "修改";
            this.checkbx_Back.UseVisualStyleBackColor = true;
            this.checkbx_Back.CheckedChanged += new System.EventHandler(this.checkbx_Back_CheckedChanged);
            // 
            // gbx_Left
            // 
            this.gbx_Left.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Left.Controls.Add(this.tbx_LeftOffset);
            this.gbx_Left.Controls.Add(this.lbl_LeftOffset);
            this.gbx_Left.Controls.Add(this.lbl_LeftGird);
            this.gbx_Left.Controls.Add(this.cbx_LeftGird);
            this.gbx_Left.Controls.Add(this.checkbx_Left);
            this.gbx_Left.Location = new System.Drawing.Point(12, 372);
            this.gbx_Left.Name = "gbx_Left";
            this.gbx_Left.Size = new System.Drawing.Size(325, 84);
            this.gbx_Left.TabIndex = 15;
            this.gbx_Left.TabStop = false;
            this.gbx_Left.Text = "左";
            // 
            // tbx_LeftOffset
            // 
            this.tbx_LeftOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_LeftOffset.Enabled = false;
            this.tbx_LeftOffset.Location = new System.Drawing.Point(127, 47);
            this.tbx_LeftOffset.Name = "tbx_LeftOffset";
            this.tbx_LeftOffset.Size = new System.Drawing.Size(181, 21);
            this.tbx_LeftOffset.TabIndex = 3;
            this.tbx_LeftOffset.Text = "0";
            // 
            // lbl_LeftOffset
            // 
            this.lbl_LeftOffset.AutoSize = true;
            this.lbl_LeftOffset.Location = new System.Drawing.Point(80, 50);
            this.lbl_LeftOffset.Name = "lbl_LeftOffset";
            this.lbl_LeftOffset.Size = new System.Drawing.Size(41, 12);
            this.lbl_LeftOffset.TabIndex = 2;
            this.lbl_LeftOffset.Text = "偏移量";
            // 
            // lbl_LeftGird
            // 
            this.lbl_LeftGird.AutoSize = true;
            this.lbl_LeftGird.Location = new System.Drawing.Point(92, 22);
            this.lbl_LeftGird.Name = "lbl_LeftGird";
            this.lbl_LeftGird.Size = new System.Drawing.Size(29, 12);
            this.lbl_LeftGird.TabIndex = 2;
            this.lbl_LeftGird.Text = "轴网";
            // 
            // cbx_LeftGird
            // 
            this.cbx_LeftGird.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_LeftGird.Enabled = false;
            this.cbx_LeftGird.FormattingEnabled = true;
            this.cbx_LeftGird.Location = new System.Drawing.Point(127, 18);
            this.cbx_LeftGird.Name = "cbx_LeftGird";
            this.cbx_LeftGird.Size = new System.Drawing.Size(181, 20);
            this.cbx_LeftGird.TabIndex = 1;
            // 
            // checkbx_Left
            // 
            this.checkbx_Left.AutoSize = true;
            this.checkbx_Left.Location = new System.Drawing.Point(6, 22);
            this.checkbx_Left.Name = "checkbx_Left";
            this.checkbx_Left.Size = new System.Drawing.Size(48, 16);
            this.checkbx_Left.TabIndex = 0;
            this.checkbx_Left.Text = "修改";
            this.checkbx_Left.UseVisualStyleBackColor = true;
            this.checkbx_Left.CheckedChanged += new System.EventHandler(this.checkbx_Left_CheckedChanged);
            // 
            // gbx_Right
            // 
            this.gbx_Right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Right.Controls.Add(this.tbx_RightOffset);
            this.gbx_Right.Controls.Add(this.lbl_RightOffset);
            this.gbx_Right.Controls.Add(this.lbl_RightGird);
            this.gbx_Right.Controls.Add(this.cbx_RightGird);
            this.gbx_Right.Controls.Add(this.checkbx_Right);
            this.gbx_Right.Location = new System.Drawing.Point(12, 462);
            this.gbx_Right.Name = "gbx_Right";
            this.gbx_Right.Size = new System.Drawing.Size(325, 84);
            this.gbx_Right.TabIndex = 16;
            this.gbx_Right.TabStop = false;
            this.gbx_Right.Text = "右";
            // 
            // tbx_RightOffset
            // 
            this.tbx_RightOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_RightOffset.Enabled = false;
            this.tbx_RightOffset.Location = new System.Drawing.Point(127, 47);
            this.tbx_RightOffset.Name = "tbx_RightOffset";
            this.tbx_RightOffset.Size = new System.Drawing.Size(181, 21);
            this.tbx_RightOffset.TabIndex = 3;
            this.tbx_RightOffset.Text = "0";
            // 
            // lbl_RightOffset
            // 
            this.lbl_RightOffset.AutoSize = true;
            this.lbl_RightOffset.Location = new System.Drawing.Point(80, 50);
            this.lbl_RightOffset.Name = "lbl_RightOffset";
            this.lbl_RightOffset.Size = new System.Drawing.Size(41, 12);
            this.lbl_RightOffset.TabIndex = 2;
            this.lbl_RightOffset.Text = "偏移量";
            // 
            // lbl_RightGird
            // 
            this.lbl_RightGird.AutoSize = true;
            this.lbl_RightGird.Location = new System.Drawing.Point(92, 22);
            this.lbl_RightGird.Name = "lbl_RightGird";
            this.lbl_RightGird.Size = new System.Drawing.Size(29, 12);
            this.lbl_RightGird.TabIndex = 2;
            this.lbl_RightGird.Text = "轴网";
            // 
            // cbx_RightGird
            // 
            this.cbx_RightGird.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_RightGird.Enabled = false;
            this.cbx_RightGird.FormattingEnabled = true;
            this.cbx_RightGird.Location = new System.Drawing.Point(127, 18);
            this.cbx_RightGird.Name = "cbx_RightGird";
            this.cbx_RightGird.Size = new System.Drawing.Size(181, 20);
            this.cbx_RightGird.TabIndex = 1;
            // 
            // checkbx_Right
            // 
            this.checkbx_Right.AutoSize = true;
            this.checkbx_Right.Location = new System.Drawing.Point(6, 22);
            this.checkbx_Right.Name = "checkbx_Right";
            this.checkbx_Right.Size = new System.Drawing.Size(48, 16);
            this.checkbx_Right.TabIndex = 0;
            this.checkbx_Right.Text = "修改";
            this.checkbx_Right.UseVisualStyleBackColor = true;
            this.checkbx_Right.CheckedChanged += new System.EventHandler(this.checkbx_Right_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 552);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 124);
            this.panel2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "后（北）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "前（南）";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(71, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 60);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "右（东）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "左（西）";
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(263, 611);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 18;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(262, 650);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 19;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 690);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbx_Right);
            this.Controls.Add(this.gbx_Left);
            this.Controls.Add(this.gbx_Back);
            this.Controls.Add(this.gbx_Front);
            this.Controls.Add(this.gbx_Bottom);
            this.Controls.Add(this.gbx_Top);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "剖面框设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.gbx_Top.ResumeLayout(false);
            this.gbx_Top.PerformLayout();
            this.gbx_Bottom.ResumeLayout(false);
            this.gbx_Bottom.PerformLayout();
            this.gbx_Front.ResumeLayout(false);
            this.gbx_Front.PerformLayout();
            this.gbx_Back.ResumeLayout(false);
            this.gbx_Back.PerformLayout();
            this.gbx_Left.ResumeLayout(false);
            this.gbx_Left.PerformLayout();
            this.gbx_Right.ResumeLayout(false);
            this.gbx_Right.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_Top;
        private System.Windows.Forms.TextBox tbx_TopOffset;
        private System.Windows.Forms.Label lbl_TopOffset;
        private System.Windows.Forms.Label lbl_TopLevel;
        private System.Windows.Forms.ComboBox cbx_TopLevel;
        private System.Windows.Forms.CheckBox checkbx_Top;
        private System.Windows.Forms.GroupBox gbx_Bottom;
        private System.Windows.Forms.TextBox tbx_BottomOffset;
        private System.Windows.Forms.Label lbl_BottomOffset;
        private System.Windows.Forms.Label lbl_BottomLevel;
        private System.Windows.Forms.ComboBox cbx_BottomLevel;
        private System.Windows.Forms.CheckBox checkbx_Bottom;
        private System.Windows.Forms.GroupBox gbx_Front;
        private System.Windows.Forms.TextBox tbx_FrontOffset;
        private System.Windows.Forms.Label lbl_FrontOffset;
        private System.Windows.Forms.Label lbl_FrontGird;
        private System.Windows.Forms.ComboBox cbx_FrontGird;
        private System.Windows.Forms.CheckBox checkbx_Front;
        private System.Windows.Forms.GroupBox gbx_Back;
        private System.Windows.Forms.TextBox tbx_BackOffset;
        private System.Windows.Forms.Label lbl_BackOffset;
        private System.Windows.Forms.Label lbl_BackGird;
        private System.Windows.Forms.ComboBox cbx_BackGird;
        private System.Windows.Forms.CheckBox checkbx_Back;
        private System.Windows.Forms.GroupBox gbx_Left;
        private System.Windows.Forms.TextBox tbx_LeftOffset;
        private System.Windows.Forms.Label lbl_LeftOffset;
        private System.Windows.Forms.Label lbl_LeftGird;
        private System.Windows.Forms.ComboBox cbx_LeftGird;
        private System.Windows.Forms.CheckBox checkbx_Left;
        private System.Windows.Forms.GroupBox gbx_Right;
        private System.Windows.Forms.TextBox tbx_RightOffset;
        private System.Windows.Forms.Label lbl_RightOffset;
        private System.Windows.Forms.Label lbl_RightGird;
        private System.Windows.Forms.ComboBox cbx_RightGird;
        private System.Windows.Forms.CheckBox checkbx_Right;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}