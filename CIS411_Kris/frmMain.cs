
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS411
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void txtStudentID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnIdSearch.PerformClick();
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
            disableChangeID();
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
            frmAdmin adminForm = new frmAdmin();
            adminForm.Show();
        }

        private void rdoTutor_Click(object sender, EventArgs e)
        {
            // If student is registered as a tutor, asks if they are being tutored. Skips this if student is not a tutor
            if (isTutor(studentID))
            {
                if (MessageBox.Show("Are you being tutored?", "Tutoring", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    btnSubmit.Enabled = true;
                    comboClassList.SelectedIndex = 0;
                    comboClassList.Enabled = false;
                    return;
                }
            }
            // Initialize the comboTutors box if it hasn't been yet
            if (comboTutors.Items.Count==0)
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
            return (ID==99999999);
        }

        private void rdoOther_Click(object sender, EventArgs e)
        {
            if (comboTutors.Visible)
                comboTutors.Visible = false;
            comboClassList.Enabled = true;
        }

        private void comboClassList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((!(comboTutors.Visible)) && (comboClassList.SelectedIndex != 0))
                this.btnSubmit.Enabled = true;
        }

        private void comboTutors_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((comboTutors.SelectedIndex != 0) && (comboClassList.SelectedIndex != 0))
                this.btnSubmit.Enabled = true;
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            resetForm();
        }

        private string getName()
        {
            if (studentID == 99999999)
                return "William Warren";
            if (studentID == 11111111)
                return "Matthew Miller";
            else
                return "ERROR";
        }

        private int StripID(int old)
        {
            return old % 100000000;
        }

        //  Queries database for classes taken by student with ID cardNumber
        private void updateClassComboBox(int studentID)
        {
            comboClassList.Items.Add("Select a class...");
            comboClassList.Items.Add("CIS 411");
            comboClassList.Items.Add("CIS 402");
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

        private void signIn()
        {
            MessageBox.Show("You have been signed in");
            resetForm();
        }

        private void resetForm()
        {
            this.btnSwipe.Visible = true;
            this.txtStudentID.Text = "";
            this.txtStudentID.Visible = false;
            this.txtStudentID.ReadOnly = false;
            this.btnIdSearch.Visible = false;
            this.lblStudentID.Visible = false;
            this.btnForgotId.Visible = false;
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
        public bool studentIDExists(int searchID)
        {
            //CHANGE THIS
            return ((searchID == 99999999) || (searchID == 11111111));
        }

        public void updatetxtStudentID (int numIn)
        {
            studentID = StripID(numIn);
            btnSwipe.Visible = false;
            txtStudentID.Visible = true;
            txtStudentID.Text = studentID.ToString();
            txtStudentID.ReadOnly = true;
            initClassCombo();
            groupRadioButtons.Enabled = true;
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

        public void manualStudentIDEntry()
        {
            txtStudentID.Visible = true;
            txtStudentID.MaxLength = 8;
            btnSwipe.Visible = false;
            btnIdSearch.Visible = true;
            btnForgotId.Visible = true;
        }

        public void disableChangeID()
        {
            txtStudentID.ReadOnly = true;
            btnForgotId.Visible = false;
            btnIdSearch.Visible = false;
        }

        private int studentID = 0;
    }
}
