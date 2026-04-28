namespace MEP_TeeRotater
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
            this.gbx_Dir = new System.Windows.Forms.GroupBox();
            this.rbtn_B = new System.Windows.Forms.RadioButton();
            this.rbtn_T = new System.Windows.Forms.RadioButton();
            this.gbx_Angle = new System.Windows.Forms.GroupBox();
            this.rbtn_90 = new System.Windows.Forms.RadioButton();
            this.rbtn_30 = new System.Windows.Forms.RadioButton();
            this.rbtn_60 = new System.Windows.Forms.RadioButton();
            this.rbtn_45 = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.rbtn_0 = new System.Windows.Forms.RadioButton();
            this.rbtn_x = new System.Windows.Forms.RadioButton();
            this.cbx_Angle = new System.Windows.Forms.ComboBox();
            this.gbx_Dir.SuspendLayout();
            this.gbx_Angle.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_Dir
            // 
            this.gbx_Dir.Controls.Add(this.rbtn_B);
            this.gbx_Dir.Controls.Add(this.rbtn_T);
            this.gbx_Dir.Location = new System.Drawing.Point(12, 12);
            this.gbx_Dir.Name = "gbx_Dir";
            this.gbx_Dir.Size = new System.Drawing.Size(211, 53);
            this.gbx_Dir.TabIndex = 3;
            this.gbx_Dir.TabStop = false;
            this.gbx_Dir.Text = "方向";
            this.gbx_Dir.Enter += new System.EventHandler(this.gbx_Dir_Enter);
            // 
            // rbtn_B
            // 
            this.rbtn_B.AutoSize = true;
            this.rbtn_B.Location = new System.Drawing.Point(152, 20);
            this.rbtn_B.Name = "rbtn_B";
            this.rbtn_B.Size = new System.Drawing.Size(47, 16);
            this.rbtn_B.TabIndex = 0;
            this.rbtn_B.Text = "向下";
            this.rbtn_B.UseVisualStyleBackColor = true;
            // 
            // rbtn_T
            // 
            this.rbtn_T.AutoSize = true;
            this.rbtn_T.Checked = true;
            this.rbtn_T.Location = new System.Drawing.Point(7, 21);
            this.rbtn_T.Name = "rbtn_T";
            this.rbtn_T.Size = new System.Drawing.Size(47, 16);
            this.rbtn_T.TabIndex = 0;
            this.rbtn_T.TabStop = true;
            this.rbtn_T.Text = "向上";
            this.rbtn_T.UseVisualStyleBackColor = true;
            // 
            // gbx_Angle
            // 
            this.gbx_Angle.Controls.Add(this.cbx_Angle);
            this.gbx_Angle.Controls.Add(this.rbtn_x);
            this.gbx_Angle.Controls.Add(this.rbtn_0);
            this.gbx_Angle.Controls.Add(this.rbtn_90);
            this.gbx_Angle.Controls.Add(this.rbtn_30);
            this.gbx_Angle.Controls.Add(this.rbtn_60);
            this.gbx_Angle.Controls.Add(this.rbtn_45);
            this.gbx_Angle.Location = new System.Drawing.Point(12, 71);
            this.gbx_Angle.Name = "gbx_Angle";
            this.gbx_Angle.Size = new System.Drawing.Size(211, 86);
            this.gbx_Angle.TabIndex = 5;
            this.gbx_Angle.TabStop = false;
            this.gbx_Angle.Text = "角度";
            this.gbx_Angle.Enter += new System.EventHandler(this.gbx_Angle_Enter);
            // 
            // rbtn_90
            // 
            this.rbtn_90.AutoSize = true;
            this.rbtn_90.Location = new System.Drawing.Point(130, 20);
            this.rbtn_90.Name = "rbtn_90";
            this.rbtn_90.Size = new System.Drawing.Size(35, 16);
            this.rbtn_90.TabIndex = 1;
            this.rbtn_90.Text = "90";
            this.rbtn_90.UseVisualStyleBackColor = true;
            // 
            // rbtn_30
            // 
            this.rbtn_30.AutoSize = true;
            this.rbtn_30.Location = new System.Drawing.Point(7, 21);
            this.rbtn_30.Name = "rbtn_30";
            this.rbtn_30.Size = new System.Drawing.Size(35, 16);
            this.rbtn_30.TabIndex = 0;
            this.rbtn_30.Text = "30";
            this.rbtn_30.UseVisualStyleBackColor = true;
            // 
            // rbtn_60
            // 
            this.rbtn_60.AutoSize = true;
            this.rbtn_60.Location = new System.Drawing.Point(89, 20);
            this.rbtn_60.Name = "rbtn_60";
            this.rbtn_60.Size = new System.Drawing.Size(35, 16);
            this.rbtn_60.TabIndex = 0;
            this.rbtn_60.Text = "60";
            this.rbtn_60.UseVisualStyleBackColor = true;
            // 
            // rbtn_45
            // 
            this.rbtn_45.AutoSize = true;
            this.rbtn_45.Location = new System.Drawing.Point(48, 20);
            this.rbtn_45.Name = "rbtn_45";
            this.rbtn_45.Size = new System.Drawing.Size(35, 16);
            this.rbtn_45.TabIndex = 0;
            this.rbtn_45.Text = "45";
            this.rbtn_45.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(148, 163);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_OK.Location = new System.Drawing.Point(12, 163);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // rbtn_0
            // 
            this.rbtn_0.AutoSize = true;
            this.rbtn_0.Location = new System.Drawing.Point(170, 20);
            this.rbtn_0.Name = "rbtn_0";
            this.rbtn_0.Size = new System.Drawing.Size(29, 16);
            this.rbtn_0.TabIndex = 1;
            this.rbtn_0.Text = "0";
            this.rbtn_0.UseVisualStyleBackColor = true;
            // 
            // rbtn_x
            // 
            this.rbtn_x.AutoSize = true;
            this.rbtn_x.Location = new System.Drawing.Point(7, 55);
            this.rbtn_x.Name = "rbtn_x";
            this.rbtn_x.Size = new System.Drawing.Size(83, 16);
            this.rbtn_x.TabIndex = 1;
            this.rbtn_x.Text = "自定义角度";
            this.rbtn_x.UseVisualStyleBackColor = true;
            // 
            // cbx_Angle
            // 
            this.cbx_Angle.FormattingEnabled = true;
            this.cbx_Angle.Location = new System.Drawing.Point(96, 55);
            this.cbx_Angle.Name = "cbx_Angle";
            this.cbx_Angle.Size = new System.Drawing.Size(109, 20);
            this.cbx_Angle.TabIndex = 2;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 198);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbx_Angle);
            this.Controls.Add(this.gbx_Dir);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.gbx_Dir.ResumeLayout(false);
            this.gbx_Dir.PerformLayout();
            this.gbx_Angle.ResumeLayout(false);
            this.gbx_Angle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_Dir;
        private System.Windows.Forms.RadioButton rbtn_B;
        private System.Windows.Forms.RadioButton rbtn_T;
        private System.Windows.Forms.GroupBox gbx_Angle;
        private System.Windows.Forms.RadioButton rbtn_30;
        private System.Windows.Forms.RadioButton rbtn_60;
        private System.Windows.Forms.RadioButton rbtn_45;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.RadioButton rbtn_90;
        private System.Windows.Forms.RadioButton rbtn_0;
        private System.Windows.Forms.RadioButton rbtn_x;
        private System.Windows.Forms.ComboBox cbx_Angle;
    }
}