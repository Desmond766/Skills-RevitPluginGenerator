namespace MEP_Replaycer
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
            this.button_offset = new System.Windows.Forms.Button();
            this.button_system = new System.Windows.Forms.Button();
            this.button_size = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_offset
            // 
            this.button_offset.Location = new System.Drawing.Point(12, 12);
            this.button_offset.Name = "button_offset";
            this.button_offset.Size = new System.Drawing.Size(75, 23);
            this.button_offset.TabIndex = 0;
            this.button_offset.Text = "标高刷";
            this.button_offset.UseVisualStyleBackColor = true;
            this.button_offset.Click += new System.EventHandler(this.button_offset_Click);
            // 
            // button_system
            // 
            this.button_system.Location = new System.Drawing.Point(105, 12);
            this.button_system.Name = "button_system";
            this.button_system.Size = new System.Drawing.Size(75, 23);
            this.button_system.TabIndex = 1;
            this.button_system.Text = "系统刷";
            this.button_system.UseVisualStyleBackColor = true;
            this.button_system.Click += new System.EventHandler(this.button_system_Click);
            // 
            // button_size
            // 
            this.button_size.Location = new System.Drawing.Point(197, 12);
            this.button_size.Name = "button_size";
            this.button_size.Size = new System.Drawing.Size(75, 23);
            this.button_size.TabIndex = 2;
            this.button_size.Text = "管径刷";
            this.button_size.UseVisualStyleBackColor = true;
            this.button_size.Click += new System.EventHandler(this.button_size_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 45);
            this.Controls.Add(this.button_size);
            this.Controls.Add(this.button_system);
            this.Controls.Add(this.button_offset);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "属性刷";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_offset;
        private System.Windows.Forms.Button button_system;
        private System.Windows.Forms.Button button_size;
    }
}