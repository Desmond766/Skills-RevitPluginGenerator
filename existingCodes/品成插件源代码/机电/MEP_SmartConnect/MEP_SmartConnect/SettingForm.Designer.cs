namespace MEP_SmartConnect
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
            this.gbx_Datum = new System.Windows.Forms.GroupBox();
            this.rbtn_Center = new System.Windows.Forms.RadioButton();
            this.rbtn_SecondPick = new System.Windows.Forms.RadioButton();
            this.rbtn_FirstPick = new System.Windows.Forms.RadioButton();
            this.gbx_Angle = new System.Windows.Forms.GroupBox();
            this.rbtn_30 = new System.Windows.Forms.RadioButton();
            this.rbtn_90 = new System.Windows.Forms.RadioButton();
            this.rbtn_60 = new System.Windows.Forms.RadioButton();
            this.rbtn_45 = new System.Windows.Forms.RadioButton();
            this.rbtn_15 = new System.Windows.Forms.RadioButton();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.gbx_Datum.SuspendLayout();
            this.gbx_Angle.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_Datum
            // 
            this.gbx_Datum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Datum.Controls.Add(this.rbtn_Center);
            this.gbx_Datum.Controls.Add(this.rbtn_SecondPick);
            this.gbx_Datum.Controls.Add(this.rbtn_FirstPick);
            this.gbx_Datum.Location = new System.Drawing.Point(12, 12);
            this.gbx_Datum.Name = "gbx_Datum";
            this.gbx_Datum.Size = new System.Drawing.Size(248, 71);
            this.gbx_Datum.TabIndex = 1;
            this.gbx_Datum.TabStop = false;
            this.gbx_Datum.Text = "对齐";
            // 
            // rbtn_Center
            // 
            this.rbtn_Center.AutoSize = true;
            this.rbtn_Center.Location = new System.Drawing.Point(7, 43);
            this.rbtn_Center.Name = "rbtn_Center";
            this.rbtn_Center.Size = new System.Drawing.Size(47, 16);
            this.rbtn_Center.TabIndex = 0;
            this.rbtn_Center.Text = "中心";
            this.rbtn_Center.UseVisualStyleBackColor = true;
            // 
            // rbtn_SecondPick
            // 
            this.rbtn_SecondPick.AutoSize = true;
            this.rbtn_SecondPick.Location = new System.Drawing.Point(148, 20);
            this.rbtn_SecondPick.Name = "rbtn_SecondPick";
            this.rbtn_SecondPick.Size = new System.Drawing.Size(83, 16);
            this.rbtn_SecondPick.TabIndex = 0;
            this.rbtn_SecondPick.Text = "第二次选择";
            this.rbtn_SecondPick.UseVisualStyleBackColor = true;
            // 
            // rbtn_FirstPick
            // 
            this.rbtn_FirstPick.AutoSize = true;
            this.rbtn_FirstPick.Checked = true;
            this.rbtn_FirstPick.Location = new System.Drawing.Point(6, 20);
            this.rbtn_FirstPick.Name = "rbtn_FirstPick";
            this.rbtn_FirstPick.Size = new System.Drawing.Size(83, 16);
            this.rbtn_FirstPick.TabIndex = 0;
            this.rbtn_FirstPick.TabStop = true;
            this.rbtn_FirstPick.Text = "第一次选择";
            this.rbtn_FirstPick.UseVisualStyleBackColor = true;
            // 
            // gbx_Angle
            // 
            this.gbx_Angle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Angle.Controls.Add(this.rbtn_30);
            this.gbx_Angle.Controls.Add(this.rbtn_90);
            this.gbx_Angle.Controls.Add(this.rbtn_60);
            this.gbx_Angle.Controls.Add(this.rbtn_45);
            this.gbx_Angle.Controls.Add(this.rbtn_15);
            this.gbx_Angle.Location = new System.Drawing.Point(12, 89);
            this.gbx_Angle.Name = "gbx_Angle";
            this.gbx_Angle.Size = new System.Drawing.Size(248, 53);
            this.gbx_Angle.TabIndex = 2;
            this.gbx_Angle.TabStop = false;
            this.gbx_Angle.Text = "角度";
            // 
            // rbtn_30
            // 
            this.rbtn_30.AutoSize = true;
            this.rbtn_30.Location = new System.Drawing.Point(57, 21);
            this.rbtn_30.Name = "rbtn_30";
            this.rbtn_30.Size = new System.Drawing.Size(35, 16);
            this.rbtn_30.TabIndex = 0;
            this.rbtn_30.Text = "30";
            this.rbtn_30.UseVisualStyleBackColor = true;
            // 
            // rbtn_90
            // 
            this.rbtn_90.AutoSize = true;
            this.rbtn_90.Checked = true;
            this.rbtn_90.Location = new System.Drawing.Point(207, 21);
            this.rbtn_90.Name = "rbtn_90";
            this.rbtn_90.Size = new System.Drawing.Size(35, 16);
            this.rbtn_90.TabIndex = 0;
            this.rbtn_90.TabStop = true;
            this.rbtn_90.Text = "90";
            this.rbtn_90.UseVisualStyleBackColor = true;
            // 
            // rbtn_60
            // 
            this.rbtn_60.AutoSize = true;
            this.rbtn_60.Location = new System.Drawing.Point(157, 21);
            this.rbtn_60.Name = "rbtn_60";
            this.rbtn_60.Size = new System.Drawing.Size(35, 16);
            this.rbtn_60.TabIndex = 0;
            this.rbtn_60.Text = "60";
            this.rbtn_60.UseVisualStyleBackColor = true;
            // 
            // rbtn_45
            // 
            this.rbtn_45.AutoSize = true;
            this.rbtn_45.Location = new System.Drawing.Point(107, 21);
            this.rbtn_45.Name = "rbtn_45";
            this.rbtn_45.Size = new System.Drawing.Size(35, 16);
            this.rbtn_45.TabIndex = 0;
            this.rbtn_45.Text = "45";
            this.rbtn_45.UseVisualStyleBackColor = true;
            // 
            // rbtn_15
            // 
            this.rbtn_15.AutoSize = true;
            this.rbtn_15.Location = new System.Drawing.Point(7, 21);
            this.rbtn_15.Name = "rbtn_15";
            this.rbtn_15.Size = new System.Drawing.Size(35, 16);
            this.rbtn_15.TabIndex = 0;
            this.rbtn_15.Text = "15";
            this.rbtn_15.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(12, 153);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(185, 153);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 188);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbx_Angle);
            this.Controls.Add(this.gbx_Datum);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参数设置";
            this.gbx_Datum.ResumeLayout(false);
            this.gbx_Datum.PerformLayout();
            this.gbx_Angle.ResumeLayout(false);
            this.gbx_Angle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_Datum;
        private System.Windows.Forms.RadioButton rbtn_Center;
        private System.Windows.Forms.RadioButton rbtn_SecondPick;
        private System.Windows.Forms.RadioButton rbtn_FirstPick;
        private System.Windows.Forms.GroupBox gbx_Angle;
        private System.Windows.Forms.RadioButton rbtn_30;
        private System.Windows.Forms.RadioButton rbtn_90;
        private System.Windows.Forms.RadioButton rbtn_60;
        private System.Windows.Forms.RadioButton rbtn_45;
        private System.Windows.Forms.RadioButton rbtn_15;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}