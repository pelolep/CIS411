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
    public partial class frmEditList : Form
    {
        static DateTime min;
        static DateTime max;
        static int ID;
        DateTime originalDateTime;

        public frmEditList(int studentID, DateTime minSearch, DateTime maxSearch)
        {
            InitializeComponent();
            loadvisits(studentID, minSearch, maxSearch);
            dateTimePickerEditTimeIn.Value = DateTime.Now;
            dateTimePickerEditTimeOut.Value = DateTime.Now;
        }

        public void loadvisits(int studentID, DateTime minDate, DateTime maxDate)
        {
            min = minDate;
            max = maxDate;
            ID = studentID;
            //clears the list box to enter new information
            listBoxEditVisit.Items.Clear();
            //TAB THIS
            listBoxEditVisit.Items.Add("DATE".PadRight(25) + " NAME".PadRight(60)+  "TIME IN".PadRight(25)+    "TIME OUT".PadRight(20)+ "METHOD");
            //creates new dataconnection
            DataConnection conn = new DataConnection();
            SqlDataReader rd;

            conn.Open();

                //gets visits request
                //just added STUDENT.FIRSTNAME, STUDENT.LASTNAME, STUDENT TABLE
                rd = conn.joinQuery("SELECT VISIT.CLARION_ID, VISIT.DATE, VISIT.TIME_IN, VISIT.TIME_OUT, STUDENT.FIRSTNAME, STUDENT.LASTNAME, VISIT.METHOD, TUTOR.TUTOR_ID, SUBJECT, CATALOG, S_TUTOR.FIRSTNAME AS TUTORFIRSTNAME, S_TUTOR.LASTNAME AS TUTORLASTNAME, SECTION FROM VISIT INNER JOIN student on visit.clarion_id = student.clarion_id LEFT JOIN TUTOR ON VISIT.TUTOR_ID = TUTOR.TUTOR_ID LEFT JOIN STUDENT S_TUTOR ON TUTOR.CLARION_ID = S_TUTOR.CLARION_ID WHERE visit.DATE<='" + maxDate + "' AND visit.DATE>='" + minDate + (studentID == 0 ? "'":"' AND VISIT.CLARION_ID = '" + studentID + "'") + " ORDER BY DATE, TIME_IN");


            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    DateTime thedate = DateTime.Parse(rd["DATE"].ToString());

                    listBoxEditVisit.Items.Add(thedate.ToString("d").PadRight(15) + "\t" + rd["FIRSTNAME"].ToString().PadRight(10) + "\t" + rd["LASTNAME"].ToString().PadRight(10) + "\t" + int.Parse(rd["CLARION_ID"].ToString()).ToString("D8").PadRight(5) + "\t" + rd["TIME_IN"].ToString().PadRight(10) + "\t" + rd["TIME_OUT"].ToString().PadRight(10) + "\t" + rd["METHOD"].ToString().PadRight(30) + "\t" + rd["TUTORFIRSTNAME"].ToString().PadRight(10) + " " + rd["TUTORLASTNAME"].ToString().PadRight(10) + "\t" + rd["SUBJECT"].ToString().PadRight(10) + "\t" + rd["CATALOG"].ToString().PadRight(5) + "\t" + rd["SECTION"].ToString().PadRight(10));

                }
            }
            rd.Close();
            //closes connection
            conn.Close();

            if (studentID == 0)
            {
                conn.Open();

                //gets visits request
                //just added STUDENT.FIRSTNAME, STUDENT.LASTNAME, STUDENT TABLE
               // rd = conn.joinQuery("SELECT VISIT.CLARION_ID, VISIT.DATE, VISIT.TIME_IN, VISIT.TIME_OUT, STUDENT.FIRSTNAME, STUDENT.LASTNAME, VISIT.METHOD, TUTOR.TUTOR_ID, SUBJECT, CATALOG, S_TUTOR.FIRSTNAME AS TUTORFIRSTNAME, S_TUTOR.LASTNAME AS TUTORLASTNAME, SECTION FROM VISIT INNER JOIN student on visit.clarion_id = student.clarion_id LEFT JOIN TUTOR ON VISIT.TUTOR_ID = TUTOR.TUTOR_ID LEFT JOIN STUDENT S_TUTOR ON TUTOR.CLARION_ID = S_TUTOR.CLARION_ID WHERE visit.DATE<='" + maxDate + "' AND visit.DATE>='" + minDate + (studentID == 0 ? "'" : "' AND VISIT.CLARION_ID = '" + studentID + "'") + " ORDER BY DATE, TIME_IN");
                rd = conn.joinQuery("select tutor_hour.tutor_id, tutor_hour.date, tutor_hour.time_out ,tutor_hour.time_difference, tutor_hour.time_in, student.lastname, student.firstname from tutor_hour inner join tutor on tutor_hour.tutor_id = tutor.tutor_id inner join student on tutor.clarion_id = student.clarion_id where tutor_hour.DATE<='" + maxDate + "' AND tutor_hour.DATE>='" + minDate+"' ");


                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        DateTime thedate = DateTime.Parse(rd["DATE"].ToString());

                        listBoxEditVisit.Items.Add(thedate.ToString("d").PadRight(15) + "\t" + rd["FIRSTNAME"].ToString().PadRight(10) + "\t" + rd["LASTNAME"].ToString().PadRight(10) + "\t" + rd["tutor_ID"].ToString().PadRight(5) + "\t" + rd["TIME_IN"].ToString().PadRight(10) + "\t" + rd["TIME_OUT"].ToString().PadRight(10) + "\t" + "i'm_a_tutor");

                    }
                }
                rd.Close();
                //closes connection
                conn.Close();
            }
        }
        private void btnEditSelectedVisit_Click(object sender, EventArgs e)
        {
            string[] selectedVisitEdit;
            try
            {
                selectedVisitEdit = listBoxEditVisit.SelectedItem.ToString().Split('\t');
                
                
            }
            catch
            {
                return;
            }
            string dateEdit = selectedVisitEdit[0];
            DateTime TimeInEdit = DateTime.Parse(selectedVisitEdit[4].ToString());
            originalDateTime = TimeInEdit;


            if (selectedVisitEdit[3] != null)
            {
                DateTime TimeOutEdit = DateTime.Parse(selectedVisitEdit[5]);
                dateTimePickerEditTimeOut.Value = TimeOutEdit;
            }
            txtEditDate.Text = dateEdit;
            txtEditStudentID.Text = selectedVisitEdit[3];

            comboEditMethod.Items.Clear();
            DataConnection conn = new DataConnection();
            try
            {
               
                conn.Open();
                SqlDataReader rd = conn.GetReader("DISTINCT METHOD", "VISIT");
                while (rd.Read())
                    comboEditMethod.Items.Add(rd[0].ToString());
                conn.Close();
                for (int i = 0; i < Properties.Settings.Default.MethodNames.Count; i++)
                {
                    if (!(comboEditMethod.Items.Contains(Properties.Settings.Default.MethodNames[i])))
                        comboEditMethod.Items.Add(Properties.Settings.Default.MethodNames[i]);
                }
                for (int i = 0; i < comboEditMethod.Items.Count; i++)
                    if (selectedVisitEdit[6] == comboEditMethod.Items[i].ToString())
                        comboEditMethod.SelectedIndex = i;
                comboEditMethod.Items.Add("is_a_tutor");
                comboaddClass.Items.Clear();
                conn.Open();
                rd = conn.GetReader("SUBJECT, CATALOG, SECTION", "STUDENT_COURSE", "CLARION_ID", selectedVisitEdit[3]);
                while (rd.Read())
                    comboaddClass.Items.Add(rd[0].ToString() + " " + rd[1] + " " + rd[2]);
                conn.Close();
                comboaddClass.Items.Add("Other");
                for (int i = 0; i < comboaddClass.Items.Count; i++)
                    if (selectedVisitEdit[8] + " " + selectedVisitEdit[9] + " " + selectedVisitEdit[10] == comboaddClass.Items[i].ToString())
                        comboaddClass.SelectedIndex = i;
                conn.Open();
                rd = conn.GetReader("FIRSTNAME, LASTNAME", "TUTOR INNER JOIN STUDENT ON STUDENT.CLARION_ID = TUTOR.CLARION_ID");
                while (rd.Read())
                    comboAddTutoring.Items.Add(rd[0].ToString() + " " + rd[1]);
                conn.Close();
                for (int i = 0; i < comboAddTutoring.Items.Count; i++)
                    if (selectedVisitEdit[7] == comboAddTutoring.Items[i].ToString())
                        comboAddTutoring.SelectedIndex = i;

                comboaddClass.Enabled = true;
                dateTimePickerEditTimeIn.Value = TimeInEdit;
                btnSaveEdit.Enabled = true;
                comboEditMethod.Enabled = true;
                dateTimePickerEditTimeIn.Enabled = true;
                dateTimePickerEditTimeOut.Enabled = true;
            }
            catch
            {
                dateTimePickerEditTimeIn.Enabled = true;
                dateTimePickerEditTimeOut.Enabled = true;
                btnSaveEdit.Enabled = true;
                conn.Close();
            }
            
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            TimeSpan timedifference;
            DateTime timeOut = DateTime.Parse(dateTimePickerEditTimeOut.Value.ToString("HH:mm:ss tt"));
            DateTime timeIn = DateTime.Parse(dateTimePickerEditTimeIn.Value.ToString("HH:mm:ss tt"));
            DateTime date = DateTime.Parse(txtEditDate.Text);
            string studentID = txtEditStudentID.Text;
            string method = "";
            string[] course = new string[10];
            string[] tutor = new string[10];
            bool istutor = false;
            try
            {
                
                method = comboEditMethod.SelectedItem.ToString();
                
                course = comboaddClass.SelectedItem.ToString().Split();
               
                if(comboAddTutoring.Enabled==true)
                tutor = comboAddTutoring.SelectedItem.ToString().Split();
                
            }
            catch
            {
                
                istutor = true;
            }
            //MessageBox.Show(istutor.ToString());
            string tutorID = null;
            DataConnection conn = new DataConnection();
            conn.Open();
            try
            {
                SqlDataReader rd = conn.GetReader("TUTOR_ID", "STUDENT INNER JOIN TUTOR ON STUDENT.CLARION_ID = TUTOR.CLARION_ID", "STUDENT.FIRSTNAME", tutor[0], "STUDENT.LASTNAME", tutor[1]);
                if (rd.HasRows)
                {
                    rd.Read();
                    tutorID = rd[0].ToString();
                }
                else if (comboAddTutoring.SelectedItem.ToString() == Properties.Settings.Default.TutoringMethod)
                {
                    MessageBox.Show("Please choose a tutor.");
                    conn.Close();
                    return;
                }
            }
            catch { }
            conn.Close();
            timedifference = timeOut.Subtract(timeIn);
            if (timedifference < TimeSpan.Zero)
            {
                MessageBox.Show("Sign out time is before sign in time. " + timeOut.ToString() + " " + timeIn.ToString() + " " + timedifference.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            conn.Open();
            if (istutor)
                conn.Query("update tutor_hour set tutor_ID = '" + txtEditStudentID.Text + "' , DATE = '" + date + "' , TIME_IN ='" + timeIn.ToString("HH:mm:ss tt") + "' , TIME_OUT = '" + timeOut.ToString("HH:mm:ss tt") + "' , TIME_DIFFERENCE = '" + timedifference.ToString("c") + "' where tutor_ID = '" + txtEditStudentID.Text + "' AND DATE = '" + date + "' AND TIME_IN ='" + originalDateTime.ToString("HH:mm:ss tt") + "'");
            else if(comboAddTutoring.Enabled)
                conn.Query("update VISIT set CLARION_ID = '" + txtEditStudentID.Text + "' , DATE = '" + date + "' , TIME_IN ='" + timeIn.ToString("HH:mm:ss tt") + "' , TIME_OUT = '" + timeOut.ToString("HH:mm:ss tt") + "' , TIME_DIFFERENCE = '" + timedifference.ToString("c") + "', SUBJECT = '" + course[0] + "', CATALOG = '" + course[1] + "', SECTION = '" + course[2] + "', TUTOR_ID = " + tutorID + ", METHOD = '" + method + "' where CLARION_ID = '" + txtEditStudentID.Text + "' AND DATE = '" + date + "' AND TIME_IN ='" + originalDateTime.ToString("HH:mm:ss tt") + "'");
            else
                conn.Query("update VISIT set CLARION_ID = '" + txtEditStudentID.Text + "' , DATE = '" + date + "' , TIME_IN ='" + timeIn.ToString("HH:mm:ss tt") + "' , TIME_OUT = '" + timeOut.ToString("HH:mm:ss tt") + "' , TIME_DIFFERENCE = '" + timedifference.ToString("c") + "', SUBJECT = '" + course[0] + "', CATALOG = '" + course[1] + "', SECTION = '" + course[2] + "', METHOD = '" + method + "' where CLARION_ID = '" + txtEditStudentID.Text + "' AND DATE = '" + date + "' AND TIME_IN ='" + originalDateTime.ToString("HH:mm:ss tt") + "'");

            conn.Close();
           // MessageBox.Show(date);
            MessageBox.Show("Visit has been edited.");
            this.Close();
        }

        private void comboEditMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboaddClass.Enabled = true;
            if (comboEditMethod.SelectedItem.ToString() == Properties.Settings.Default.TutoringMethod)
                comboAddTutoring.Enabled = true;
            else if (comboEditMethod.SelectedItem.ToString() == "is a tutor")
            {
                comboaddClass.Enabled = false;
                comboAddTutoring.Enabled = false;
            }
            else
            {
                comboAddTutoring.Enabled = false;
                comboAddTutoring.SelectedIndex = -1;
            }
        }

        private void btnDeleteVisit_Click(object sender, EventArgs e)
        {
            string[] items = listBoxEditVisit.SelectedItem.ToString().Split('\t');
            bool tutor = false;
            
            if (items[6] == "i'm_a_tutor")
                tutor = true;
            //MessageBox.Show(items[6]);
            DataConnection conn = new DataConnection();
            conn.Open();
            try
            {
                if(tutor)
                    conn.Query("DELETE FROM tutor_hour WHERE tutor_ID = '" + items[3] + "' AND DATE = '" + items[0] + "' AND TIME_IN = '" + items[4] + "' ");
                else
                conn.Query("DELETE FROM VISIT WHERE CLARION_ID = '" + items[3] + "' AND DATE = '" + items[0] + "' AND TIME_IN = '" + items[4]+"' ");
            }
            catch
            {
                MessageBox.Show("Error while attempting to delete visit. Please reload visit information and try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            loadvisits(ID,min,max);
        }

    }
}
