namespace MEP_3DViewCreater
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clbx_viewName = new System.Windows.Forms.CheckedListBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_AllSelect = new System.Windows.Forms.Button();
            this.btn_AllCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "名称。";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(34, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "请选择要生成局部三维的剖面视图";
            // 
            // clbx_viewName
            // 
            this.clbx_viewName.FormattingEnabled = true;
            this.clbx_viewName.Location = new System.Drawing.Point(8, 67);
            this.clbx_viewName.Name = "clbx_viewName";
            this.clbx_viewName.Size = new System.Drawing.Size(209, 308);
            this.clbx_viewName.TabIndex = 25;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(12, 420);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(78, 23);
            this.btn_OK.TabIndex = 26;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(139, 420);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(78, 23);
            this.btn_Cancel.TabIndex = 27;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_AllSelect
            // 
            this.btn_AllSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_AllSelect.Location = new System.Drawing.Point(12, 387);
            this.btn_AllSelect.Name = "btn_AllSelect";
            this.btn_AllSelect.Size = new System.Drawing.Size(78, 23);
            this.btn_AllSelect.TabIndex = 28;
            this.btn_AllSelect.Text = "选择全部";
            this.btn_AllSelect.UseVisualStyleBackColor = true;
            this.btn_AllSelect.Click += new System.EventHandler(this.btn_AllSelect_Click);
            // 
            // btn_AllCancel
            // 
            this.btn_AllCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_AllCancel.Location = new System.Drawing.Point(139, 387);
            this.btn_AllCancel.Name = "btn_AllCancel";
            this.btn_AllCancel.Size = new System.Drawing.Size(78, 23);
            this.btn_AllCancel.TabIndex = 29;
            this.btn_AllCancel.Text = "放弃全部";
            this.btn_AllCancel.UseVisualStyleBackColor = true;
            this.btn_AllCancel.Click += new System.EventHandler(this.btn_AllCancel_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 455);
            this.Controls.Add(this.btn_AllCancel);
            this.Controls.Add(this.btn_AllSelect);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.clbx_viewName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "勾选视图名称";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox clbx_viewName;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_AllSelect;
        private System.Windows.Forms.Button btn_AllCancel;
    }
}