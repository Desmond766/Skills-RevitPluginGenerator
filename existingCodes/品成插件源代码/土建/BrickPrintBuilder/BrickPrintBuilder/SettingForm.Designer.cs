
namespace BrickPrintBuilder
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
            this.tbx_tickness = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_Grouped = new System.Windows.Forms.CheckBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_DirectShape = new System.Windows.Forms.RadioButton();
            this.rbtn_Floor = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "砖厚";
            // 
            // tbx_tickness
            // 
            this.tbx_tickness.Location = new System.Drawing.Point(48, 10);
            this.tbx_tickness.Name = "tbx_tickness";
            this.tbx_tickness.Size = new System.Drawing.Size(155, 21);
            this.tbx_tickness.TabIndex = 1;
            this.tbx_tickness.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "mm";
            // 
            // cbx_Grouped
            // 
            this.cbx_Grouped.AutoSize = true;
            this.cbx_Grouped.Checked = true;
            this.cbx_Grouped.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_Grouped.Location = new System.Drawing.Point(15, 37);
            this.cbx_Grouped.Name = "cbx_Grouped";
            this.cbx_Grouped.Size = new System.Drawing.Size(48, 16);
            this.cbx_Grouped.TabIndex = 2;
            this.cbx_Grouped.Text = "成组";
            this.cbx_Grouped.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(12, 136);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(151, 136);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtn_Floor);
            this.groupBox1.Controls.Add(this.rbtn_DirectShape);
            this.groupBox1.Location = new System.Drawing.Point(13, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 70);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "异形砖";
            // 
            // rbtn_DirectShape
            // 
            this.rbtn_DirectShape.AutoSize = true;
            this.rbtn_DirectShape.Location = new System.Drawing.Point(6, 20);
            this.rbtn_DirectShape.Name = "rbtn_DirectShape";
            this.rbtn_DirectShape.Size = new System.Drawing.Size(203, 16);
            this.rbtn_DirectShape.TabIndex = 0;
            this.rbtn_DirectShape.Text = "内建模型（数据设备，不可编辑）";
            this.rbtn_DirectShape.UseVisualStyleBackColor = true;
            // 
            // rbtn_Floor
            // 
            this.rbtn_Floor.AutoSize = true;
            this.rbtn_Floor.Checked = true;
            this.rbtn_Floor.Location = new System.Drawing.Point(6, 42);
            this.rbtn_Floor.Name = "rbtn_Floor";
            this.rbtn_Floor.Size = new System.Drawing.Size(65, 16);
            this.rbtn_Floor.TabIndex = 0;
            this.rbtn_Floor.TabStop = true;
            this.rbtn_Floor.Text = "墙/楼板";
            this.rbtn_Floor.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(238, 171);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.cbx_Grouped);
            this.Controls.Add(this.tbx_tickness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "砖翻模V1.0";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_tickness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbx_Grouped;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn_Floor;
        private System.Windows.Forms.RadioButton rbtn_DirectShape;
    }
}