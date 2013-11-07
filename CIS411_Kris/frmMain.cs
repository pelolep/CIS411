
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
    public static class Globals
    {
       //Here is the Password!!!!!
        public static String password= "CIS411"; 
        
    }

    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "insert into VISIT (DATE, TIME_IN, CLARION_ID, TERM, SUBJECT, CATALOG, TUTOR_ID, METHOD, SECTION) values ('" + System.DateTime.Today.ToString() + "','" + System.DateTime.UtcNow.TimeOfDay.ToString() + "','" + txtStudentID.Text + "','" + );
            cmd.ExecuteNonQuery();
            cmd.Clone();
            cn.Close();
            /*
            cn.Open();
            cmd.CommandText = "delete from VISIT where CLARION_ID='" + 123 + "' and LASTNAME= '" + "123" + "'";
            cmd.ExecuteNonQuery();
            cn.Close();
            */
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
                    comboClassList.SelectedIndex = 0;
                    comboClassList.Enabled = false;
                    comboTutors.SelectedIndex = 0;
                    comboTutors.Visible = false;
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
            return (ID == 10569779);
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
            /*            
            if (studentID == 99999999)
                return "William Warren";
            if (studentID == 11111111)
                return "Matthew Miller";
            else
                return "ERROR";
             */
            string name = "";
            int column = 0, f=0, l=0;
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=../../../VEN_LSC_SR_Project_Students_sample.xls;Extended Properties=Excel 12.0 Xml";
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
                    column = i;
                if (excelReader.GetName(i) == "FIRST_NAME")
                    f = i;
                if (excelReader.GetName(i) == "LAST_NAME")
                    l = i;
            }

            while (excelReader.Read())
            {

                if (excelReader[column].ToString() == studentID.ToString())
                {
                    name += excelReader[l].ToString();
                    name += " ";
                    name += excelReader[f].ToString();
                    excelConnection.Close();
                    return name;
                }
            }
            excelConnection.Close();
            return "ERROR";
        }
        //  Queries database for classes taken by student with ID cardNumber
        private void updateClassComboBox(int studentID)
        {
            string name = "";
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
            comboClassList.Items.Add("Select a class...");
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
            comboClassList.SelectedIndex = 0;
            comboClassList.Items.Add("Other");
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
        public string[] getTutors()
        {
            string[] tutors = new string[2];
            tutors[0] = "Kris Demor";
            tutors[1] = "Sean Fagan";
            return tutors;
        }

        // Searches through database for searchID and returns true if ID is found
        public bool studentIDExists(int numIn)
        {
            //return ((searchID == 99999999) || (searchID == 11111111));
            int column=0, searchID = StripID(numIn);
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\VEN_LSC_SR_Project_Students_sample.xls;Extended Properties=Excel 12.0 Xml";
            // Create the connection
            System.Data.OleDb.OleDbConnection excelConnection = new System.Data.OleDb.OleDbConnection(connectionString);
            string excelQuery = @"Select * from [Export Worksheet$]";
            System.Data.OleDb.OleDbCommand excelCommand = new System.Data.OleDb.OleDbCommand(excelQuery, excelConnection);
            excelConnection.Open();
            System.Data.OleDb.OleDbDataReader excelReader;
            excelReader = excelCommand.ExecuteReader();
            // Get student IDs
            for (int i = 0; i < excelReader.FieldCount; i++)
            {
                if (excelReader.GetName(i) == "EMPLID")
                        column = i;             
            }
            // Check to see if student ID exists in spreadsheet
            while (excelReader.Read())//ready
            {

                    if (excelReader[column].ToString() == searchID.ToString())
                    {
                        excelConnection.Close();
                        return true;
                    }
            }
            excelConnection.Close();
            return false;
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
        public bool studentSignedIn(int searchID)
        {
            return false; //CHANGE THIS
        }

        public void signOut(int searchID)
        {
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
        public int StripID(int old)
        {
            return old % 100000000;
        }

        private int studentID = 0;
        private bool usingCard = false;
    }
}
