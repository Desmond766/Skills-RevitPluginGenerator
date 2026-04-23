namespace NetHeightDim
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
            this.rbtn_SelectCurrent = new System.Windows.Forms.RadioButton();
            this.gbx_SelectSet = new System.Windows.Forms.GroupBox();
            this.rbtn_SelectLink = new System.Windows.Forms.RadioButton();
            this.gbx_DatumSet = new System.Windows.Forms.GroupBox();
            this.lbl_PickedDatumVaule = new System.Windows.Forms.Label();
            this.lbl_PickedDatum = new System.Windows.Forms.Label();
            this.btn_PickDatum = new System.Windows.Forms.Button();
            this.rbtn_PickDatum = new System.Windows.Forms.RadioButton();
            this.rbtn_SlabDatum = new System.Windows.Forms.RadioButton();
            this.gbx_NoteSet = new System.Windows.Forms.GroupBox();
            this.rbtn_KeepNote = new System.Windows.Forms.RadioButton();
            this.rbtn_DeleteNote = new System.Windows.Forms.RadioButton();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_middleStart = new System.Windows.Forms.RadioButton();
            this.rbtn_bottomStart = new System.Windows.Forms.RadioButton();
            this.gbx_SelectSet.SuspendLayout();
            this.gbx_DatumSet.SuspendLayout();
            this.gbx_NoteSet.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtn_SelectCurrent
            // 
            this.rbtn_SelectCurrent.AutoSize = true;
            this.rbtn_SelectCurrent.Checked = true;
            this.rbtn_SelectCurrent.Location = new System.Drawing.Point(6, 20);
            this.rbtn_SelectCurrent.Name = "rbtn_SelectCurrent";
            this.rbtn_SelectCurrent.Size = new System.Drawing.Size(119, 16);
            this.rbtn_SelectCurrent.TabIndex = 0;
            this.rbtn_SelectCurrent.TabStop = true;
            this.rbtn_SelectCurrent.Text = "选择单前模型构件";
            this.rbtn_SelectCurrent.UseVisualStyleBackColor = true;
            // 
            // gbx_SelectSet
            // 
            this.gbx_SelectSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_SelectSet.Controls.Add(this.rbtn_SelectLink);
            this.gbx_SelectSet.Controls.Add(this.rbtn_SelectCurrent);
            this.gbx_SelectSet.Location = new System.Drawing.Point(12, 12);
            this.gbx_SelectSet.Name = "gbx_SelectSet";
            this.gbx_SelectSet.Size = new System.Drawing.Size(245, 65);
            this.gbx_SelectSet.TabIndex = 1;
            this.gbx_SelectSet.TabStop = false;
            this.gbx_SelectSet.Text = "选择设置";
            // 
            // rbtn_SelectLink
            // 
            this.rbtn_SelectLink.AutoSize = true;
            this.rbtn_SelectLink.Location = new System.Drawing.Point(6, 42);
            this.rbtn_SelectLink.Name = "rbtn_SelectLink";
            this.rbtn_SelectLink.Size = new System.Drawing.Size(119, 16);
            this.rbtn_SelectLink.TabIndex = 0;
            this.rbtn_SelectLink.Text = "选择链接模型构件";
            this.rbtn_SelectLink.UseVisualStyleBackColor = true;
            // 
            // gbx_DatumSet
            // 
            this.gbx_DatumSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_DatumSet.Controls.Add(this.lbl_PickedDatumVaule);
            this.gbx_DatumSet.Controls.Add(this.lbl_PickedDatum);
            this.gbx_DatumSet.Controls.Add(this.btn_PickDatum);
            this.gbx_DatumSet.Controls.Add(this.rbtn_PickDatum);
            this.gbx_DatumSet.Controls.Add(this.rbtn_SlabDatum);
            this.gbx_DatumSet.Location = new System.Drawing.Point(12, 154);
            this.gbx_DatumSet.Name = "gbx_DatumSet";
            this.gbx_DatumSet.Size = new System.Drawing.Size(245, 103);
            this.gbx_DatumSet.TabIndex = 1;
            this.gbx_DatumSet.TabStop = false;
            this.gbx_DatumSet.Text = "基准设置";
            // 
            // lbl_PickedDatumVaule
            // 
            this.lbl_PickedDatumVaule.AutoSize = true;
            this.lbl_PickedDatumVaule.Location = new System.Drawing.Point(196, 72);
            this.lbl_PickedDatumVaule.Name = "lbl_PickedDatumVaule";
            this.lbl_PickedDatumVaule.Size = new System.Drawing.Size(35, 12);
            this.lbl_PickedDatumVaule.TabIndex = 3;
            this.lbl_PickedDatumVaule.Text = "0.000";
            // 
            // lbl_PickedDatum
            // 
            this.lbl_PickedDatum.AutoSize = true;
            this.lbl_PickedDatum.Location = new System.Drawing.Point(124, 72);
            this.lbl_PickedDatum.Name = "lbl_PickedDatum";
            this.lbl_PickedDatum.Size = new System.Drawing.Size(71, 12);
            this.lbl_PickedDatum.TabIndex = 3;
            this.lbl_PickedDatum.Text = "拾取的标高:";
            // 
            // btn_PickDatum
            // 
            this.btn_PickDatum.Enabled = false;
            this.btn_PickDatum.Location = new System.Drawing.Point(24, 67);
            this.btn_PickDatum.Name = "btn_PickDatum";
            this.btn_PickDatum.Size = new System.Drawing.Size(75, 23);
            this.btn_PickDatum.TabIndex = 2;
            this.btn_PickDatum.Text = "拾取";
            this.btn_PickDatum.UseVisualStyleBackColor = true;
            this.btn_PickDatum.Click += new System.EventHandler(this.btn_PickDatum_Click);
            // 
            // rbtn_PickDatum
            // 
            this.rbtn_PickDatum.AutoSize = true;
            this.rbtn_PickDatum.Location = new System.Drawing.Point(6, 42);
            this.rbtn_PickDatum.Name = "rbtn_PickDatum";
            this.rbtn_PickDatum.Size = new System.Drawing.Size(83, 16);
            this.rbtn_PickDatum.TabIndex = 0;
            this.rbtn_PickDatum.Text = "拾取基准面";
            this.rbtn_PickDatum.UseVisualStyleBackColor = true;
            this.rbtn_PickDatum.CheckedChanged += new System.EventHandler(this.rbtn_PickDatum_CheckedChanged);
            // 
            // rbtn_SlabDatum
            // 
            this.rbtn_SlabDatum.AutoSize = true;
            this.rbtn_SlabDatum.Checked = true;
            this.rbtn_SlabDatum.Location = new System.Drawing.Point(6, 20);
            this.rbtn_SlabDatum.Name = "rbtn_SlabDatum";
            this.rbtn_SlabDatum.Size = new System.Drawing.Size(155, 16);
            this.rbtn_SlabDatum.TabIndex = 0;
            this.rbtn_SlabDatum.TabStop = true;
            this.rbtn_SlabDatum.Text = "垂直向下遇到的板、基础";
            this.rbtn_SlabDatum.UseVisualStyleBackColor = true;
            // 
            // gbx_NoteSet
            // 
            this.gbx_NoteSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_NoteSet.Controls.Add(this.rbtn_KeepNote);
            this.gbx_NoteSet.Controls.Add(this.rbtn_DeleteNote);
            this.gbx_NoteSet.Location = new System.Drawing.Point(12, 263);
            this.gbx_NoteSet.Name = "gbx_NoteSet";
            this.gbx_NoteSet.Size = new System.Drawing.Size(245, 71);
            this.gbx_NoteSet.TabIndex = 1;
            this.gbx_NoteSet.TabStop = false;
            this.gbx_NoteSet.Text = "标注设置";
            // 
            // rbtn_KeepNote
            // 
            this.rbtn_KeepNote.AutoSize = true;
            this.rbtn_KeepNote.Location = new System.Drawing.Point(6, 42);
            this.rbtn_KeepNote.Name = "rbtn_KeepNote";
            this.rbtn_KeepNote.Size = new System.Drawing.Size(71, 16);
            this.rbtn_KeepNote.TabIndex = 0;
            this.rbtn_KeepNote.Text = "保留标注";
            this.rbtn_KeepNote.UseVisualStyleBackColor = true;
            // 
            // rbtn_DeleteNote
            // 
            this.rbtn_DeleteNote.AutoSize = true;
            this.rbtn_DeleteNote.Checked = true;
            this.rbtn_DeleteNote.Location = new System.Drawing.Point(6, 20);
            this.rbtn_DeleteNote.Name = "rbtn_DeleteNote";
            this.rbtn_DeleteNote.Size = new System.Drawing.Size(71, 16);
            this.rbtn_DeleteNote.TabIndex = 0;
            this.rbtn_DeleteNote.TabStop = true;
            this.rbtn_DeleteNote.Text = "删除标注";
            this.rbtn_DeleteNote.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(12, 351);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(182, 351);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtn_middleStart);
            this.groupBox1.Controls.Add(this.rbtn_bottomStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择起点";
            // 
            // rbtn_middleStart
            // 
            this.rbtn_middleStart.AutoSize = true;
            this.rbtn_middleStart.Location = new System.Drawing.Point(6, 20);
            this.rbtn_middleStart.Name = "rbtn_middleStart";
            this.rbtn_middleStart.Size = new System.Drawing.Size(47, 16);
            this.rbtn_middleStart.TabIndex = 0;
            this.rbtn_middleStart.Text = "管中";
            this.rbtn_middleStart.UseVisualStyleBackColor = true;
            // 
            // rbtn_bottomStart
            // 
            this.rbtn_bottomStart.AutoSize = true;
            this.rbtn_bottomStart.Checked = true;
            this.rbtn_bottomStart.Location = new System.Drawing.Point(6, 43);
            this.rbtn_bottomStart.Name = "rbtn_bottomStart";
            this.rbtn_bottomStart.Size = new System.Drawing.Size(47, 16);
            this.rbtn_bottomStart.TabIndex = 0;
            this.rbtn_bottomStart.TabStop = true;
            this.rbtn_bottomStart.Text = "管底";
            this.rbtn_bottomStart.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(269, 386);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbx_NoteSet);
            this.Controls.Add(this.gbx_DatumSet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbx_SelectSet);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查看净高设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.gbx_SelectSet.ResumeLayout(false);
            this.gbx_SelectSet.PerformLayout();
            this.gbx_DatumSet.ResumeLayout(false);
            this.gbx_DatumSet.PerformLayout();
            this.gbx_NoteSet.ResumeLayout(false);
            this.gbx_NoteSet.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn_SelectCurrent;
        private System.Windows.Forms.GroupBox gbx_SelectSet;
        private System.Windows.Forms.RadioButton rbtn_SelectLink;
        private System.Windows.Forms.GroupBox gbx_DatumSet;
        private System.Windows.Forms.RadioButton rbtn_PickDatum;
        private System.Windows.Forms.RadioButton rbtn_SlabDatum;
        private System.Windows.Forms.GroupBox gbx_NoteSet;
        private System.Windows.Forms.RadioButton rbtn_KeepNote;
        private System.Windows.Forms.RadioButton rbtn_DeleteNote;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_PickedDatumVaule;
        private System.Windows.Forms.Label lbl_PickedDatum;
        private System.Windows.Forms.Button btn_PickDatum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn_middleStart;
        private System.Windows.Forms.RadioButton rbtn_bottomStart;
    }
}