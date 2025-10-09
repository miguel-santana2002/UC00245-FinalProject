using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjetoFinal
{
    public partial class HeaderControl : UserControl
    {
        // Standard event declaration for clarity and convention.
        public event EventHandler LogoutClicked;
        public event EventHandler ExportRequested; // Changed from custom delegate to standard EventHandler

        public HeaderControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the ExportRequested event when the export button is clicked.
        /// </summary>
        protected virtual void OnExportRequested(EventArgs e)
        {
            ExportRequested?.Invoke(this, e);
        }

        /// <summary>
        /// Gets or sets the text displayed for the current user's name.
        /// </summary>
        public string UsernameText
        {
            get { return lbl_username_header.Text; }
            set { lbl_username_header.Text = value; }
        }

        /// <summary>
        /// Handles the Logout button click, prompting the user for confirmation.
        /// </summary>
        private void pb_logout_header_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Invoke the event for the parent form to handle the logout logic.
                LogoutClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Handles the Export button click, raising the event to initiate the export process.
        /// </summary>
        private void btn_export_pdf_Click(object sender, EventArgs e)
        {
            OnExportRequested(EventArgs.Empty);
        }
    }
}