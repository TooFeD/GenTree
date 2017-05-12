namespace GenTree.Program.Forms
{
    partial class MemberPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.secondNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.PhotoBox = new System.Windows.Forms.PictureBox();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.secondNameLabel);
            this.groupBox.Controls.Add(this.firstNameLabel);
            this.groupBox.Controls.Add(this.PhotoBox);
            this.groupBox.Location = new System.Drawing.Point(3, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(348, 173);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "MemberInfo";
            // 
            // secondNameLabel
            // 
            this.secondNameLabel.AutoSize = true;
            this.secondNameLabel.Location = new System.Drawing.Point(126, 59);
            this.secondNameLabel.Name = "secondNameLabel";
            this.secondNameLabel.Size = new System.Drawing.Size(59, 13);
            this.secondNameLabel.TabIndex = 2;
            this.secondNameLabel.Text = "Прізвище:";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(126, 34);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(32, 13);
            this.firstNameLabel.TabIndex = 1;
            this.firstNameLabel.Text = "Ім\'я: ";
            // 
            // PhotoBox
            // 
            this.PhotoBox.Location = new System.Drawing.Point(24, 19);
            this.PhotoBox.Name = "PhotoBox";
            this.PhotoBox.Size = new System.Drawing.Size(84, 69);
            this.PhotoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PhotoBox.TabIndex = 0;
            this.PhotoBox.TabStop = false;
            // 
            // MemberPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "MemberPanel";
            this.Size = new System.Drawing.Size(356, 178);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.PictureBox PhotoBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label secondNameLabel;
    }
}
