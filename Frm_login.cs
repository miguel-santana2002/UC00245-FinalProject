using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class Frm_login : Form
    {
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        public Frm_login()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pb_closeeye.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
            Color.Lime, 2, ButtonBorderStyle.Solid,  // Left
            Color.Lime, 2, ButtonBorderStyle.Solid,  // Top
            Color.Lime, 2, ButtonBorderStyle.Solid,  // Right
            Color.Lime, 2, ButtonBorderStyle.Solid); // Bottom    
        }

        private void pb_closeeye_Click(object sender, EventArgs e)
        {
            pb_closeeye.Hide();
            pb_showeye.Show();
            txt_pass.UseSystemPasswordChar = true;
        }

        private void pb_showeye_Click(object sender, EventArgs e)
        {
            pb_showeye.Hide();
            pb_closeeye.Show();
            txt_pass.UseSystemPasswordChar = false;
        }

        private void pb_exitapp_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Are you sure you want to exit?", "Exit application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_user.Text;
            string password= txt_pass.Text;
            
            if (username=="admin" && password=="admin")
            {
                this.Hide();
                Frm_MainMenu frm_MainMenu = new Frm_MainMenu(username);
                frm_MainMenu.Show();
                
            }
            else
            {
                lbl_errormsg.Show();
                SystemSounds.Hand.Play();
                txt_user.Text = "";
                txt_pass.Text = "";
            }
        }

        private void Frm_login_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            lastForm = this.Location;
        }

        private void Frm_login_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calcula a diferença entre a posição antiga e a nova
                int deltaX = Cursor.Position.X - lastCursor.X;
                int deltaY = Cursor.Position.Y - lastCursor.Y;

                // Move o formulário pela diferença
                this.Location = new Point(lastForm.X + deltaX, lastForm.Y + deltaY);
            }
        }

        private void Frm_login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = this.Location;
            }
        }
    }
}
