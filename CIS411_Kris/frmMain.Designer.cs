namespace CIS411
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.btnIdSearch = new System.Windows.Forms.Button();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.btnForgotId = new System.Windows.Forms.Button();
            this.groupRadioButtons = new System.Windows.Forms.GroupBox();
            this.comboClassList = new System.Windows.Forms.ComboBox();
            this.comboTutors = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.keyTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(196, 35);
            this.txtStudentID.MaxLength = 8;
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtStudentID.TabIndex = 0;
            this.txtStudentID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtStudentID_PreviewKeyDown);
            // 
            // btnIdSearch
            // 
            this.btnIdSearch.Location = new System.Drawing.Point(314, 12);
            this.btnIdSearch.Name = "btnIdSearch";
            this.btnIdSearch.Size = new System.Drawing.Size(190, 64);
            this.btnIdSearch.TabIndex = 1;
            this.btnIdSearch.Text = "Search by ID";
            this.btnIdSearch.UseVisualStyleBackColor = true;
            this.btnIdSearch.Click += new System.EventHandler(this.btnIdSearch_Click);
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(132, 38);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(58, 13);
            this.lblStudentID.TabIndex = 3;
            this.lblStudentID.Text = "Student ID";
            // 
            // btnForgotId
            // 
            this.btnForgotId.FlatAppearance.BorderSize = 0;
            this.btnForgotId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgotId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgotId.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnForgotId.Location = new System.Drawing.Point(123, 61);
            this.btnForgotId.Name = "btnForgotId";
            this.btnForgotId.Size = new System.Drawing.Size(190, 23);
            this.btnForgotId.TabIndex = 4;
            this.btnForgotId.Text = "Don\'t know your ID number?";
            this.btnForgotId.UseVisualStyleBackColor = true;
            this.btnForgotId.Click += new System.EventHandler(this.btnForgotId_Click);
            // 
            // groupRadioButtons
            // 
            this.groupRadioButtons.Enabled = false;
            this.groupRadioButtons.Location = new System.Drawing.Point(29, 133);
            this.groupRadioButtons.Name = "groupRadioButtons";
            this.groupRadioButtons.Size = new System.Drawing.Size(200, 343);
            this.groupRadioButtons.TabIndex = 5;
            this.groupRadioButtons.TabStop = false;
            this.groupRadioButtons.Text = "I am here for:";
            // 
            // comboClassList
            // 
            this.comboClassList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClassList.Enabled = false;
            this.comboClassList.FormattingEnabled = true;
            this.comboClassList.Location = new System.Drawing.Point(314, 133);
            this.comboClassList.Name = "comboClassList";
            this.comboClassList.Size = new System.Drawing.Size(235, 21);
            this.comboClassList.TabIndex = 6;
            this.comboClassList.SelectedIndexChanged += new System.EventHandler(this.comboClassList_SelectedIndexChanged);
            // 
            // comboTutors
            // 
            this.comboTutors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTutors.FormattingEnabled = true;
            this.comboTutors.Location = new System.Drawing.Point(314, 163);
            this.comboTutors.Name = "comboTutors";
            this.comboTutors.Size = new System.Drawing.Size(235, 21);
            this.comboTutors.TabIndex = 6;
            this.comboTutors.Visible = false;
            this.comboTutors.SelectedIndexChanged += new System.EventHandler(this.comboTutors_SelectedIndexChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(314, 327);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(235, 149);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(12, 500);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(46, 25);
            this.btnAdmin.TabIndex = 8;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(46, 25);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // keyTimer
            // 
            this.keyTimer.Interval = 200;
            this.keyTimer.Tick += new System.EventHandler(this.keyTimer_Tick);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnIdSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 537);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.comboClassList);
            this.Controls.Add(this.comboTutors);
            this.Controls.Add(this.groupRadioButtons);
            this.Controls.Add(this.btnForgotId);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.btnIdSearch);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.btnReset);
            this.Name = "frmMain";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Button btnIdSearch;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Button btnForgotId;
        private System.Windows.Forms.GroupBox groupRadioButtons;
        private System.Windows.Forms.ComboBox comboClassList;
        private System.Windows.Forms.ComboBox comboTutors;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer keyTimer;

    }
}

