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

        private void frmSwipe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                cardNumber += (e.KeyChar-'0').ToString();
            else if ((e.KeyChar == '\r'))
            {
                int cardInt;
                if (int.TryParse(cardNumber, out cardInt))
                {
                    if (frmMain.studentIDExists(frmMain.StripID(cardInt)))
                        if (frmMain.studentSignedIn(frmMain.StripID(cardInt)))
                            frmMain.signOut(cardInt);
                        else
                            Program.mainForm.updatetxtStudentID(frmMain.StripID(cardInt));
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
            else
            {
                MessageBox.Show(e.KeyChar.ToString());
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
