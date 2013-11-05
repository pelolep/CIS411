using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace CIS411
{

    public partial class frmAdmin : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;
        public frmAdmin()
        {
            InitializeComponent();
        }

        //Adds Tutor ot the list of tutors via Student ID and adds their information to the Tutors table
        private void btnAddTutor_Click(object sender, EventArgs e)
        {/////////////// edit table so only clarion id, status and cnet_username are used
            bool real = false;
            //Gets the student id
            string studentID = txtTutorStudentID.Text;

            listBoxEnableTutors.Items.Clear();
            listBoxDisableTutors.Items.Clear();


            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from student";
            
            rd = cmd.ExecuteReader();
            
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    if (rd[1].ToString() == studentID.ToString())
                    {
                        real = true;
                    }
                }
            }
            rd.Close();
            MessageBox.Show("d");
            cn.Close();
            if (real)
            {
                cmd.Connection = cn;
                cn.Open();
                // cmd.CommandText = "insert into tutors(clarion_id,status) values ('"+ studentID +"', '"+ "active" +"')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                cn.Close();
                //loadlist();
            }
        }

        private void btnDisableSelected_Click(object sender, EventArgs e)
        {

            cn.Open();
           // cmd.CommandText = "insert into tutors(term,clarion_id,lastname,firstname,middle_initial,cnet_username,eaglemail,status) values ('" + term + "','" + id + "','" + last + "','" + first + "','" + middle + "','" + user + "','" + eagle + "','" + status + "')";
            cmd.ExecuteNonQuery();
            cmd.Clone();
            cn.Close();
            loadlist();
        }

        private void btnDisableAll_Click(object sender, EventArgs e)
        {

            //loadlist();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from tutor";
            rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    cmd.CommandText = "update tutor set status = '"+ "inactive" +"' where status= '"+ "active"+"'";
                }
            }
            cn.Close();
            rd.Close();
        }


        //Retrieves the Student Visit Records to edit
        private void btnEditVisit_Click(object sender, EventArgs e)
        {
            //gets the student id
            string studentID = txtStudentID.Text;

            //Gets the student visit record from that day

            //Displays the sign and sign out from the record

            //Hide Edit Button, Add Button, and show Save Button
            btnAddVisit.Hide();
            btnEditVisit.Hide();
            btnSave.Show();

        }

        //Saves the edited Visit record
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Gets new sign In and Sign Out times

            //Updates Visits Record

            //Includes date of update

            //Show Edit Button, Add Button, and hide Save Button
            btnAddVisit.Show();
            btnEditVisit.Show();
            btnSave.Hide();

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            /*
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            SHA1CryptoServiceProvider x = new SHA1CryptoServiceProvider();
            byte[] currentPassSHA = Encoding.ASCII.GetBytes(txtCurrentPassword.Text);
            currentPassSHA = x.ComputeHash(currentPassSHA);
            string currentPassSHAString = Encoding.ASCII.GetString(currentPassSHA);
            */

            //Check that the Password matches the current Password entered by the user
            if (hash(txtCurrentPassword.Text) != Properties.Settings.Default.EncryptedPassword)
            {
                MessageBox.Show( "Error: The password you used is incorrect");
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Error: The new password doesn't match");
            }
            else
            {
                /*
                byte[] newPassSHA = Encoding.ASCII.GetBytes(txtNewPassword.Text);
                newPassSHA = x.ComputeHash(newPassSHA);
                string newPassSHAString = Encoding.ASCII.GetString(newPassSHA);
                */
                Properties.Settings.Default.EncryptedPassword = hash(txtNewPassword.Text);
                Properties.Settings.Default.Save();
                MessageBox.Show("The password was changed");
            }
        }

        private string hash(string input)
        {
            SHA1CryptoServiceProvider x = new SHA1CryptoServiceProvider();
            //RSACryptoServiceProvider y = new RSACryptoServiceProvider();
            return Encoding.ASCII.GetString/*(y.Encrypt*/(x.ComputeHash(Encoding.ASCII.GetBytes(input))/*,true)*/);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                string sql = null;
                MyConnection = new System.Data.OleDb.OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source='../../../ReportBook.xls';Extended Properties=Excel 12.0 Xml;");
                MyConnection.Open();
                myCommand.Connection = MyConnection;
                sql = "Insert into [Sheet1$] (Student,NumOfHours) values('Bill Warren','30')";
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_student_import_Click(object sender, EventArgs e)
        {
            try
            {
                // int term, id, last, first, middle, username, eaglemail, standing, degree, major, major2, minor, minor2, credits_att, sex, his, am_in, asian, black, pac_is, white, age, campus, housing, trans, trans_cr, visits;
                string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\VEN_LSC_SR_Project_Students_sample.xls;Extended Properties=Excel 12.0 Xml";
                // Create the connection
                string last, first, middle;

                System.Data.OleDb.OleDbConnection excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
                string excelQuery = @"Select * from [Export Worksheet$]";
                System.Data.OleDb.OleDbCommand excelCommand = new System.Data.OleDb.OleDbCommand(excelQuery, excelConnection);
                excelConnection.Open();
                System.Data.OleDb.OleDbDataReader excelReader;
                excelReader = excelCommand.ExecuteReader();
                cmd.Connection = cn;
                cn.Open();

                // Add class names to comboClassList
                while (excelReader.Read())
                {
                    last = excelReader[2].ToString();
                    last = last.Replace("'", " ");
                    first = excelReader[3].ToString();
                    first = first.Replace("'", " ");
                    middle = excelReader[4].ToString();
                    middle = first.Replace("'", " ");
                    cmd.CommandText = "insert into STUDENT ( term,clarion_id,lastname,firstname,middle_name,cnet_username,eaglemail,class_standing,degree_seeking,major_1,major_2,minor_1,minor_2,credit_attempted,sex,hispanic,amer_indian,asian,black,pacific_islander,White,age,campus,housing,transfer,transfer_credit,number_of_visit) values ('" + excelReader[0] + "','" + excelReader[1] + "','" + last + "','" + first + "','" + middle + "','" + excelReader[5] + "','" + excelReader[6] + "','" + excelReader[7] + "','" + excelReader[8] + "','" + excelReader[9] + "','" + excelReader[10] + "','" + excelReader[11] + "','" + excelReader[12] + "','" + excelReader[13] + "','" + excelReader[14] + "','" + excelReader[15] + "','" + excelReader[16] + "','" + excelReader[17] + "','" + excelReader[18] + "','" + excelReader[19] + "','" + excelReader[20] + "','" + excelReader[21] + "','" + excelReader[22] + "','" + excelReader[23] + "','" + excelReader[24] + "','" + excelReader[25] + "','" + 0 + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
                excelReader.Close();
                excelConnection.Close();
                cn.Close();
            }
            catch
            {
            }
            cn.Close();
        }

        private void btn_courses_import_Click(object sender, EventArgs e)
        {
            string last, first;
            SqlCommand cmd2 = new SqlCommand();
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\VEN_LSC_SR_Project_Courses_sample.xls;Extended Properties=Excel 12.0 Xml";
            // Create the connection

            System.Data.OleDb.OleDbConnection excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
            string excelQuery = @"Select * from [sheet1$]";
            System.Data.OleDb.OleDbCommand excelCommand = new System.Data.OleDb.OleDbCommand(excelQuery, excelConnection);
            excelConnection.Open();
            System.Data.OleDb.OleDbDataReader excelReader;
            excelReader = excelCommand.ExecuteReader();
            cmd.Connection = cn;
            cmd2.Connection = cn;
            cn.Open();
           
            // Add class names to comboClassList
            while (excelReader.Read())
            {
      
                last = excelReader[5].ToString();
                last = last.Replace("'"," ");
                first = excelReader[6].ToString();
                first= first.Replace("'"," ");
                try
                {
                    cmd.CommandText = "insert into Course (term,subject,catalog,section) values ('" + excelReader[0] + "','" + excelReader[2] + "','" + excelReader[3] + "','" + excelReader[4] + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
                catch
                {
                }
                try
                {
                    cmd2.CommandText = "insert into PROFESSOR (PROF_EMAIL, LASTNAME, FIRSTNAME) values ('" + excelReader[7] + "', '" + last + "', '" + first + "')";
                    cmd2.ExecuteNonQuery();
                    cmd2.Clone();
                }
                catch{
                }
            }
            excelReader.Close();
            cn.Close();
            cn.Close();

            
            excelConnection.Close();

            
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            //loadlist();
        }

        public void loadlist()
        {
            listBoxEnableTutors.Items.Clear();
            listBoxDisableTutors.Items.Clear();

            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from tutor";
            rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    if(rd[7].ToString() == "active")
                    listBoxEnableTutors.Items.Add(rd[2].ToString() + " " + rd[3].ToString());
                    else
                        listBoxDisableTutors.Items.Add(rd[2].ToString() + " " + rd[3].ToString());
                }
            }

            cn.Close();
        }


    }
}
