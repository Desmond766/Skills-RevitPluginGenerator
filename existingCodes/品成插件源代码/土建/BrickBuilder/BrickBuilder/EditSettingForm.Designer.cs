namespace BrickBuilder
{
    partial class EditSettingForm
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
            this.gbx_offsetSetting = new System.Windows.Forms.GroupBox();
            this.lbl_hOffset = new System.Windows.Forms.Label();
            this.tbx_hOffset = new System.Windows.Forms.TextBox();
            this.lbl_unit1 = new System.Windows.Forms.Label();
            this.lbl_vOffset = new System.Windows.Forms.Label();
            this.lbl_unit3 = new System.Windows.Forms.Label();
            this.tbx_vOffset = new System.Windows.Forms.TextBox();
            this.lbl_unit2 = new System.Windows.Forms.Label();
            this.lbl_unit4 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.gbx_offsetSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_offsetSetting
            // 
            this.gbx_offsetSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_offsetSetting.Controls.Add(this.tbx_vOffset);
            this.gbx_offsetSetting.Controls.Add(this.lbl_unit3);
            this.gbx_offsetSetting.Controls.Add(this.tbx_hOffset);
            this.gbx_offsetSetting.Controls.Add(this.lbl_vOffset);
            this.gbx_offsetSetting.Controls.Add(this.lbl_unit4);
            this.gbx_offsetSetting.Controls.Add(this.lbl_unit2);
            this.gbx_offsetSetting.Controls.Add(this.lbl_unit1);
            this.gbx_offsetSetting.Controls.Add(this.lbl_hOffset);
            this.gbx_offsetSetting.Location = new System.Drawing.Point(12, 12);
            this.gbx_offsetSetting.Name = "gbx_offsetSetting";
            this.gbx_offsetSetting.Size = new System.Drawing.Size(260, 86);
            this.gbx_offsetSetting.TabIndex = 0;
            this.gbx_offsetSetting.TabStop = false;
            this.gbx_offsetSetting.Text = "偏移参数";
            // 
            // lbl_hOffset
            // 
            this.lbl_hOffset.AutoSize = true;
            this.lbl_hOffset.Location = new System.Drawing.Point(6, 26);
            this.lbl_hOffset.Name = "lbl_hOffset";
            this.lbl_hOffset.Size = new System.Drawing.Size(53, 12);
            this.lbl_hOffset.TabIndex = 0;
            this.lbl_hOffset.Text = "水平偏移";
            // 
            // tbx_hOffset
            // 
            this.tbx_hOffset.Location = new System.Drawing.Point(65, 23);
            this.tbx_hOffset.Name = "tbx_hOffset";
            this.tbx_hOffset.Size = new System.Drawing.Size(100, 21);
            this.tbx_hOffset.TabIndex = 1;
            this.tbx_hOffset.Text = "0";
            // 
            // lbl_unit1
            // 
            this.lbl_unit1.AutoSize = true;
            this.lbl_unit1.Location = new System.Drawing.Point(171, 26);
            this.lbl_unit1.Name = "lbl_unit1";
            this.lbl_unit1.Size = new System.Drawing.Size(17, 12);
            this.lbl_unit1.TabIndex = 0;
            this.lbl_unit1.Text = "mm";
            // 
            // lbl_vOffset
            // 
            this.lbl_vOffset.AutoSize = true;
            this.lbl_vOffset.Location = new System.Drawing.Point(6, 53);
            this.lbl_vOffset.Name = "lbl_vOffset";
            this.lbl_vOffset.Size = new System.Drawing.Size(53, 12);
            this.lbl_vOffset.TabIndex = 0;
            this.lbl_vOffset.Text = "垂直偏移";
            // 
            // lbl_unit3
            // 
            this.lbl_unit3.AutoSize = true;
            this.lbl_unit3.Location = new System.Drawing.Point(171, 53);
            this.lbl_unit3.Name = "lbl_unit3";
            this.lbl_unit3.Size = new System.Drawing.Size(17, 12);
            this.lbl_unit3.TabIndex = 0;
            this.lbl_unit3.Text = "mm";
            // 
            // tbx_vOffset
            // 
            this.tbx_vOffset.Location = new System.Drawing.Point(65, 50);
            this.tbx_vOffset.Name = "tbx_vOffset";
            this.tbx_vOffset.Size = new System.Drawing.Size(100, 21);
            this.tbx_vOffset.TabIndex = 1;
            this.tbx_vOffset.Text = "0";
            // 
            // lbl_unit2
            // 
            this.lbl_unit2.AutoSize = true;
            this.lbl_unit2.ForeColor = System.Drawing.Color.Red;
            this.lbl_unit2.Location = new System.Drawing.Point(191, 27);
            this.lbl_unit2.Name = "lbl_unit2";
            this.lbl_unit2.Size = new System.Drawing.Size(59, 12);
            this.lbl_unit2.TabIndex = 0;
            this.lbl_unit2.Text = "*左负右正";
            // 
            // lbl_unit4
            // 
            this.lbl_unit4.AutoSize = true;
            this.lbl_unit4.ForeColor = System.Drawing.Color.Red;
            this.lbl_unit4.Location = new System.Drawing.Point(191, 53);
            this.lbl_unit4.Name = "lbl_unit4";
            this.lbl_unit4.Size = new System.Drawing.Size(59, 12);
            this.lbl_unit4.TabIndex = 0;
            this.lbl_unit4.Text = "*下负上正";
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(116, 104);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(197, 104);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // EditSettingForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(284, 136);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbx_offsetSetting);
            this.Name = "EditSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "品成排砖V1.0";
            this.Load += new System.EventHandler(this.EditSettingForm_Load);
            this.gbx_offsetSetting.ResumeLayout(false);
            this.gbx_offsetSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_offsetSetting;
        private System.Windows.Forms.TextBox tbx_vOffset;
        private System.Windows.Forms.Label lbl_unit3;
        private System.Windows.Forms.TextBox tbx_hOffset;
        private System.Windows.Forms.Label lbl_vOffset;
        private System.Windows.Forms.Label lbl_unit4;
        private System.Windows.Forms.Label lbl_unit2;
        private System.Windows.Forms.Label lbl_unit1;
        private System.Windows.Forms.Label lbl_hOffset;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}