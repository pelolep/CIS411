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
using System.Reflection;

namespace CIS411
{
    public partial class frmAdmin : Form
    {//        AppDomain currentDomain = AppDomain.CurrentDomain.SetData("DataDirectory", "App1.config");

//        AppDomain currentDomain = AppDomain.CurrentDomain;
        


     
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;
        public frmAdmin()
        {
            InitializeComponent();
            for (int i = 0; i < Properties.Settings.Default.MethodNames.Count; i++)
            {
               comboAddMethod.Items.Add(Properties.Settings.Default.MethodNames[i]);
                
            }
        }
        
        //Adds Tutor ot the list of tutors via Student ID and adds their information to the Tutors table
        private void btnAddTutor_Click(object sender, EventArgs e)
        {/////////////// edit table so only clarion id, status and cnet_username are used
            bool real = false;
            //Gets the student id
            string studentID = txtTutorStudentID.Text;
           
            

            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from student";
            
            rd = cmd.ExecuteReader();
            
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    
                    if (rd[0].ToString() == studentID.ToString())
                    {
                        
                        real = true;
                    }
                }
            }
            rd.Close();

            cn.Close();
            if (real)
            {

                cmd.Connection = cn;
                cn.Open();
                 cmd.CommandText = "insert into tutor(clarion_id,status) values ('"+ studentID +"', '"+ "active" +"')";

                cmd.ExecuteNonQuery();
               // cmd.Clone();
                cn.Close();
                MessageBox.Show("dd");
                
            }
            cn.Close();
           loadlist();
        }

        private void btnDisableSelected_Click(object sender, EventArgs e)
        {
            SqlConnection cn2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = cn2;
            cmd.Connection = cn;
            cn.Open();
            cn2.Open();
           // try
            {
                string[] words = listBoxEnableTutors.SelectedItem.ToString().Split();
                MessageBox.Show("1st");
                
                cmd.CommandText = "select * from tutor join student on tutor.clarion_id=student.clarion_id ";

                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        cmd2.CommandText = "update tutor set status = '" + "inactive" + "'from tutor join student on tutor.clarion_id=student.clarion_id where firstname = '" + "cxllpn" + "'";
         cmd2.ExecuteNonQuery();
            cmd2.Clone();
                    }
                }

            MessageBox.Show(words[0]);
            }
           // catch
            { }

   
            cn.Close();
            cn2.Close();
            loadlist();
        }

        private void btnDisableAll_Click(object sender, EventArgs e)
        {
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
            rd.Close();
            cmd.ExecuteNonQuery();
            //cmd.Clone();
            cn.Close();
            loadlist();
        }

        private void btnEnableAll_Click(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from tutor";
            rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    cmd.CommandText = "update tutor set status = '" + "active" + "' where status= '" + "inactive" + "'";
                }
            }
            rd.Close();
            cmd.ExecuteNonQuery();
           // cmd.Clone();
            cn.Close();
            loadlist();
        }

        
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //Check that the Password matches the current Password entered by the user
            if (hash(txtCurrentPassword.Text) != Properties.Settings.Default.EncryptedPassword)
            {
                MessageBox.Show( "Error: The password you used is incorrect");
                txtCurrentPassword.Clear();
                txtCurrentPassword.Focus();
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Error: The new password doesn't match");
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
                txtNewPassword.Focus();
            }
            else
            {
                Properties.Settings.Default.EncryptedPassword = hash(txtNewPassword.Text);
                Properties.Settings.Default.Save();
                MessageBox.Show("The password was changed");
                txtCurrentPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
        }

        static public string hash(string input)
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
            SaveFileDialog reportFile = new SaveFileDialog();
            reportFile.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            reportFile.RestoreDirectory = true;
            reportFile.DefaultExt = "xlsx";
            reportFile.OverwritePrompt = false;

            if (reportFile.ShowDialog() == DialogResult.OK)
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
                Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 1] = "Student";
                xlWorkSheet.Cells[1, 2] = "Hours";
                xlWorkSheet.Cells[2, 1] = "Bill Warren";
                xlWorkSheet.Cells[2, 2] = "30";
                xlWorkSheet.Cells[3, 1] = "Kris Demor";
                xlWorkSheet.Cells[3, 2] = "40";

                try
                {
                    xlWorkBook.SaveAs(reportFile.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook);
                    xlWorkBook.Close();
                }
                catch (Exception ex)
                {
                    if (ex.Source == "Microsoft Excel")
                        MessageBox.Show("File may be open in another window", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.ToString());
                }
            }
            reportFile.Dispose();
            this.Focus();
            /*
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
            */
        }

        private void btn_student_import_Click(object sender, EventArgs e)
        {
           
                OpenFileDialog o = new OpenFileDialog();
                o.ShowDialog();
                if (o.FileName == "")
                    return;
                // int term, id, last, first, middle, username, eaglemail, standing, degree, major, major2, minor, minor2, credits_att, sex, his, am_in, asian, black, pac_is, white, age, campus, housing, trans, trans_cr, visits;
                string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source="+o.FileName+";Extended Properties=Excel 12.0 Xml";
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
                    int up = 1;
                    
                    last = excelReader[2].ToString();
                    last = last.Replace("'", " ");
                    first = excelReader[3].ToString();
                    first = first.Replace("'", " ");
                    middle = excelReader[4].ToString();
                    middle = first.Replace("'", " ");
                    try
                    {
                        
                        cmd.CommandText = "insert into STUDENT ( term,clarion_id,lastname,firstname,middle_name,cnet_username,eaglemail,class_standing,degree_seeking,major_1,major_2,minor_1,minor_2,credit_attempted,sex,hispanic,amer_indian,asian,black,pacific_islander,White,age,campus,housing,transfer,transfer_credit,number_of_visit) values ('" + excelReader[0] + "','" + excelReader[1] + "','" + last + "','" + first + "','" + middle + "','" + excelReader[5] + "','" + excelReader[6] + "','" + excelReader[7] + "','" + excelReader[8] + "','" + excelReader[9] + "','" + excelReader[10] + "','" + excelReader[11] + "','" + excelReader[12] + "','" + excelReader[13] + "','" + excelReader[14] + "','" + excelReader[15] + "','" + excelReader[16] + "','" + excelReader[17] + "','" + excelReader[18] + "','" + excelReader[19] + "','" + excelReader[20] + "','" + excelReader[21] + "','" + excelReader[22] + "','" + excelReader[23] + "','" + excelReader[24] + "','" + excelReader[25] + "','" + 0 + "')";
                        cmd.ExecuteNonQuery();
                      //  cmd.Clone();     
                        up = 2;
                    }
                    catch
                    {
                    }
                    if (up == 1)
                    {
                        MessageBox.Show(excelReader[1].ToString() + "update");
                        cmd.CommandText = "update STUDENT set term = '" + excelReader[0] + "', lastname = '" + last + "', firstname = '" + first + "',middle_name = '" + middle + "',cnet_username = '" + excelReader[5] + "',eaglemail = '" + excelReader[6] + "',class_standing = '" + excelReader[7] + "',degree_seeking = '" + excelReader[8] + "',major_1 = '" + excelReader[9] + "',major_2 = '" + excelReader[10] + "',minor_1 = '" + excelReader[11] + "',minor_2 = '" + excelReader[12] + "',credit_attempted = '" + excelReader[13] + "',sex = '" + excelReader[14] + "',hispanic = '" + excelReader[15] + "',amer_indian = '" + excelReader[16] + "',asian = '" + excelReader[17] + "',black = '" + excelReader[18] + "',pacific_islander = '" + excelReader[19] + "',White = '" + excelReader[20] + "',age = '" + excelReader[21] + "',campus = '" + excelReader[22] + "',housing = '" + excelReader[23] + "',transfer = '" + excelReader[24] + "',transfer_credit = '" + excelReader[25] + "' where clarion_id = '" + excelReader[1] + "'";
                        cmd.ExecuteNonQuery();
                      //  cmd.Clone();
                    }
  
                }
                
                excelReader.Close();
                excelConnection.Close();
                cn.Close();
                

 

            cn.Close();
        }

        private void btn_courses_import_Click(object sender, EventArgs e)
        {
            string last, first;
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();
            if (o.FileName == "")
                return;
            SqlCommand cmd2 = new SqlCommand();
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source="+o.FileName+";Extended Properties=Excel 12.0 Xml";
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
                   // cmd.Clone();
                }
                catch
                {
                }
                try
                {
                    cmd2.CommandText = "insert into PROFESSOR (PROF_EMAIL, LASTNAME, FIRSTNAME) values ('" + excelReader[7] + "', '" + last + "', '" + first + "')";
                    cmd2.ExecuteNonQuery();
                    //cmd2.Clone();
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
          //  MessageBox.Show("");
            loadlist();
           // AppDomain.CurrentDomain.SetData("DataDirectory", "~/cis411/cis411_Kris/db.mdf");
            //currentDomain.SetData("DataDirectory", "~/cis411/cis411_Kris/db.mdf");
           // MessageBox.Show(currentDomain.GetData("DataDirectory").ToString());
            
        }

        public void loadlist()
        {

            

            listBoxEnableTutors.Items.Clear();
            listBoxDisableTutors.Items.Clear();
           
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from tutor inner join student on tutor.clarion_id=student.clarion_id";
            rd = cmd.ExecuteReader();
          
            if (rd.HasRows)
            {  
                
                while (rd.Read())
                {
                    if(rd[2].ToString() == "active")
                    listBoxEnableTutors.Items.Add(rd[5].ToString() + " " +rd[6].ToString());
                    else
                        listBoxDisableTutors.Items.Add(rd[5].ToString() + " " + rd[6].ToString());
                }
            }
            cn.Close();
        }

        private void tabControlAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlAdmin.SelectedTab.Name == "tabAdmin")
                this.AcceptButton = btnChangePassword;
            else
                this.AcceptButton = null;
            if (tabControlAdmin.SelectedTab.Name == "tabMethods")
            {
                initializeMethodTextBoxes();
            }
            else
            {
                txtMethods.Clear();
                methodIndex = 0;
            }
        }

        void initializeMethodTextBoxes()
        {
            for (; methodIndex < Properties.Settings.Default.MethodNames.Count; methodIndex++)
            {
                addMethodTextbox();
                addRemoveButton();
            }
            btnAddMethod.Text = "Add new method";
            updateAddMethodButtonLocation();
            btnAddMethod.Name = "btnAddMethod";
            btnAddMethod.Size = new System.Drawing.Size(100, 20);
            btnAddMethod.TabIndex = txtMethods.Count;
            btnAddMethod.Click += btnAddMethod_Click;
            tabMethods.Controls.Add(btnAddMethod);
            btnSaveMethods.Enabled = false;
        }

        void btnAddMethod_Click(object sender, EventArgs e)
        {
            addMethodTextbox();
            addRemoveButton();
            methodIndex++;
            updateAddMethodButtonLocation();
            btnSaveMethods.Enabled = true;
        }

        void addMethodTextbox()
        {
            txtMethods.Add(new TextBox());
            if (methodIndex < Properties.Settings.Default.MethodNames.Count)
                txtMethods[methodIndex].Text = Properties.Settings.Default.MethodNames[methodIndex];
            else
                txtMethods[methodIndex].Text = "";
            txtMethods[methodIndex].Location = new System.Drawing.Point(((methodIndex / 10) * 200) + 50, ((methodIndex % 10) * 26) + 47);
            txtMethods[methodIndex].Name = "txtMethods" + methodIndex.ToString();
            txtMethods[methodIndex].Size = new System.Drawing.Size(100, 20);
            txtMethods[methodIndex].TabIndex = methodIndex;
            txtMethods[methodIndex].TextChanged+=txtMethods_TextChanged;
            tabMethods.Controls.Add(txtMethods[methodIndex]);
        }

        void addRemoveButton()
        {
            btnRemoveMethods.Add(new Button());
            btnRemoveMethods[methodIndex].Text = "Remove";
            btnRemoveMethods[methodIndex].Location = new System.Drawing.Point(((methodIndex / 10) * 200) + 155, ((methodIndex % 10) * 26) + 47);
            btnRemoveMethods[methodIndex].Name = "btnRemoveMethods" + methodIndex.ToString();
            btnRemoveMethods[methodIndex].TabIndex = (methodIndex + 1) * 2;
            btnRemoveMethods[methodIndex].Click += btnRemoveMethods_Click;
            tabMethods.Controls.Add(btnRemoveMethods[methodIndex]);
        }

        void updateAddMethodButtonLocation()
        {
            btnAddMethod.Location = new System.Drawing.Point(((methodIndex / 10) * 200) + 50, ((methodIndex % 10) * 26) + 47);
        }

        private void txtMethods_TextChanged(object sender, EventArgs e)
        {
            btnSaveMethods.Enabled = true;
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }

