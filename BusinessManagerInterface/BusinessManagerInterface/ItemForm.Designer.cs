namespace BusinessManagerInterface
{
    partial class ItemForm
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
            this.ItemName = new System.Windows.Forms.Label();
            this.ItemDescription = new System.Windows.Forms.Label();
            this.Suppliers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Suppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemName
            // 
            this.ItemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemName.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemName.Location = new System.Drawing.Point(0, 0);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(1262, 42);
            this.ItemName.TabIndex = 0;
            this.ItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemDescription
            // 
            this.ItemDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemDescription.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemDescription.Location = new System.Drawing.Point(0, 42);
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.Size = new System.Drawing.Size(1262, 33);
            this.ItemDescription.TabIndex = 1;
            // 
            // Suppliers
            // 
            this.Suppliers.AllowUserToAddRows = false;
            this.Suppliers.AllowUserToDeleteRows = false;
            this.Suppliers.AllowUserToResizeColumns = false;
            this.Suppliers.AllowUserToResizeRows = false;
            this.Suppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Suppliers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Suppliers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Suppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Suppliers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Suppliers.Location = new System.Drawing.Point(0, 256);
            this.Suppliers.Name = "Suppliers";
            this.Suppliers.ReadOnly = true;
            this.Suppliers.RowHeadersWidth = 51;
            this.Suppliers.RowTemplate.Height = 24;
            this.Suppliers.Size = new System.Drawing.Size(1262, 361);
            this.Suppliers.TabIndex = 2;
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 617);
            this.Controls.Add(this.Suppliers);
            this.Controls.Add(this.ItemDescription);
            this.Controls.Add(this.ItemName);
            this.Name = "ItemForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ItemForm_Load);
            this.ClientSizeChanged += new System.EventHandler(this.SupplierDataGridView_Adjust);
            this.SizeChanged += new System.EventHandler(this.SupplierDataGridView_Adjust);
            ((System.ComponentModel.ISupportInitialize)(this.Suppliers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ItemName;
        private System.Windows.Forms.Label ItemDescription;
        private System.Windows.Forms.DataGridView Suppliers;
    }
}