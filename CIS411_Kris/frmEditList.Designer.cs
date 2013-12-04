namespace CIS411
{
    partial class frmEditList
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
            this.lblEditing = new System.Windows.Forms.Label();
            this.listBoxEditVisit = new System.Windows.Forms.ListBox();
            this.btnEditSelectedVisit = new System.Windows.Forms.Button();
            this.comboEditMethod = new System.Windows.Forms.ComboBox();
            this.lblEditMethod = new System.Windows.Forms.Label();
            this.dateTimePickerEditTimeOut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEditTimeIn = new System.Windows.Forms.DateTimePicker();
            this.txtEditDate = new System.Windows.Forms.TextBox();
            this.lblEditDate = new System.Windows.Forms.Label();
            this.txtEditStudentID = new System.Windows.Forms.TextBox();
            this.lblEditTimeOut = new System.Windows.Forms.Label();
            this.lblEditTimeIn = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboaddClass = new System.Windows.Forms.ComboBox();
            this.comboAddTutoring = new System.Windows.Forms.ComboBox();
            this.lblAddTutor = new System.Windows.Forms.Label();
            this.lblAddClass = new System.Windows.Forms.Label();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.btnDeleteVisit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEditing
            // 
            this.lblEditing.AutoSize = true;
            this.lblEditing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditing.Location = new System.Drawing.Point(3, 0);
            this.lblEditing.Name = "lblEditing";
            this.lblEditing.Size = new System.Drawing.Size(51, 17);
            this.lblEditing.TabIndex = 0;
            this.lblEditing.Text = "Editing";
            // 
            // listBoxEditVisit
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxEditVisit, 5);
            this.listBoxEditVisit.FormattingEnabled = true;
            this.listBoxEditVisit.Location = new System.Drawing.Point(3, 20);
            this.listBoxEditVisit.Name = "listBoxEditVisit";
            this.listBoxEditVisit.Size = new System.Drawing.Size(880, 134);
            this.listBoxEditVisit.TabIndex = 1;
            // 
            // btnEditSelectedVisit
            // 
            this.btnEditSelectedVisit.Location = new System.Drawing.Point(464, 160);
            this.btnEditSelectedVisit.Name = "btnEditSelectedVisit";
            this.tableLayoutPanel1.SetRowSpan(this.btnEditSelectedVisit, 2);
            this.btnEditSelectedVisit.Size = new System.Drawing.Size(101, 44);
            this.btnEditSelectedVisit.TabIndex = 2;
            this.btnEditSelectedVisit.Text = "Select Visit";
            this.btnEditSelectedVisit.UseVisualStyleBackColor = true;
            this.btnEditSelectedVisit.Click += new System.EventHandler(this.btnEditSelectedVisit_Click);
            // 
            // comboEditMethod
            // 
            this.comboEditMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEditMethod.Enabled = false;
            this.comboEditMethod.FormattingEnabled = true;
            this.comboEditMethod.Location = new System.Drawing.Point(337, 223);
            this.comboEditMethod.Name = "comboEditMethod";
            this.comboEditMethod.Size = new System.Drawing.Size(121, 21);
            this.comboEditMethod.TabIndex = 59;
            this.comboEditMethod.SelectedIndexChanged += new System.EventHandler(this.comboEditMethod_SelectedIndexChanged);
            // 
            // lblEditMethod
            // 
            this.lblEditMethod.AutoSize = true;
            this.lblEditMethod.Location = new System.Drawing.Point(337, 207);
            this.lblEditMethod.Name = "lblEditMethod";
            this.lblEditMethod.Size = new System.Drawing.Size(43, 13);
            this.lblEditMethod.TabIndex = 58;
            this.lblEditMethod.Text = "Method";
            // 
            // dateTimePickerEditTimeOut
            // 
            this.dateTimePickerEditTimeOut.Enabled = false;
            this.dateTimePickerEditTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerEditTimeOut.Location = new System.Drawing.Point(245, 223);
            this.dateTimePickerEditTimeOut.Name = "dateTimePickerEditTimeOut";
            this.dateTimePickerEditTimeOut.ShowUpDown = true;
            this.dateTimePickerEditTimeOut.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerEditTimeOut.TabIndex = 57;
            this.dateTimePickerEditTimeOut.Value = new System.DateTime(2013, 11, 12, 16, 23, 0, 0);
            // 
            // dateTimePickerEditTimeIn
            // 
            this.dateTimePickerEditTimeIn.Enabled = false;
            this.dateTimePickerEditTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerEditTimeIn.Location = new System.Drawing.Point(118, 223);
            this.dateTimePickerEditTimeIn.Name = "dateTimePickerEditTimeIn";
            this.dateTimePickerEditTimeIn.ShowUpDown = true;
            this.dateTimePickerEditTimeIn.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerEditTimeIn.TabIndex = 56;
            this.dateTimePickerEditTimeIn.Value = new System.DateTime(2013, 11, 12, 16, 23, 0, 0);
            // 
            // txtEditDate
            // 
            this.txtEditDate.Enabled = false;
            this.txtEditDate.Location = new System.Drawing.Point(3, 223);
            this.txtEditDate.Name = "txtEditDate";
            this.txtEditDate.Size = new System.Drawing.Size(100, 20);
            this.txtEditDate.TabIndex = 55;
            // 
            // lblEditDate
            // 
            this.lblEditDate.AutoSize = true;
            this.lblEditDate.Location = new System.Drawing.Point(3, 207);
            this.lblEditDate.Name = "lblEditDate";
            this.lblEditDate.Size = new System.Drawing.Size(30, 13);
            this.lblEditDate.TabIndex = 54;
            this.lblEditDate.Text = "Date";
            // 
            // txtEditStudentID
            // 
            this.txtEditStudentID.Enabled = false;
            this.txtEditStudentID.Location = new System.Drawing.Point(3, 173);
            this.txtEditStudentID.MaxLength = 8;
            this.txtEditStudentID.Name = "txtEditStudentID";
            this.txtEditStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtEditStudentID.TabIndex = 50;
            // 
            // lblEditTimeOut
            // 
            this.lblEditTimeOut.AutoSize = true;
            this.lblEditTimeOut.Location = new System.Drawing.Point(245, 207);
            this.lblEditTimeOut.Name = "lblEditTimeOut";
            this.lblEditTimeOut.Size = new System.Drawing.Size(50, 13);
            this.lblEditTimeOut.TabIndex = 49;
            this.lblEditTimeOut.Text = "Time Out";
            // 
            // lblEditTimeIn
            // 
            this.lblEditTimeIn.AutoSize = true;
            this.lblEditTimeIn.Location = new System.Drawing.Point(118, 207);
            this.lblEditTimeIn.Name = "lblEditTimeIn";
            this.lblEditTimeIn.Size = new System.Drawing.Size(42, 13);
            this.lblEditTimeIn.TabIndex = 48;
            this.lblEditTimeIn.Text = "Time In";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Student ID";
            // 
            // comboaddClass
            // 
            this.comboaddClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboaddClass.Enabled = false;
            this.comboaddClass.FormattingEnabled = true;
            this.comboaddClass.Location = new System.Drawing.Point(3, 273);
            this.comboaddClass.Name = "comboaddClass";
            this.comboaddClass.Size = new System.Drawing.Size(109, 21);
            this.comboaddClass.TabIndex = 63;
            // 
            // comboAddTutoring
            // 
            this.comboAddTutoring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAddTutoring.Enabled = false;
            this.comboAddTutoring.FormattingEnabled = true;
            this.comboAddTutoring.Location = new System.Drawing.Point(118, 273);
            this.comboAddTutoring.Name = "comboAddTutoring";
            this.comboAddTutoring.Size = new System.Drawing.Size(121, 21);
            this.comboAddTutoring.TabIndex = 62;
            // 
            // lblAddTutor
            // 
            this.lblAddTutor.AutoSize = true;
            this.lblAddTutor.Location = new System.Drawing.Point(118, 257);
            this.lblAddTutor.Name = "lblAddTutor";
            this.lblAddTutor.Size = new System.Drawing.Size(32, 13);
            this.lblAddTutor.TabIndex = 61;
            this.lblAddTutor.Text = "Tutor";
            // 
            // lblAddClass
            // 
            this.lblAddClass.AutoSize = true;
            this.lblAddClass.Location = new System.Drawing.Point(3, 257);
            this.lblAddClass.Name = "lblAddClass";
            this.lblAddClass.Size = new System.Drawing.Size(32, 13);
            this.lblAddClass.TabIndex = 60;
            this.lblAddClass.Text = "Class";
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Enabled = false;
            this.btnSaveEdit.Location = new System.Drawing.Point(464, 210);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.tableLayoutPanel1.SetRowSpan(this.btnSaveEdit, 2);
            this.btnSaveEdit.Size = new System.Drawing.Size(101, 44);
            this.btnSaveEdit.TabIndex = 64;
            this.btnSaveEdit.Text = "Save Edit";
            this.btnSaveEdit.UseVisualStyleBackColor = true;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // btnDeleteVisit
            // 
            this.btnDeleteVisit.Location = new System.Drawing.Point(464, 260);
            this.btnDeleteVisit.Name = "btnDeleteVisit";
            this.tableLayoutPanel1.SetRowSpan(this.btnDeleteVisit, 2);
            this.btnDeleteVisit.Size = new System.Drawing.Size(101, 44);
            this.btnDeleteVisit.TabIndex = 65;
            this.btnDeleteVisit.Text = "Delete Visit";
            this.btnDeleteVisit.UseVisualStyleBackColor = true;
            this.btnDeleteVisit.Click += new System.EventHandler(this.btnDeleteVisit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblEditing, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboAddTutoring, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.comboaddClass, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblAddTutor, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteVisit, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.listBoxEditVisit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveEdit, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblAddClass, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtEditStudentID, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblEditDate, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtEditDate, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblEditTimeIn, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnEditSelectedVisit, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboEditMethod, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerEditTimeIn, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblEditMethod, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblEditTimeOut, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerEditTimeOut, 2, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(892, 345);
            this.tableLayoutPanel1.TabIndex = 66;
            // 
            // frmEditList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 440);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmEditList";
            this.Text = "frmEditList";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEditing;
        private System.Windows.Forms.ListBox listBoxEditVisit;
        private System.Windows.Forms.Button btnEditSelectedVisit;
        internal System.Windows.Forms.ComboBox comboEditMethod;
        private System.Windows.Forms.Label lblEditMethod;
        internal System.Windows.Forms.DateTimePicker dateTimePickerEditTimeOut;
        internal System.Windows.Forms.DateTimePicker dateTimePickerEditTimeIn;
        internal System.Windows.Forms.TextBox txtEditDate;
        private System.Windows.Forms.Label lblEditDate;
        private System.Windows.Forms.TextBox txtEditStudentID;
        private System.Windows.Forms.Label lblEditTimeOut;
        private System.Windows.Forms.Label lblEditTimeIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboaddClass;
        private System.Windows.Forms.ComboBox comboAddTutoring;
        private System.Windows.Forms.Label lblAddTutor;
        private System.Windows.Forms.Label lblAddClass;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Button btnDeleteVisit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}