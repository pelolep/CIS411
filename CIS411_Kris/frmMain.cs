
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CIS411
{

    public partial class frmMain : Form
    {
        bool tutoring;
        /*
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader rd;
        */
        public frmMain()
        {
            InitializeComponent();
            tutoring = false;
<<<<<<< HEAD
            /*
            cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");
=======
            cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\matt\Documents\GitHub\CIS411\CIS411_Kris\db.mdf;Integrated Security=True");
>>>>>>> origin/Matt8
            cmd = new SqlCommand();
            cn.Open(); //TESTING DATABASE
            cn.Close();
            cmd.Connection = cn;
            */
        }

        private void txtStudentID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        { 
            if (txtStudentID.Text == "")
            {
                // Starts a timer to see if user is swiping a card.
                // keyTimer sets usingCard to false in 200 ms
                usingCard = true;
                keyTimer.Start();
            }
            /*
             * if (e.KeyCode == Keys.Enter)
                btnIdSearch.PerformClick();
             */
            else if ((txtStudentID.TextLength == 8)&&(usingCard))
            {
                // If student is swiping card, first character must be stripped from ID textbox because it is an extraneous 9.
                txtStudentID.Text = txtStudentID.Text.Remove(0, 1);
                txtStudentID.Select(7, 0);
            }
        }

        private void keyTimer_Tick(object sender, EventArgs e)
        {
            usingCard = false;
            keyTimer.Stop();
        }

        private void btnIdSearch_Click(object sender, EventArgs e)
        {
            //Check for StudentId Number in textbox
            if (!(int.TryParse(txtStudentID.Text, out studentID)))
            {
                MessageBox.Show("Invalid Student ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!(studentIDExists(studentID)))
            {
                MessageBox.Show("Student ID does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you " + getName() + "?", "ID Validation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            //Check Visits Table for not-signed in
            if (studentSignedIn(studentID))
            {
                //If signed in, then logout student and display "Thank you for logging out" Message
                signOut(studentID);
                MessageBox.Show("Thank you for signing out.");
                return;
            }
            
            //Import classes information into the classes dropdown menu
            initClassCombo();
            groupRadioButtons.Enabled = true;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
=======
            if (tutoring)
            {
                cn.Open();
                cmd.CommandText = "select";
                cmd.ExecuteNonQuery();                                                                                                                                                                                                                                              
                cmd.Clone();
                cn.Close();
            }

string[] words = comboClassList.SelectedItem.ToString().Split();
           
           /*
            try
            {
                cn.Open();
                cmd.CommandText = "select * from course where term = '" + words[0] + "', subject = '"+words[1]+"'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
               
            catch { }
 */
            cn.Close();
            
            string[] tutors = comboTutors.SelectedItem.ToString().Split();
            cn.Open();
            try
            {
                cmd.CommandText = "insert into VISIT (DATE, TIME_IN, CLARION_ID, TERM, SUBJECT, CATALOG, TUTOR_ID, METHOD, SECTION) values ('" + System.DateTime.Today.ToString() + "','" + System.DateTime.UtcNow.TimeOfDay.ToString() + "','" + txtStudentID.Text + "', '" +words[0].ToString() + "', '" + words[1].ToString() + "', '" + words[2].ToString() + "', '" + tutors[0] + "' , '" + "method" + "', '" + words[3].ToString() + "')";
            }
            catch 
            {
               
            }
                
                // cmd.CommandText = "insert into VISIT (DATE, TIME_IN, CLARION_ID, TERM, SUBJECT, CATALOG, METHOD, SECTION) values ('" + System.DateTime.Today.ToString() + "','" + System.DateTime.UtcNow.TimeOfDay.ToString() + "','" + txtStudentID.Text + "', '" + "term" + "', '" + words[0] + "', '" + words[1] + "', '" + "method" + "', '" + words[2] + "')";
            cmd.ExecuteNonQuery();                                                                                                                                                                                                                                              
            cmd.Clone();
            cn.Close();
>>>>>>> origin/Matt8
            signIn();
        }

        private void btnSwipe_Click(object sender, EventArgs e)
        {
            frmSwipe swipeForm = new frmSwipe();
            swipeForm.Show();
        }

        private void btnForgotId_Click(object sender, EventArgs e)
        {
            frmSearchByName searchByNameForm = new frmSearchByName();
            searchByNameForm.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
                if (frm is frmAdminPass)
                {
                    frm.Focus();
                    return;
                }
            frmAdminPass adminPassForm = new frmAdminPass();
            adminPassForm.Show();
        }

        private void rdoTutor_Click(object sender, EventArgs e)
        {
            // If student is registered as a tutor, asks if they are being tutored. Skips this if student is not a tutor
            if ((isTutor(studentID))&&(MessageBox.Show("Are you being tutored?", "Tutoring", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No))
            {
                    btnSubmit.Enabled = true;
                  
                  //  comboClassList.SelectedIndex = 0;
                    comboClassList.Enabled = false;
                 //   comboTutors.SelectedIndex = 0;
                    comboTutors.Visible = false;
                    tutoring = true;
                    return;
            }
            // Otherwise, initialize the comboTutors box if it hasn't been yet
            else if (comboTutors.Items.Count==0)
            {
                this.comboTutors.Items.Add("Select a tutor...");
                this.comboTutors.Items.AddRange(getTutors());
                this.comboTutors.SelectedIndex = 0;

            }
            this.comboTutors.Visible = true;
            comboClassList.Enabled = true;
        }

        // Checks if student is registered as a tutor
        private bool isTutor(int ID)
        {
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("CLARION_ID", "TUTOR", "CLARION_ID", ID.ToString());
            bool b = rd.HasRows;
            conn.Close();
            return b;
            /*
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select clarion_id from tutor";

            rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                while (rd.Read())
                {

                    if (int.Parse(rd[0].ToString()) == ID)
                    { 
                        rd.Close();
                        cn.Close();
                        return true;
                    }
                }
            }
            rd.Close();
            cn.Close();
            return false;
            */
        }

        private void rdoOther_Click(object sender, EventArgs e)
        {
            if (comboTutors.Visible)
                comboTutors.Visible = false;
            comboClassList.Enabled = true;
        }

        private void comboClassList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((comboClassList.SelectedIndex == 0) || ((comboTutors.Visible) && (comboTutors.SelectedIndex == 0)))
                this.btnSubmit.Enabled = false;
            else if (comboClassList.SelectedIndex != 0)
                this.btnSubmit.Enabled = true;
        }

        private void comboTutors_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((comboTutors.SelectedIndex == 0) || (comboClassList.SelectedIndex == 0))
                this.btnSubmit.Enabled = false;
            else if ((comboTutors.SelectedIndex != 0) && (comboClassList.SelectedIndex != 0))
                this.btnSubmit.Enabled = true;
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            resetForm();
        }

        private void btnNoCard_Click(object sender, System.EventArgs e)
        {
            manualStudentIDEntry();
        }

        private string getName()
        {
            string name;
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("FIRSTNAME, MIDDLE_NAME, LASTNAME", "STUDENT", "CLARION_ID", studentID.ToString());
            if (rd.HasRows)
            {
                rd.Read();
                name = rd[0] + " " + rd[1] + " " + rd[2];
            }
            else
                name = "ERROR - name not found";
            conn.Close();
            return name;
            /*
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "SELECT FIRSTNAME, MIDDLE_NAME, LASTNAME FROM STUDENT WHERE CLARION_ID=" + studentID.ToString();
            rd = cmd.ExecuteReader();
            
            if (rd.HasRows)
            {
                rd.Read();
                name += rd[0] + " " + rd[1] + " " + rd[2];
                cn.Close();
                rd.Close();
                return name;
            }
            rd.Close();
            cn.Close();
            return "ERROR";
             */
        }
        //  Queries database for classes taken by student with ID cardNumber
        private void updateClassComboBox(int studentID)
        {
            //string name = "";
            //MessageBox.Show("");
            comboClassList.Items.Add("Select a class...");
<<<<<<< HEAD
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("subject, catalog", "student_course", "clarion_id", studentID.ToString());
=======
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select subject, catalog, clarion_ID, section, term from student_course where clarion_ID = '"+studentID+"'";

            rd = cmd.ExecuteReader();
>>>>>>> origin/Matt8
            
            if (rd.HasRows)
            {
                while (rd.Read())
                {
<<<<<<< HEAD
                    //if (!(comboClassList.Items.Contains(rd[0].ToString() + rd[1].ToString())))
                        comboClassList.Items.Add(rd[0].ToString() + rd[1].ToString());
=======
                    comboClassList.Items.Add(rd[4] + " " +rd[0].ToString() + rd[1].ToString() + " " +rd[3]);
>>>>>>> origin/Matt8
                }
            }
            conn.Close();
            /*

            <<<<<<< HEAD







            int column = 0, s=0, c = 0;
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=../../../VEN_LSC_SR_Project_Courses_sample.xls;Extended Properties=Excel 12.0 Xml";
            //Create the connection
            System.Data.OleDb.OleDbConnection excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
            string excelQuery = @"Select * from [sheet1$]";
            System.Data.OleDb.OleDbCommand excelCommand = new System.Data.OleDb.OleDbCommand(excelQuery, excelConnection);
            excelConnection.Open();
            System.Data.OleDb.OleDbDataReader excelReader;
            excelReader = excelCommand.ExecuteReader();
            // Get classes from Excel sheet
            for (int i = 0; i < excelReader.FieldCount; i++)
            {
                if (excelReader.GetName(i) == "ID")
                    column = i;
                else if (excelReader.GetName(i) == "Subject")
                    s = i;
                else if (excelReader.GetName(i) == "Catalog")
                    c = i;
            }
            // Add class names to comboClassList
            while (excelReader.Read())
            {

                if (excelReader[column].ToString() == studentID.ToString())
                {
                    name += excelReader[s].ToString();
                    name += " ";
                    name += excelReader[c].ToString();
                    comboClassList.Items.Add(name);
                    name = "";
                }
            }
            excelConnection.Close();
            */
            comboClassList.Items.Add("Other");
            comboClassList.SelectedIndex = 0;
        }

        // Initializes classComboBox if it hasn't been yet
        private void initClassCombo()
        {
            if (comboClassList.Items.Count==0)
            {
                updateClassComboBox(studentID);
            }
        }

        // Adds an entry to the visits table with the information currently selected and resets the form
        private void signIn()
        {
            MessageBox.Show("You have been signed in");
            resetForm();
        }

        private void resetForm()
        {
            //this.btnSwipe.Visible = true;
            //this.btnNoCard.Visible = true;
            this.txtStudentID.Text = "";
            this.txtStudentID.Visible = true;
            this.txtStudentID.ReadOnly = false;
            this.btnIdSearch.Visible = true;
            this.lblStudentID.Visible = true;
            this.btnForgotId.Visible = true;
            this.btnIdSearch.Enabled = true;
            this.btnForgotId.Enabled = true;
            for (int i = 0; i < rdoMethods.Length; i++)
                this.rdoMethods[i].Checked = false;
            this.groupRadioButtons.Visible = true;
            this.groupRadioButtons.Enabled = false;
            this.comboClassList.Text = "";
            this.comboClassList.Items.Clear();
            this.comboClassList.Visible = true;
            this.comboClassList.Enabled = false;
            this.comboTutors.Items.Clear();
            this.comboTutors.Visible = false;
            this.comboTutors.Enabled = true;
            this.btnSubmit.Visible = true;
            this.btnSubmit.Enabled = false;
            studentID = 0;
        }

        // Returns array of all tutors
        static public string[] getTutors()
        {
            List<string> tutorList = new List<string>();
            /*string name = "";
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from tutor inner join student on tutor.clarion_id=student.clarion_id where status = '"+"active"+"'";
            rd = cmd.ExecuteReader();*/

            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("STUDENT.FIRSTNAME, STUDENT.LASTNAME", "TUTOR INNER JOIN STUDENT ON TUTOR.CLARION_ID=STUDENT.CLARION_ID", "STATUS","ACTIVE");

            if (rd.HasRows)
            {
                while (rd.Read())
                {
<<<<<<< HEAD
                    tutorList.Add(rd[0] + " " + rd[1]);
                    /*if (rd[0].ToString() == studentID.ToString())
                    {
=======
>>>>>>> origin/Matt8

                    
                        name +=rd[0]+ " " +rd[5] + " " + rd[6];
                        tutorList.Add(name);
<<<<<<< HEAD
                        tutors[i] = name;
                        i++;
                    }
                    name = "";*/
=======
                        //tutors[i] = name;
                        //i++;
                    
                    name = "";
>>>>>>> origin/Matt8
                }
            }
            conn.Close();
            /*
            rd.Close();
            cn.Close();
            */
            return tutorList.ToArray();
        }

        // Searches through database for searchID and returns true if ID is found
        static public bool studentIDExists(int numIn)
        {
            bool b;
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("CLARION_ID", "STUDENT", "CLARION_ID", numIn.ToString());
            b = rd.HasRows;
            conn.Close();
            return b;
            /*
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "SELECT CLARION_ID FROM STUDENT WHERE CLARION_ID=" + numIn.ToString();
            rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Close();
                cn.Close();
                return true;
            }
            rd.Close();
            cn.Close();
            return false;
            */
        }

        public void updatetxtStudentID (int numIn)
        {
            studentID = numIn;
            //btnSwipe.Visible = false;
            //btnNoCard.Visible = false;
            txtStudentID.Visible = true;
            txtStudentID.Text = studentID.ToString();
            //txtStudentID.ReadOnly = true;
            initClassCombo();
            //groupRadioButtons.Enabled = true;
        }

        // Queries database to see if student with searchID is already signed in
        static public bool studentSignedIn(int searchID)
        {
            bool b;
            DataConnection conn = new DataConnection();

            /*
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select clarion_id from visit where clarion_id='"+searchID+"' and time_out=NULL";

            rd = cmd.ExecuteReader();
            */
            SqlDataReader rd = conn.GetReader("clarion_id", "visit", "clarion_id", searchID.ToString(), "time_out", "DBNull");
            b = rd.HasRows;
            conn.Close();
            return b;
            /*
            if (rd.HasRows)
            {
                rd.Close();
                cn.Close();
                return true;
            }
            rd.Close();
            cn.Close();

            return false;
            */
        }

        public void signOut(int searchID)
        {
            System.DateTime timeout, timenow, timedifference;
            DataConnection conn = new DataConnection();
            conn.Open();

            SqlDataReader rd = conn.GetReader("time_in", "visits", "student_id", studentID.ToString() + " and time_out=DBNull");
            /*
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select time_in from visits where student_id= '" + studentID + "' and time_out=DBNull";
            */
            if (rd.HasRows)
            {
                timeout = DateTime.Parse(rd[0].ToString());
            }
            else
            {
                conn.Close();
                return;
            }
            /*
            rd.Close();
            cn.Close();
            */
            timenow = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss tt"));

            timedifference = DateTime.Parse(timenow.Subtract(timeout).TotalMinutes.ToString());
            conn.Query("update visits set time_out = '" + timenow + "' , time_difference = '" + timedifference + "' where clarion_id= '" + studentID + "' and time_out=DBNULL");
            conn.Close();
            /*
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "update visits set time_out = '" + timenow + "' , time_difference = '" + timedifference + "' where clarion_id= '" + studentID + "' and time_out=DBNULL";

            rd.Close();
            cn.Close();
            */

            MessageBox.Show("You have been signed out."); //ADD TO THIS
            resetForm();
        }

        private void manualStudentIDEntry()
        {
            txtStudentID.Visible = true;
            txtStudentID.MaxLength = 8;
            //btnSwipe.Visible = false;
            //btnNoCard.Visible = false;
            btnIdSearch.Visible = true;
            btnForgotId.Visible = true;
        }
        /*
        public void disableChangeID()
        {
            txtStudentID.ReadOnly = true;
            btnForgotId.Enabled = false;
            btnIdSearch.Enabled = false;
        }
        */
        static public int StripID(int old)
        {
            return old % 100000000;
        }

        private int studentID = 0;
        private bool usingCard = false;
    }
}
