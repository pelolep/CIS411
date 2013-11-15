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
using System.IO;

namespace CIS411
{
    public partial class frmAdmin : Form
    {//        AppDomain currentDomain = AppDomain.CurrentDomain.SetData("DataDirectory", "App1.config");

        AppDomain Directory = AppDomain.CurrentDomain;


<<<<<<< HEAD
        /*
=======

        
>>>>>>> origin/Matt8
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader rd;
        */
        public frmAdmin()
        {
            InitializeComponent();
            for (int i = 0; i < Properties.Settings.Default.MethodNames.Count; i++)
            {
               comboAddMethod.Items.Add(Properties.Settings.Default.MethodNames[i]);

            }
<<<<<<< HEAD
            /*
            cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");
=======


            cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\matt\Documents\GitHub\CIS411\CIS411_Kris\db.mdf;Integrated Security=True");
>>>>>>> origin/Matt8
            cmd = new SqlCommand();
            cmd.Connection = cn;
            */
        }
        
        //Adds Tutor to the list of tutors via Student ID and adds their information to the Tutors table
        private void btnAddTutor_Click(object sender, EventArgs e)
        {/////////////// edit table so only clarion id, status and cnet_username are used
            //bool valid = false;
            //Gets the student id
            string studentID = txtTutorStudentID.Text;
            /*cn.Open();
            cmd.CommandText = "select * from student where CLARION_ID=" + studentID;
            
            rd = cmd.ExecuteReader();
            */
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("*","STUDENT","CLARION_ID",studentID);
            if (rd.HasRows)
            {
                /*
                while (rd.Read())
                {
                    
                    if (rd[0].ToString() == studentID.ToString())
                    {
                        
                        real = true;
                    }
                }
                valid = true;
                */
                conn.Close();
                conn.Open();
                conn.Query("insert into tutor(clarion_id,status) values ('"+ studentID +"', '"+ "active" +"')");
            }
            conn.Close();
            loadlist();
            /*
            if (valid)
            {
                cn.Open();
                cmd.CommandText = "insert into tutor(clarion_id,status) values ('"+ studentID +"', '"+ "active" +"')";

                cmd.ExecuteNonQuery();
                //cmd.Clone();
                cn.Close();
            }
            cn.Close();
            loadlist();
            */
        }

        private void btnDisableSelected_Click(object sender, EventArgs e)
        {
            string[] name = listBoxEnableTutors.SelectedItem.ToString().Split();
            DataConnection conn = new DataConnection();
            conn.Open();
            conn.Query("update tutor set status = 'inactive' where CLARION_ID = '" + name[2] + "'");
            conn.Close();
            /*
            cn.Open();
            try
            {
                string[] words = listBoxEnableTutors.SelectedItem.ToString().Split();
                cmd.CommandText = "update tutor set status = '" + "inactive" + "'where clarion_id = '" + words[2] + "'";
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            cn.Close();
            */
            loadlist();
        }
        private void btnEnableSelected_Click(object sender, EventArgs e)
        {
            string[] name = listBoxDisableTutors.SelectedItem.ToString().Split();
            DataConnection conn = new DataConnection();
            conn.Open();
            conn.Query("update tutor set status = 'active' where CLARION_ID = '" + name[2] + "'");
            conn.Close();
            /*
            cn.Open();
            try
            {
                string[] words = listBoxDisableTutors.SelectedItem.ToString().Split();
                cmd.CommandText = "update tutor set status = '" + "active" + "'where clarion_id = '" + words[2] + "'";
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            cn.Close();
            */
            loadlist();
        }

        private void btnDisableAll_Click(object sender, EventArgs e)
        {
            DataConnection conn = new DataConnection();
            conn.Open();
            conn.Query("update tutor set status = 'inactive' where status = 'active'");
            conn.Close();
            /*
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
            */
            loadlist();
        }

        private void btnEnableAll_Click(object sender, EventArgs e)
        {
            DataConnection conn = new DataConnection();
            conn.Open();
            conn.Query("update tutor set status = 'active' where status = 'inactive'");
            conn.Close();
            /*
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
            */
            loadlist();
        }
		
        //Retrieves the Student Visit Records to edit
        /*
        private void btnEditVisit_Click(object sender, EventArgs e)
        {

            //Gets the student visit record from that day

            //Displays the sign and sign out from the record

            //Hide Edit Button, Add Button, and show Save Button
            btnAddVisit.Enabled=false;
            btnEditVisit.Enabled=false;

        }*/

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

