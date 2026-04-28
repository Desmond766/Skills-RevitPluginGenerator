
namespace BeamColor
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
            this.rbtn_ShowBeamSize = new System.Windows.Forms.RadioButton();
            this.rbtn_NotShowBeamSize = new System.Windows.Forms.RadioButton();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbtn_ShowBeamSize
            // 
            this.rbtn_ShowBeamSize.AutoSize = true;
            this.rbtn_ShowBeamSize.Checked = true;
            this.rbtn_ShowBeamSize.Location = new System.Drawing.Point(12, 21);
            this.rbtn_ShowBeamSize.Name = "rbtn_ShowBeamSize";
            this.rbtn_ShowBeamSize.Size = new System.Drawing.Size(83, 16);
            this.rbtn_ShowBeamSize.TabIndex = 0;
            this.rbtn_ShowBeamSize.TabStop = true;
            this.rbtn_ShowBeamSize.Text = "显示梁尺寸";
            this.rbtn_ShowBeamSize.UseVisualStyleBackColor = true;
            // 
            // rbtn_NotShowBeamSize
            // 
            this.rbtn_NotShowBeamSize.AutoSize = true;
            this.rbtn_NotShowBeamSize.Location = new System.Drawing.Point(12, 43);
            this.rbtn_NotShowBeamSize.Name = "rbtn_NotShowBeamSize";
            this.rbtn_NotShowBeamSize.Size = new System.Drawing.Size(95, 16);
            this.rbtn_NotShowBeamSize.TabIndex = 0;
            this.rbtn_NotShowBeamSize.Text = "不显示梁尺寸";
            this.rbtn_NotShowBeamSize.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(20, 103);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(157, 103);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "不满足净高的梁高度(<)：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 21);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(238, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "mm";
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(268, 138);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.rbtn_NotShowBeamSize);
            this.Controls.Add(this.rbtn_ShowBeamSize);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingFrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn_ShowBeamSize;
        private System.Windows.Forms.RadioButton rbtn_NotShowBeamSize;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}