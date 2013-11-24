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
            this.tabVisits = new System.Windows.Forms.TabPage();
            this.comboaddClass = new System.Windows.Forms.ComboBox();
            this.comboAddTutoring = new System.Windows.Forms.ComboBox();
            this.dateTimePickerEditTimeOut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEditTimeIn = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerAddTimeOut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerAddTimeIn = new System.Windows.Forms.DateTimePicker();
            this.lblAddTutor = new System.Windows.Forms.Label();
            this.comboAddMethod = new System.Windows.Forms.ComboBox();
            this.lblAddClass = new System.Windows.Forms.Label();
            this.lblAddMethod = new System.Windows.Forms.Label();
            this.txtEditDate = new System.Windows.Forms.TextBox();
            this.lblEditDate = new System.Windows.Forms.Label();
            this.btnEditVisit = new System.Windows.Forms.Button();
            this.dateTimePickerEditMax = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEditMin = new System.Windows.Forms.DateTimePicker();
            this.lblEditDateRange = new System.Windows.Forms.Label();
            this.txtEditStudentID = new System.Windows.Forms.TextBox();
            this.lblEditTimeOut = new System.Windows.Forms.Label();
            this.lblEditTimeIn = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblEditVisit = new System.Windows.Forms.Label();
            this.dateTimePickerAdd = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtAddStudentID = new System.Windows.Forms.TextBox();
            this.btnAddVisit = new System.Windows.Forms.Button();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblAddVisit = new System.Windows.Forms.Label();
            this.lblLoggedIn = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.listBoxLoggedIn = new System.Windows.Forms.ListBox();
            this.tabTutors = new System.Windows.Forms.TabPage();
            this.lblInactiveTutors = new System.Windows.Forms.Label();
            this.lblActiveTutors = new System.Windows.Forms.Label();
            this.btnAddTutor = new System.Windows.Forms.Button();
            this.btnDisableSelected = new System.Windows.Forms.Button();
            this.btnDisableAll = new System.Windows.Forms.Button();
            this.btnEnableAll = new System.Windows.Forms.Button();
            this.btnEnableSelected = new System.Windows.Forms.Button();
            this.listBoxDisableTutors = new System.Windows.Forms.ListBox();
            this.listBoxEnableTutors = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTutorStudentID = new System.Windows.Forms.TextBox();
            this.tabMethods = new System.Windows.Forms.TabPage();
            this.btnSaveMethods = new System.Windows.Forms.Button();
            this.btnAddMethod = new System.Windows.Forms.Button();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.btn_courses_import = new System.Windows.Forms.Button();
            this.btn_student_import = new System.Windows.Forms.Button();
            this.grpBoxPassword = new System.Windows.Forms.GroupBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.lblGroup = new System.Windows.Forms.Label();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.listBoxReport = new System.Windows.Forms.ListBox();
            this.comboCountCategory = new System.Windows.Forms.ComboBox();
            this.comboTerm = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEditSignOut = new System.Windows.Forms.TextBox();
            this.txtEditSignIn = new System.Windows.Forms.TextBox();
            this.lblEditSignOut = new System.Windows.Forms.Label();
            this.lblEditSignIn = new System.Windows.Forms.Label();
            this.txtAddTutor = new System.Windows.Forms.TextBox();
            this.txtAddSignOut = new System.Windows.Forms.TextBox();
            this.txtAddSignIn = new System.Windows.Forms.TextBox();
            this.tabControlAdmin.SuspendLayout();
            this.tabVisits.SuspendLayout();
            this.tabTutors.SuspendLayout();
            this.tabMethods.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            this.grpBoxPassword.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabVisits);
            this.tabControlAdmin.Controls.Add(this.tabTutors);
            this.tabControlAdmin.Controls.Add(this.tabMethods);
            this.tabControlAdmin.Controls.Add(this.tabAdmin);
            this.tabControlAdmin.Controls.Add(this.tabReports);
            this.tabControlAdmin.Location = new System.Drawing.Point(12, 12);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(658, 421);
            this.tabControlAdmin.TabIndex = 0;
            this.tabControlAdmin.SelectedIndexChanged += new System.EventHandler(this.tabControlAdmin_SelectedIndexChanged);
            // 
            // tabVisits
            // 
            this.tabVisits.Controls.Add(this.comboaddClass);
            this.tabVisits.Controls.Add(this.comboAddTutoring);
            this.tabVisits.Controls.Add(this.dateTimePickerEditTimeOut);
            this.tabVisits.Controls.Add(this.dateTimePickerEditTimeIn);
            this.tabVisits.Controls.Add(this.dateTimePickerAddTimeOut);
            this.tabVisits.Controls.Add(this.dateTimePickerAddTimeIn);
            this.tabVisits.Controls.Add(this.lblAddTutor);
            this.tabVisits.Controls.Add(this.comboAddMethod);
            this.tabVisits.Controls.Add(this.lblAddClass);
            this.tabVisits.Controls.Add(this.lblAddMethod);
            this.tabVisits.Controls.Add(this.txtEditDate);
            this.tabVisits.Controls.Add(this.lblEditDate);
            this.tabVisits.Controls.Add(this.btnEditVisit);
            this.tabVisits.Controls.Add(this.dateTimePickerEditMax);
            this.tabVisits.Controls.Add(this.dateTimePickerEditMin);
            this.tabVisits.Controls.Add(this.lblEditDateRange);
            this.tabVisits.Controls.Add(this.txtEditStudentID);
            this.tabVisits.Controls.Add(this.lblEditTimeOut);
            this.tabVisits.Controls.Add(this.lblEditTimeIn);
            this.tabVisits.Controls.Add(this.label6);
            this.tabVisits.Controls.Add(this.lblEditVisit);
            this.tabVisits.Controls.Add(this.dateTimePickerAdd);
            this.tabVisits.Controls.Add(this.lblDate);
            this.tabVisits.Controls.Add(this.txtAddStudentID);
            this.tabVisits.Controls.Add(this.btnAddVisit);
            this.tabVisits.Controls.Add(this.lblTimeOut);
            this.tabVisits.Controls.Add(this.lblTimeIn);
            this.tabVisits.Controls.Add(this.lblStudentID);
            this.tabVisits.Controls.Add(this.lblAddVisit);
            this.tabVisits.Controls.Add(this.lblLoggedIn);
            this.tabVisits.Controls.Add(this.btnLogOut);
            this.tabVisits.Controls.Add(this.listBoxLoggedIn);
            this.tabVisits.Location = new System.Drawing.Point(4, 22);
            this.tabVisits.Name = "tabVisits";
            this.tabVisits.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisits.Size = new System.Drawing.Size(650, 395);
            this.tabVisits.TabIndex = 2;
            this.tabVisits.Text = "Visits";
            this.tabVisits.UseVisualStyleBackColor = true;
            // 
            // comboaddClass
            // 
            this.comboaddClass.Enabled = false;
            this.comboaddClass.FormattingEnabled = true;
            this.comboaddClass.Location = new System.Drawing.Point(149, 251);
            this.comboaddClass.Name = "comboaddClass";
            this.comboaddClass.Size = new System.Drawing.Size(109, 21);
            this.comboaddClass.TabIndex = 44;
            // 
            // comboAddTutoring
            // 
            this.comboAddTutoring.Enabled = false;
            this.comboAddTutoring.FormattingEnabled = true;
            this.comboAddTutoring.Location = new System.Drawing.Point(264, 251);
            this.comboAddTutoring.Name = "comboAddTutoring";
            this.comboAddTutoring.Size = new System.Drawing.Size(121, 21);
            this.comboAddTutoring.TabIndex = 43;
            this.comboAddTutoring.SelectedIndexChanged += new System.EventHandler(this.comboAddTutoring_SelectedIndexChanged);
            // 
            // dateTimePickerEditTimeOut
            // 
            this.dateTimePickerEditTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerEditTimeOut.Location = new System.Drawing.Point(220, 360);
            this.dateTimePickerEditTimeOut.Name = "dateTimePickerEditTimeOut";
            this.dateTimePickerEditTimeOut.ShowUpDown = true;
            this.dateTimePickerEditTimeOut.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerEditTimeOut.TabIndex = 41;
            this.dateTimePickerEditTimeOut.Value = new System.DateTime(2013, 11, 12, 16, 23, 0, 0);
            // 
            // dateTimePickerEditTimeIn
            // 
            this.dateTimePickerEditTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerEditTimeIn.Location = new System.Drawing.Point(128, 360);
            this.dateTimePickerEditTimeIn.Name = "dateTimePickerEditTimeIn";
            this.dateTimePickerEditTimeIn.ShowUpDown = true;
            this.dateTimePickerEditTimeIn.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerEditTimeIn.TabIndex = 40;
            this.dateTimePickerEditTimeIn.Value = new System.DateTime(2013, 11, 12, 16, 23, 0, 0);
            // 
            // dateTimePickerAddTimeOut
            // 
            this.dateTimePickerAddTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerAddTimeOut.Location = new System.Drawing.Point(329, 206);
            this.dateTimePickerAddTimeOut.Name = "dateTimePickerAddTimeOut";
            this.dateTimePickerAddTimeOut.ShowUpDown = true;
            this.dateTimePickerAddTimeOut.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerAddTimeOut.TabIndex = 39;
            this.dateTimePickerAddTimeOut.Value = new System.DateTime(2013, 11, 12, 16, 23, 0, 0);
            // 
            // dateTimePickerAddTimeIn
            // 
            this.dateTimePickerAddTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerAddTimeIn.Location = new System.Drawing.Point(237, 206);
            this.dateTimePickerAddTimeIn.Name = "dateTimePickerAddTimeIn";
            this.dateTimePickerAddTimeIn.ShowUpDown = true;
            this.dateTimePickerAddTimeIn.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerAddTimeIn.TabIndex = 38;
            this.dateTimePickerAddTimeIn.Value = new System.DateTime(2013, 11, 12, 16, 23, 0, 0);
            // 
            // lblAddTutor
            // 
            this.lblAddTutor.AutoSize = true;
            this.lblAddTutor.Location = new System.Drawing.Point(255, 235);
            this.lblAddTutor.Name = "lblAddTutor";
            this.lblAddTutor.Size = new System.Drawing.Size(32, 13);
            this.lblAddTutor.TabIndex = 36;
            this.lblAddTutor.Text = "Tutor";
            // 
            // comboAddMethod
            // 
            this.comboAddMethod.FormattingEnabled = true;
            this.comboAddMethod.Location = new System.Drawing.Point(22, 250);
            this.comboAddMethod.Name = "comboAddMethod";
            this.comboAddMethod.Size = new System.Drawing.Size(121, 21);
            this.comboAddMethod.TabIndex = 35;
            this.comboAddMethod.SelectedIndexChanged += new System.EventHandler(this.comboAddMethod_SelectedIndexChanged);
            // 
            // lblAddClass
            // 
            this.lblAddClass.AutoSize = true;
            this.lblAddClass.Location = new System.Drawing.Point(149, 235);
            this.lblAddClass.Name = "lblAddClass";
            this.lblAddClass.Size = new System.Drawing.Size(32, 13);
            this.lblAddClass.TabIndex = 33;
            this.lblAddClass.Text = "Class";
            // 
            // lblAddMethod
            // 
            this.lblAddMethod.AutoSize = true;
            this.lblAddMethod.Location = new System.Drawing.Point(19, 235);
            this.lblAddMethod.Name = "lblAddMethod";
            this.lblAddMethod.Size = new System.Drawing.Size(71, 13);
            this.lblAddMethod.TabIndex = 31;
            this.lblAddMethod.Text = "I was here for";
            // 
            // txtEditDate
            // 
            this.txtEditDate.Enabled = false;
            this.txtEditDate.Location = new System.Drawing.Point(22, 360);
            this.txtEditDate.Name = "txtEditDate";
            this.txtEditDate.Size = new System.Drawing.Size(100, 20);
            this.txtEditDate.TabIndex = 30;
            // 
            // lblEditDate
            // 
            this.lblEditDate.AutoSize = true;
            this.lblEditDate.Location = new System.Drawing.Point(19, 342);
            this.lblEditDate.Name = "lblEditDate";
            this.lblEditDate.Size = new System.Drawing.Size(30, 13);
            this.lblEditDate.TabIndex = 29;
            this.lblEditDate.Text = "Date";
            // 
            // btnEditVisit
            // 
            this.btnEditVisit.Location = new System.Drawing.Point(559, 312);
            this.btnEditVisit.Name = "btnEditVisit";
            this.btnEditVisit.Size = new System.Drawing.Size(75, 68);
            this.btnEditVisit.TabIndex = 16;
            this.btnEditVisit.Text = "Edit Visit";
            this.btnEditVisit.UseVisualStyleBackColor = true;
            this.btnEditVisit.Click += new System.EventHandler(this.btnEditVisit_Click);
            // 
            // dateTimePickerEditMax
            // 
            this.dateTimePickerEditMax.CustomFormat = "MM\'/\'dd\'/\'yyyy";
            this.dateTimePickerEditMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEditMax.Location = new System.Drawing.Point(334, 315);
            this.dateTimePickerEditMax.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEditMax.Name = "dateTimePickerEditMax";
            this.dateTimePickerEditMax.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEditMax.TabIndex = 28;
            this.dateTimePickerEditMax.Value = new System.DateTime(2013, 11, 7, 0, 0, 0, 0);
            // 
            // dateTimePickerEditMin
            // 
            this.dateTimePickerEditMin.CustomFormat = "MM\'/\'dd\'/\'yyyy";
            this.dateTimePickerEditMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEditMin.Location = new System.Drawing.Point(128, 315);
            this.dateTimePickerEditMin.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEditMin.Name = "dateTimePickerEditMin";
            this.dateTimePickerEditMin.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEditMin.TabIndex = 27;
            this.dateTimePickerEditMin.Value = new System.DateTime(2013, 11, 7, 0, 0, 0, 0);
            // 
            // lblEditDateRange
            // 
            this.lblEditDateRange.AutoSize = true;
            this.lblEditDateRange.Location = new System.Drawing.Point(128, 297);
            this.lblEditDateRange.Name = "lblEditDateRange";
            this.lblEditDateRange.Size = new System.Drawing.Size(65, 13);
            this.lblEditDateRange.TabIndex = 26;
            this.lblEditDateRange.Text = "Date Range";
            // 
            // txtEditStudentID
            // 
            this.txtEditStudentID.Location = new System.Drawing.Point(22, 315);
            this.txtEditStudentID.Name = "txtEditStudentID";
            this.txtEditStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtEditStudentID.TabIndex = 23;
            // 
            // lblEditTimeOut
            // 
            this.lblEditTimeOut.AutoSize = true;
            this.lblEditTimeOut.Location = new System.Drawing.Point(217, 342);
            this.lblEditTimeOut.Name = "lblEditTimeOut";
            this.lblEditTimeOut.Size = new System.Drawing.Size(50, 13);
            this.lblEditTimeOut.TabIndex = 21;
            this.lblEditTimeOut.Text = "Time Out";
            // 
            // lblEditTimeIn
            // 
            this.lblEditTimeIn.AutoSize = true;
            this.lblEditTimeIn.Location = new System.Drawing.Point(128, 342);
            this.lblEditTimeIn.Name = "lblEditTimeIn";
            this.lblEditTimeIn.Size = new System.Drawing.Size(42, 13);
            this.lblEditTimeIn.TabIndex = 20;
            this.lblEditTimeIn.Text = "Time In";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Student ID";
            // 
            // lblEditVisit
            // 
            this.lblEditVisit.AutoSize = true;
            this.lblEditVisit.Location = new System.Drawing.Point(19, 275);
            this.lblEditVisit.Name = "lblEditVisit";
            this.lblEditVisit.Size = new System.Drawing.Size(50, 13);
            this.lblEditVisit.TabIndex = 18;
            this.lblEditVisit.Text = "Edit Visit:";
            // 
            // dateTimePickerAdd
            // 
            this.dateTimePickerAdd.CustomFormat = "MM\'/\'dd\'/\'yyyy";
            this.dateTimePickerAdd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAdd.Location = new System.Drawing.Point(128, 206);
            this.dateTimePickerAdd.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerAdd.Name = "dateTimePickerAdd";
            this.dateTimePickerAdd.Size = new System.Drawing.Size(103, 20);
            this.dateTimePickerAdd.TabIndex = 17;
            this.dateTimePickerAdd.Value = new System.DateTime(2013, 11, 7, 0, 0, 0, 0);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(128, 188);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 16;
            this.lblDate.Text = "Date";
            // 
            // txtAddStudentID
            // 
            this.txtAddStudentID.Location = new System.Drawing.Point(22, 206);
            this.txtAddStudentID.Name = "txtAddStudentID";
            this.txtAddStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtAddStudentID.TabIndex = 13;
            // 
            // btnAddVisit
            // 
            this.btnAddVisit.Location = new System.Drawing.Point(449, 203);
            this.btnAddVisit.Name = "btnAddVisit";
            this.btnAddVisit.Size = new System.Drawing.Size(75, 62);
            this.btnAddVisit.TabIndex = 10;
            this.btnAddVisit.Text = "Add Visit";
            this.btnAddVisit.UseVisualStyleBackColor = true;
            this.btnAddVisit.Click += new System.EventHandler(this.btnAddVisit_Click);
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(340, 188);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(50, 13);
            this.lblTimeOut.TabIndex = 9;
            this.lblTimeOut.Text = "Time Out";
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.AutoSize = true;
            this.lblTimeIn.Location = new System.Drawing.Point(234, 188);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(42, 13);
            this.lblTimeIn.TabIndex = 8;
            this.lblTimeIn.Text = "Time In";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(19, 188);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(58, 13);
            this.lblStudentID.TabIndex = 7;
            this.lblStudentID.Text = "Student ID";
            // 
            // lblAddVisit
            // 
            this.lblAddVisit.AutoSize = true;
            this.lblAddVisit.Location = new System.Drawing.Point(19, 166);
            this.lblAddVisit.Name = "lblAddVisit";
            this.lblAddVisit.Size = new System.Drawing.Size(51, 13);
            this.lblAddVisit.TabIndex = 3;
            this.lblAddVisit.Text = "Add Visit:";
            // 
            // lblLoggedIn
            // 
            this.lblLoggedIn.AutoSize = true;
            this.lblLoggedIn.Location = new System.Drawing.Point(17, 20);
            this.lblLoggedIn.Name = "lblLoggedIn";
            this.lblLoggedIn.Size = new System.Drawing.Size(147, 13);
            this.lblLoggedIn.TabIndex = 2;
            this.lblLoggedIn.Text = "Students Currently Logged In:";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(559, 162);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 1;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // listBoxLoggedIn
            // 
            this.listBoxLoggedIn.FormattingEnabled = true;
            this.listBoxLoggedIn.Location = new System.Drawing.Point(20, 36);
            this.listBoxLoggedIn.Name = "listBoxLoggedIn";
            this.listBoxLoggedIn.Size = new System.Drawing.Size(615, 121);
            this.listBoxLoggedIn.TabIndex = 0;
            // 
            // tabTutors
            // 
            this.tabTutors.Controls.Add(this.lblInactiveTutors);
            this.tabTutors.Controls.Add(this.lblActiveTutors);
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
            this.tabTutors.Size = new System.Drawing.Size(650, 395);
            this.tabTutors.TabIndex = 1;
            this.tabTutors.Text = "Tutors";
            this.tabTutors.UseVisualStyleBackColor = true;
            // 
            // lblInactiveTutors
            // 
            this.lblInactiveTutors.AutoSize = true;
            this.lblInactiveTutors.Location = new System.Drawing.Point(472, 20);
            this.lblInactiveTutors.Name = "lblInactiveTutors";
            this.lblInactiveTutors.Size = new System.Drawing.Size(81, 13);
            this.lblInactiveTutors.TabIndex = 11;
            this.lblInactiveTutors.Text = "Inactive Tutors:";
            // 
            // lblActiveTutors
            // 
            this.lblActiveTutors.AutoSize = true;
            this.lblActiveTutors.Location = new System.Drawing.Point(222, 20);
            this.lblActiveTutors.Name = "lblActiveTutors";
            this.lblActiveTutors.Size = new System.Drawing.Size(73, 13);
            this.lblActiveTutors.TabIndex = 10;
            this.lblActiveTutors.Text = "Active Tutors:";
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
            this.btnDisableSelected.Click += new System.EventHandler(this.btnDisableSelected_Click);
            // 
            // btnDisableAll
            // 
            this.btnDisableAll.Location = new System.Drawing.Point(412, 175);
            this.btnDisableAll.Name = "btnDisableAll";
            this.btnDisableAll.Size = new System.Drawing.Size(39, 35);
            this.btnDisableAll.TabIndex = 7;
            this.btnDisableAll.Text = ">>";
            this.btnDisableAll.UseVisualStyleBackColor = true;
            this.btnDisableAll.Click += new System.EventHandler(this.btnDisableAll_Click);
            // 
            // btnEnableAll
            // 
            this.btnEnableAll.Location = new System.Drawing.Point(412, 80);
            this.btnEnableAll.Name = "btnEnableAll";
            this.btnEnableAll.Size = new System.Drawing.Size(39, 35);
            this.btnEnableAll.TabIndex = 6;
            this.btnEnableAll.Text = "<<";
            this.btnEnableAll.UseVisualStyleBackColor = true;
            this.btnEnableAll.Click += new System.EventHandler(this.btnEnableAll_Click);
            // 
            // btnEnableSelected
            // 
            this.btnEnableSelected.Location = new System.Drawing.Point(412, 39);
            this.btnEnableSelected.Name = "btnEnableSelected";
            this.btnEnableSelected.Size = new System.Drawing.Size(39, 35);
            this.btnEnableSelected.TabIndex = 4;
            this.btnEnableSelected.Text = "<";
            this.btnEnableSelected.UseVisualStyleBackColor = true;
            this.btnEnableSelected.Click += new System.EventHandler(this.btnEnableSelected_Click);
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
            // tabMethods
            // 
            this.tabMethods.Controls.Add(this.btnSaveMethods);
            this.tabMethods.Controls.Add(this.btnAddMethod);
            this.tabMethods.Location = new System.Drawing.Point(4, 22);
            this.tabMethods.Name = "tabMethods";
            this.tabMethods.Padding = new System.Windows.Forms.Padding(3);
            this.tabMethods.Size = new System.Drawing.Size(650, 395);
            this.tabMethods.TabIndex = 4;
            this.tabMethods.Text = "Methods";
            this.tabMethods.UseVisualStyleBackColor = true;
            // 
            // btnSaveMethods
            // 
            this.btnSaveMethods.Location = new System.Drawing.Point(569, 330);
            this.btnSaveMethods.Name = "btnSaveMethods";
            this.btnSaveMethods.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMethods.TabIndex = 0;
            this.btnSaveMethods.Text = "Save Changes";
            this.btnSaveMethods.UseVisualStyleBackColor = true;
            this.btnSaveMethods.Click += new System.EventHandler(this.btnSaveMethods_Click);
            // 
            // btnAddMethod
            // 
            this.btnAddMethod.Location = new System.Drawing.Point(0, 0);
            this.btnAddMethod.Name = "btnAddMethod";
            this.btnAddMethod.Size = new System.Drawing.Size(100, 20);
            this.btnAddMethod.TabIndex = 1;
            this.btnAddMethod.Text = "Add new method";
            this.btnAddMethod.Click += new System.EventHandler(this.btnAddMethod_Click);
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.btn_courses_import);
            this.tabAdmin.Controls.Add(this.btn_student_import);
            this.tabAdmin.Controls.Add(this.grpBoxPassword);
            this.tabAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmin.Size = new System.Drawing.Size(650, 395);
            this.tabAdmin.TabIndex = 3;
            this.tabAdmin.Text = "Administration";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // btn_courses_import
            // 
            this.btn_courses_import.Location = new System.Drawing.Point(19, 34);
            this.btn_courses_import.Name = "btn_courses_import";
            this.btn_courses_import.Size = new System.Drawing.Size(93, 23);
            this.btn_courses_import.TabIndex = 6;
            this.btn_courses_import.Text = "Import Courses";
            this.btn_courses_import.UseVisualStyleBackColor = true;
            this.btn_courses_import.Click += new System.EventHandler(this.btn_courses_import_Click);
            // 
            // btn_student_import
            // 
            this.btn_student_import.Location = new System.Drawing.Point(19, 63);
            this.btn_student_import.Name = "btn_student_import";
            this.btn_student_import.Size = new System.Drawing.Size(93, 23);
            this.btn_student_import.TabIndex = 5;
            this.btn_student_import.Text = "Import Students";
            this.btn_student_import.UseVisualStyleBackColor = true;
            this.btn_student_import.Click += new System.EventHandler(this.btn_student_import_Click);
            // 
            // grpBoxPassword
            // 
            this.grpBoxPassword.Controls.Add(this.btnChangePassword);
            this.grpBoxPassword.Controls.Add(this.txtConfirmPassword);
            this.grpBoxPassword.Controls.Add(this.txtNewPassword);
            this.grpBoxPassword.Controls.Add(this.txtCurrentPassword);
            this.grpBoxPassword.Controls.Add(this.lblConfirmPassword);
            this.grpBoxPassword.Controls.Add(this.lblNewPassword);
            this.grpBoxPassword.Controls.Add(this.lblCurrentPassword);
            this.grpBoxPassword.Location = new System.Drawing.Point(328, 34);
            this.grpBoxPassword.Name = "grpBoxPassword";
            this.grpBoxPassword.Size = new System.Drawing.Size(271, 164);
            this.grpBoxPassword.TabIndex = 4;
            this.grpBoxPassword.TabStop = false;
            this.grpBoxPassword.Text = "Password";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(147, 111);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(104, 23);
            this.btnChangePassword.TabIndex = 9;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(107, 73);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(144, 20);
            this.txtConfirmPassword.TabIndex = 8;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(107, 46);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(144, 20);
            this.txtNewPassword.TabIndex = 7;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(107, 20);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(144, 20);
            this.txtCurrentPassword.TabIndex = 6;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(10, 76);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(91, 13);
            this.lblConfirmPassword.TabIndex = 5;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(23, 49);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(78, 13);
            this.lblNewPassword.TabIndex = 1;
            this.lblNewPassword.Text = "New Password";
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Location = new System.Drawing.Point(11, 23);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(90, 13);
            this.lblCurrentPassword.TabIndex = 0;
            this.lblCurrentPassword.Text = "Current Password";
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.btnMoveDown);
            this.tabReports.Controls.Add(this.btnMoveUp);
            this.tabReports.Controls.Add(this.lblGroup);
            this.tabReports.Controls.Add(this.comboFilter);
            this.tabReports.Controls.Add(this.lblCount);
            this.tabReports.Controls.Add(this.btnReport);
            this.tabReports.Controls.Add(this.listBoxReport);
            this.tabReports.Controls.Add(this.comboCountCategory);
            this.tabReports.Controls.Add(this.comboTerm);
            this.tabReports.Controls.Add(this.lblYear);
            this.tabReports.Controls.Add(this.btnClear);
            this.tabReports.Controls.Add(this.txtYear);
            this.tabReports.Controls.Add(this.btnDisplay);
            this.tabReports.Location = new System.Drawing.Point(4, 22);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(650, 395);
            this.tabReports.TabIndex = 5;
            this.tabReports.Text = "Reports";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(100, 138);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDown.TabIndex = 17;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(4, 138);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 16;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(6, 85);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(53, 13);
            this.lblGroup.TabIndex = 15;
            this.lblGroup.Text = "Filter/Sort";
            // 
            // comboFilter
            // 
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(62, 82);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(113, 21);
            this.comboFilter.TabIndex = 14;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboGroup_SelectedIndexChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(6, 58);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(35, 13);
            this.lblCount.TabIndex = 13;
            this.lblCount.Text = "Count";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(9, 349);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 38);
            this.btnReport.TabIndex = 12;
            this.btnReport.Text = "Generate Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // listBoxReport
            // 
            this.listBoxReport.FormattingEnabled = true;
            this.listBoxReport.Location = new System.Drawing.Point(181, 6);
            this.listBoxReport.Name = "listBoxReport";
            this.listBoxReport.ScrollAlwaysVisible = true;
            this.listBoxReport.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxReport.Size = new System.Drawing.Size(463, 381);
            this.listBoxReport.TabIndex = 11;
            this.listBoxReport.SelectedIndexChanged += new System.EventHandler(this.listBoxReport_SelectedIndexChanged);
            // 
            // comboCountCategory
            // 
            this.comboCountCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCountCategory.FormattingEnabled = true;
            this.comboCountCategory.Items.AddRange(new object[] {
            "Method",
            "Student",
            "Tutor",
            "Course"});
            this.comboCountCategory.Location = new System.Drawing.Point(62, 55);
            this.comboCountCategory.Name = "comboCountCategory";
            this.comboCountCategory.Size = new System.Drawing.Size(113, 21);
            this.comboCountCategory.TabIndex = 10;
            this.comboCountCategory.SelectedIndexChanged += new System.EventHandler(this.comboCountCategory_SelectedIndexChanged);
            // 
            // comboTerm
            // 
            this.comboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTerm.FormattingEnabled = true;
            this.comboTerm.Items.AddRange(new object[] {
            "Winter",
            "Sprint",
            "Summer",
            "Fall"});
            this.comboTerm.Location = new System.Drawing.Point(81, 21);
            this.comboTerm.Name = "comboTerm";
            this.comboTerm.Size = new System.Drawing.Size(74, 21);
            this.comboTerm.TabIndex = 7;
            this.comboTerm.SelectedIndexChanged += new System.EventHandler(this.comboTerm_SelectedIndexChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(6, 24);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 6;
            this.lblYear.Text = "Year:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(100, 109);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(44, 21);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(31, 20);
            this.txtYear.TabIndex = 1;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_KeyPress);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(4, 109);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 0;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.displayBtn_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(591, 439);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Date";
            // 
            // txtEditSignOut
            // 
            this.txtEditSignOut.Location = new System.Drawing.Point(237, 360);
            this.txtEditSignOut.Name = "txtEditSignOut";
            this.txtEditSignOut.Size = new System.Drawing.Size(100, 20);
            this.txtEditSignOut.TabIndex = 25;
            // 
            // txtEditSignIn
            // 
            this.txtEditSignIn.Location = new System.Drawing.Point(131, 360);
            this.txtEditSignIn.Name = "txtEditSignIn";
            this.txtEditSignIn.Size = new System.Drawing.Size(100, 20);
            this.txtEditSignIn.TabIndex = 24;
            // 
            // lblEditSignOut
            // 
            this.lblEditSignOut.AutoSize = true;
            this.lblEditSignOut.Location = new System.Drawing.Point(234, 342);
            this.lblEditSignOut.Name = "lblEditSignOut";
            this.lblEditSignOut.Size = new System.Drawing.Size(48, 13);
            this.lblEditSignOut.TabIndex = 21;
            this.lblEditSignOut.Text = "Sign Out";
            // 
            // lblEditSignIn
            // 
            this.lblEditSignIn.AutoSize = true;
            this.lblEditSignIn.Location = new System.Drawing.Point(128, 342);
            this.lblEditSignIn.Name = "lblEditSignIn";
            this.lblEditSignIn.Size = new System.Drawing.Size(40, 13);
            this.lblEditSignIn.TabIndex = 20;
            this.lblEditSignIn.Text = "Sign In";
            // 
            // txtAddTutor
            // 
            this.txtAddTutor.Enabled = false;
            this.txtAddTutor.Location = new System.Drawing.Point(255, 251);
            this.txtAddTutor.Name = "txtAddTutor";
            this.txtAddTutor.Size = new System.Drawing.Size(100, 20);
            this.txtAddTutor.TabIndex = 37;
            // 
            // txtAddSignOut
            // 
            this.txtAddSignOut.Location = new System.Drawing.Point(440, 212);
            this.txtAddSignOut.Name = "txtAddSignOut";
            this.txtAddSignOut.Size = new System.Drawing.Size(100, 20);
            this.txtAddSignOut.TabIndex = 15;
            // 
            // txtAddSignIn
            // 
            this.txtAddSignIn.Location = new System.Drawing.Point(334, 212);
            this.txtAddSignIn.Name = "txtAddSignIn";
            this.txtAddSignIn.Size = new System.Drawing.Size(100, 20);
            this.txtAddSignIn.TabIndex = 14;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 474);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControlAdmin);
            this.Name = "frmAdmin";
            this.Text = "Administration";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.tabControlAdmin.ResumeLayout(false);
            this.tabVisits.ResumeLayout(false);
            this.tabVisits.PerformLayout();
            this.tabTutors.ResumeLayout(false);
            this.tabTutors.PerformLayout();
            this.tabMethods.ResumeLayout(false);
            this.tabAdmin.ResumeLayout(false);
            this.grpBoxPassword.ResumeLayout(false);
            this.grpBoxPassword.PerformLayout();
            this.tabReports.ResumeLayout(false);
            this.tabReports.PerformLayout();
            this.ResumeLayout(false);

        }
        #region Declarations
        private System.Windows.Forms.TabControl tabControlAdmin;
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
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.Button btnAddVisit;
        private System.Windows.Forms.TextBox txtAddStudentID;
        private System.Windows.Forms.Label lblAddVisit;
        private System.Windows.Forms.Button btnEditVisit;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.GroupBox grpBoxPassword;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TabPage tabMethods;
        private System.Windows.Forms.Button btnSaveMethods;
        private System.Windows.Forms.DateTimePicker dateTimePickerAdd;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblEditVisit;
        private System.Windows.Forms.TextBox txtEditDate;
        private System.Windows.Forms.Label lblEditDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEditMax;
        private System.Windows.Forms.DateTimePicker dateTimePickerEditMin;
        private System.Windows.Forms.Label lblEditDateRange;
        private System.Windows.Forms.TextBox txtEditStudentID;
        private System.Windows.Forms.Label lblEditTimeOut;
        private System.Windows.Forms.Label lblEditTimeIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAddMethod;
        private System.Windows.Forms.Label lblAddClass;
        private System.Windows.Forms.ComboBox comboAddMethod;
        private System.Windows.Forms.Label lblAddTutor;
        private System.Windows.Forms.Button btnAddMethod;
        private System.Windows.Forms.DateTimePicker dateTimePickerEditTimeOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerEditTimeIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerAddTimeOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerAddTimeIn;
        private System.Windows.Forms.ComboBox comboAddTutoring;
        private System.Windows.Forms.Label lblInactiveTutors;
        private System.Windows.Forms.Label lblActiveTutors;
        private System.Windows.Forms.TextBox txtAddTutor;
        private System.Windows.Forms.Label lblEditSignIn;
        private System.Windows.Forms.Label lblEditSignOut;
        private System.Windows.Forms.TextBox txtEditSignIn;
        private System.Windows.Forms.TextBox txtEditSignOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddSignIn;
        private System.Windows.Forms.TextBox txtAddSignOut;
        private System.Windows.Forms.TabPage tabReports;
        #endregion

        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ComboBox comboaddClass;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox comboTerm;
        private System.Windows.Forms.ComboBox comboCountCategory;
        private System.Windows.Forms.Button btn_courses_import;
        private System.Windows.Forms.Button btn_student_import;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.ComboBox comboFilter;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.ListBox listBoxReport;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        //private DataSet1TableAdapters.DataTable2TableAdapter dataTable2TableAdapter;
    }
        #endregion
}
