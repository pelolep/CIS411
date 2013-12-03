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
        public frmEditList(int studentID, DateTime minSearch, DateTime maxSearch)
        {
            InitializeComponent();
            loadvisits(studentID, minSearch, maxSearch);
        }

        private frmAdmin adminForm = null;
        public frmEditList(Form callingForm)
    {
        adminForm = callingForm as frmAdmin; 
        InitializeComponent();
    }
            

         public void loadvisits(int studentID, DateTime minDate, DateTime maxDate)
        {
            //clears the list box to enter new information
            listBoxEditVisit.Items.Clear();
            //TAB THIS
            listBoxEditVisit.Items.Add("DATE NAME TIME IN    TIME OUT METHOD");
            //creates new dataconnection
            DataConnection conn = new DataConnection();

            conn.Open();
            if (studentID == 0)
            {
                //gets visits request
                //just added STUDENT.FIRSTNAME, STUDENT.LASTNAME, STUDENT TABLE
                SqlDataReader rd = conn.joinQuery("SELECT VISIT.CLARION_ID, VISIT.DATE, VISIT.TIME_IN, VISIT.TIME_OUT, STUDENT.FIRSTNAME, STUDENT.LASTNAME, VISIT.METHOD FROM VISIT INNER JOIN student on visit.clarion_id = student.clarion_id WHERE visit.DATE<'" + maxDate + "' AND visit.DATE>'" + minDate + "'");


                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        DateTime thedate = DateTime.Parse(rd["DATE"].ToString());


                       // if (thedate >= minDate && thedate <= maxDate)
                            //TAB THIS
                            listBoxEditVisit.Items.Add(thedate.ToString("d") + "\t\t" + rd["FIRSTNAME"] + "\t\t" + rd["LASTNAME"] + "\t\t" + rd["TIME_IN"] + "\t\t" + rd["TIME_OUT"] + "\t\t" + rd["METHOD"]);
                        // else(thedate >= minDate && thedate <= maxDate)
                        //   listBoxLoggedIn.Items.Add(thedate.ToString("MM/dd/yyyy") + " " + rd[1] + " " + rd[2] + " " + rd[4] + " " + rd[5] + " " + rd[6]);



                    }
                }
                rd.Close();


                //closes connection
                conn.Close();
            }
            else
            {
                //gets visits request
                //just added STUDENT.FIRSTNAME, STUDENT.LASTNAME, STUDENT TABLE
                SqlDataReader rd = conn.joinQuery("SELECT VISIT.CLARION_ID, VISIT.DATE, VISIT.TIME_IN, VISIT.TIME_OUT, STUDENT.FIRSTNAME, STUDENT.LASTNAME, VISIT.METHOD FROM VISIT INNER JOIN student on visit.clarion_id = student.clarion_id WHERE visit.DATE<'" + maxDate + "' AND visit.DATE>'" + minDate +"' AND VISIT.CLARION_ID = '" + studentID + "'");


                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        DateTime thedate = DateTime.Parse(rd["DATE"].ToString());

                            listBoxEditVisit.Items.Add(thedate.ToString("d") + "/t/t" + rd["FIRSTNAME"] + "/t/t" + rd["LASTNAME"] + "/t/t" + rd["TIME_IN"] + "/t/t" + rd["TIME_OUT"] + "/t/t" + rd["METHOD"]);

                    }
                }
                rd.Close();


                //closes connection
                conn.Close();
            }


        }
        private void btnEditSelectedVisit_Click(object sender, EventArgs e)
        {
            string[] selectedVisitEdit = listBoxEditVisit.SelectedItem.ToString().Split();
            string dateEdit = selectedVisitEdit[0];
            DateTime TimeInEdit = DateTime.Parse(selectedVisitEdit[3]);

            /*if (selectedVisitEdit[2] != "")
            {
                DateTime TimeOutEdit = DateTime.Parse(selectedVisitEdit[2]);
                dateTimePickerEditTimeOut.Value = TimeOutEdit;
            }*/
            if (selectedVisitEdit[4] != null)
            {
                DateTime TimeOutEdit =DateTime.Parse(selectedVisitEdit[4]);
                this.adminForm.dateTimePickerEditTimeOut.Value = TimeOutEdit;
            }
            this.adminForm.txtEditDate.Text = dateEdit;
            this.adminForm.dateTimePickerEditTimeIn.Value = TimeInEdit;
            this.adminForm.comboEditMethod.SelectedItem = selectedVisitEdit[5];
        }
       
    }
}
