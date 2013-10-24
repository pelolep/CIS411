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
    public partial class frmSwipe : Form
    {
        public frmSwipe()
        {
            InitializeComponent();
            this.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSwipe_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9))
                cardNumber += e.KeyValue-48;
            if (cardNumber.Length >= 8)
            {
                int cardInt;
                if (int.TryParse(cardNumber, out cardInt))
                {
                    if (Program.mainForm.studentIDExists(cardInt))
                        if (Program.mainForm.studentSignedIn(cardInt))
                            Program.mainForm.signOut(cardInt);
                        else
                            Program.mainForm.updatetxtStudentID(cardInt);
                    else
                        MessageBox.Show("Invalid ID, please try again");
                    Program.mainForm.Focus();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid ID, please try again");
                    cardNumber = "";
                }
            }
        }
        /*
        private void btnDontHave_Click(object sender, EventArgs e)
        {
            Program.mainForm.manualStudentIDEntry();
            this.Close();
        }
        */
        string cardNumber = "";
    }
}
