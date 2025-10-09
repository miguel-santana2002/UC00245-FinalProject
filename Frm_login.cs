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
        // Variables for custom form dragging/movement
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        public Frm_login()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            // Hide the 'closed eye' icon by default, showing the 'open eye'
            pb_closeeye.Hide();
        }

        /// <summary>
        /// Custom drawing event for panel1 to apply a border style, 
        /// which creates a distinctive visual effect (e.g., a neon or cyber border).
        /// </summary>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
            Color.Lime, 2, ButtonBorderStyle.Solid,  // Left
            Color.Lime, 2, ButtonBorderStyle.Solid,  // Top
            Color.Lime, 2, ButtonBorderStyle.Solid,  // Right
            Color.Lime, 2, ButtonBorderStyle.Solid); // Bottom 
        }

        /// <summary>
        /// Handles the click event for the 'closed eye' icon.
        /// Hides the password and shows the 'open eye' icon.
        /// </summary>
        private void pb_closeeye_Click(object sender, EventArgs e)
        {
            pb_closeeye.Hide();
            pb_showeye.Show();
            txt_pass.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Handles the click event for the 'open eye' icon.
        /// Shows the password and shows the 'closed eye' icon.
        /// </summary>
        private void pb_showeye_Click(object sender, EventArgs e)
        {
            pb_showeye.Hide();
            pb_closeeye.Show();
            txt_pass.UseSystemPasswordChar = false;
        }

        /// <summary>
        /// Handles the exit button click, showing a confirmation dialog.
        /// </summary>
        private void pb_exitapp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        /// <summary>
        /// Handles the login button click.
        /// Contains hardcoded credential logic for demonstration.
        /// </summary>
        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_user.Text;
            string password = txt_pass.Text;

            // Hardcoded credential check
            if (username == "user" && password == "123")
            {
                this.Hide();
                // Pass the successfully logged-in username to the main form
                Frm_MainMenu frm_MainMenu = new Frm_MainMenu(username);
                frm_MainMenu.Show();

            }
            else
            {
                // Display error message, play system sound, and clear fields
                lbl_errormsg.Show();
                SystemSounds.Hand.Play();
                txt_user.Text = "";
                txt_pass.Text = "";
            }
        }

        // --- Custom Form Dragging Logic ---

        private void Frm_login_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            lastForm = this.Location;
        }

        private void Frm_login_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate the difference between the old and new cursor position
                int deltaX = Cursor.Position.X - lastCursor.X;
                int deltaY = Cursor.Position.Y - lastCursor.Y;

                // Move the form by the difference
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