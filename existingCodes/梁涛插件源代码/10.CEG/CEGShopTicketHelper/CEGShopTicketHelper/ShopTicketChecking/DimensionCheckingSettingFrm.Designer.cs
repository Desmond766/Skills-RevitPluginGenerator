namespace CEGShopTicketHelper.ShopTicketChecking
{
    partial class DimensionCheckingSettingFrm
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbx_TitleContain = new System.Windows.Forms.TextBox();
            this.rbtn_CheckActive = new System.Windows.Forms.RadioButton();
            this.rbtn_CheckTitleContain = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(227, 183);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(112, 34);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(348, 183);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(112, 34);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbx_TitleContain);
            this.groupBox2.Controls.Add(this.rbtn_CheckActive);
            this.groupBox2.Controls.Add(this.rbtn_CheckTitleContain);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(447, 150);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ExprotSetting";
            // 
            // tbx_TitleContain
            // 
            this.tbx_TitleContain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_TitleContain.Location = new System.Drawing.Point(33, 99);
            this.tbx_TitleContain.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_TitleContain.Name = "tbx_TitleContain";
            this.tbx_TitleContain.Size = new System.Drawing.Size(390, 28);
            this.tbx_TitleContain.TabIndex = 11;
            this.tbx_TitleContain.Text = "TOP VIEW IN FORM";
            // 
            // rbtn_CheckActive
            // 
            this.rbtn_CheckActive.AutoSize = true;
            this.rbtn_CheckActive.Location = new System.Drawing.Point(9, 33);
            this.rbtn_CheckActive.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn_CheckActive.Name = "rbtn_CheckActive";
            this.rbtn_CheckActive.Size = new System.Drawing.Size(312, 22);
            this.rbtn_CheckActive.TabIndex = 8;
            this.rbtn_CheckActive.Text = "Check All Views In Active Sheet";
            this.rbtn_CheckActive.UseVisualStyleBackColor = true;
            // 
            // rbtn_CheckTitleContain
            // 
            this.rbtn_CheckTitleContain.AutoSize = true;
            this.rbtn_CheckTitleContain.Checked = true;
            this.rbtn_CheckTitleContain.Location = new System.Drawing.Point(9, 66);
            this.rbtn_CheckTitleContain.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn_CheckTitleContain.Name = "rbtn_CheckTitleContain";
            this.rbtn_CheckTitleContain.Size = new System.Drawing.Size(285, 22);
            this.rbtn_CheckTitleContain.TabIndex = 9;
            this.rbtn_CheckTitleContain.TabStop = true;
            this.rbtn_CheckTitleContain.Text = "Check All View Title Contain";
            this.rbtn_CheckTitleContain.UseVisualStyleBackColor = true;
            // 
            // DimensionCheckingSettingFrm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(482, 230);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.groupBox2);
            this.Name = "DimensionCheckingSettingFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DimensionCheckingSettingFrm";
            this.Load += new System.EventHandler(this.DimensionCheckingSettingFrm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbx_TitleContain;
        private System.Windows.Forms.RadioButton rbtn_CheckActive;
        private System.Windows.Forms.RadioButton rbtn_CheckTitleContain;
    }
}