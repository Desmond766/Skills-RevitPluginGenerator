
namespace BeamColorInLink
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
            this.rbtn_NotShowBeamSize = new System.Windows.Forms.RadioButton();
            this.rbtn_ShowBeamSize = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_error_high = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(202, 101);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(12, 101);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // rbtn_NotShowBeamSize
            // 
            this.rbtn_NotShowBeamSize.AutoSize = true;
            this.rbtn_NotShowBeamSize.Location = new System.Drawing.Point(14, 39);
            this.rbtn_NotShowBeamSize.Name = "rbtn_NotShowBeamSize";
            this.rbtn_NotShowBeamSize.Size = new System.Drawing.Size(95, 16);
            this.rbtn_NotShowBeamSize.TabIndex = 3;
            this.rbtn_NotShowBeamSize.Text = "不显示梁尺寸";
            this.rbtn_NotShowBeamSize.UseVisualStyleBackColor = true;
            // 
            // rbtn_ShowBeamSize
            // 
            this.rbtn_ShowBeamSize.AutoSize = true;
            this.rbtn_ShowBeamSize.Checked = true;
            this.rbtn_ShowBeamSize.Location = new System.Drawing.Point(14, 17);
            this.rbtn_ShowBeamSize.Name = "rbtn_ShowBeamSize";
            this.rbtn_ShowBeamSize.Size = new System.Drawing.Size(83, 16);
            this.rbtn_ShowBeamSize.TabIndex = 4;
            this.rbtn_ShowBeamSize.TabStop = true;
            this.rbtn_ShowBeamSize.Text = "显示梁尺寸";
            this.rbtn_ShowBeamSize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "不满足净高的梁高度(<):";
            // 
            // tb_error_high
            // 
            this.tb_error_high.Location = new System.Drawing.Point(153, 69);
            this.tb_error_high.Name = "tb_error_high";
            this.tb_error_high.Size = new System.Drawing.Size(79, 21);
            this.tb_error_high.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "mm";
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(289, 136);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_error_high);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.rbtn_NotShowBeamSize);
            this.Controls.Add(this.rbtn_ShowBeamSize);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.RadioButton rbtn_NotShowBeamSize;
        private System.Windows.Forms.RadioButton rbtn_ShowBeamSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_error_high;
        private System.Windows.Forms.Label label2;
    }
}