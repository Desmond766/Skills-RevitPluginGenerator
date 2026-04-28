namespace CEGRegister
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_LicenseType = new System.Windows.Forms.Label();
            this.lbl_TrailDays = new System.Windows.Forms.Label();
            this.tbx_ComputerID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_Tips = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "计算机ID：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "注册类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "试用天数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 3;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbl_LicenseType
            // 
            this.lbl_LicenseType.AutoSize = true;
            this.lbl_LicenseType.Location = new System.Drawing.Point(122, 93);
            this.lbl_LicenseType.Name = "lbl_LicenseType";
            this.lbl_LicenseType.Size = new System.Drawing.Size(11, 12);
            this.lbl_LicenseType.TabIndex = 4;
            this.lbl_LicenseType.Text = "-";
            this.lbl_LicenseType.Click += new System.EventHandler(this.label5_Click);
            // 
            // lbl_TrailDays
            // 
            this.lbl_TrailDays.AutoSize = true;
            this.lbl_TrailDays.Location = new System.Drawing.Point(122, 131);
            this.lbl_TrailDays.Name = "lbl_TrailDays";
            this.lbl_TrailDays.Size = new System.Drawing.Size(11, 12);
            this.lbl_TrailDays.TabIndex = 5;
            this.lbl_TrailDays.Text = "-";
            // 
            // tbx_ComputerID
            // 
            this.tbx_ComputerID.Location = new System.Drawing.Point(122, 54);
            this.tbx_ComputerID.Name = "tbx_ComputerID";
            this.tbx_ComputerID.Size = new System.Drawing.Size(318, 21);
            this.tbx_ComputerID.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Tips
            // 
            this.lbl_Tips.AutoSize = true;
            this.lbl_Tips.Location = new System.Drawing.Point(51, 169);
            this.lbl_Tips.MaximumSize = new System.Drawing.Size(400, 0);
            this.lbl_Tips.Name = "lbl_Tips";
            this.lbl_Tips.Size = new System.Drawing.Size(41, 12);
            this.lbl_Tips.TabIndex = 8;
            this.lbl_Tips.Text = "提示：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 346);
            this.Controls.Add(this.lbl_Tips);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbx_ComputerID);
            this.Controls.Add(this.lbl_TrailDays);
            this.Controls.Add(this.lbl_LicenseType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "品成插件注册信息";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_LicenseType;
        private System.Windows.Forms.Label lbl_TrailDays;
        private System.Windows.Forms.TextBox tbx_ComputerID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_Tips;
    }
}