namespace CIS411
{
    partial class frmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlAdmin = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabTutors = new System.Windows.Forms.TabPage();
            this.btnAddTutor = new System.Windows.Forms.Button();
            this.btnDisableSelected = new System.Windows.Forms.Button();
            this.btnDisableAll = new System.Windows.Forms.Button();
            this.btnEnableAll = new System.Windows.Forms.Button();
            this.btnEnableSelected = new System.Windows.Forms.Button();
            this.listBoxDisableTutors = new System.Windows.Forms.ListBox();
            this.listBoxEnableTutors = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTutorStudentID = new System.Windows.Forms.TextBox();
            this.tabVisits = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEditVisit = new System.Windows.Forms.Button();
            this.txtSignOut = new System.Windows.Forms.TextBox();
            this.txtSignIn = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.btnAddVisit = new System.Windows.Forms.Button();
            this.lblSignOut = new System.Windows.Forms.Label();
            this.lblSignIn = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblModifyVisit = new System.Windows.Forms.Label();
            this.lblLoggedIn = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.listBoxLoggedIn = new System.Windows.Forms.ListBox();
            this.tabPermission = new System.Windows.Forms.TabPage();
            this.grpBoxPassword = new System.Windows.Forms.GroupBox();
            this.listBoxAdminUsers = new System.Windows.Forms.ListBox();
            this.lblAdminUsers = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdminStudentID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControlAdmin.SuspendLayout();
            this.tabTutors.SuspendLayout();
            this.tabVisits.SuspendLayout();
            this.tabPermission.SuspendLayout();
            this.grpBoxPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabGeneral);
            this.tabControlAdmin.Controls.Add(this.tabTutors);
            this.tabControlAdmin.Controls.Add(this.tabVisits);
            this.tabControlAdmin.Controls.Add(this.tabPermission);
            this.tabControlAdmin.Location = new System.Drawing.Point(12, 12);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(658, 385);
            this.tabControlAdmin.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(650, 359);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabTutors
            // 
            this.tabTutors.Controls.Add(this.btnAddTutor);
            this.tabTutors.Controls.Add(this.btnDisableSelected);
            this.tabTutors.Controls.Add(this.btnDisableAll);
            this.tabTutors.Controls.Add(this.btnEnableAll);
            this.tabTutors.Controls.Add(this.btnEnableSelected);
            this.tabTutors.Controls.Add(this.listBoxDisableTutors);
            this.tabTutors.Controls.Add(this.listBoxEnableTutors);
            this.tabTutors.Controls.Add(this.label1);
            this.tabTutors.Controls.Add(this.txtTutorStudentID);
            this.tabTutors.Location = new System.Drawing.Point(4, 22);
            this.tabTutors.Name = "tabTutors";
            this.tabTutors.Padding = new System.Windows.Forms.Padding(3);
            this.tabTutors.Size = new System.Drawing.Size(650, 359);
            this.tabTutors.TabIndex = 1;
            this.tabTutors.Text = "Tutors";
            this.tabTutors.UseVisualStyleBackColor = true;
            // 
            // btnAddTutor
            // 
            this.btnAddTutor.Location = new System.Drawing.Point(74, 66);
            this.btnAddTutor.Name = "btnAddTutor";
            this.btnAddTutor.Size = new System.Drawing.Size(75, 23);
            this.btnAddTutor.TabIndex = 9;
            this.btnAddTutor.Text = "Add";
            this.btnAddTutor.UseVisualStyleBackColor = true;
            this.btnAddTutor.Click += new System.EventHandler(this.btnAddTutor_Click);
            // 
            // btnDisableSelected
            // 
            this.btnDisableSelected.Location = new System.Drawing.Point(412, 216);
            this.btnDisableSelected.Name = "btnDisableSelected";
            this.btnDisableSelected.Size = new System.Drawing.Size(39, 35);
            this.btnDisableSelected.TabIndex = 8;
            this.btnDisableSelected.Text = ">";
            this.btnDisableSelected.UseVisualStyleBackColor = true;
            // 
            // btnDisableAll
            // 
            this.btnDisableAll.Location = new System.Drawing.Point(412, 175);
            this.btnDisableAll.Name = "btnDisableAll";
            this.btnDisableAll.Size = new System.Drawing.Size(39, 35);
            this.btnDisableAll.TabIndex = 7;
            this.btnDisableAll.Text = ">>";
            this.btnDisableAll.UseVisualStyleBackColor = true;
            // 
            // btnEnableAll
            // 
            this.btnEnableAll.Location = new System.Drawing.Point(412, 80);
            this.btnEnableAll.Name = "btnEnableAll";
            this.btnEnableAll.Size = new System.Drawing.Size(39, 35);
            this.btnEnableAll.TabIndex = 6;
            this.btnEnableAll.Text = "<<";
            this.btnEnableAll.UseVisualStyleBackColor = true;
            // 
            // btnEnableSelected
            // 
            this.btnEnableSelected.Location = new System.Drawing.Point(412, 39);
            this.btnEnableSelected.Name = "btnEnableSelected";
            this.btnEnableSelected.Size = new System.Drawing.Size(39, 35);
            this.btnEnableSelected.TabIndex = 4;
            this.btnEnableSelected.Text = "<";
            this.btnEnableSelected.UseVisualStyleBackColor = true;
            // 
            // listBoxDisableTutors
            // 
            this.listBoxDisableTutors.FormattingEnabled = true;
            this.listBoxDisableTutors.Location = new System.Drawing.Point(472, 39);
            this.listBoxDisableTutors.Name = "listBoxDisableTutors";
            this.listBoxDisableTutors.Size = new System.Drawing.Size(161, 212);
            this.listBoxDisableTutors.TabIndex = 3;
            // 
            // listBoxEnableTutors
            // 
            this.listBoxEnableTutors.FormattingEnabled = true;
            this.listBoxEnableTutors.Location = new System.Drawing.Point(222, 39);
            this.listBoxEnableTutors.Name = "listBoxEnableTutors";
            this.listBoxEnableTutors.Size = new System.Drawing.Size(174, 212);
            this.listBoxEnableTutors.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student ID:";
            // 
            // txtTutorStudentID
            // 
            this.txtTutorStudentID.Location = new System.Drawing.Point(74, 39);
            this.txtTutorStudentID.Name = "txtTutorStudentID";
            this.txtTutorStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtTutorStudentID.TabIndex = 0;
            // 
            // tabVisits
            // 
            this.tabVisits.Controls.Add(this.btnSave);
            this.tabVisits.Controls.Add(this.btnEditVisit);
            this.tabVisits.Controls.Add(this.txtSignOut);
            this.tabVisits.Controls.Add(this.txtSignIn);
            this.tabVisits.Controls.Add(this.txtStudentID);
            this.tabVisits.Controls.Add(this.btnAddVisit);
            this.tabVisits.Controls.Add(this.lblSignOut);
            this.tabVisits.Controls.Add(this.lblSignIn);
            this.tabVisits.Controls.Add(this.lblStudentID);
            this.tabVisits.Controls.Add(this.lblModifyVisit);
            this.tabVisits.Controls.Add(this.lblLoggedIn);
            this.tabVisits.Controls.Add(this.btnLogOut);
            this.tabVisits.Controls.Add(this.listBoxLoggedIn);
            this.tabVisits.Location = new System.Drawing.Point(4, 22);
            this.tabVisits.Name = "tabVisits";
            this.tabVisits.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisits.Size = new System.Drawing.Size(650, 359);
            this.tabVisits.TabIndex = 2;
            this.tabVisits.Text = "Visits";
            this.tabVisits.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(273, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEditVisit
            // 
            this.btnEditVisit.Location = new System.Drawing.Point(162, 256);
            this.btnEditVisit.Name = "btnEditVisit";
            this.btnEditVisit.Size = new System.Drawing.Size(75, 23);
            this.btnEditVisit.TabIndex = 16;
            this.btnEditVisit.Text = "Edit Visit";
            this.btnEditVisit.UseVisualStyleBackColor = true;
            this.btnEditVisit.Click += new System.EventHandler(this.btnEditVisit_Click);
            // 
            // txtSignOut
            // 
            this.txtSignOut.Location = new System.Drawing.Point(152, 312);
            this.txtSignOut.Name = "txtSignOut";
            this.txtSignOut.Size = new System.Drawing.Size(100, 20);
            this.txtSignOut.TabIndex = 15;
            // 
            // txtSignIn
            // 
            this.txtSignIn.Location = new System.Drawing.Point(46, 312);
            this.txtSignIn.Name = "txtSignIn";
            this.txtSignIn.Size = new System.Drawing.Size(100, 20);
            this.txtSignIn.TabIndex = 14;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(46, 260);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtStudentID.TabIndex = 13;
            // 
            // btnAddVisit
            // 
            this.btnAddVisit.Location = new System.Drawing.Point(273, 309);
            this.btnAddVisit.Name = "btnAddVisit";
            this.btnAddVisit.Size = new System.Drawing.Size(75, 23);
            this.btnAddVisit.TabIndex = 10;
            this.btnAddVisit.Text = "Add Visit";
            this.btnAddVisit.UseVisualStyleBackColor = true;
            // 
            // lblSignOut
            // 
            this.lblSignOut.AutoSize = true;
            this.lblSignOut.Location = new System.Drawing.Point(149, 294);
            this.lblSignOut.Name = "lblSignOut";
            this.lblSignOut.Size = new System.Drawing.Size(48, 13);
            this.lblSignOut.TabIndex = 9;
            this.lblSignOut.Text = "Sign Out";
            // 
            // lblSignIn
            // 
            this.lblSignIn.AutoSize = true;
            this.lblSignIn.Location = new System.Drawing.Point(43, 294);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(40, 13);
            this.lblSignIn.TabIndex = 8;
            this.lblSignIn.Text = "Sign In";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(43, 244);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(58, 13);
            this.lblStudentID.TabIndex = 7;
            this.lblStudentID.Text = "Student ID";
            // 
            // lblModifyVisit
            // 
            this.lblModifyVisit.AutoSize = true;
            this.lblModifyVisit.Location = new System.Drawing.Point(17, 205);
            this.lblModifyVisit.Name = "lblModifyVisit";
            this.lblModifyVisit.Size = new System.Drawing.Size(74, 13);
            this.lblModifyVisit.TabIndex = 3;
            this.lblModifyVisit.Text = "Add/Edit Visit:";
            // 
            // lblLoggedIn
            // 
            this.lblLoggedIn.AutoSize = true;
            this.lblLoggedIn.Location = new System.Drawing.Point(17, 36);
            this.lblLoggedIn.Name = "lblLoggedIn";
            this.lblLoggedIn.Size = new System.Drawing.Size(147, 13);
            this.lblLoggedIn.TabIndex = 2;
            this.lblLoggedIn.Text = "Students Currently Logged In:";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(560, 179);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 1;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // listBoxLoggedIn
            // 
            this.listBoxLoggedIn.FormattingEnabled = true;
            this.listBoxLoggedIn.Location = new System.Drawing.Point(20, 52);
            this.listBoxLoggedIn.Name = "listBoxLoggedIn";
            this.listBoxLoggedIn.Size = new System.Drawing.Size(615, 121);
            this.listBoxLoggedIn.TabIndex = 0;
            // 
            // tabPermission
            // 
            this.tabPermission.Controls.Add(this.grpBoxPassword);
            this.tabPermission.Controls.Add(this.listBoxAdminUsers);
            this.tabPermission.Controls.Add(this.lblAdminUsers);
            this.tabPermission.Controls.Add(this.label2);
            this.tabPermission.Controls.Add(this.txtAdminStudentID);
            this.tabPermission.Location = new System.Drawing.Point(4, 22);
            this.tabPermission.Name = "tabPermission";
            this.tabPermission.Padding = new System.Windows.Forms.Padding(3);
            this.tabPermission.Size = new System.Drawing.Size(650, 359);
            this.tabPermission.TabIndex = 3;
            this.tabPermission.Text = "Permissions";
            this.tabPermission.UseVisualStyleBackColor = true;
            // 
            // grpBoxPassword
            // 
            this.grpBoxPassword.Controls.Add(this.label3);
            this.grpBoxPassword.Location = new System.Drawing.Point(399, 34);
            this.grpBoxPassword.Name = "grpBoxPassword";
            this.grpBoxPassword.Size = new System.Drawing.Size(200, 249);
            this.grpBoxPassword.TabIndex = 4;
            this.grpBoxPassword.TabStop = false;
            this.grpBoxPassword.Text = "Password";
            // 
            // listBoxAdminUsers
            // 
            this.listBoxAdminUsers.FormattingEnabled = true;
            this.listBoxAdminUsers.Location = new System.Drawing.Point(13, 83);
            this.listBoxAdminUsers.Name = "listBoxAdminUsers";
            this.listBoxAdminUsers.Size = new System.Drawing.Size(189, 251);
            this.listBoxAdminUsers.TabIndex = 3;
            // 
            // lblAdminUsers
            // 
            this.lblAdminUsers.AutoSize = true;
            this.lblAdminUsers.Location = new System.Drawing.Point(10, 67);
            this.lblAdminUsers.Name = "lblAdminUsers";
            this.lblAdminUsers.Size = new System.Drawing.Size(69, 13);
            this.lblAdminUsers.TabIndex = 2;
            this.lblAdminUsers.Text = "Admin Users:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Student ID:";
            // 
            // txtAdminStudentID
            // 
            this.txtAdminStudentID.Location = new System.Drawing.Point(74, 27);
            this.txtAdminStudentID.Name = "txtAdminStudentID";
            this.txtAdminStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtAdminStudentID.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(595, 421);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 474);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControlAdmin);
            this.Name = "frmAdmin";
            this.Text = "frmAdmin";
            this.tabControlAdmin.ResumeLayout(false);
            this.tabTutors.ResumeLayout(false);
            this.tabTutors.PerformLayout();
            this.tabVisits.ResumeLayout(false);
            this.tabVisits.PerformLayout();
            this.tabPermission.ResumeLayout(false);
            this.tabPermission.PerformLayout();
            this.grpBoxPassword.ResumeLayout(false);
            this.grpBoxPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabTutors;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTutorStudentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxEnableTutors;
        private System.Windows.Forms.ListBox listBoxDisableTutors;
        private System.Windows.Forms.Button btnEnableSelected;
        private System.Windows.Forms.Button btnEnableAll;
        private System.Windows.Forms.Button btnDisableAll;
        private System.Windows.Forms.Button btnDisableSelected;
        private System.Windows.Forms.Button btnAddTutor;
        private System.Windows.Forms.TabPage tabVisits;
        private System.Windows.Forms.ListBox listBoxLoggedIn;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblLoggedIn;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblSignIn;
        private System.Windows.Forms.Label lblSignOut;
        private System.Windows.Forms.Button btnAddVisit;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtSignIn;
        private System.Windows.Forms.TextBox txtSignOut;
        private System.Windows.Forms.Label lblModifyVisit;
        private System.Windows.Forms.Button btnEditVisit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabPermission;
        private System.Windows.Forms.TextBox txtAdminStudentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAdminUsers;
        private System.Windows.Forms.ListBox listBoxAdminUsers;
        private System.Windows.Forms.GroupBox grpBoxPassword;
        private System.Windows.Forms.Label label3;
    }
}