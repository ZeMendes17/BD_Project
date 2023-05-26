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
            this.label1 = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // avail
            // 
            this.avail.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avail.Location = new System.Drawing.Point(12, 67);
            this.avail.Name = "avail";
            this.avail.Size = new System.Drawing.Size(203, 31);
            this.avail.TabIndex = 0;
            this.avail.Text = "Check Avalailability";
            this.avail.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.Location = new System.Drawing.Point(256, 431);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(203, 31);
            this.confirm.TabIndex = 5;
            this.confirm.Text = "Confirm Order";
            this.confirm.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(732, 431);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(203, 31);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Cancel Order";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // StaffManageOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 631);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.avail);
            this.Name = "StaffManageOrder";
            this.Text = "StaffManageOrder";
            this.Load += new System.EventHandler(this.StaffManageOrder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button avail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
    }
}