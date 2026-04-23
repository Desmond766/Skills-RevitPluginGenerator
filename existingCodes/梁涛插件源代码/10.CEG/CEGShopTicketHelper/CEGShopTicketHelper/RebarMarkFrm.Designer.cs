namespace CEGShopTicketHelper
{
    partial class RebarMarkFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_Selected = new System.Windows.Forms.RadioButton();
            this.rbtn_ActiveView = new System.Windows.Forms.RadioButton();
            this.rbtn_Document = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtn_CM = new System.Windows.Forms.RadioButton();
            this.rbtn_IDC = new System.Windows.Forms.RadioButton();
            this.rbtn_Comments = new System.Windows.Forms.RadioButton();
            this.rbtn_Others = new System.Windows.Forms.RadioButton();
            this.tbx_CustomParam = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtn_BarDia = new System.Windows.Forms.RadioButton();
            this.rbtn_CustomPre = new System.Windows.Forms.RadioButton();
            this.tbx_CustomPre = new System.Windows.Forms.TextBox();
            this.rbtn_NonePre = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtn_Document);
            this.groupBox1.Controls.Add(this.rbtn_ActiveView);
            this.groupBox1.Controls.Add(this.rbtn_Selected);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scope";
            // 
            // rbtn_Selected
            // 
            this.rbtn_Selected.AutoSize = true;
            this.rbtn_Selected.Checked = true;
            this.rbtn_Selected.Location = new System.Drawing.Point(16, 20);
            this.rbtn_Selected.Name = "rbtn_Selected";
            this.rbtn_Selected.Size = new System.Drawing.Size(71, 16);
            this.rbtn_Selected.TabIndex = 0;
            this.rbtn_Selected.TabStop = true;
            this.rbtn_Selected.Text = "selected";
            this.rbtn_Selected.UseVisualStyleBackColor = true;
            // 
            // rbtn_ActiveView
            // 
            this.rbtn_ActiveView.AutoSize = true;
            this.rbtn_ActiveView.Location = new System.Drawing.Point(16, 42);
            this.rbtn_ActiveView.Name = "rbtn_ActiveView";
            this.rbtn_ActiveView.Size = new System.Drawing.Size(107, 16);
            this.rbtn_ActiveView.TabIndex = 1;
            this.rbtn_ActiveView.Text = "In active view";
            this.rbtn_ActiveView.UseVisualStyleBackColor = true;
            // 
            // rbtn_Document
            // 
            this.rbtn_Document.AutoSize = true;
            this.rbtn_Document.Location = new System.Drawing.Point(16, 64);
            this.rbtn_Document.Name = "rbtn_Document";
            this.rbtn_Document.Size = new System.Drawing.Size(89, 16);
            this.rbtn_Document.TabIndex = 2;
            this.rbtn_Document.Text = "In document";
            this.rbtn_Document.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbx_CustomParam);
            this.groupBox2.Controls.Add(this.rbtn_Others);
            this.groupBox2.Controls.Add(this.rbtn_Comments);
            this.groupBox2.Controls.Add(this.rbtn_IDC);
            this.groupBox2.Controls.Add(this.rbtn_CM);
            this.groupBox2.Location = new System.Drawing.Point(12, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 115);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RebarMarkParam";
            // 
            // rbtn_CM
            // 
            this.rbtn_CM.AutoSize = true;
            this.rbtn_CM.Location = new System.Drawing.Point(16, 20);
            this.rbtn_CM.Name = "rbtn_CM";
            this.rbtn_CM.Size = new System.Drawing.Size(95, 16);
            this.rbtn_CM.TabIndex = 0;
            this.rbtn_CM.Text = "CONTROL_MARK";
            this.rbtn_CM.UseVisualStyleBackColor = true;
            // 
            // rbtn_IDC
            // 
            this.rbtn_IDC.AutoSize = true;
            this.rbtn_IDC.Location = new System.Drawing.Point(16, 42);
            this.rbtn_IDC.Name = "rbtn_IDC";
            this.rbtn_IDC.Size = new System.Drawing.Size(119, 16);
            this.rbtn_IDC.TabIndex = 1;
            this.rbtn_IDC.Text = "IDENTITY_COMMENT";
            this.rbtn_IDC.UseVisualStyleBackColor = true;
            // 
            // rbtn_Comments
            // 
            this.rbtn_Comments.AutoSize = true;
            this.rbtn_Comments.Checked = true;
            this.rbtn_Comments.Location = new System.Drawing.Point(16, 64);
            this.rbtn_Comments.Name = "rbtn_Comments";
            this.rbtn_Comments.Size = new System.Drawing.Size(71, 16);
            this.rbtn_Comments.TabIndex = 2;
            this.rbtn_Comments.TabStop = true;
            this.rbtn_Comments.Text = "Comments";
            this.rbtn_Comments.UseVisualStyleBackColor = true;
            // 
            // rbtn_Others
            // 
            this.rbtn_Others.AutoSize = true;
            this.rbtn_Others.Location = new System.Drawing.Point(16, 86);
            this.rbtn_Others.Name = "rbtn_Others";
            this.rbtn_Others.Size = new System.Drawing.Size(53, 16);
            this.rbtn_Others.TabIndex = 3;
            this.rbtn_Others.Text = "Other";
            this.rbtn_Others.UseVisualStyleBackColor = true;
            // 
            // tbx_CustomParam
            // 
            this.tbx_CustomParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_CustomParam.Location = new System.Drawing.Point(75, 85);
            this.tbx_CustomParam.Name = "tbx_CustomParam";
            this.tbx_CustomParam.Size = new System.Drawing.Size(147, 21);
            this.tbx_CustomParam.TabIndex = 4;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 336);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(239, 71);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "Tips: this tool will read the DIM_LENGTH of rebar, and write it to selected param" +
    "eter by text.";
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(95, 413);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(176, 413);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbx_CustomPre);
            this.groupBox3.Controls.Add(this.rbtn_CustomPre);
            this.groupBox3.Controls.Add(this.rbtn_NonePre);
            this.groupBox3.Controls.Add(this.rbtn_BarDia);
            this.groupBox3.Location = new System.Drawing.Point(12, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 98);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Prefix";
            // 
            // rbtn_BarDia
            // 
            this.rbtn_BarDia.AutoSize = true;
            this.rbtn_BarDia.Checked = true;
            this.rbtn_BarDia.Location = new System.Drawing.Point(18, 46);
            this.rbtn_BarDia.Name = "rbtn_BarDia";
            this.rbtn_BarDia.Size = new System.Drawing.Size(89, 16);
            this.rbtn_BarDia.TabIndex = 0;
            this.rbtn_BarDia.Text = "BarDiameter";
            this.rbtn_BarDia.UseVisualStyleBackColor = true;
            // 
            // rbtn_CustomPre
            // 
            this.rbtn_CustomPre.AutoSize = true;
            this.rbtn_CustomPre.Location = new System.Drawing.Point(18, 68);
            this.rbtn_CustomPre.Name = "rbtn_CustomPre";
            this.rbtn_CustomPre.Size = new System.Drawing.Size(59, 16);
            this.rbtn_CustomPre.TabIndex = 0;
            this.rbtn_CustomPre.Text = "Custom";
            this.rbtn_CustomPre.UseVisualStyleBackColor = true;
            // 
            // tbx_CustomPre
            // 
            this.tbx_CustomPre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_CustomPre.Location = new System.Drawing.Point(83, 67);
            this.tbx_CustomPre.Name = "tbx_CustomPre";
            this.tbx_CustomPre.Size = new System.Drawing.Size(141, 21);
            this.tbx_CustomPre.TabIndex = 4;
            // 
            // rbtn_NonePre
            // 
            this.rbtn_NonePre.AutoSize = true;
            this.rbtn_NonePre.Location = new System.Drawing.Point(18, 24);
            this.rbtn_NonePre.Name = "rbtn_NonePre";
            this.rbtn_NonePre.Size = new System.Drawing.Size(47, 16);
            this.rbtn_NonePre.TabIndex = 0;
            this.rbtn_NonePre.Text = "None";
            this.rbtn_NonePre.UseVisualStyleBackColor = true;
            // 
            // RebarMarkFrm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(263, 448);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RebarMarkFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RebarMarkFrm";
            this.Load += new System.EventHandler(this.RebarMarkFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn_Document;
        private System.Windows.Forms.RadioButton rbtn_ActiveView;
        private System.Windows.Forms.RadioButton rbtn_Selected;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtn_CM;
        private System.Windows.Forms.TextBox tbx_CustomParam;
        private System.Windows.Forms.RadioButton rbtn_Others;
        private System.Windows.Forms.RadioButton rbtn_Comments;
        private System.Windows.Forms.RadioButton rbtn_IDC;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbx_CustomPre;
        private System.Windows.Forms.RadioButton rbtn_CustomPre;
        private System.Windows.Forms.RadioButton rbtn_BarDia;
        private System.Windows.Forms.RadioButton rbtn_NonePre;
    }
}