namespace CEGShopTicketHelper
{
    partial class AdjustCtrlMarkFrm
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
            this.cbx_Param = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_BeginMark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_EndMark = new System.Windows.Forms.TextBox();
            this.cbx_Operation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_Integer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parameter:";
            // 
            // cbx_Param
            // 
            this.cbx_Param.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_Param.FormattingEnabled = true;
            this.cbx_Param.Items.AddRange(new object[] {
            "CONTROL_MARK",
            "CONTROL_NUMBER"});
            this.cbx_Param.Location = new System.Drawing.Point(96, 16);
            this.cbx_Param.Name = "cbx_Param";
            this.cbx_Param.Size = new System.Drawing.Size(121, 20);
            this.cbx_Param.TabIndex = 2;
            this.cbx_Param.Text = "CONTROL_MARK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Begin With:";
            // 
            // tbx_BeginMark
            // 
            this.tbx_BeginMark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_BeginMark.Location = new System.Drawing.Point(96, 42);
            this.tbx_BeginMark.Name = "tbx_BeginMark";
            this.tbx_BeginMark.Size = new System.Drawing.Size(121, 21);
            this.tbx_BeginMark.TabIndex = 4;
            this.tbx_BeginMark.Text = "T-1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "End With:";
            // 
            // tbx_EndMark
            // 
            this.tbx_EndMark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_EndMark.Location = new System.Drawing.Point(96, 69);
            this.tbx_EndMark.Name = "tbx_EndMark";
            this.tbx_EndMark.Size = new System.Drawing.Size(121, 21);
            this.tbx_EndMark.TabIndex = 5;
            this.tbx_EndMark.Text = "T-100";
            // 
            // cbx_Operation
            // 
            this.cbx_Operation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_Operation.FormattingEnabled = true;
            this.cbx_Operation.Items.AddRange(new object[] {
            "+",
            "-"});
            this.cbx_Operation.Location = new System.Drawing.Point(96, 96);
            this.cbx_Operation.Name = "cbx_Operation";
            this.cbx_Operation.Size = new System.Drawing.Size(121, 20);
            this.cbx_Operation.TabIndex = 7;
            this.cbx_Operation.Text = "+";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Operation:";
            // 
            // tbx_Integer
            // 
            this.tbx_Integer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Integer.Location = new System.Drawing.Point(96, 122);
            this.tbx_Integer.Name = "tbx_Integer";
            this.tbx_Integer.Size = new System.Drawing.Size(121, 21);
            this.tbx_Integer.TabIndex = 8;
            this.tbx_Integer.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Integer:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(142, 195);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(61, 195);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 10;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 29);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tip: Control mark with suffix is not supprot. (i.e. T-9A)";
            // 
            // AdjustCtrlMarkFrm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(238, 230);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.tbx_Integer);
            this.Controls.Add(this.cbx_Operation);
            this.Controls.Add(this.tbx_EndMark);
            this.Controls.Add(this.tbx_BeginMark);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_Param);
            this.Controls.Add(this.label1);
            this.Name = "AdjustCtrlMarkFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adjust Mark/No.";
            this.Load += new System.EventHandler(this.AdjustCtrlMarkFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Param;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_BeginMark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_EndMark;
        private System.Windows.Forms.ComboBox cbx_Operation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_Integer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label6;
    }
}