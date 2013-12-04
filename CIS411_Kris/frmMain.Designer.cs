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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStudentID
            // 
            this.txtStudentID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStudentID.Location = new System.Drawing.Point(119, 34);
            this.txtStudentID.MaxLength = 8;
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtStudentID.TabIndex = 0;
            this.txtStudentID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtStudentID_PreviewKeyDown);
            // 
            // btnIdSearch
            // 
            this.btnIdSearch.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.btnIdSearch, 2);
            this.btnIdSearch.Location = new System.Drawing.Point(261, 34);
            this.btnIdSearch.Name = "btnIdSearch";
            this.tableLayoutPanel1.SetRowSpan(this.btnIdSearch, 2);
            this.btnIdSearch.Size = new System.Drawing.Size(190, 64);
            this.btnIdSearch.TabIndex = 1;
            this.btnIdSearch.Text = "Search by ID";
            this.btnIdSearch.UseVisualStyleBackColor = true;
            this.btnIdSearch.Click += new System.EventHandler(this.btnIdSearch_Click);
            // 
            // lblStudentID
            // 
            this.lblStudentID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(55, 44);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(58, 13);
            this.lblStudentID.TabIndex = 3;
            this.lblStudentID.Text = "Student ID";
            // 
            // btnForgotId
            // 
            this.btnForgotId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnForgotId, 2);
            this.btnForgotId.FlatAppearance.BorderSize = 0;
            this.btnForgotId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgotId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgotId.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnForgotId.Location = new System.Drawing.Point(65, 60);
            this.btnForgotId.Name = "btnForgotId";
            this.btnForgotId.Size = new System.Drawing.Size(190, 23);
            this.btnForgotId.TabIndex = 4;
            this.btnForgotId.Text = "Don\'t know your ID number?";
            this.btnForgotId.UseVisualStyleBackColor = true;
            this.btnForgotId.Click += new System.EventHandler(this.btnForgotId_Click);
            // 
            // groupRadioButtons
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupRadioButtons, 2);
            this.groupRadioButtons.Enabled = false;
            this.groupRadioButtons.Location = new System.Drawing.Point(55, 104);
            this.groupRadioButtons.Name = "groupRadioButtons";
            this.tableLayoutPanel1.SetRowSpan(this.groupRadioButtons, 11);
            this.groupRadioButtons.Size = new System.Drawing.Size(200, 343);
            this.groupRadioButtons.TabIndex = 5;
            this.groupRadioButtons.TabStop = false;
            this.groupRadioButtons.Text = "I am here for:";
            // 
            // comboClassList
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboClassList, 2);
            this.comboClassList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClassList.Enabled = false;
            this.comboClassList.FormattingEnabled = true;
            this.comboClassList.Location = new System.Drawing.Point(261, 132);
            this.comboClassList.Name = "comboClassList";
            this.comboClassList.Size = new System.Drawing.Size(235, 21);
            this.comboClassList.TabIndex = 6;
            this.comboClassList.SelectedIndexChanged += new System.EventHandler(this.comboClassList_SelectedIndexChanged);
            // 
            // comboTutors
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboTutors, 2);
            this.comboTutors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTutors.FormattingEnabled = true;
            this.comboTutors.Location = new System.Drawing.Point(261, 159);
            this.comboTutors.Name = "comboTutors";
            this.comboTutors.Size = new System.Drawing.Size(235, 21);
            this.comboTutors.TabIndex = 6;
            this.comboTutors.Visible = false;
            this.comboTutors.SelectedIndexChanged += new System.EventHandler(this.comboTutors_SelectedIndexChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(261, 270);
            this.btnSubmit.Name = "btnSubmit";
            this.tableLayoutPanel1.SetRowSpan(this.btnSubmit, 2);
            this.btnSubmit.Size = new System.Drawing.Size(235, 90);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdmin.Location = new System.Drawing.Point(3, 491);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(46, 25);
            this.btnAdmin.TabIndex = 8;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = true;
            this.btnReset.Location = new System.Drawing.Point(3, 3);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnReset, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdmin, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.lblStudentID, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtStudentID, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboTutors, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboClassList, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnIdSearch, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupRadioButtons, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnForgotId, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSubmit, 3, 9);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 16;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(553, 519);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnIdSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 537);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMain";
            this.Text = "Login";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}

