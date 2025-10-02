namespace ProjetoFinal
{
    partial class HeaderControl
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
            this.pb_logout_header = new System.Windows.Forms.PictureBox();
            this.lbl_username_header = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logout_header)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_logout_header
            // 
            this.pb_logout_header.Image = global::ProjetoFinal.Properties.Resources.logout_app_green;
            this.pb_logout_header.Location = new System.Drawing.Point(116, 4);
            this.pb_logout_header.Name = "pb_logout_header";
            this.pb_logout_header.Size = new System.Drawing.Size(21, 30);
            this.pb_logout_header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logout_header.TabIndex = 11;
            this.pb_logout_header.TabStop = false;
            this.pb_logout_header.Click += new System.EventHandler(this.pb_logout_header_Click);
            // 
            // lbl_username_header
            // 
            this.lbl_username_header.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_username_header.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username_header.ForeColor = System.Drawing.Color.Lime;
            this.lbl_username_header.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_username_header.Location = new System.Drawing.Point(0, 0);
            this.lbl_username_header.Name = "lbl_username_header";
            this.lbl_username_header.Size = new System.Drawing.Size(105, 40);
            this.lbl_username_header.TabIndex = 10;
            this.lbl_username_header.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HeaderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pb_logout_header);
            this.Controls.Add(this.lbl_username_header);
            this.Name = "HeaderControl";
            this.Size = new System.Drawing.Size(146, 40);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logout_header)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_logout_header;
        private System.Windows.Forms.Label lbl_username_header;
    }
}
