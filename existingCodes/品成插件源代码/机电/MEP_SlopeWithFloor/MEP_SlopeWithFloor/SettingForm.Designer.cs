
namespace MEP_SlopeWithFloor
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.gbx_Distance = new System.Windows.Forms.GroupBox();
            this.lbl_Units = new System.Windows.Forms.Label();
            this.tbx_Distance = new System.Windows.Forms.TextBox();
            this.gbx_Distance.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(128, 70);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(12, 70);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // gbx_Distance
            // 
            this.gbx_Distance.Controls.Add(this.lbl_Units);
            this.gbx_Distance.Controls.Add(this.tbx_Distance);
            this.gbx_Distance.Location = new System.Drawing.Point(12, 12);
            this.gbx_Distance.Name = "gbx_Distance";
            this.gbx_Distance.Size = new System.Drawing.Size(191, 52);
            this.gbx_Distance.TabIndex = 7;
            this.gbx_Distance.TabStop = false;
            this.gbx_Distance.Text = "距离";
            // 
            // lbl_Units
            // 
            this.lbl_Units.AutoSize = true;
            this.lbl_Units.Location = new System.Drawing.Point(162, 23);
            this.lbl_Units.Name = "lbl_Units";
            this.lbl_Units.Size = new System.Drawing.Size(17, 12);
            this.lbl_Units.TabIndex = 1;
            this.lbl_Units.Text = "mm";
            // 
            // tbx_Distance
            // 
            this.tbx_Distance.Location = new System.Drawing.Point(12, 20);
            this.tbx_Distance.Name = "tbx_Distance";
            this.tbx_Distance.Size = new System.Drawing.Size(144, 21);
            this.tbx_Distance.TabIndex = 0;
            this.tbx_Distance.Text = "0";
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(216, 110);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbx_Distance);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MEP管道随斜板";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.gbx_Distance.ResumeLayout(false);
            this.gbx_Distance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox gbx_Distance;
        private System.Windows.Forms.Label lbl_Units;
        private System.Windows.Forms.TextBox tbx_Distance;
    }
}