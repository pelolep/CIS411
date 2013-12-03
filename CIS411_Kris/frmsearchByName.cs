using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CIS411
{
    public partial class frmSearchByName : Form
    {
        /*
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;
        */
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
                //Program.mainForm.disableChangeID();
                Program.mainForm.Focus();
                this.Close();
            }
            else
                MessageBox.Show("Username does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool SearchForUser(string username, out int userID)
        {
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("CLARION_ID", "STUDENT", "CNET_USERNAME", username);
            if (rd.HasRows)
            {
                rd.Read();
                userID = int.Parse(rd[0].ToString());
                conn.Close();
                return true;
            }
            userID = -1;
            conn.Close();
            return false;
        }
    }
}
