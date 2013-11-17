
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
            /*
            cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");
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
                this.comboTutors.Items.AddRange(getTutors(false));
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

        }
        //  Queries database for classes taken by student with ID cardNumber
        private void updateClassComboBox(int studentID)
        {

            comboClassList.Items.Add("Select a class...");
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("term, subject, catalog, section, clarion_id", "student_course", "clarion_id", studentID.ToString()); 
            if (rd.HasRows)
            {
                
                while (rd.Read())
                {
                    comboClassList.Items.Add(rd[0].ToString() +" "+ rd[1].ToString() +" "+ rd[2].ToString() +" " + rd[3].ToString());
                }
            }
            conn.Close();
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
            DataConnection conn = new DataConnection();
            
            if (tutoring)
            {
                int tutorid = 0;
                SqlDataReader rd = conn.GetReader("*", "tutor", "clarion_id", studentID.ToString());
                if (rd.HasRows)
                {
                    tutorid = int.Parse(rd[0].ToString());
                }
                conn.Open();
                conn.Query("insert into tutor_hour(tutor_id,Date,Time_in)values('" + tutorid + "', '" + System.DateTime.Today.ToString("d") + "', '" + DateTime.Parse(DateTime.Now.ToString("HH:mm:ss tt")) + "')");

            }
            
            string[] selectedClass = comboClassList.SelectedItem.ToString().Split();
            if (comboTutors.Visible == false)
            {
                conn.Open();
                if (selectedClass[0].ToString() == "other")
                    conn.Query("insert into visit(clarion_id,date,time_in,term,subject,catalog,section,method)values('" + studentID + "', '" +System.DateTime.Today.ToString("d") + "','" + DateTime.Parse(DateTime.Now.ToString("HH:mm:ss tt")) + "','" + "other" + "','" + "other" + "','" + "other" + "','" + "other" + "', '" + "method" + "')");
                else
                    conn.Query("insert into visit(clarion_id,date,time_in,term,subject,catalog,section,method)values('" + studentID + "', '" +System.DateTime.Today.ToString("d") + "','" + DateTime.Parse(DateTime.Now.ToString("HH:mm:ss tt")) + "','" + selectedClass[0] + "','" + selectedClass[1] + "','" + selectedClass[2] + "','" + selectedClass[3] + "', '" + "method" + "')");
            }
            string[] selectedTutor={""};
            if (comboTutors.SelectedItem!=null)
                selectedTutor = comboTutors.SelectedItem.ToString().Split();
            conn.Open();
            try
            {
                if (selectedClass[0].ToString().ToLower() == "other")
                    conn.Query("insert into visit(clarion_id,date,time_in,term,subject,catalog,section,method)values('" + studentID + "', '" + DateTime.Today.ToString("d") + "','" + DateTime.Parse(DateTime.Now.ToString("HH:mm:ss tt")) + "','" + "other" + "','" + "other" + "','" + "other" + "','" + "other" + "', '" + "method" + "')");
                else
                conn.Query("insert into VISIT (DATE, TIME_IN, CLARION_ID, TERM, SUBJECT, CATALOG, TUTOR_ID, METHOD, SECTION) values ('" + System.DateTime.Today.ToString("d") + "','" + DateTime.Parse(DateTime.UtcNow.ToString("HH:mm:ss tt")) + "','" + txtStudentID.Text + "', '" + selectedClass[0] + "', '" + selectedClass[1] + "', '" + selectedClass[2] + "', '" + selectedTutor[0] + "' , '" + "method" + "', '" + selectedClass[3] + "')");

                //cmd.CommandText = "insert into VISIT (DATE, TIME_IN, CLARION_ID, TERM, SUBJECT, CATALOG, TUTOR_ID, METHOD, SECTION) values ('" + System.DateTime.Today.ToString() + "','" + System.DateTime.UtcNow.TimeOfDay.ToString() + "','" + txtStudentID.Text + "', '" + selectedClass[0].ToString() + "', '" + selectedClass[1].ToString() + "', '" + selectedClass[2].ToString() + "', '" + selectedTutor[0] + "' , '" + "method" + "', '" + selectedClass[3].ToString() + "')";
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                MessageBox.Show("Failed to sign in", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
            resetForm();
        }

        private void resetForm()
        {

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
        static public string[] getTutors(bool includeIDs = true)
        {
            List<string> tutorList = new List<string>();
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("STUDENT.FIRSTNAME, STUDENT.LASTNAME" + (includeIDs ? ", tutor.tutor_id" : ""), "TUTOR INNER JOIN STUDENT ON TUTOR.CLARION_ID=STUDENT.CLARION_ID", "STATUS","ACTIVE");
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    tutorList.Add((includeIDs ? rd[2].ToString() : "") + " " +rd[0] + " " + rd[1]);
                }
            }
            conn.Close();

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
            conn.Open();
            SqlDataReader rd = conn.GetReader("clarion_id, time_out", "visit", "clarion_id", searchID.ToString(), "time_out", "null");

            b = rd.HasRows;
            conn.Close();
            return b;

        }

        public void signOut(int searchID)
        {
            System.DateTime timein=DateTime.Parse("12:12:25"), timenow, timedifference; // sign out works for everything but searching for the time out
            DataConnection conn = new DataConnection();
            conn.Open();
            SqlDataReader rd = conn.GetReader("time_in, time_out", "visit", "clarion_id", studentID.ToString(), "time_out", "null");
            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    timein = DateTime.Parse( rd[0].ToString());
                }
                rd.Close();
            }
            else
            {
                conn.Close();
                return;
            }
 
            timenow = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss tt"));

            timedifference =DateTime.Parse( timenow.Subtract(timein).ToString());
            conn.Query("update visit set time_out = '" + timenow + "' , time_difference = '" + timedifference + "' where clarion_id= '" + studentID + "' and time_out is null");
            conn.Close();


            MessageBox.Show("You have been signed out."); //ADD TO THIS
            resetForm();
        }

        private void manualStudentIDEntry()
        {
            txtStudentID.Visible = true;
            txtStudentID.MaxLength = 8;
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
