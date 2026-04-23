namespace MEP_VerticalPipe
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.chebx_Level2 = new System.Windows.Forms.CheckBox();
            this.chebx_Level1 = new System.Windows.Forms.CheckBox();
            this.tbx_Level2Offset = new System.Windows.Forms.TextBox();
            this.tbx_Level1Offset = new System.Windows.Forms.TextBox();
            this.tbx_Diameter = new System.Windows.Forms.TextBox();
            this.cbx_Level2 = new System.Windows.Forms.ComboBox();
            this.cbx_Level1 = new System.Windows.Forms.ComboBox();
            this.cbx_SystemType = new System.Windows.Forms.ComboBox();
            this.lbl_Level2Offset = new System.Windows.Forms.Label();
            this.cbx_PipeType = new System.Windows.Forms.ComboBox();
            this.lbl_Level1Offset = new System.Windows.Forms.Label();
            this.lbl_Diameter = new System.Windows.Forms.Label();
            this.lbl_SystemType = new System.Windows.Forms.Label();
            this.lbl_PipeType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(171, 208);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 21;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(22, 208);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 20;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // chebx_Level2
            // 
            this.chebx_Level2.AutoSize = true;
            this.chebx_Level2.Checked = true;
            this.chebx_Level2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chebx_Level2.Location = new System.Drawing.Point(22, 149);
            this.chebx_Level2.Name = "chebx_Level2";
            this.chebx_Level2.Size = new System.Drawing.Size(72, 16);
            this.chebx_Level2.TabIndex = 18;
            this.chebx_Level2.Text = "参照标高";
            this.chebx_Level2.UseVisualStyleBackColor = true;
            this.chebx_Level2.CheckedChanged += new System.EventHandler(this.Chebx_Level2_CheckedChanged);
            // 
            // chebx_Level1
            // 
            this.chebx_Level1.AutoSize = true;
            this.chebx_Level1.Checked = true;
            this.chebx_Level1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chebx_Level1.Location = new System.Drawing.Point(22, 96);
            this.chebx_Level1.Name = "chebx_Level1";
            this.chebx_Level1.Size = new System.Drawing.Size(72, 16);
            this.chebx_Level1.TabIndex = 19;
            this.chebx_Level1.Text = "参照标高";
            this.chebx_Level1.UseVisualStyleBackColor = true;
            this.chebx_Level1.CheckedChanged += new System.EventHandler(this.Chebx_Level1_CheckedChanged);
            // 
            // tbx_Level2Offset
            // 
            this.tbx_Level2Offset.Location = new System.Drawing.Point(97, 171);
            this.tbx_Level2Offset.Name = "tbx_Level2Offset";
            this.tbx_Level2Offset.Size = new System.Drawing.Size(149, 21);
            this.tbx_Level2Offset.TabIndex = 15;
            this.tbx_Level2Offset.Text = "0";
            // 
            // tbx_Level1Offset
            // 
            this.tbx_Level1Offset.Location = new System.Drawing.Point(97, 118);
            this.tbx_Level1Offset.Name = "tbx_Level1Offset";
            this.tbx_Level1Offset.Size = new System.Drawing.Size(149, 21);
            this.tbx_Level1Offset.TabIndex = 16;
            this.tbx_Level1Offset.Text = "4800";
            // 
            // tbx_Diameter
            // 
            this.tbx_Diameter.Location = new System.Drawing.Point(97, 65);
            this.tbx_Diameter.Name = "tbx_Diameter";
            this.tbx_Diameter.Size = new System.Drawing.Size(149, 21);
            this.tbx_Diameter.TabIndex = 17;
            this.tbx_Diameter.Text = "100";
            // 
            // cbx_Level2
            // 
            this.cbx_Level2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Level2.FormattingEnabled = true;
            this.cbx_Level2.Location = new System.Drawing.Point(97, 145);
            this.cbx_Level2.Name = "cbx_Level2";
            this.cbx_Level2.Size = new System.Drawing.Size(149, 20);
            this.cbx_Level2.TabIndex = 11;
            // 
            // cbx_Level1
            // 
            this.cbx_Level1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Level1.FormattingEnabled = true;
            this.cbx_Level1.Location = new System.Drawing.Point(97, 92);
            this.cbx_Level1.Name = "cbx_Level1";
            this.cbx_Level1.Size = new System.Drawing.Size(149, 20);
            this.cbx_Level1.TabIndex = 12;
            // 
            // cbx_SystemType
            // 
            this.cbx_SystemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_SystemType.FormattingEnabled = true;
            this.cbx_SystemType.Location = new System.Drawing.Point(97, 39);
            this.cbx_SystemType.Name = "cbx_SystemType";
            this.cbx_SystemType.Size = new System.Drawing.Size(149, 20);
            this.cbx_SystemType.TabIndex = 13;
            // 
            // lbl_Level2Offset
            // 
            this.lbl_Level2Offset.AutoSize = true;
            this.lbl_Level2Offset.Location = new System.Drawing.Point(20, 176);
            this.lbl_Level2Offset.Name = "lbl_Level2Offset";
            this.lbl_Level2Offset.Size = new System.Drawing.Size(77, 12);
            this.lbl_Level2Offset.TabIndex = 6;
            this.lbl_Level2Offset.Text = "相对标高(mm)";
            // 
            // cbx_PipeType
            // 
            this.cbx_PipeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_PipeType.FormattingEnabled = true;
            this.cbx_PipeType.Location = new System.Drawing.Point(97, 13);
            this.cbx_PipeType.Name = "cbx_PipeType";
            this.cbx_PipeType.Size = new System.Drawing.Size(149, 20);
            this.cbx_PipeType.TabIndex = 14;
            // 
            // lbl_Level1Offset
            // 
            this.lbl_Level1Offset.AutoSize = true;
            this.lbl_Level1Offset.Location = new System.Drawing.Point(20, 123);
            this.lbl_Level1Offset.Name = "lbl_Level1Offset";
            this.lbl_Level1Offset.Size = new System.Drawing.Size(77, 12);
            this.lbl_Level1Offset.TabIndex = 7;
            this.lbl_Level1Offset.Text = "相对标高(mm)";
            // 
            // lbl_Diameter
            // 
            this.lbl_Diameter.AutoSize = true;
            this.lbl_Diameter.Location = new System.Drawing.Point(20, 70);
            this.lbl_Diameter.Name = "lbl_Diameter";
            this.lbl_Diameter.Size = new System.Drawing.Size(77, 12);
            this.lbl_Diameter.TabIndex = 8;
            this.lbl_Diameter.Text = "公称直径(mm)";
            // 
            // lbl_SystemType
            // 
            this.lbl_SystemType.AutoSize = true;
            this.lbl_SystemType.Location = new System.Drawing.Point(38, 44);
            this.lbl_SystemType.Name = "lbl_SystemType";
            this.lbl_SystemType.Size = new System.Drawing.Size(53, 12);
            this.lbl_SystemType.TabIndex = 9;
            this.lbl_SystemType.Text = "系统类型";
            // 
            // lbl_PipeType
            // 
            this.lbl_PipeType.AutoSize = true;
            this.lbl_PipeType.Location = new System.Drawing.Point(38, 18);
            this.lbl_PipeType.Name = "lbl_PipeType";
            this.lbl_PipeType.Size = new System.Drawing.Size(53, 12);
            this.lbl_PipeType.TabIndex = 10;
            this.lbl_PipeType.Text = "管道类型";
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(266, 245);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.chebx_Level2);
            this.Controls.Add(this.chebx_Level1);
            this.Controls.Add(this.tbx_Level2Offset);
            this.Controls.Add(this.tbx_Level1Offset);
            this.Controls.Add(this.tbx_Diameter);
            this.Controls.Add(this.cbx_Level2);
            this.Controls.Add(this.cbx_Level1);
            this.Controls.Add(this.cbx_SystemType);
            this.Controls.Add(this.lbl_Level2Offset);
            this.Controls.Add(this.cbx_PipeType);
            this.Controls.Add(this.lbl_Level1Offset);
            this.Controls.Add(this.lbl_Diameter);
            this.Controls.Add(this.lbl_SystemType);
            this.Controls.Add(this.lbl_PipeType);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "立管布置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.CheckBox chebx_Level2;
        private System.Windows.Forms.CheckBox chebx_Level1;
        private System.Windows.Forms.TextBox tbx_Level2Offset;
        private System.Windows.Forms.TextBox tbx_Level1Offset;
        private System.Windows.Forms.TextBox tbx_Diameter;
        private System.Windows.Forms.ComboBox cbx_Level2;
        private System.Windows.Forms.ComboBox cbx_Level1;
        private System.Windows.Forms.ComboBox cbx_SystemType;
        private System.Windows.Forms.Label lbl_Level2Offset;
        private System.Windows.Forms.ComboBox cbx_PipeType;
        private System.Windows.Forms.Label lbl_Level1Offset;
        private System.Windows.Forms.Label lbl_Diameter;
        private System.Windows.Forms.Label lbl_SystemType;
        private System.Windows.Forms.Label lbl_PipeType;
    }
}