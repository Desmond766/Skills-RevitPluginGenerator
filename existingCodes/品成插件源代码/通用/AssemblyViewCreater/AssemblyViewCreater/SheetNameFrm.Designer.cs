namespace AssemblyViewCreater
{
    partial class SheetNameFrm
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
            this.cbx_Name = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_No = new System.Windows.Forms.ComboBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_space = new System.Windows.Forms.ComboBox();
            this.cbx_Number = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_Numspace = new System.Windows.Forms.ComboBox();
            this.cbx_NumText = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sheet Name";
            // 
            // cbx_Name
            // 
            this.cbx_Name.FormattingEnabled = true;
            this.cbx_Name.Location = new System.Drawing.Point(12, 24);
            this.cbx_Name.Name = "cbx_Name";
            this.cbx_Name.Size = new System.Drawing.Size(333, 20);
            this.cbx_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Number";
            // 
            // cbx_No
            // 
            this.cbx_No.FormattingEnabled = true;
            this.cbx_No.Location = new System.Drawing.Point(351, 24);
            this.cbx_No.Name = "cbx_No";
            this.cbx_No.Size = new System.Drawing.Size(75, 20);
            this.cbx_No.TabIndex = 3;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(352, 110);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(270, 110);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "图纸名称中的编号递增间隔";
            // 
            // cbx_space
            // 
            this.cbx_space.FormattingEnabled = true;
            this.cbx_space.Location = new System.Drawing.Point(351, 50);
            this.cbx_space.Name = "cbx_space";
            this.cbx_space.Size = new System.Drawing.Size(75, 20);
            this.cbx_space.TabIndex = 10;
            // 
            // cbx_Number
            // 
            this.cbx_Number.FormattingEnabled = true;
            this.cbx_Number.Location = new System.Drawing.Point(123, 76);
            this.cbx_Number.Name = "cbx_Number";
            this.cbx_Number.Size = new System.Drawing.Size(115, 20);
            this.cbx_Number.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sheet Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "图纸编号递增间隔";
            // 
            // cbx_Numspace
            // 
            this.cbx_Numspace.FormattingEnabled = true;
            this.cbx_Numspace.Location = new System.Drawing.Point(351, 76);
            this.cbx_Numspace.Name = "cbx_Numspace";
            this.cbx_Numspace.Size = new System.Drawing.Size(75, 20);
            this.cbx_Numspace.TabIndex = 13;
            // 
            // cbx_NumText
            // 
            this.cbx_NumText.FormattingEnabled = true;
            this.cbx_NumText.Location = new System.Drawing.Point(12, 76);
            this.cbx_NumText.Name = "cbx_NumText";
            this.cbx_NumText.Size = new System.Drawing.Size(105, 20);
            this.cbx_NumText.TabIndex = 14;
            // 
            // SheetNameFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 141);
            this.Controls.Add(this.cbx_NumText);
            this.Controls.Add(this.cbx_Numspace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbx_Number);
            this.Controls.Add(this.cbx_space);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.cbx_No);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_Name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "SheetNameFrm";
            this.Text = "SheetNameFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_No;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_space;
        private System.Windows.Forms.ComboBox cbx_Number;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_Numspace;
        private System.Windows.Forms.ComboBox cbx_NumText;
    }
}