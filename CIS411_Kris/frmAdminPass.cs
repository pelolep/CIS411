using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS411
{
    public partial class frmAdminPass : Form
    {
        public frmAdminPass()
        {
            InitializeComponent();
            //Properties.Settings.Default.EncryptedPassword = frmAdmin.hash("CIS411");
            //Properties.Settings.Default.Save();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Matt6
            /*
            if (frmAdmin.hash(txtPass.Text) == Properties.Settings.Default.EncryptedPassword)
            {*/
                frmAdmin adminForm = new frmAdmin();
                adminForm.Show();
                this.Close();
<<<<<<< HEAD
            /*
            }
=======
          //  if (frmAdmin.hash(txtPass.Text) == Properties.Settings.Default.EncryptedPassword)
            //{
                frmAdmin adminForm = new frmAdmin();
                adminForm.Show();
                this.Close();
         /*   }
>>>>>>> origin/Kris5
=======
            /*}
>>>>>>> Matt6
            else
            {
                MessageBox.Show("Incorrect Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Clear();
<<<<<<< HEAD
<<<<<<< HEAD
            }
            */
=======
            }*/
>>>>>>> origin/Kris5
=======
            }*/
>>>>>>> Matt6
        }
    }
}
