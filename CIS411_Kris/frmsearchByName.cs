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
    public partial class frmSearchByName : Form
    {
        public frmSearchByName()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int userID;
            if (SearchForUser(txtUsername.Text, out userID))
            {
                Program.mainForm.updatetxtStudentID(userID);
                Program.mainForm.disableChangeID();
                Program.mainForm.Focus();
                this.Close();
            }
            else
                MessageBox.Show("Username does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool SearchForUser(string username, out int userID)
        {
            if (username == "s_wwwarren")
            {
                userID = 999999999;
                return true;
            }
            else if (username == "s_mjmiller")
            {
                userID = 111111111;
                return true;
            }
            else
            {
                userID = 000000000;
                return false;
            }
        }

        private void frmSearchByName_Load(object sender, EventArgs e)
        {

        }
    }
}
