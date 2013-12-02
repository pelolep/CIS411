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
            this.SuspendLayout();
            // 
            // lblEditing
            // 
            this.lblEditing.AutoSize = true;
            this.lblEditing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditing.Location = new System.Drawing.Point(13, 19);
            this.lblEditing.Name = "lblEditing";
            this.lblEditing.Size = new System.Drawing.Size(51, 17);
            this.lblEditing.TabIndex = 0;
            this.lblEditing.Text = "Editing";
            // 
            // listBoxEditVisit
            // 
            this.listBoxEditVisit.FormattingEnabled = true;
            this.listBoxEditVisit.Location = new System.Drawing.Point(16, 39);
            this.listBoxEditVisit.Name = "listBoxEditVisit";
            this.listBoxEditVisit.Size = new System.Drawing.Size(615, 329);
            this.listBoxEditVisit.TabIndex = 1;
            // 
            // btnEditSelectedVisit
            // 
            this.btnEditSelectedVisit.Location = new System.Drawing.Point(530, 374);
            this.btnEditSelectedVisit.Name = "btnEditSelectedVisit";
            this.btnEditSelectedVisit.Size = new System.Drawing.Size(101, 44);
            this.btnEditSelectedVisit.TabIndex = 2;
            this.btnEditSelectedVisit.Text = "Edit Selected Visit";
            this.btnEditSelectedVisit.UseVisualStyleBackColor = true;
            this.btnEditSelectedVisit.Click += new System.EventHandler(this.btnEditSelectedVisit_Click);
            // 
            // frmEditList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 440);
            this.Controls.Add(this.btnEditSelectedVisit);
            this.Controls.Add(this.listBoxEditVisit);
            this.Controls.Add(this.lblEditing);
            this.Name = "frmEditList";
            this.Text = "frmEditList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEditing;
        private System.Windows.Forms.ListBox listBoxEditVisit;
        private System.Windows.Forms.Button btnEditSelectedVisit;
    }
}