                DataConnection conn = new DataConnection();

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
                DataConnection conn = new DataConnection();
                conn.Open();
                /*
                cmd.Connection = cn;
                cn.Open();
                */
                // Add class names to comboClassList
                while (excelReader.Read())
                {
                    last = excelReader[2].ToString();
                    last = last.Replace("'", " ");
                    first = excelReader[3].ToString();
                    first = first.Replace("'", " ");
                    middle = excelReader[4].ToString();
                    middle = middle.Replace("'", " ");
                    try
                    {
                        conn.Query("insert into STUDENT ( term,clarion_id,lastname,firstname,middle_name,cnet_username,eaglemail,class_standing,degree_seeking,major_1,major_2,minor_1,minor_2,credit_attempted,sex,hispanic,amer_indian,asian,black,pacific_islander,White,age,campus,housing,transfer,transfer_credit,number_of_visit) values ('" + excelReader[0] + "','" + excelReader[1] + "','" + last + "','" + first + "','" + middle + "','" + excelReader[5] + "','" + excelReader[6] + "','" + excelReader[7] + "','" + excelReader[8] + "','" + excelReader[9] + "','" + excelReader[10] + "','" + excelReader[11] + "','" + excelReader[12] + "','" + excelReader[13] + "','" + excelReader[14] + "','" + excelReader[15] + "','" + excelReader[16] + "','" + excelReader[17] + "','" + excelReader[18] + "','" + excelReader[19] + "','" + excelReader[20] + "','" + excelReader[21] + "','" + excelReader[22] + "','" + excelReader[23] + "','" + excelReader[24] + "','" + excelReader[25] + "','" + 0 + "')");
                        /*
                        cmd.CommandText = "insert into STUDENT ( term,clarion_id,lastname,firstname,middle_name,cnet_username,eaglemail,class_standing,degree_seeking,major_1,major_2,minor_1,minor_2,credit_attempted,sex,hispanic,amer_indian,asian,black,pacific_islander,White,age,campus,housing,transfer,transfer_credit,number_of_visit) values ('" + excelReader[0] + "','" + excelReader[1] + "','" + last + "','" + first + "','" + middle + "','" + excelReader[5] + "','" + excelReader[6] + "','" + excelReader[7] + "','" + excelReader[8] + "','" + excelReader[9] + "','" + excelReader[10] + "','" + excelReader[11] + "','" + excelReader[12] + "','" + excelReader[13] + "','" + excelReader[14] + "','" + excelReader[15] + "','" + excelReader[16] + "','" + excelReader[17] + "','" + excelReader[18] + "','" + excelReader[19] + "','" + excelReader[20] + "','" + excelReader[21] + "','" + excelReader[22] + "','" + excelReader[23] + "','" + excelReader[24] + "','" + excelReader[25] + "','" + 0 + "')";
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                        */
                    }
                    catch
                    {
                        conn.Query("update STUDENT set term = '" + excelReader[0] + "', lastname = '" + last + "', firstname = '" + first + "',middle_name = '" + middle + "',cnet_username = '" + excelReader[5] + "',eaglemail = '" + excelReader[6] + "',class_standing = '" + excelReader[7] + "',degree_seeking = '" + excelReader[8] + "',major_1 = '" + excelReader[9] + "',major_2 = '" + excelReader[10] + "',minor_1 = '" + excelReader[11] + "',minor_2 = '" + excelReader[12] + "',credit_attempted = '" + excelReader[13] + "',sex = '" + excelReader[14] + "',hispanic = '" + excelReader[15] + "',amer_indian = '" + excelReader[16] + "',asian = '" + excelReader[17] + "',black = '" + excelReader[18] + "',pacific_islander = '" + excelReader[19] + "',White = '" + excelReader[20] + "',age = '" + excelReader[21] + "',campus = '" + excelReader[22] + "',housing = '" + excelReader[23] + "',transfer = '" + excelReader[24] + "',transfer_credit = '" + excelReader[25] + "' where clarion_id = '" + excelReader[1] + "'");
                        /*
                        //MessageBox.Show(excelReader[1].ToString() + "update");
                        cmd.CommandText = "update STUDENT set term = '" + excelReader[0] + "', lastname = '" + last + "', firstname = '" + first + "',middle_name = '" + middle + "',cnet_username = '" + excelReader[5] + "',eaglemail = '" + excelReader[6] + "',class_standing = '" + excelReader[7] + "',degree_seeking = '" + excelReader[8] + "',major_1 = '" + excelReader[9] + "',major_2 = '" + excelReader[10] + "',minor_1 = '" + excelReader[11] + "',minor_2 = '" + excelReader[12] + "',credit_attempted = '" + excelReader[13] + "',sex = '" + excelReader[14] + "',hispanic = '" + excelReader[15] + "',amer_indian = '" + excelReader[16] + "',asian = '" + excelReader[17] + "',black = '" + excelReader[18] + "',pacific_islander = '" + excelReader[19] + "',White = '" + excelReader[20] + "',age = '" + excelReader[21] + "',campus = '" + excelReader[22] + "',housing = '" + excelReader[23] + "',transfer = '" + excelReader[24] + "',transfer_credit = '" + excelReader[25] + "' where clarion_id = '" + excelReader[1] + "'";
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                        */
                    }
                }
                
