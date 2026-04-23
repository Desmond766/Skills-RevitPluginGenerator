namespace MEP_OffsetPro
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
            this.gbx_Type = new System.Windows.Forms.GroupBox();
            this.rbtn_TwoSide = new System.Windows.Forms.RadioButton();
            this.rbtn_OneSide = new System.Windows.Forms.RadioButton();
            this.gbx_Dis = new System.Windows.Forms.GroupBox();
            this.cbx_Dis = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_Dia = new System.Windows.Forms.ComboBox();
            this.gbx_Type.SuspendLayout();
            this.gbx_Dis.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_Type
            // 
            this.gbx_Type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Type.Controls.Add(this.rbtn_TwoSide);
            this.gbx_Type.Controls.Add(this.rbtn_OneSide);
            this.gbx_Type.Location = new System.Drawing.Point(12, 12);
            this.gbx_Type.Name = "gbx_Type";
            this.gbx_Type.Size = new System.Drawing.Size(248, 53);
            this.gbx_Type.TabIndex = 4;
            this.gbx_Type.TabStop = false;
            this.gbx_Type.Text = "类型";
            // 
            // rbtn_TwoSide
            // 
            this.rbtn_TwoSide.AutoSize = true;
            this.rbtn_TwoSide.Checked = true;
            this.rbtn_TwoSide.Location = new System.Drawing.Point(140, 21);
            this.rbtn_TwoSide.Name = "rbtn_TwoSide";
            this.rbtn_TwoSide.Size = new System.Drawing.Size(47, 16);
            this.rbtn_TwoSide.TabIndex = 0;
            this.rbtn_TwoSide.TabStop = true;
            this.rbtn_TwoSide.Text = "双侧";
            this.rbtn_TwoSide.UseVisualStyleBackColor = true;
            // 
            // rbtn_OneSide
            // 
            this.rbtn_OneSide.AutoSize = true;
            this.rbtn_OneSide.Location = new System.Drawing.Point(7, 21);
            this.rbtn_OneSide.Name = "rbtn_OneSide";
            this.rbtn_OneSide.Size = new System.Drawing.Size(47, 16);
            this.rbtn_OneSide.TabIndex = 0;
            this.rbtn_OneSide.Text = "单侧";
            this.rbtn_OneSide.UseVisualStyleBackColor = true;
            // 
            // gbx_Dis
            // 
            this.gbx_Dis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Dis.Controls.Add(this.cbx_Dis);
            this.gbx_Dis.Location = new System.Drawing.Point(12, 71);
            this.gbx_Dis.Name = "gbx_Dis";
            this.gbx_Dis.Size = new System.Drawing.Size(113, 53);
            this.gbx_Dis.TabIndex = 6;
            this.gbx_Dis.TabStop = false;
            this.gbx_Dis.Text = "升降距离";
            // 
            // cbx_Dis
            // 
            this.cbx_Dis.FormattingEnabled = true;
            this.cbx_Dis.Location = new System.Drawing.Point(7, 21);
            this.cbx_Dis.Name = "cbx_Dis";
            this.cbx_Dis.Size = new System.Drawing.Size(96, 20);
            this.cbx_Dis.TabIndex = 0;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(28, 144);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(152, 144);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbx_Dia);
            this.groupBox1.Location = new System.Drawing.Point(141, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 53);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "立管管径";
            // 
            // cbx_Dia
            // 
            this.cbx_Dia.FormattingEnabled = true;
            this.cbx_Dia.Location = new System.Drawing.Point(7, 21);
            this.cbx_Dia.Name = "cbx_Dia";
            this.cbx_Dia.Size = new System.Drawing.Size(104, 20);
            this.cbx_Dia.TabIndex = 0;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 179);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbx_Dis);
            this.Controls.Add(this.gbx_Type);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "喷淋支管爬升";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.gbx_Type.ResumeLayout(false);
            this.gbx_Type.PerformLayout();
            this.gbx_Dis.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_Type;
        private System.Windows.Forms.RadioButton rbtn_TwoSide;
        private System.Windows.Forms.RadioButton rbtn_OneSide;
        private System.Windows.Forms.GroupBox gbx_Dis;
        private System.Windows.Forms.ComboBox cbx_Dis;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbx_Dia;
    }
}