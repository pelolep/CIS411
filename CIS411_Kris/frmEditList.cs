﻿using System;
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
            listBoxEditVisit.Items.Add("DATE".PadRight(15) + "\t" + "FIRST NAME".PadRight(30) + "\t" + "LAST NAME".PadRight(30) + "\t" + "ID".PadRight(12)+ "\t" + "TIME IN".PadRight(10)+"\t" + "TIME OUT".PadRight(10) + "\t" + "METHOD".PadRight(20) + "\t" + "TUTOR'S FIRST NAME".PadRight(30) + "TUTOR'S LAST NAME".PadRight(30)+ "\t" + "SUBJECT" + "\t" + "CATALOG" + "\t" + "SECTION");
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
                    string TIMEOUT = rd["TIME_OUT"].ToString().PadRight(10);
                    if (TIMEOUT.Replace(" ","").Length !=8)
                        TIMEOUT = " ".PadRight(18);
                    listBoxEditVisit.Items.Add(thedate.ToString("d").PadRight(15) + "\t" + rd["FIRSTNAME"].ToString().PadRight(30) + "\t" + rd["LASTNAME"].ToString().PadRight(30) + "\t" + (int.Parse(rd["CLARION_ID"].ToString())).ToString("D8").PadRight(12) + "\t" + rd["TIME_IN"].ToString().PadRight(10) + "\t" + TIMEOUT.PadRight(10) + "\t" + rd["METHOD"].ToString().PadRight(20) + "\t" + rd["TUTORFIRSTNAME"].ToString().PadRight(30) + " " + rd["TUTORLASTNAME"].ToString().PadRight(30) + "\t" + rd["SUBJECT"].ToString().PadRight(5) + "\t" + ((rd["CATALOG"]).ToString()).PadRight(5) + "\t" + ((rd["SECTION"]).ToString()).PadRight(4));
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
                        string TIMEOUT = rd["TIME_OUT"].ToString().PadRight(10);
                        if (TIMEOUT.Replace(" ", "").Length != 8)
                            TIMEOUT = " ".PadRight(18); 
                        listBoxEditVisit.Items.Add(thedate.ToString("d").PadRight(15) + "\t" + rd["FIRSTNAME"].ToString().PadRight(30) + "\t" + rd["LASTNAME"].ToString().PadRight(30) + "\t" + ("TUT" + int.Parse(rd["tutor_ID"].ToString()).ToString("D4").PadRight(10)) + "\t" + rd["TIME_IN"].ToString().PadRight(10) + "\t" + rd["TIME_OUT"].ToString().PadRight(10) + "\t" + "TUTOR");
                    }
                }
                rd.Close();
                //closes connection
                conn.Close();
            }
        }
        private void btnEditSelectedVisit_Click(object sender, EventArgs e)
        {
            if ((listBoxEditVisit.SelectedIndex == 0)||(listBoxEditVisit.SelectedIndices.Count>1))
                return;
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
                try
                {
                    DateTime TimeOutEdit = DateTime.Parse(selectedVisitEdit[5]);
                
                dateTimePickerEditTimeOut.Value = TimeOutEdit;
                }
                catch {
                   // dateTimePickerEditTimeOut.Value = null;
                }
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
                    if (selectedVisitEdit[6].ToString().TrimEnd() == comboEditMethod.Items[i].ToString())
                        comboEditMethod.SelectedIndex = i;
                comboEditMethod.Items.Add("Tutor");
                comboaddClass.Items.Clear();
                conn.Open();
                rd = conn.GetReader("SUBJECT, CATALOG, SECTION", "STUDENT_COURSE", "CLARION_ID", selectedVisitEdit[3]);
                while (rd.Read())
                    comboaddClass.Items.Add(rd[0].ToString() + " " + rd[1] + " " + rd[2]);
                conn.Close();
                comboaddClass.Items.Add("Other");
                conn.Open();
                rd = conn.GetReader("SUBJECT, CATALOG, SECTION", "VISIT", "CLARION_ID", selectedVisitEdit[3], "DATE", selectedVisitEdit[0], "TIME_IN", selectedVisitEdit[4]);
                rd.Read();
                if (rd[0].ToString() == "other")
                    for (int i = 0; i < comboaddClass.Items.Count; i++)
                        if (comboaddClass.Items[i].ToString() == "Other")
                            comboaddClass.SelectedIndex = i;
                for (int i = 0; i < comboaddClass.Items.Count; i++)
                    if (rd[0] + " " + rd[1] + " " + rd[2] == comboaddClass.Items[i].ToString())
                        comboaddClass.SelectedIndex = i;
                conn.Close();
                conn.Open();
                rd = conn.GetReader("FIRSTNAME, LASTNAME", "TUTOR INNER JOIN STUDENT ON STUDENT.CLARION_ID = TUTOR.CLARION_ID");
                while (rd.Read())
                    comboAddTutoring.Items.Add(rd[0].ToString() + " " + rd[1]);
                conn.Close();
                for (int i = 0; i < comboAddTutoring.Items.Count; i++)
                    if (selectedVisitEdit[7].ToString() == comboAddTutoring.Items[i].ToString())
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
            btnDeleteVisit.Enabled = false;
            
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
                if (course[0].ToString().ToLower() == "other")
                {
                    course = new string[10];
                    course[0] = "other";
                    course[1] = "other";
                    course[2] = "other";
                    course[3] = "other";
                }
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
            try
            {
                if (istutor)
                    conn.Query("update tutor_hour set tutor_ID = '" + txtEditStudentID.Text.Remove(0, 3) + "' , DATE = '" + date + "' , TIME_IN ='" + timeIn.ToString("HH:mm:ss tt") + "' , TIME_OUT = '" + timeOut.ToString("HH:mm:ss tt") + "' , TIME_DIFFERENCE = '" + timedifference.ToString("c") + "' where tutor_ID = '" + txtEditStudentID.Text.Remove(0, 3) + "' AND DATE = '" + date + "' AND TIME_IN ='" + originalDateTime.ToString("HH:mm:ss tt") + "'");
                else if (comboAddTutoring.Enabled)
                    conn.Query("update VISIT set CLARION_ID = '" + txtEditStudentID.Text + "' , DATE = '" + date + "' , TIME_IN ='" + timeIn.ToString("HH:mm:ss tt") + "' , TIME_OUT = '" + timeOut.ToString("HH:mm:ss tt") + "' , TIME_DIFFERENCE = '" + timedifference.ToString("c") + "', SUBJECT = '" + course[0] + "', CATALOG = '" + course[1] + "', SECTION = '" + course[2] + "', TUTOR_ID = " + tutorID + ", METHOD = '" + method + "'" + ((comboaddClass.SelectedItem.ToString()=="Other") ? ", TERM='Other'" : "") + " where CLARION_ID = '" + txtEditStudentID.Text + "' AND DATE = '" + date + "' AND TIME_IN ='" + originalDateTime.ToString("HH:mm:ss tt") + "'");
                else
                    conn.Query("update VISIT set CLARION_ID = '" + txtEditStudentID.Text + "' , DATE = '" + date + "' , TIME_IN ='" + timeIn.ToString("HH:mm:ss tt") + "' , TIME_OUT = '" + timeOut.ToString("HH:mm:ss tt") + "' , TIME_DIFFERENCE = '" + timedifference.ToString("c") + "', SUBJECT = '" + course[0] + "', CATALOG = '" + course[1] + "', SECTION = '" + course[2] + "', METHOD = '" + method + "'" + ((comboaddClass.SelectedItem.ToString()=="Other") ? ", TERM='Other'" : "") + " where CLARION_ID = '" + txtEditStudentID.Text + "' AND DATE = '" + date + "' AND TIME_IN ='" + originalDateTime.ToString("HH:mm:ss tt") + "'");
            }
            catch
            {
                MessageBox.Show("Cannot save visit", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }
            conn.Close();
            MessageBox.Show("Visit has been edited.");
            this.Close();
        }

        private void comboEditMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboaddClass.Enabled = true;
            if (comboEditMethod.SelectedItem.ToString() == Properties.Settings.Default.TutoringMethod)
                comboAddTutoring.Enabled = true;
            else if (comboEditMethod.SelectedItem.ToString() == "Tutor")
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
            if (MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (listBoxEditVisit.SelectedIndex == 0)
                    return;
                string[] items;
                bool tutor;
                for (int i = 0; i < listBoxEditVisit.SelectedItems.Count; i++)
                {
                    items = listBoxEditVisit.SelectedItems[i].ToString().Split('\t');
                    tutor = false;

                    if (items[3].Remove(3) == "TUT")
                        tutor = true;
                    //MessageBox.Show(items[6]);
                    DataConnection conn = new DataConnection();
                    conn.Open();
                    try
                    {
                        if (tutor)
                            conn.Query("DELETE FROM tutor_hour WHERE tutor_ID = '" + items[3].Remove(0, 3) + "' AND DATE = '" + items[0] + "' AND TIME_IN = '" + items[4] + "' ");
                        else
                            conn.Query("DELETE FROM VISIT WHERE CLARION_ID = '" + items[3] + "' AND DATE = '" + items[0] + "' AND TIME_IN = '" + items[4] + "' ");
                    }
                    catch
                    {
                        MessageBox.Show("Error while attempting to delete visit. Please reload visit information and try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }
                loadvisits(ID, min, max);
            }
        }

    }
}
