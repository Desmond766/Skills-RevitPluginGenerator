namespace MEP_SplitByLine
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
            this.btn_Plane = new System.Windows.Forms.Button();
            this.btn_Vertical = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Plane
            // 
            this.btn_Plane.Location = new System.Drawing.Point(40, 16);
            this.btn_Plane.Name = "btn_Plane";
            this.btn_Plane.Size = new System.Drawing.Size(136, 23);
            this.btn_Plane.TabIndex = 1;
            this.btn_Plane.Text = "平面打断";
            this.btn_Plane.UseVisualStyleBackColor = true;
            this.btn_Plane.Click += new System.EventHandler(this.btn_Plane_Click);
            // 
            // btn_Vertical
            // 
            this.btn_Vertical.Location = new System.Drawing.Point(40, 50);
            this.btn_Vertical.Name = "btn_Vertical";
            this.btn_Vertical.Size = new System.Drawing.Size(136, 23);
            this.btn_Vertical.TabIndex = 2;
            this.btn_Vertical.Text = "立面打断";
            this.btn_Vertical.UseVisualStyleBackColor = true;
            this.btn_Vertical.Click += new System.EventHandler(this.btn_Vertical_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 88);
            this.Controls.Add(this.btn_Vertical);
            this.Controls.Add(this.btn_Plane);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "根据线打断";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Plane;
        private System.Windows.Forms.Button btn_Vertical;
    }
}