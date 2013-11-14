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
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;
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
            conn.open();
            SqlDataReader rd = conn.getReader("CLARION_ID", "STUDENT", "CNET_USERNAME", username);
            if (rd.HasRows)
            {
                rd.Read();
                userID = int.Parse(rd[0].ToString());
                conn.close();
                return true;
            }
            userID = -1;
            conn.close();
            return false;
            /*DataConnection.cmd.CommandText = "select CLARION_ID from STUDENT where CNET_USERNAME='" + username + "'";
            DataConnection.cn.Open();
            DataConnection.rd = DataConnection.cmd.ExecuteReader();
            if (DataConnection.rd.HasRows)
            {
                DataConnection.rd.Read();
                userID = int.Parse(DataConnection.rd[0].ToString());
                DataConnection.cn.Close();
                return true;
            }
            userID = -1;
            DataConnection.cn.Close();
            return false;
            */
            /*
            int column = 0, idCol = 0;
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\VEN_LSC_SR_Project_Students_sample.xls;Extended Properties=Excel 12.0 Xml";
            //Create the connection
            System.Data.OleDb.OleDbConnection excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
            string excelQuery = @"Select * from [Export Worksheet$]";
            System.Data.OleDb.OleDbCommand excelCommand = new System.Data.OleDb.OleDbCommand(excelQuery, excelConnection);
            excelConnection.Open();
            System.Data.OleDb.OleDbDataReader excelReader;
            excelReader = excelCommand.ExecuteReader();
            //CHANGE THIS
            for (int i = 0; i < excelReader.FieldCount; i++)
            {
                if (excelReader.GetName(i) == "EMPLID")
                    idCol = i;
                if (excelReader.GetName(i) == "CZ_CNET_ID")
                    column = i;
            }
=======

            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select clarion_id from student where cnet_username='" + username + "'";

            rd = cmd.ExecuteReader();
>>>>>>> origin/Matt7

            if (rd.HasRows)
            {
                rd.Read();
                userID = int.Parse(rd[0].ToString());
                rd.Close();
                cn.Close();
                return true;
            }
            rd.Close();
            cn.Close();
            userID = -1;
            return false;
            */
        }
    }
}