                excelReader.Close();
                excelConnection.Close();
                conn.Close();
                //cn.Close();
        }

        private void btn_courses_import_Click(object sender, EventArgs e)
        {
            string last, first;
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();
            if (o.FileName == "")
                return;
            SqlCommand cmd2 = new SqlCommand();
            SqlCommand cmd3 = new SqlCommand();
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source="+o.FileName+";Extended Properties=Excel 12.0 Xml";
            // Create the connection

            System.Data.OleDb.OleDbConnection excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
            string excelQuery = @"Select * from [sheet1$]";
            System.Data.OleDb.OleDbCommand excelCommand = new System.Data.OleDb.OleDbCommand(excelQuery, excelConnection);
            excelConnection.Open();
            System.Data.OleDb.OleDbDataReader excelReader;
            excelReader = excelCommand.ExecuteReader();
            DataConnection conn = new DataConnection();
            /*
            cmd.Connection = cn;
            cmd2.Connection = cn;
            cn.Open();
            */
            while (excelReader.Read())
            {
      
                last = excelReader[5].ToString();
                last = last.Replace("'"," ");
                first = excelReader[6].ToString();
                first= first.Replace("'"," ");
                try
                {
                    conn.Query("insert into Course (term,subject,catalog,section,prof_email) values ('" + excelReader[0] + "','" + excelReader[2] + "','" + excelReader[3] + "','" + excelReader[4] + "','"+excelReader[7]+"')");
                    /*
                    cmd.CommandText = "insert into Course (term,subject,catalog,section,prof_email) values ('" + excelReader[0] + "','" + excelReader[2] + "','" + excelReader[3] + "','" + excelReader[4] + "','"+excelReader[7]+"')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    */
                }
                catch
                {
                }
                try
                {
                    conn.Query("insert into PROFESSOR (PROF_EMAIL, LASTNAME, FIRSTNAME) values ('" + excelReader[7] + "', '" + last + "', '" + first + "')");
                    /*
                    cmd2.CommandText = "insert into PROFESSOR (PROF_EMAIL, LASTNAME, FIRSTNAME) values ('" + excelReader[7] + "', '" + last + "', '" + first + "')";
                    cmd2.ExecuteNonQuery();
                    cmd2.Clone();
                    */
                }
                catch
                {
                }
                try
                {
                    conn.Query("insert into student_Course (clarion_id,term,subject,catalog,section) values ('"+excelReader[1]+"' ,'" + excelReader[0] + "','" + excelReader[2] + "','" + excelReader[3] + "','" + excelReader[4] + "')");
                    /*
                    cmd.CommandText = "insert into student_Course (clarion_id,term,subject,catalog,section) values ('"+excelReader[1]+"' ,'" + excelReader[0] + "','" + excelReader[2] + "','" + excelReader[3] + "','" + excelReader[4] + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    */
                }
                catch 
                { 
                }
            }
            excelReader.Close();
            conn.Close();
            //cn.Close();
            excelConnection.Close();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

            string folder = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetEntryAssembly().Location);
            string dbPath = System.IO.Path.Combine(folder, "CIS411_Kris");
            string connString = "DataSource=" +dbPath;
            
