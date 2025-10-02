namespace ProjetoFinal
{
    partial class Frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_login));
            this.pb_exitapp = new System.Windows.Forms.PictureBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pb_closeeye = new System.Windows.Forms.PictureBox();
            this.pb_showeye = new System.Windows.Forms.PictureBox();
            this.lbl_errormsg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exitapp)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_closeeye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_showeye)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_exitapp
            // 
            this.pb_exitapp.BackColor = System.Drawing.Color.Transparent;
            this.pb_exitapp.Image = global::ProjetoFinal.Properties.Resources.exit_app_green;
            this.pb_exitapp.Location = new System.Drawing.Point(358, 14);
            this.pb_exitapp.Name = "pb_exitapp";
            this.pb_exitapp.Size = new System.Drawing.Size(43, 36);
            this.pb_exitapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_exitapp.TabIndex = 1;
            this.pb_exitapp.TabStop = false;
            this.pb_exitapp.Click += new System.EventHandler(this.pb_exitapp_Click);
            // 
            // txt_user
            // 
            this.txt_user.BackColor = System.Drawing.Color.Black;
            this.txt_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_user.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.ForeColor = System.Drawing.Color.Lime;
            this.txt_user.Location = new System.Drawing.Point(168, 83);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(146, 26);
            this.txt_user.TabIndex = 0;
            // 
            // txt_pass
            // 
            this.txt_pass.BackColor = System.Drawing.Color.Black;
            this.txt_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pass.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.ForeColor = System.Drawing.Color.Lime;
            this.txt_pass.Location = new System.Drawing.Point(168, 115);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(146, 26);
            this.txt_pass.TabIndex = 1;
            this.txt_pass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(63, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "USERNAME: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(63, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "PASSWORD:";
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.Black;
            this.btn_login.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_login.FlatAppearance.BorderSize = 2;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.Lime;
            this.btn_login.Location = new System.Drawing.Point(123, 195);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(161, 59);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pb_closeeye);
            this.panel1.Controls.Add(this.pb_showeye);
            this.panel1.Controls.Add(this.lbl_errormsg);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pb_exitapp);
            this.panel1.Controls.Add(this.btn_login);
            this.panel1.Controls.Add(this.txt_user);
            this.panel1.Controls.Add(this.txt_pass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(67, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 313);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(179, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Developed by Miguel Santana 2025";
            // 
            // pb_closeeye
            // 
            this.pb_closeeye.Image = global::ProjetoFinal.Properties.Resources.closed_eye_green;
            this.pb_closeeye.Location = new System.Drawing.Point(320, 115);
            this.pb_closeeye.Name = "pb_closeeye";
            this.pb_closeeye.Size = new System.Drawing.Size(24, 26);
            this.pb_closeeye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_closeeye.TabIndex = 10;
            this.pb_closeeye.TabStop = false;
            this.pb_closeeye.Click += new System.EventHandler(this.pb_closeeye_Click);
            // 
            // pb_showeye
            // 
            this.pb_showeye.Image = global::ProjetoFinal.Properties.Resources.open_eye_green;
            this.pb_showeye.Location = new System.Drawing.Point(320, 115);
            this.pb_showeye.Name = "pb_showeye";
            this.pb_showeye.Size = new System.Drawing.Size(24, 26);
            this.pb_showeye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_showeye.TabIndex = 9;
            this.pb_showeye.TabStop = false;
            this.pb_showeye.Click += new System.EventHandler(this.pb_showeye_Click);
            // 
            // lbl_errormsg
            // 
            this.lbl_errormsg.AutoSize = true;
            this.lbl_errormsg.BackColor = System.Drawing.Color.Transparent;
            this.lbl_errormsg.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_errormsg.ForeColor = System.Drawing.Color.Lime;
            this.lbl_errormsg.Location = new System.Drawing.Point(94, 155);
            this.lbl_errormsg.Name = "lbl_errormsg";
            this.lbl_errormsg.Size = new System.Drawing.Size(225, 19);
            this.lbl_errormsg.TabIndex = 8;
            this.lbl_errormsg.Text = "Erro ao efectuar Login!!";
            this.lbl_errormsg.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(94, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "WELCOME TO CYBER";
            // 
            // Frm_login
            // 
            this.AcceptButton = this.btn_login;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(556, 422);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Frm_login_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Frm_login_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pb_exitapp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_closeeye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_showeye)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pb_exitapp;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_errormsg;
        private System.Windows.Forms.PictureBox pb_showeye;
        private System.Windows.Forms.PictureBox pb_closeeye;
        private System.Windows.Forms.Label label4;
    }
}

