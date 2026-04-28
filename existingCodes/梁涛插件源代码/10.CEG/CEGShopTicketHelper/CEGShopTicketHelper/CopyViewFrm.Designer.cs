namespace CEGShopTicketHelper
{
    partial class CopyViewFrm
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
            this.rbtn_90negative = new System.Windows.Forms.RadioButton();
            this.rbtn_90 = new System.Windows.Forms.RadioButton();
            this.rbtn_NoRotation = new System.Windows.Forms.RadioButton();
            this.cbx_CopyDimensions = new System.Windows.Forms.CheckBox();
            this.cbx_CopyTags = new System.Windows.Forms.CheckBox();
            this.cbx_CopyAnnotations = new System.Windows.Forms.CheckBox();
            this.gbx_Assembly = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_CurrentAssembly = new System.Windows.Forms.TextBox();
            this.tbx_CurrentView = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(283, 468);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(363, 468);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbtn_90negative);
            this.groupBox2.Controls.Add(this.rbtn_90);
            this.groupBox2.Controls.Add(this.rbtn_NoRotation);
            this.groupBox2.Controls.Add(this.cbx_CopyDimensions);
            this.groupBox2.Controls.Add(this.cbx_CopyTags);
            this.groupBox2.Controls.Add(this.cbx_CopyAnnotations);
            this.groupBox2.Location = new System.Drawing.Point(11, 368);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(425, 89);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CopyContent";
            // 
            // rbtn_90negative
            // 
            this.rbtn_90negative.AutoSize = true;
            this.rbtn_90negative.Location = new System.Drawing.Point(270, 24);
            this.rbtn_90negative.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtn_90negative.Name = "rbtn_90negative";
            this.rbtn_90negative.Size = new System.Drawing.Size(41, 16);
            this.rbtn_90negative.TabIndex = 5;
            this.rbtn_90negative.Text = "-90";
            this.rbtn_90negative.UseVisualStyleBackColor = true;
            // 
            // rbtn_90
            // 
            this.rbtn_90.AutoSize = true;
            this.rbtn_90.Location = new System.Drawing.Point(232, 24);
            this.rbtn_90.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtn_90.Name = "rbtn_90";
            this.rbtn_90.Size = new System.Drawing.Size(35, 16);
            this.rbtn_90.TabIndex = 4;
            this.rbtn_90.Text = "90";
            this.rbtn_90.UseVisualStyleBackColor = true;
            // 
            // rbtn_NoRotation
            // 
            this.rbtn_NoRotation.AutoSize = true;
            this.rbtn_NoRotation.Checked = true;
            this.rbtn_NoRotation.Location = new System.Drawing.Point(140, 24);
            this.rbtn_NoRotation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtn_NoRotation.Name = "rbtn_NoRotation";
            this.rbtn_NoRotation.Size = new System.Drawing.Size(89, 16);
            this.rbtn_NoRotation.TabIndex = 3;
            this.rbtn_NoRotation.TabStop = true;
            this.rbtn_NoRotation.Text = "no rotation";
            this.rbtn_NoRotation.UseVisualStyleBackColor = true;
            // 
            // cbx_CopyDimensions
            // 
            this.cbx_CopyDimensions.AutoSize = true;
            this.cbx_CopyDimensions.Checked = true;
            this.cbx_CopyDimensions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_CopyDimensions.Location = new System.Drawing.Point(16, 62);
            this.cbx_CopyDimensions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbx_CopyDimensions.Name = "cbx_CopyDimensions";
            this.cbx_CopyDimensions.Size = new System.Drawing.Size(84, 16);
            this.cbx_CopyDimensions.TabIndex = 2;
            this.cbx_CopyDimensions.Text = "Dimensions";
            this.cbx_CopyDimensions.UseVisualStyleBackColor = true;
            // 
            // cbx_CopyTags
            // 
            this.cbx_CopyTags.AutoSize = true;
            this.cbx_CopyTags.Checked = true;
            this.cbx_CopyTags.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_CopyTags.Location = new System.Drawing.Point(16, 43);
            this.cbx_CopyTags.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbx_CopyTags.Name = "cbx_CopyTags";
            this.cbx_CopyTags.Size = new System.Drawing.Size(48, 16);
            this.cbx_CopyTags.TabIndex = 1;
            this.cbx_CopyTags.Text = "Tags";
            this.cbx_CopyTags.UseVisualStyleBackColor = true;
            // 
            // cbx_CopyAnnotations
            // 
            this.cbx_CopyAnnotations.AutoSize = true;
            this.cbx_CopyAnnotations.Checked = true;
            this.cbx_CopyAnnotations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_CopyAnnotations.Location = new System.Drawing.Point(16, 25);
            this.cbx_CopyAnnotations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbx_CopyAnnotations.Name = "cbx_CopyAnnotations";
            this.cbx_CopyAnnotations.Size = new System.Drawing.Size(120, 16);
            this.cbx_CopyAnnotations.TabIndex = 0;
            this.cbx_CopyAnnotations.Text = "Annotation Items";
            this.cbx_CopyAnnotations.UseVisualStyleBackColor = true;
            // 
            // gbx_Assembly
            // 
            this.gbx_Assembly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Assembly.Location = new System.Drawing.Point(11, 97);
            this.gbx_Assembly.Name = "gbx_Assembly";
            this.gbx_Assembly.Size = new System.Drawing.Size(425, 266);
            this.gbx_Assembly.TabIndex = 6;
            this.gbx_Assembly.TabStop = false;
            this.gbx_Assembly.Text = "gbx_Assembly";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "ViewName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "AssemblyName";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbx_CurrentView);
            this.groupBox1.Controls.Add(this.tbx_CurrentAssembly);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(425, 81);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current/Source";
            // 
            // tbx_CurrentAssembly
            // 
            this.tbx_CurrentAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_CurrentAssembly.Enabled = false;
            this.tbx_CurrentAssembly.Location = new System.Drawing.Point(97, 22);
            this.tbx_CurrentAssembly.Name = "tbx_CurrentAssembly";
            this.tbx_CurrentAssembly.Size = new System.Drawing.Size(310, 21);
            this.tbx_CurrentAssembly.TabIndex = 1;
            // 
            // tbx_CurrentView
            // 
            this.tbx_CurrentView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_CurrentView.Enabled = false;
            this.tbx_CurrentView.Location = new System.Drawing.Point(97, 47);
            this.tbx_CurrentView.Name = "tbx_CurrentView";
            this.tbx_CurrentView.Size = new System.Drawing.Size(310, 21);
            this.tbx_CurrentView.TabIndex = 1;
            // 
            // CopyViewFrm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(447, 499);
            this.Controls.Add(this.gbx_Assembly);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Name = "CopyViewFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CEG-China CopyViews";
            this.Load += new System.EventHandler(this.CopyTicketFrm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbx_CopyAnnotations;
        private System.Windows.Forms.CheckBox cbx_CopyDimensions;
        private System.Windows.Forms.CheckBox cbx_CopyTags;
        private System.Windows.Forms.RadioButton rbtn_90negative;
        private System.Windows.Forms.RadioButton rbtn_90;
        private System.Windows.Forms.RadioButton rbtn_NoRotation;
        private System.Windows.Forms.GroupBox gbx_Assembly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_CurrentView;
        private System.Windows.Forms.TextBox tbx_CurrentAssembly;
    }
}