            string fileName = "CIS411_kris";
            FileInfo f = new FileInfo(fileName);
           // string aa [] = f.FullName.ToString().Split();
            //Directory fullname = f.Directory;
            //Directory.get
          //  MessageBox.Show("");
            loadlist();
           // AppDomain.CurrentDomain.SetData("DataDirectory", "~/cis411/cis411_Kris/db.mdf");
            //currentDomain.SetData("DataDirectory", "~/cis411/cis411_Kris/db.mdf");
            
           
        }

        public void loadlist()
        {
            listBoxEnableTutors.Items.Clear();
            listBoxDisableTutors.Items.Clear();
            listBoxLoggedIn.Items.Clear();
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("STUDENT.FIRSTNAME, STUDENT.MIDDLE_NAME, STUDENT.LASTNAME", "TUTOR INNER JOIN STUDENT ON TUTOR.CLARION_ID=STUDENT.CLARION_ID");
            
            /*
            cn.Open();


            cmd.CommandText = "select * from tutor inner join student on tutor.clarion_id=student.clarion_id";
            rd = cmd.ExecuteReader();
            */
            if (rd.HasRows)
            {  
                
                while (rd.Read())
                {
                    if(rd[2].ToString() == "active")
                    listBoxEnableTutors.Items.Add(rd[5].ToString() + " " +rd[6].ToString() + " " + rd[1]);
                    else
                        listBoxDisableTutors.Items.Add(rd[5].ToString() + " " + rd[6].ToString() + " " + rd[1]);
                }
            }
            /*
            rd.Close();
            cn.Close();
            cn.Open();
<<<<<<< HEAD
            cmd.CommandText = "select * from visit";
            */
            rd = conn.GetReader("*", "VISIT");
            listBoxLoggedIn.Items.Add("Date               time in       id      term     method");
=======
            cmd.CommandText = "select * from visit inner join student on visit.clarion_id=student.clarion_id";
            rd = cmd.ExecuteReader();
            listBoxLoggedIn.Items.Add("Date                                   time in                                        id                            last name                             first name");
>>>>>>> origin/Matt8
            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    
                    DateTime jdate= DateTime.Parse(rd[1].ToString());
                    listBoxLoggedIn.Items.Add(jdate.ToString("dd/M/yyyy") + "                    "+rd[2] + "                    " + rd[0] + "                  "+rd[13] + "                            " + rd[14]);
                }
            }
            conn.Close();
            /*
            rd.Close();
            cn.Close();
            */
        }

        private void tabControlAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlAdmin.SelectedTab.Name == "tabAdmin")
                this.AcceptButton = btnChangePassword;
            if (tabControlAdmin.SelectedTab.Name == "tabMethods")
            {
                initializeMethodTextBoxes();
                this.AcceptButton = btnSaveMethods;
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
                createRemoveButton();
            }
            updateAddMethodButtonLocation();
            btnSaveMethods.Enabled = false;
        }

        void btnAddMethod_Click(object sender, EventArgs e)
        {
            addMethodTextbox();
            createRemoveButton();
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
            txtMethods[methodIndex].TabIndex = (methodIndex + 1) * 2;
            txtMethods[methodIndex].TextChanged += txtMethods_TextChanged;
            tabMethods.Controls.Add(txtMethods[methodIndex]);
        }

        void createRemoveButton()
        {
            btnRemoveMethods.Add(new Button());
            btnRemoveMethods[methodIndex].Text = "Remove";
            btnRemoveMethods[methodIndex].Location = new System.Drawing.Point(((methodIndex / 10) * 200) + 155, ((methodIndex % 10) * 26) + 47);
            btnRemoveMethods[methodIndex].Name = "btnRemoveMethods" + methodIndex.ToString();
            btnRemoveMethods[methodIndex].TabIndex = (methodIndex + 1) * 2 + 1;
            btnRemoveMethods[methodIndex].Click += btnRemoveMethods_Click;
            tabMethods.Controls.Add(btnRemoveMethods[methodIndex]);
        }

        void updateAddMethodButtonLocation()
        {
            btnAddMethod.Location = new System.Drawing.Point(((methodIndex / 10) * 200) + 50, ((methodIndex % 10) * 26) + 47);
            btnAddMethod.TabIndex = (methodIndex + 1) * 2 + 2;
        }

        private void txtMethods_TextChanged(object sender, EventArgs e)
        {
            btnSaveMethods.Enabled = true;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DataConnection conn = new DataConnection();
            conn.Open();
            conn.Query("insert into visit(Date, time_in, clarion_id, method) values ('" + DateTime.Today + "', '" + "10:52:02" + "', '" + "11111111" + "', '" + "testing" + "')");
            conn.Close();
            /*
            cn.Open();
            cmd.CommandText = "insert into visit(Date, time_in, clarion_id, method) values ('" + DateTime.Today + "', '" + "10:52:02" + "', '" + "11111111" + "', '" + "testing" + "')";

            cmd.ExecuteNonQuery();
            cmd.Clone();
            cn.Close();
            */
            loadlist();
        }

        List<TextBox> txtMethods = new List<TextBox>();
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

        private void btnRemoveMethods_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < btnRemoveMethods.Count; i++)
                if (sender.Equals(btnRemoveMethods[i]))
                {
                    txtMethods[i].Visible = false;
                    btnRemoveMethods[i].Visible = false;
                    txtMethods.RemoveAt(i);
                    btnRemoveMethods.RemoveAt(i);
                    methodIndex--;
                    resetMethodButtonPositions();
                    updateAddMethodButtonLocation();
                    btnSaveMethods.Enabled = true;
                }
        }

        private void resetMethodButtonPositions()
        {
            for (int i = 0; i < methodIndex; i++)
            {
                txtMethods[i].Location = new System.Drawing.Point(((i / 10) * 200) + 50, ((i % 10) * 26) + 47);
                txtMethods[i].TabIndex = (i + 1) * 2;
                btnRemoveMethods[i].Location = new System.Drawing.Point(((i / 10) * 200) + 155, ((i % 10) * 26) + 47);
                btnRemoveMethods[i].TabIndex = (i + 1) * 2 + 1;
            }
        }

        private void comboTutoring_SelectedIndex(object sender, EventArgs e)
        {
            comboAddTutoring.Enabled = true;
            txtAddClass.Enabled = true;
        }

        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            /*Won't run because of tutor ID issue.
             * The Tutor ID being uploaded to the visits
             * table does not line up with the Tutor table
             * 
             * 
             */
            
            string studentID = txtAddStudentID.Text;
            string date = dateTimePickerAdd.Text;
            string timeIn = dateTimePickerAddTimeIn.Text;
            string timeOut = dateTimePickerAddTimeOut.Text;
            string method = comboAddMethod.SelectedIndex.ToString();
            string course = txtAddClass.Text;
            int tutor = 2;
            
            string nothing = " ";

            /*if (method == "Tutoring")
            {
                if (course == null || tutor == null)
                {
                    MessageBox.Show("Please Enter a course and a tutor.");
                }
            }
            else
            {
            */
            //cmd.Connection = cn;
