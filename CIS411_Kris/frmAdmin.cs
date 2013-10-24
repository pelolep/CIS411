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

    public partial class frmAdmin : Form
    {

        public frmAdmin()
        {
            InitializeComponent();
        }

        //Adds Tutor ot the list of tutors via Student ID and adds their information to the Tutors table
        private void btnAddTutor_Click(object sender, EventArgs e)
        {
            //Gets the student id
            string studentID = txtTutorStudentID.Text;


            //Get student information from Student Database and Add to Tutors Table

            //Adds student name to the tutors enabled List
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
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string password = Globals.password;

            //Check that the Password matches the current Password entered by the user
            if (currentPassword != password)
            {
                MessageBox.Show( "Error: The password you used is incorrect");
            }
            else if (newPassword != confirmPassword)
            {
                MessageBox.Show("Error: The new password doesn't match");
            }
            else
            {
                MessageBox.Show("The password was changed");
                Globals.password = newPassword;
            }

        }
    }
}
