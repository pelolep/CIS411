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
            username += "@clarion.not";
            int column = 0, id = 0;
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=../../../VEN_LSC_SR_Project_Students_sample.xls;Extended Properties=Excel 12.0 Xml";
            //Create the connection
            System.Data.OleDb.OleDbConnection excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
            string excelQuery = @"Select * from [Export Worksheet$]";
            System.Data.OleDb.OleDbCommand excelCommand = new System.Data.OleDb.OleDbCommand(excelQuery, excelConnection);
            excelConnection.Open();
            System.Data.OleDb.OleDbDataReader excelReader;
            excelReader = excelCommand.ExecuteReader();
            
            for (int i = 0; i < excelReader.FieldCount; i++)
            {
                if (excelReader.GetName(i) == "CZ_CNET_ID")
                    column = i;
                if (excelReader.GetName(i) == "EMPLID")
                    id = i;

            }

            while (excelReader.Read())
            {

                if (excelReader[column].ToString() == username.ToString())
                {
                    userID = int.Parse( excelReader[id].ToString());
                    return true;
                }
            }
            userID = 000000000;
            return false;

        }
    }
}
