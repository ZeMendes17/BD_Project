namespace BusinessManagerInterface
{
    partial class StaffManageOrder
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
            this.avail = new System.Windows.Forms.Button();
            this.displayTxt = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // avail
            // 
            this.avail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.avail.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avail.Location = new System.Drawing.Point(112, 380);
            this.avail.Name = "avail";
            this.avail.Size = new System.Drawing.Size(211, 107);
            this.avail.TabIndex = 0;
            this.avail.Text = "Check Avalailability";
            this.avail.UseVisualStyleBackColor = true;
            this.avail.Click += new System.EventHandler(this.avail_Click);
            // 
            // displayTxt
            // 
            this.displayTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.displayTxt.BackColor = System.Drawing.SystemColors.Control;
            this.displayTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayTxt.Location = new System.Drawing.Point(107, 131);
            this.displayTxt.Name = "displayTxt";
            this.displayTxt.Size = new System.Drawing.Size(924, 31);
            this.displayTxt.TabIndex = 3;
            this.displayTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confirm
            // 
            this.confirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirm.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.Location = new System.Drawing.Point(466, 380);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(211, 107);
            this.confirm.TabIndex = 5;
            this.confirm.Text = "Confirm Order";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(820, 380);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(211, 107);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Cancel Order";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // StaffManageOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 591);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.displayTxt);
            this.Controls.Add(this.avail);
            this.Name = "StaffManageOrder";
            this.Text = "StaffManageOrder";
            this.Load += new System.EventHandler(this.StaffManageOrder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button avail;
        private System.Windows.Forms.Label displayTxt;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
    }
}