<<<<<<< HEAD
            DataConnection conn = new DataConnection();
            conn.Open();
            conn.Query("insert into VISIT(DATE, TIME_IN, TIME_OUT, CLARION_ID, TERM, SUBJECT, CATALOG, TUTOR_ID, METHOD, SECTION) values ('" + date + "','" + timeIn + "', '" + timeOut + "', '" + studentID + "', '" + nothing + "', '" + nothing + "', '" + nothing + "', '" + tutor + "', '" + method + "', '" + nothing + "')");
            conn.Close();
            /*
=======
           // try
            {
>>>>>>> origin/Matt8
                cn.Open();
                cmd.CommandText = "insert into VISIT(DATE, TIME_IN, TIME_OUT, CLARION_ID, TERM, SUBJECT, CATALOG, TUTOR_ID, METHOD, SECTION) values ('" + date + "','" + timeIn + "', '" + timeOut + "', '" + studentID + "', '" + "2138" + "', '" + "LS" + "', '" + "540" + "', '" + tutor + "', '" + method + "', '" + "W01" + "')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                cn.Close();
<<<<<<< HEAD
            */
=======
            }
           // catch
            {}
>>>>>>> origin/Matt8

          //  }
            lblTest.Text = date + "','" + timeIn + "', '" + timeOut + "', '" + studentID +  "', '" + method;
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
            
        }

        private void comboAddMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboAddMethod.SelectedIndex == 0)
            {
                comboAddTutoring.Enabled = true;
                comboAddTutoring.Items.Add("Select a tutor...");
                comboAddTutoring.Items.AddRange(frmMain.getTutors());
                comboAddTutoring.SelectedIndex = 0;
            }
            else
                comboAddTutoring.Enabled = false;


        
        }

        // Returns array of all tutors
        /*
        public string[] getTutors()
        {
            List<string> tutorslist = new List<string>();
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("STUDENT.FIRSTNAME,STUDENT.MIDDLE_NAME,STUDENT.LASTNAME","tutor inner join student","tutor.clarion_id","student.clarion_id");
            if (rd.HasRows)
                while (rd.Read())
                    tutorslist.Add(rd[0] + " " + rd[1] + " " + rd[2]);
            return tutorslist.ToArray();
            /*
            string name = "";
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from tutor inner join student on tutor.clarion_id=student.clarion_id";

            rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                while (rd.Read())
                {

                    name += rd[5].ToString() + " " + rd[6].ToString() + " " + rd[0].ToString();
                    tutorslist.Add(name);
                }
            }
            rd.Close();
            cn.Close();

            string[] tutors = new string[tutorslist.Count()];
            for (int i = 0; i < tutorslist.Count(); i++)
                tutors[i] = tutorslist.ElementAt(i);

            return tutors;
        }
            */
    }
}
