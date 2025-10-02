using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class HeaderControl : UserControl
    {
        public event EventHandler LogoutClicked;

        public HeaderControl()
        {
            InitializeComponent();
        }

        public string UsernameText
        {
            get { return lbl_username_header.Text; }
            set
            {
                lbl_username_header.Text = value;
            }
        }

        private void pb_logout_header_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Are you sure you want to logout?", "Logout application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                LogoutClicked?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