<<<<<<< HEAD
        List<TextBox> txtMethods = new List<TextBox>();
        Button btnAddMethod = new Button();
        List<Button> btnRemoveMethods = new List<Button>();
        int methodIndex = 0;

        private void btnSaveMethods_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MethodNames.Clear();
            for (int i = 0; i < txtMethods.Count; i++)
            {
                Properties.Settings.Default.MethodNames.Add(txtMethods[i].Text);
            }
            Properties.Settings.Default.Save();
            btnSaveMethods.Enabled = false;
        }

        void btnRemoveMethods_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < btnRemoveMethods.Count; i++)
                if (sender.Equals(btnRemoveMethods[i]))
                {
                    txtMethods[i].Visible = false;
                    btnRemoveMethods[i].Visible = false;
                    txtMethods.RemoveAt(i);
                    btnRemoveMethods.RemoveAt(i);
                    methodIndex--;
                    updateAddMethodButtonLocation();
                    btnSaveMethods.Enabled = true;
                }
=======
        private void comboTutoring_SelectedIndex(object sender, EventArgs e)
        {
            txtAddTutor.Enabled = true;
            txtAddClass.Enabled = true;
        }

        private void btnAddVisit_Click(object sender, EventArgs e)
        {

        }
        
        //Retrieves the Student Visit Records to edit
        private void btnEditVisit_Click(object sender, EventArgs e)
        {
            
           //Change button text to save and return to Edit Visit
            if (btnEditVisit.Text == "EditVisit")
                btnEditVisit.Text = "Save Edit";
            else
                btnEditVisit.Text = "Edit Visit";
            

        }

        
        //null
        private void btnSave_Click(object sender, EventArgs e)
        {
            
>>>>>>> origin/Kris5
        }
    }
}
