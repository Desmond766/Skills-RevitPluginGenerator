namespace ARC_BeamMaterial
{
    partial class BeamMaterialForm
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
            this.gbx_function = new System.Windows.Forms.GroupBox();
            this.rbtn_Clear = new System.Windows.Forms.RadioButton();
            this.rbtn_Add = new System.Windows.Forms.RadioButton();
            this.gbx_function.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(197, 68);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(12, 71);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // gbx_function
            // 
            this.gbx_function.Controls.Add(this.rbtn_Clear);
            this.gbx_function.Controls.Add(this.rbtn_Add);
            this.gbx_function.Location = new System.Drawing.Point(12, 13);
            this.gbx_function.Name = "gbx_function";
            this.gbx_function.Size = new System.Drawing.Size(260, 49);
            this.gbx_function.TabIndex = 5;
            this.gbx_function.TabStop = false;
            this.gbx_function.Text = "功能选项";
            // 
            // rbtn_Clear
            // 
            this.rbtn_Clear.AutoSize = true;
            this.rbtn_Clear.Location = new System.Drawing.Point(159, 20);
            this.rbtn_Clear.Name = "rbtn_Clear";
            this.rbtn_Clear.Size = new System.Drawing.Size(83, 16);
            this.rbtn_Clear.TabIndex = 0;
            this.rbtn_Clear.Text = "清除梁材质";
            this.rbtn_Clear.UseVisualStyleBackColor = true;
            // 
            // rbtn_Add
            // 
            this.rbtn_Add.AutoSize = true;
            this.rbtn_Add.Checked = true;
            this.rbtn_Add.Location = new System.Drawing.Point(7, 21);
            this.rbtn_Add.Name = "rbtn_Add";
            this.rbtn_Add.Size = new System.Drawing.Size(83, 16);
            this.rbtn_Add.TabIndex = 0;
            this.rbtn_Add.TabStop = true;
            this.rbtn_Add.Text = "添加梁材质";
            this.rbtn_Add.UseVisualStyleBackColor = true;
            // 
            // BeamMaterialForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(284, 107);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbx_function);
            this.Name = "BeamMaterialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "梁材质转换";
            this.gbx_function.ResumeLayout(false);
            this.gbx_function.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox gbx_function;
        private System.Windows.Forms.RadioButton rbtn_Clear;
        private System.Windows.Forms.RadioButton rbtn_Add;
    }
}