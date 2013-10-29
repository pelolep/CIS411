namespace CIS411
{
    partial class frmSwipe
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
            this.lblPleaseSwipe = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPleaseSwipe
            // 
            this.lblPleaseSwipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPleaseSwipe.Location = new System.Drawing.Point(12, 9);
            this.lblPleaseSwipe.Name = "lblPleaseSwipe";
            this.lblPleaseSwipe.Size = new System.Drawing.Size(210, 20);
            this.lblPleaseSwipe.TabIndex = 0;
            this.lblPleaseSwipe.Text = "Please swipe card...";
            this.lblPleaseSwipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(131, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSwipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(234, 88);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPleaseSwipe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmSwipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSwipe";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSwipe_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPleaseSwipe;
        private System.Windows.Forms.Button btnCancel;
//        private System.Windows.Forms.Button btnDontHave;

    }
}