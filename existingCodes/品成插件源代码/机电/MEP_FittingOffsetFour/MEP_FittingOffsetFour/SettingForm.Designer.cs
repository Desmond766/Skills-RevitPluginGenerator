namespace MEP_FittingOffsetFour
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
            this.gbx_Angle = new System.Windows.Forms.GroupBox();
            this.rbtn_30 = new System.Windows.Forms.RadioButton();
            this.rbtn_90 = new System.Windows.Forms.RadioButton();
            this.rbtn_60 = new System.Windows.Forms.RadioButton();
            this.rbtn_45 = new System.Windows.Forms.RadioButton();
            this.rbtn_15 = new System.Windows.Forms.RadioButton();
            this.gbx_Dis = new System.Windows.Forms.GroupBox();
            this.cbx_Dis = new System.Windows.Forms.ComboBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.gbx_Angle.SuspendLayout();
            this.gbx_Dis.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_Angle
            // 
            this.gbx_Angle.Controls.Add(this.rbtn_30);
            this.gbx_Angle.Controls.Add(this.rbtn_90);
            this.gbx_Angle.Controls.Add(this.rbtn_60);
            this.gbx_Angle.Controls.Add(this.rbtn_45);
            this.gbx_Angle.Controls.Add(this.rbtn_15);
            this.gbx_Angle.Location = new System.Drawing.Point(12, 12);
            this.gbx_Angle.Name = "gbx_Angle";
            this.gbx_Angle.Size = new System.Drawing.Size(245, 53);
            this.gbx_Angle.TabIndex = 9;
            this.gbx_Angle.TabStop = false;
            this.gbx_Angle.Text = "角度";
            // 
            // rbtn_30
            // 
            this.rbtn_30.AutoSize = true;
            this.rbtn_30.Location = new System.Drawing.Point(57, 21);
            this.rbtn_30.Name = "rbtn_30";
            this.rbtn_30.Size = new System.Drawing.Size(35, 16);
            this.rbtn_30.TabIndex = 0;
            this.rbtn_30.Text = "30";
            this.rbtn_30.UseVisualStyleBackColor = true;
            // 
            // rbtn_90
            // 
            this.rbtn_90.AutoSize = true;
            this.rbtn_90.Checked = true;
            this.rbtn_90.Location = new System.Drawing.Point(207, 21);
            this.rbtn_90.Name = "rbtn_90";
            this.rbtn_90.Size = new System.Drawing.Size(35, 16);
            this.rbtn_90.TabIndex = 0;
            this.rbtn_90.TabStop = true;
            this.rbtn_90.Text = "90";
            this.rbtn_90.UseVisualStyleBackColor = true;
            // 
            // rbtn_60
            // 
            this.rbtn_60.AutoSize = true;
            this.rbtn_60.Location = new System.Drawing.Point(157, 21);
            this.rbtn_60.Name = "rbtn_60";
            this.rbtn_60.Size = new System.Drawing.Size(35, 16);
            this.rbtn_60.TabIndex = 0;
            this.rbtn_60.Text = "60";
            this.rbtn_60.UseVisualStyleBackColor = true;
            // 
            // rbtn_45
            // 
            this.rbtn_45.AutoSize = true;
            this.rbtn_45.Location = new System.Drawing.Point(107, 21);
            this.rbtn_45.Name = "rbtn_45";
            this.rbtn_45.Size = new System.Drawing.Size(35, 16);
            this.rbtn_45.TabIndex = 0;
            this.rbtn_45.Text = "45";
            this.rbtn_45.UseVisualStyleBackColor = true;
            // 
            // rbtn_15
            // 
            this.rbtn_15.AutoSize = true;
            this.rbtn_15.Location = new System.Drawing.Point(7, 21);
            this.rbtn_15.Name = "rbtn_15";
            this.rbtn_15.Size = new System.Drawing.Size(35, 16);
            this.rbtn_15.TabIndex = 0;
            this.rbtn_15.Text = "15";
            this.rbtn_15.UseVisualStyleBackColor = true;
            // 
            // gbx_Dis
            // 
            this.gbx_Dis.Controls.Add(this.cbx_Dis);
            this.gbx_Dis.Location = new System.Drawing.Point(12, 71);
            this.gbx_Dis.Name = "gbx_Dis";
            this.gbx_Dis.Size = new System.Drawing.Size(245, 53);
            this.gbx_Dis.TabIndex = 10;
            this.gbx_Dis.TabStop = false;
            this.gbx_Dis.Text = "偏移距离";
            // 
            // cbx_Dis
            // 
            this.cbx_Dis.FormattingEnabled = true;
            this.cbx_Dis.Location = new System.Drawing.Point(7, 21);
            this.cbx_Dis.Name = "cbx_Dis";
            this.cbx_Dis.Size = new System.Drawing.Size(234, 20);
            this.cbx_Dis.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(178, 132);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_OK.Location = new System.Drawing.Point(19, 132);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 167);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbx_Dis);
            this.Controls.Add(this.gbx_Angle);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "带四通升降";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.gbx_Angle.ResumeLayout(false);
            this.gbx_Angle.PerformLayout();
            this.gbx_Dis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_Angle;
        private System.Windows.Forms.RadioButton rbtn_30;
        private System.Windows.Forms.RadioButton rbtn_90;
        private System.Windows.Forms.RadioButton rbtn_60;
        private System.Windows.Forms.RadioButton rbtn_45;
        private System.Windows.Forms.RadioButton rbtn_15;
        private System.Windows.Forms.GroupBox gbx_Dis;
        private System.Windows.Forms.ComboBox cbx_Dis;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}