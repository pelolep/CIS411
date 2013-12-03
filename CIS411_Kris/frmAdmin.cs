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

        /*
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
               comboEditMethod.Items.Add(Properties.Settings.Default.MethodNames[i]);
            }
            comboEditMethod.Items.Clear();
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("DISTINCT Method", "Visit");
            while (rd.Read())
                comboEditMethod.Items.Add(rd[0]);
            conn.Close();
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
            try
            {
                bool real = frmMain.studentIDExists(int.Parse(studentID));
                DataConnection conn = new DataConnection();
                if (real)
                {
                    conn.Open();
                    conn.Query("insert into tutor(clarion_id,status) values ('" + studentID + "', '" + "active" + "')");
                    conn.Close();
                }
                else
                    MessageBox.Show("please check the student id and try again");
            }
            catch
            {
                MessageBox.Show("please enter a valid number");
            }
        }

        private void btnDisableSelected_Click(object sender, EventArgs e)
        {
            string[] name= new string[3];
            
            try
            {
               name = listBoxEnableTutors.SelectedItem.ToString().Split();
            }
            catch
            {
                MessageBox.Show("please choose a tutor first");
            }
            DataConnection conn = new DataConnection();
            conn.Open();
            try
            {
                conn.Query("update tutor set status = 'inactive' where CLARION_ID = " + name[2]);
            }
            catch
            {
                MessageBox.Show("Unable to update tutor status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            loadlist();
        }
        
        private void btnEnableSelected_Click(object sender, EventArgs e)
        {
            string[] name = new string[3];
            try
            {
                name = listBoxDisableTutors.SelectedItem.ToString().Split();
            }
            catch
            {
                MessageBox.Show("please choose a tutor first");
            }
            DataConnection conn = new DataConnection();
            conn.Open();
            try
            {
                conn.Query("update tutor set status = 'active' where CLARION_ID = " + name[2]);
            }
            catch
            {
                MessageBox.Show("Unable to update tutor status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            loadlist();
        }

        private void btnDisableAll_Click(object sender, EventArgs e)
        {
            DataConnection conn = new DataConnection();
            conn.Open();
            try
            {
                conn.Query("update tutor set status = 'inactive' where status = 'active'");
            }
            catch
            {
                MessageBox.Show("Unable to update tutor status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            loadlist();
        }

        private void btnEnableAll_Click(object sender, EventArgs e)
        {
            DataConnection conn = new DataConnection();
            conn.Open();
            try
            {
                conn.Query("update tutor set status = 'active' where status = 'inactive'");
            }
            catch
            {
                MessageBox.Show("Unable to update tutor status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
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
                string[] row;
                for (int i = 0; i < listBoxReport.Items.Count; i++)
                {
                    row = listBoxReport.Items[i].ToString().Split('\t');
                    for (int j = 0; j < row.Length; j++)
                        xlWorkSheet.Cells[i+1, j+1].Value = row[j];
                }

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
                xlApp.Quit();
            }
            reportFile.Dispose();
            MessageBox.Show("Report Generation Complete!");
        }

        private void ImportStudents()
        {
            string last, first, middle, connectionString = "";
            OpenFileDialog studentsFile = new OpenFileDialog();
            studentsFile.Title = "Import Students";
            studentsFile.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            studentsFile.RestoreDirectory = true;
            studentsFile.DefaultExt = "xlsx";
            if (studentsFile.ShowDialog() == DialogResult.OK)
            {
                if (studentsFile.FileName == "")
                    return;
                try
                {
                    connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=" + studentsFile.FileName + ";Extended Properties=Excel 12.0 Xml";
                }
                catch { return; };
            }
            else
                return;
            this.Cursor = Cursors.WaitCursor;
            System.Data.OleDb.OleDbConnection excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
            string excelQuery = @"Select * from [Export Worksheet$]";
            System.Data.OleDb.OleDbCommand excelCommand = new System.Data.OleDb.OleDbCommand(excelQuery, excelConnection);
            excelConnection.Open();
            System.Data.OleDb.OleDbDataReader excelReader;
            excelReader = excelCommand.ExecuteReader();
            DataConnection conn = new DataConnection();
            conn.Open();
                // Add class names to comboClassList
            excelReader.Read();
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
                }
                catch
                {
                    conn.Query("update STUDENT set term = '" + excelReader[0] + "', lastname = '" + last + "', firstname = '" + first + "',middle_name = '" + middle + "',cnet_username = '" + excelReader[5] + "',eaglemail = '" + excelReader[6] + "',class_standing = '" + excelReader[7] + "',degree_seeking = '" + excelReader[8] + "',major_1 = '" + excelReader[9] + "',major_2 = '" + excelReader[10] + "',minor_1 = '" + excelReader[11] + "',minor_2 = '" + excelReader[12] + "',credit_attempted = '" + excelReader[13] + "',sex = '" + excelReader[14] + "',hispanic = '" + excelReader[15] + "',amer_indian = '" + excelReader[16] + "',asian = '" + excelReader[17] + "',black = '" + excelReader[18] + "',pacific_islander = '" + excelReader[19] + "',White = '" + excelReader[20] + "',age = '" + excelReader[21] + "',campus = '" + excelReader[22] + "',housing = '" + excelReader[23] + "',transfer = '" + excelReader[24] + "',transfer_credit = '" + excelReader[25] + "' where clarion_id = '" + excelReader[1] + "'");
                }
            }
            excelReader.Close();
            excelConnection.Close();
            conn.Close();
            this.Cursor = Cursors.Default;
        }

        private void ImportCourses()
        {
            string last, first, connectionString="";
            OpenFileDialog coursesFile = new OpenFileDialog();
            coursesFile.Title = "Import Courses";
            coursesFile.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            coursesFile.RestoreDirectory = true;
            coursesFile.DefaultExt = "xlsx";
            if (coursesFile.ShowDialog() == DialogResult.OK)
            {
                if (coursesFile.FileName == "")
                    return;
                try
                {
                    connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=" + coursesFile.FileName + ";Extended Properties=Excel 12.0 Xml";
                }
                catch { return; };
            }
            else
                return;
            // Create the connection
            this.Cursor = Cursors.WaitCursor;
            System.Data.OleDb.OleDbConnection excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
            string excelQuery = @"Select * from [sheet1$]";
            System.Data.OleDb.OleDbCommand excelCommand = new System.Data.OleDb.OleDbCommand(excelQuery, excelConnection);
            excelConnection.Open();
            System.Data.OleDb.OleDbDataReader excelReader;
            excelReader = excelCommand.ExecuteReader();
            DataConnection conn = new DataConnection();
            conn.Open();
            string s = "";
            int i=2;
            excelReader.Read();
            while (excelReader.Read())
            {
                i++;
                last = excelReader[5].ToString();
                last = last.Replace("'"," ");
                first = excelReader[6].ToString();
                first= first.Replace("'"," ");
                string catalog = excelReader[3].ToString().Replace(" ", "");

                try
                {
                    conn.Query("insert into PROFESSOR (PROF_EMAIL, LASTNAME, FIRSTNAME) values ('" + excelReader[7] + "', '" + last + "', '" + first + "')");
                }
                catch (Exception ex)
                {
                    s += "\n\tProfessor on row " + i.ToString() + "\n" + ex.Message.ToString();
                }
                try
                {
                    conn.Query("insert into Course (term,subject,catalog,section,prof_email) values ('" + excelReader[0] + "','" + excelReader[2] + "','" + catalog + "','" + excelReader[4] + "','"+excelReader[7]+"')");
                }
                catch (Exception ex)
                {
                    s += "\n\tCourse on row " + i.ToString() + "\n" + ex.Message.ToString();
                }
                try
                {
                    conn.Query("insert into student_Course (clarion_id,term,subject,catalog,section) values ('"+excelReader[1]+"' ,'" + excelReader[0] + "','" + excelReader[2] + "','" + catalog + "','" + excelReader[4] + "')");
                }
                catch (Exception ex)
                {
                    s += "\n\tStudent_Course on row " + i.ToString() + "\n" + ex.Message.ToString();
                }
            }
            try
            {
                conn.Query("insert into Course (term,subject,catalog,section) values ('other','other','other','other')");
            }
            catch { }
            excelReader.Close();
            conn.Close();
            excelConnection.Close();
            this.Cursor = Cursors.Default;
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            dateTimePickerAdd.Value = DateTime.Today;
            dateTimePickerEditMin.Value = DateTime.Today;
            dateTimePickerEditMax.Value = DateTime.Today;
            // TODO: This line of code loads data into the 'DataSet1.DataTable2' table. You can move, or remove it, as needed.
            //this.dataTable2TableAdapter.Fill(this.DataSet1.DataTable2);
            // TODO: This line of code loads data into the 'DataSet1.DataTable1' table. You can move, or remove it, as needed.
            
            comboCountCategory.SelectedIndex=0;
            comboTerm.SelectedIndex = 0;
       
            //fdfsadf
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
            SqlDataReader rd = conn.GetReader("STUDENT.FIRSTNAME, STUDENT.MIDDLE_NAME, STUDENT.clarion_id, tutor.status", "TUTOR INNER JOIN STUDENT ON TUTOR.CLARION_ID=STUDENT.CLARION_ID");
            
            if (rd.HasRows)
            {  
                
                while (rd.Read())
                {
                    if(rd[3].ToString() == "active")
                        listBoxEnableTutors.Items.Add(rd[0].ToString() + " " +rd[1].ToString() + " " + rd[2]);
                    else
                        listBoxDisableTutors.Items.Add(rd[0].ToString() + " " + rd[1].ToString() + " " + rd[2]);
                }
            }

            rd = conn.GetReader("*", "VISIT","student", "visit.clarion_id=student.clarion_id and time_out is null", 1);

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    
                    DateTime jdate= DateTime.Parse(rd[1].ToString());
                    listBoxLoggedIn.Items.Add(jdate.ToString("MM/dd/yyyy") + "\t" + rd[2] + "\t\t" + rd[0] + "\t" + rd[13] + "\t\t" + rd[14]);
                }
            }

            rd = conn.joinQuery("select tutor_hour.tutor_id, tutor_hour.date ,tutor_hour.time_difference, tutor_hour.time_in, student.lastname, student.firstname from tutor_hour inner join tutor on tutor_hour.tutor_id = tutor.tutor_id inner join student on tutor.clarion_id = student.clarion_id where time_difference is null");

            //rd = conn.GetReader("*", "tutor_hour", "student", "tutor_hour.clarion_id=student.clarion_id and time_out is null", 1);
            listBoxLoggedIn.Items.Add("DATE\t\tTIME IN\t\tID\t\tLAST NAME\tFIRST NAME");

            if (rd.HasRows)
            {
                
                while (rd.Read())
                {

                    DateTime jdate = DateTime.Parse(rd[1].ToString());
                    listBoxLoggedIn.Items.Add(jdate.ToString("MM/dd/yyyy") + "\t" + rd[3] + "\t\t" + rd[0] + "\t" + rd[4] + "\t\t" + rd[5]);
                }
            }


            conn.Close();

        }



        private void tabControlAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControlAdmin.SelectedTab.Name == "tabMethods")
            {
                initializeMethodTextBoxes();
                this.AcceptButton = btnSaveMethods;
            }
            else
            {
                txtMethods.Clear();
                methodIndex = 0;
                if (tabControlAdmin.SelectedTab.Name == "tabVisits")
                {
                    txtAddStudentID.Focus();
                }
                else if (tabControlAdmin.SelectedTab.Name == "tabAdmin")
                {
                    this.AcceptButton = btnChangePassword;
                    txtCurrentPassword.Focus();
                }
                else if (tabControlAdmin.SelectedTab.Name == "tabTutors")
                {
                    this.AcceptButton = btnAddTutor;
                    txtTutorStudentID.Focus();
                }
                else //if (tabControlAdmin.SelectedTab.Name == "tabReport")
                {
                    this.AcceptButton = btnDisplay;
                    txtYear.Focus();
                }
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
            txtMethods[methodIndex].MaxLength = 50;
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


            string []selectedStudent=listBoxLoggedIn.SelectedItem.ToString().Split();
            int student_ID = int.Parse(selectedStudent[3]);

          
                frmMain.signOut(student_ID);
          

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
        }

        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            int tryStudentID;
            if (int.TryParse(txtAddStudentID.Text, out tryStudentID))
            {
                try
                {
                    /*Won't run because of tutor ID issue.
                     * The Tutor ID being uploaded to the visits
                     * table does not line up with the Tutor table
                     * 
                     * 
                     */
                    string studentID = "", date = "", timeIn = "", timeOut = "", method = "", time_difference = "";
                    string[] selectedTutor, selectedClass;
                    int tutor = 0;
                    // 11319440
                    studentID = txtAddStudentID.Text;
                    date = dateTimePickerAdd.Text;
                    timeIn = dateTimePickerAddTimeIn.Text;
                    timeOut = dateTimePickerAddTimeOut.Text;

                    try
                    {
                        method = comboAddMethod.SelectedItem.ToString();
                    }
                    catch { }
                    //course = txtAddClass.Text;
                    // comboaddClass
                    TimeSpan dd = DateTime.Parse(timeOut).Subtract(DateTime.Parse(timeIn));
                    time_difference = dd.ToString();
                    //timedifference =DateTime.Parse( timenow.Subtract(timein).ToString());j
                    selectedClass = new string[5];


                    if (method == "Tutoring")
                    {
                        selectedTutor = comboAddTutoring.SelectedItem.ToString().Split();
                        tutor = int.Parse(selectedTutor[0]);
                    }
                    try
                    {
                        selectedClass = comboaddClass.SelectedItem.ToString().Split();
                    }
                    catch { }
                    string nothing = "other";

                    DataConnection conn = new DataConnection();
                    conn.Open();

                    if (method == "Tutoring")
                    {
                        if ((string)comboaddClass.SelectedItem.ToString().ToLower() == "other")
                        {
                            try
                            {
                                conn.Query("insert into VISIT(DATE, TIME_IN, TIME_OUT, CLARION_ID, TERM, SUBJECT, CATALOG, TUTOR_ID, METHOD, SECTION, time_difference) values ('" + date + "','" + timeIn + "', '" + timeOut + "', '" + studentID + "', '" + nothing + "', '" + nothing + "', '" + nothing + "', '" + tutor + "', '" + method + "', '" + nothing + "', '" + time_difference + "')");
                            }
                            catch { }
                        }
                        else
                        {
                            conn.Query("insert into VISIT(DATE, TIME_IN, TIME_OUT, CLARION_ID, TERM, SUBJECT, CATALOG, TUTOR_ID, METHOD, SECTION,time_difference) values ('" + date + "','" + timeIn + "', '" + timeOut + "', '" + studentID + "', '" + selectedClass[0] + "', '" + selectedClass[1] + "', '" + selectedClass[2] + "', '" + tutor + "', '" + method + "', '" + selectedClass[3] + "', '" + time_difference + "')");

                        }
                    }
                    else // method isn't tutoring
                    {
                        if ((string)comboaddClass.SelectedItem.ToString().ToLower() == "other")
                        {
                            try
                            {
                                conn.Query("insert into VISIT(DATE, TIME_IN, TIME_OUT, CLARION_ID, TERM, SUBJECT, CATALOG,METHOD, SECTION,time_difference) values ('" + date + "','" + timeIn + "', '" + timeOut + "', '" + studentID + "', '" + nothing + "', '" + nothing + "', '" + nothing + "', '" + method + "', '" + nothing + "','" + time_difference + "')");

                            }
                            catch { }
                        }
                        else
                        {
                            conn.Query("insert into VISIT(DATE, TIME_IN, TIME_OUT, CLARION_ID, TERM, SUBJECT, CATALOG, METHOD, SECTION,time_difference) values ('" + date + "','" + timeIn + "', '" + timeOut + "', '" + studentID + "', '" + selectedClass[0] + "', '" + selectedClass[1] + "', '" + selectedClass[2] + "', '" + method + "', '" + selectedClass[3] + "','" + time_difference + "')");

                        }
                    }
                    //cmd.Connection = cn;


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
                    }
                    */
                    // catch
                    //{}
                    //  }
                    //lblTest.Text = date + "','" + timeIn + "', '" + timeOut + "', '" + studentID +  "', '" + method;

                    comboaddClass.Enabled = false;
                    comboAddTutoring.Enabled = false;
                    txtAddStudentID.Text = "";
                    comboaddClass.Items.Clear();
                    comboAddTutoring.Items.Clear();
                }

                catch
                {
                    MessageBox.Show("Information invalid. Please check it and try again.");
                    return;
                }
                MessageBox.Show("Thank you for adding a visit!");
            }
            else
            {
                MessageBox.Show("Invalid Student ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        
        //Retrieves the Student Visit Records to edit 
        //By: Kris
        private void btnEditVisit_Click(object sender, EventArgs e)
        {


            //Change button text to save and return to Edit Visit
            if (btnEditVisit.Text == "List Visits")
            {

                int tryStudentID;
                if (int.TryParse(txtEditStudentID.Text, out tryStudentID) || txtEditStudentID.Text == "")
                {
                    int studentID = 0;
                    //Puts the student id, min search date, and max search date into variables
                    try
                    {
                        studentID = int.Parse(txtEditStudentID.Text);
                    }
                    catch { }
                    DateTime minSearch = DateTime.Parse(dateTimePickerEditMin.Text);
                    DateTime maxSearch = DateTime.Parse(dateTimePickerEditMax.Text);

                    //loads the results of the search into the listBoxLoggedIn
                    //loadvisits(studentID, minSearch, maxSearch);


                    frmEditList editListForm = new frmEditList(studentID, minSearch, maxSearch);
                    editListForm.Show();



                    //btnEditVisit.Text = "Save Edit";
                    //btnLogOut.Visible = false;
                    //btnLogOut.Enabled = false;
                    //lblLoggedIn.Text = "Editing...";
                    //dateTimePickerEditTimeIn.Enabled = true;
                    //dateTimePickerEditTimeOut.Enabled = true;
                }

                else
                {
                    MessageBox.Show("Invalid Student ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

                           /* //Enters the selected visit into the edit form
                            else if (btnEditVisit.Text =="Edit This Visit")
                            {
                                    dateTimePickerEditTimeIn.Enabled = true;
                                    dateTimePickerEditTimeOut.Enabled = true;
                    
                                    string[] selectedVisitEdit = listBoxLoggedIn.SelectedItem.ToString().Split();
                                    string dateEdit = selectedVisitEdit[0];
                                    DateTime TimeInEdit = DateTime.Parse(selectedVisitEdit[1]);
                                    if (selectedVisitEdit[2] != "")
                                    {
                                        DateTime TimeOutEdit = DateTime.Parse(selectedVisitEdit[2]);
                                        dateTimePickerEditTimeOut.Value = TimeOutEdit;
                                    }
                                    txtEditDate.Text = dateEdit;
                                    dateTimePickerEditTimeIn.Value = TimeInEdit;
                                    comboEditMethod.SelectedItem = selectedVisitEdit[3];
                    

                                    btnEditVisit.Text = "Save Edit";

                            }
                            
            
            else
            {

                //DateTime.Parse(DateTime.Now.ToString("HH:mm:ss tt")
                TimeSpan timedifference;
                DateTime timeOut = DateTime.Parse(dateTimePickerEditTimeOut.Value.ToString("HH:mm:ss tt"));
                DateTime timeIn = DateTime.Parse(dateTimePickerEditTimeIn.Value.ToString("HH:mm:ss tt"));
                timedifference = timeOut.Subtract(timeIn);
                if (timedifference < TimeSpan.Zero)
                {
                    MessageBox.Show("Sign out time is before sign in time. " + timeOut.ToString() + " " + timeIn.ToString() + " " + timedifference.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //string[] selectedVisitEdit = listBoxLoggedIn.SelectedItem.ToString().Split();
                DateTime originalTimeInEdit = getVisitOriginalTimeIn();
                string editDate = getVisitOriginalDate();


                //actually updates the visit information
                DataConnection conn = new DataConnection();
                conn.Open();
                try
                {
                    conn.Query("update VISIT set CLARION_ID = '" + txtEditStudentID.Text + "' , DATE = '" + editDate + "' , TIME_IN ='" + timeIn.ToString("HH:mm:ss tt") + "' , TIME_OUT = '" + timeOut.ToString("HH:mm:ss tt") + "' , TIME_DIFFERENCE = '" + timedifference.ToString("c") + "' where CLARION_ID = '" + txtEditStudentID.Text + "' AND DATE = '" + editDate + "' AND TIME_IN ='" + originalTimeInEdit.ToString("HH:mm:ss tt") + "'");
                }
                catch
                {
                    MessageBox.Show("Error while attempting to update visit. Please reload visit information and try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();

                MessageBox.Show("Thank you for editing this visit!");

                //resets the Edit form
                txtEditStudentID.Clear();
                txtEditDate.Clear();
                dateTimePickerEditTimeIn.Enabled = false;
                dateTimePickerEditTimeOut.Enabled = false;



                btnEditVisit.Text = "List Visits";
                //btnLogOut.Visible = true;
                //btnLogOut.Enabled = true;
                loadlist();
            }*/

        private DateTime getVisitOriginalTimeIn()
        {
            return DateTime.Parse(listBoxLoggedIn.SelectedItem.ToString().Split()[1]);
        }

        private string getVisitOriginalDate()
        {
            return listBoxLoggedIn.SelectedItem.ToString().Split()[0];
        }

        //null
        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void comboAddMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboaddClass.Items.Clear();
            comboAddTutoring.Items.Clear();

            if (comboAddMethod.SelectedIndex == 0)
            {
                comboAddTutoring.Enabled = true;
                comboAddTutoring.Items.Add("Select a tutor...");
                comboAddTutoring.Items.AddRange(frmMain.getTutors(true));
                comboAddTutoring.SelectedIndex = 0;
            }
            else
                comboAddTutoring.Enabled = false;

            comboaddClass.Items.Add("Select a class...");
            DataConnection conn = new DataConnection();
            conn.Open();
            try
            {
                SqlDataReader rd = conn.GetReader("term, subject, catalog, section, clarion_id", "student_course", "clarion_id", txtAddStudentID.Text.ToString());
                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        comboaddClass.Items.Add(rd[0].ToString() + " " + rd[1].ToString() + " " + rd[2].ToString() + " " + rd[3].ToString());
                    }
                }
                conn.Close();
                comboaddClass.Items.Add("Other");
                comboaddClass.SelectedIndex = 0;
                comboaddClass.Enabled = true;
            }
            catch
            {
                MessageBox.Show("please check student id");
            }

        
        }

        static public void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9'))&&(e.KeyChar!='\b')&&(e.KeyChar!='\n'))
                e.Handled = true;
        }

        //Created by Sean: button1_Click inside the Reporting Tab
        private void displayBtn_Click(object sender, EventArgs e)
        {
            //TODO: This should add a placeholder to the listbox that represents 
            //      the data that will be placed into the excel file
            string column, table, condition = "", row = "", first="", last="";
            DataConnection conn = new DataConnection();
            SqlDataReader rd;
            int year = 0, term=0, count = 0;
            bool y = int.TryParse(txtYear.Text, out year);
            term = DataConnection.getTerm(year, comboTerm.SelectedItem.ToString());
            conn.Open();
            rd = conn.GetReader("*", "VISIT", "WHERE TERM = '" + term.ToString() + "'");
            if (!(rd.HasRows))
            {
                conn.Close();
                return;
            }
            conn.Close();
            conn.Open();
            /*
            term += (int.Parse(year.ToString())/1000)*1000;
            term += (int.Parse(year.ToString()) % 100) * 10;
 
            if (comboTerm.SelectedItem.ToString() == "Winter")
                term += 9;
            else if (comboTerm.SelectedItem.ToString() == "Spring")
                term += 1;
            else if (comboTerm.SelectedItem.ToString() == "Summer")
                term += 5;
            else
                term += 8;
            */
            switch (comboCountCategory.SelectedItem.ToString())
            {
                case "Method":
                    column = "method, COUNT(DISTINCT CLARION_ID), term";
                    table = "VISIT";
                    //MessageBox.Show(comboFilter.SelectedItem.ToString());
                    condition = " where term = '" + term + "' GROUP BY METHOD, term";
                    if (comboFilter.SelectedItem.ToString() == "All")
                    {
                        listBoxReport.Items.Add("Method");
                       // MessageBox.Show("wind");
                        rd = conn.GetReader(column, table, condition);
                        while (rd.Read())
                        {
                           // for (int i = 0; i < 2; i++)
                            {
                                row += rd[0].ToString().PadRight(80) + "\t" +rd[1];
                               // MessageBox.Show((80 - rd[0].ToString().Length).ToString());

                            }
                            //MessageBox.Show("1".PadLeft(80-(rd[0].ToString().Length*1)));
                          //  MessageBox.Show(string.Format("{0,-50} {1,60}", rd[0].ToString(), rd[1].ToString()));h
                           listBoxReport.Items.Add(row);
                            //listBoxReport.Items.Add(new object[] { rd[0], rd[1] });
                            row = "";
                            //MessageBox.Show(row);
                        }

                    }
                    else
                    {
                        listBoxReport.Items.Add(comboFilter.SelectedItem.ToString());
                        rd = conn.GetReader("method, COUNT(DISTINCT CLARION_ID), term", "visit", " where term = '" + term.ToString() + "' and method = '" + comboFilter.SelectedItem.ToString() + "'  GROUP BY METHOD, term ");
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                for (int i = 0; i < 2; i++)
                                    row += rd[i].ToString().PadRight(80 - rd[i].ToString().Length) + "\t";
                                listBoxReport.Items.Add(row);
                                row = "";
                            }
                        }

                    }
                    listBoxReport.Items.Add("");
                    /*
                    
                    //condition = " method " + " = "+ " '"+"other"+"' ";
                    filterColumn = "METHOD";
                     * */
                    break;
                case "Student":
                    int newid = -1;
                    int nontradcount = 0;
                    int studentcount = 0;
       
                    
                    count = 0;
                    TimeSpan newtime = new TimeSpan();

                    if (comboFilter.SelectedItem.ToString() == "All" || comboFilter.SelectedItem.ToString() == "Total Hours")
                    {
                        listBoxReport.Items.Add("Student");
                       // rd = conn.GetReader(column, table, condition);
                        rd = conn.joinQuery("select visit.clarion_id, visit.time_difference, visit.term, student.lastname, student.firstname, student.age from visit inner join student on visit.clarion_id = student.clarion_id where time_difference is not null and visit.term = '" + term.ToString() + "'");

                        while (rd.Read())
                        {
                            
                            if (newid == int.Parse(rd[0].ToString()))
                            {
                                newtime += TimeSpan.Parse(rd[1].ToString());

                            }
                            else
                            {
                               
                                if (newid != -1)
                                {
                                    listBoxReport.Items.Add(first.PadRight(40 - first.Length) + "\t" + last.PadRight(40 - (last.Length)) + "\t" + newtime);
                                    studentcount++;
                                    
                                }
                                newid = int.Parse(rd[0].ToString());
                                newtime = TimeSpan.Parse(rd[1].ToString());
                               
                                first = rd[4].ToString();
                                last = rd[3].ToString();
                                
                                if (int.Parse(rd[5].ToString()) >= 24)
                                {
                                    first = "* " + rd[4].ToString();
                                    nontradcount++;
                                    

                                }
                                
                            }
                            
                            
   
                        }
                        if (newid != -1)
                        {
                            studentcount++;
                            listBoxReport.Items.Add(first.PadRight(40 - first.Length) + "\t" + last.PadRight(40 - (last.Length)) + "\t" + newtime);
                            

                            listBoxReport.Items.Add("nontraditional students".PadRight(100 - 23) + "\t" + nontradcount);
                            listBoxReport.Items.Add("traditional students".PadRight(100 - 20) + "\t" + (studentcount-nontradcount));

                        }
                        if (comboFilter.SelectedItem.ToString() == "All")
                        listBoxReport.Items.Add("");
                    }
                    if (comboFilter.SelectedItem.ToString() == "All" || comboFilter.SelectedItem.ToString() == "Visits")
                    {
                        newid = -1;
                        count = 0;
                        nontradcount = 0;
                        studentcount = 0;
                        
                     
                        column = "CLARION_ID,count(distinct time_difference), term";
                        table = "VISIT";
                        condition = "where time_difference is not null and term = '"+term.ToString()+"' group by clarion_id, term";

                           // rd = conn.GetReader(column, table, condition);
                        rd = conn.joinQuery("select visit.clarion_id, visit.time_difference, visit.term, student.lastname, student.firstname, student.age from visit inner join student on visit.clarion_id = student.clarion_id where time_difference is not null and visit.term = '" + term.ToString() + "'");


                        while (rd.Read())
                        {
                            if (newid == int.Parse(rd[0].ToString()))
                            {
                                count++;

                                
                            }
                            else
                            {
                                

                                if (newid != -1)
                                {
                                    studentcount++;
                                    listBoxReport.Items.Add(first.PadRight(40 - first.Length) + "\t" + last.PadRight(40 - (last.Length)) + "\t" + count);
                                  
                                }
                                newid = int.Parse(rd[0].ToString());
                                count = 1;
                              
                                first = rd[4].ToString();
                                last = rd[3].ToString();
                                if (int.Parse(rd[5].ToString()) >= 25)
                                {
                                    first = "* " + rd[4].ToString();
                                    nontradcount++;
                                    

                                }
                            }


                        }
                        if (newid != -1)
                        {
                            studentcount++;
                            listBoxReport.Items.Add(first.PadRight(20 - first.Length) + "\t" + last.PadRight(40 - (first.Length + last.Length)) + "\t" + count);
                            listBoxReport.Items.Add("Nontraditional Students".PadRight(60 - 23) + "\t" + nontradcount);
                            listBoxReport.Items.Add("Traditional Students".PadRight(60 - 20) + "\t" + (studentcount-nontradcount));


                        }
                    }
                   
                    listBoxReport.Items.Add("");
                    break;
                case "Tutor":

                    newid = -1;
                    count = 0;

                    newtime = new TimeSpan();
                    column = "tutor_ID, time_difference, term ";
                    table = "VISIT";
                    condition = "where time_difference is not null and tutor_id is not null and term = '" + term.ToString() + "' ORDER BY tutor_id";

                    if (comboFilter.SelectedItem.ToString() == "All" || comboFilter.SelectedItem.ToString() == "Hours Tutoring")
                    {
                        newid = -1;
                        count = 0;
                        listBoxReport.Items.Add("tutor");
                      //  rd = conn.GetReader(column, table, condition);
                        rd = conn.joinQuery("select visit.tutor_id, tutor.clarion_id, visit.time_difference, visit.term, student.lastname, student.firstname from visit inner join tutor on visit.tutor_id = tutor.tutor_id inner join student on tutor.clarion_id = student.clarion_id where time_difference is not null and visit.term = '" + term.ToString() + "' order by visit.tutor_id");

                        while (rd.Read())
                        {

                            if (newid == int.Parse(rd[0].ToString()))
                            {
                                newtime += TimeSpan.Parse(rd[2].ToString());
                              
                            }
                            else
                            {
                                if (newid != -1)
                                    listBoxReport.Items.Add(first.PadRight(40 - first.Length) + "\t" + last.PadRight(40 - (last.Length)) + "\t" + newtime);
                                newid = int.Parse(rd[0].ToString());
                                newtime = TimeSpan.Parse(rd[2].ToString());
                                first = rd[5].ToString();
                                last = rd[4].ToString();
                            }
                            
   
                        }
                        if (newid != -1)
                            listBoxReport.Items.Add(first.PadRight(40 - first.Length) + "\t" + last.PadRight(40 - (last.Length)) + "\t" + newtime);
                        
                       // listBoxReport.Items.Add(newid.ToString().PadRight(60 - newid.ToString().Length) + "\t" + newtime);
                        listBoxReport.Items.Add("");
                    }
                    if (comboFilter.SelectedItem.ToString() == "All" || comboFilter.SelectedItem.ToString() == "Students Tutored")
                    {
                        newid = -1;
                        count = 0;
                        column = "tutor_ID, count(distinct time_difference), term";
                        table = "VISIT";
                        condition = "where time_difference is not null and tutor_id is not null and term = '" + term.ToString() + "' group by tutor_id, term";

                        rd = conn.joinQuery("select visit.tutor_id, tutor.clarion_id, visit.time_difference, visit.term, student.lastname, student.firstname from visit inner join tutor on visit.tutor_id = tutor.tutor_id inner join student on tutor.clarion_id = student.clarion_id where time_difference is not null and visit.term = '" + term.ToString() + "' order by visit.tutor_id");
                        while (rd.Read())
                            {
                                if (newid == int.Parse(rd[0].ToString()))
                                {
                                    count++;
                                   
                                }
                                else
                                {
                                    if (newid != -1)
                                        listBoxReport.Items.Add(first.PadRight(40 - first.Length) + "\t" + last.PadRight(40 - (last.Length)) + "\t" + count);
                                    newid = int.Parse(rd[0].ToString());
                                    count = 1;
                                    first = rd[5].ToString();
                                    last = rd[4].ToString();
                                }
                            }
                        if (newid != -1)
                        listBoxReport.Items.Add(first.PadRight(40 - first.Length) + "\t" + last.PadRight(40 - (last.Length)) + "\t" + count);
                        
                    }
                    
                    listBoxReport.Items.Add("");
                    break;

                case "Course":
                    column = "SUBJECT, COUNT(*), term";
                    table = "VISIT";
                    count = 0;
                    condition = "where term = '"+term.ToString()+"' GROUP BY SUBJECT, term";
                    if (comboFilter.SelectedItem.ToString() == "All")
                    {
                        listBoxReport.Items.Add("Courses");
                        rd = conn.GetReader(column, table, condition);
                        while (rd.Read())
                        {
                            for (int i = 0; i < 2; i++)
                                row += rd[i].ToString().PadRight(80 - rd[i].ToString().Length) + "\t";
                            listBoxReport.Items.Add(row);
                            row = "";
                        }
                    }
                    else if (comboFilter.SelectedItem.ToString() == "Total Courses")
                    {
                        listBoxReport.Items.Add("Total Courses");
                        rd = conn.GetReader(column, table, condition);
                        while (rd.Read())
                        {
                            //for (int i = 0; i < rd.FieldCount; i++)
                            count++;
                        }
                        listBoxReport.Items.Add("total courses ".PadRight(80 - 14) + "\t" + count);
                           
                    }
                    else
                    {
                        listBoxReport.Items.Add(comboFilter.SelectedItem.ToString());
                        condition = "where term = '" + term.ToString() + "' and subject = '" + comboFilter.SelectedItem.ToString() + "' GROUP BY SUBJECT, term";

                        rd = conn.GetReader(column, table, condition);

                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                for (int i = 0; i < 2; i++)
                                    row += rd[i].ToString().PadRight(80 - rd[i].ToString().Length) + "\t";
                                listBoxReport.Items.Add(row);
                                row = "";
                            }
                        }
                    }
                    listBoxReport.Items.Add("");
                    break;
                
                default:
                    column = "-1";
                    table = "-1";
                    break;
            }
            /*
            if (!((column == "-1") && (table == "-1")))
                if (comboFilter.SelectedIndex == 0)
                    if (condition != "")
                    {
MessageBox.Show("sfgfdsgfg");
                        rd = conn.GetReader(column, table, condition);
                        
                    }
                    else
                        rd = conn.GetReader(column, table);
                else
                    if (condition != "")
                    {

                        rd = conn.GetReader(column, table, filterColumn, comboFilter.SelectedItem.ToString(), condition);
                    }
                    else
                    {
                        MessageBox.Show("");
                        rd = conn.GetReader(column, table);
                    }
            else
                return;
            while (rd.Read())
            {
                for (int i = 0; i < rd.FieldCount; i++)
                    row += rd[i] + "\t";
                listBoxReport.Items.Add(row);
                listBoxReport.Items.Add("");
                row = "";
            }
           //  */
            /*
            if (comboCountCategory.SelectedItem.ToString() == "Method" && comboGroup.SelectedItem.ToString() == "Tutoring")
            {

            }
            else if (comboCountCategory.SelectedItem.ToString() == "Total Tutors")
            {

            }
            else if (comboCountCategory.SelectedItem.ToString() == "Total Tutor Hours")
            {
                selectString = "SELECT dateadd(second, SUM(DATEPART(SECOND, TIME_DIFFERENCE)),  108) FROM TUTOR_HOUR";
            }
            */
        }

        /* private void SwitchLocalReport(string selectedreportname)
         {
             dynamic CurrentReportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
         }
         * */

        //Created by Sean: Selects which query you want to fill in the reportViewer
        /*private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectString = "";
            if (comboCountCategory.SelectedItem.ToString() == "Total Visits")
            {
                selectString = DataConnection.GetSelectString("COUNT(*)", "VISIT");
            }
            else if (comboCountCategory.SelectedItem.ToString() == "Total Tutors")
            {

            }
            else if (comboCountCategory.SelectedItem.ToString() == "Total Tutor Hours")
            {
                selectString = "SELECT dateadd(second, SUM(DATEPART(SECOND, TIME_DIFFERENCE)),  108) FROM TUTOR_HOUR";
            }
            else if (comboCountCategory.SelectedItem.ToString() == "Total Hours Per Tutor")
            {

            }
            else if (comboCountCategory.SelectedItem.ToString() == "Total Hours Per Method")
            {

            }
            else if (comboCountCategory.SelectedItem.ToString() == "Total Hours Per Class")
            {

            }
        }
         * */

        private void comboAddTutoring_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Created by Sean: Clears report form
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            listBoxReport.Items.Clear();
        }

        //From report
        private void comboCountCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboFilter.Items.Clear();
            comboFilter.Items.Add("All");

            comboFilter.SelectedIndex = 0;
            if (comboCountCategory.SelectedItem.ToString() == "Method")
            {
                DataConnection conn = new DataConnection();
                conn.Open();
                SqlDataReader rd = conn.GetReader("DISTINCT METHOD", "VISIT");
                while (rd.Read())
                    comboFilter.Items.Add(rd[0].ToString());
                conn.Close();
                /*
                comboGroup.Items.Add("Tutoring");
                comboGroup.Items.Add("Group Meeting");
                comboGroup.Items.Add("Supplemental Instruction");
                comboGroup.Items.Add("Writing Center");
                comboGroup.Items.Add("Computer Use");
                comboGroup.Items.Add("Self Study");
                comboGroup.Items.Add("Video");
                comboGroup.Items.Add("Other");
                */
                
            }
            else if (comboCountCategory.SelectedItem.ToString() == "Student")
            {
                comboFilter.Items.Add("Total Hours");
                comboFilter.Items.Add("Visits");

            }
            else if (comboCountCategory.SelectedItem.ToString() == "Tutor")
            {
                comboFilter.Items.Add("Hours Tutoring");
                comboFilter.Items.Add("Students Tutored");
            }
            else if (comboCountCategory.SelectedItem.ToString() == "Course")
            {
                DataConnection conn = new DataConnection();
                conn.Open();
                SqlDataReader rd = conn.GetReader("DISTINCT subject", "VISIT");
                while (rd.Read())
                    comboFilter.Items.Add(rd[0].ToString());
                conn.Close();
                comboFilter.Items.Add("Total Courses");
            }
        }
        //From report
        private void comboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //from report
        private void comboTerm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            listBoxReport.BeginUpdate();
            int numSelected = listBoxReport.SelectedItems.Count;
            for (int i = 0;i<numSelected;i++)
                if (listBoxReport.SelectedIndices[i] > 0)
                {
                    int toInsert = listBoxReport.SelectedIndices[i] - 1;
                    listBoxReport.Items.Insert(toInsert, listBoxReport.SelectedItems[i]);
                    listBoxReport.Items.RemoveAt(toInsert + 2);
                    listBoxReport.SelectedItem = listBoxReport.Items[toInsert];
                }
            listBoxReport.EndUpdate();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            listBoxReport.BeginUpdate();
            int numSelected = listBoxReport.SelectedItems.Count;
            for (int i = numSelected-1; i >= 0; i--)
                if (listBoxReport.SelectedIndices[i] < listBoxReport.Items.Count-1)
                {
                    int toInsert = listBoxReport.SelectedIndices[i] + 2;
                    listBoxReport.Items.Insert(toInsert, listBoxReport.SelectedItems[i]);
                    listBoxReport.Items.RemoveAt(toInsert - 2);
                    listBoxReport.SelectedItem = listBoxReport.Items[toInsert - 1];
                }
            listBoxReport.EndUpdate();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportCourses();
            ImportStudents();
            MessageBox.Show("Imports Complete.");
        }

        private void txtAddStudentID_TextChanged(object sender, EventArgs e)
        {

            if (txtAddStudentID.Text.Length == 8)
                comboAddMethod.Enabled = true;
            else
                comboAddMethod.Enabled = false;
        }

        private void AddVisitAcceptButton(object sender, System.EventArgs e)
        {
            this.AcceptButton = this.btnAddVisit;
        }

        private void EditVisitAcceptButton(object sender, System.EventArgs e)
        {
            this.AcceptButton = this.btnEditVisit;
        }

        private void listBoxLoggedIn_GotFocus(object sender, System.EventArgs e)
        {
            this.AcceptButton = this.btnLogOut;
        }

        private void btnFullReport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This may take a very long time, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                return;
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
                DataConnection conn = new DataConnection();
                conn.Open();
                SqlDataReader rd = conn.GetReader("*", "VISIT", "WHERE TERM = '" + DataConnection.getTerm(int.Parse(txtYear.Text),comboTerm.SelectedItem.ToString()).ToString() + "'");
                if (!rd.HasRows)
                    MessageBox.Show("Found no visits with the current selected term.\nAborting report generation.", "No Visits Found");
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                for (int i = 0; i < rd.FieldCount; i++)
                    xlWorkSheet.Cells[1, i + 1] = rd.GetName(i);
                for (int i = 1; rd.Read(); i++)
                {
                    for (int j = 0; j < rd.FieldCount; j++)
                        xlWorkSheet.Cells[i + 1, j + 1].Value = rd[j].ToString();
                }
                conn.Close();

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
                xlApp.Quit();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            reportFile.Dispose();
            MessageBox.Show("Report Generation Complete!");
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            DataConnection conn = new DataConnection();
            conn.Open(); 
            try
            {
                conn.Query("insert into STUDENT ( clarion_id,lastname,firstname ) values (" + txtAddID.Text + ",'" + txtAddLast + "','" + txtAddFirst + "')");
            }
            catch
            {
                if (MessageBox.Show("Entry found with that StudentID. Update existing entry?", "Conflict", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    conn.Close();
                    return;
                }
                conn.Query("update STUDENT set lastname = '" + txtAddLast.Text + "', firstname = '" + txtAddFirst.Text + "' where clarion_id = '" + txtAddID.Text + "'");
            }
            conn.Close();
            MessageBox.Show("Entry added.");
            txtAddID.Clear();
            txtAddLast.Clear();
            txtAddFirst.Clear();
        }
    }
}
