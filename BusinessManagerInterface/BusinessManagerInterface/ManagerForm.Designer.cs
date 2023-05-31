using System;
using System.Drawing;
using System.Windows.Forms;

namespace BusinessManagerInterface
{
    partial class ManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.manageButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridItems = new System.Windows.Forms.DataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridPending = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridShipped = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridDelivered = new System.Windows.Forms.DataGridView();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.canceledDataView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.itemFilter = new System.Windows.Forms.ComboBox();
            this.itemSearch = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tableLayoutSup = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GridRecebidas = new System.Windows.Forms.DataGridView();
            this.GridEnviar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDetails = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPending)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShipped)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDelivered)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canceledDataView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecebidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridEnviar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(430, 40);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1311, 691);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.manageButton);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1303, 643);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Orders";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // manageButton
            // 
            this.manageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.manageButton.BackColor = System.Drawing.Color.Red;
            this.manageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manageButton.Location = new System.Drawing.Point(1151, 6);
            this.manageButton.Name = "manageButton";
            this.manageButton.Size = new System.Drawing.Size(119, 34);
            this.manageButton.TabIndex = 5;
            this.manageButton.Text = "Delete";
            this.manageButton.UseVisualStyleBackColor = false;
            this.manageButton.Click += new System.EventHandler(this.manageButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dataGridItems);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(644, 69);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 566);
            this.panel1.TabIndex = 3;
            this.panel1.SizeChanged += new System.EventHandler(this.Panel1_SizeChanged);
            // 
            // dataGridItems
            // 
            this.dataGridItems.AllowUserToAddRows = false;
            this.dataGridItems.AllowUserToDeleteRows = false;
            this.dataGridItems.AllowUserToResizeColumns = false;
            this.dataGridItems.AllowUserToResizeRows = false;
            this.dataGridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridItems.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridItems.Location = new System.Drawing.Point(0, 344);
            this.dataGridItems.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridItems.Name = "dataGridItems";
            this.dataGridItems.RowHeadersWidth = 51;
            this.dataGridItems.Size = new System.Drawing.Size(617, 218);
            this.dataGridItems.TabIndex = 0;
            this.dataGridItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridItems_CellContentClick);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.ItemSize = new System.Drawing.Size(150, 25);
            this.tabControl2.Location = new System.Drawing.Point(1, 39);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(641, 602);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 2;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage4.Controls.Add(this.dataGridPending);
            this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.ForeColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(633, 569);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Pending";
            // 
            // dataGridPending
            // 
            this.dataGridPending.AllowUserToAddRows = false;
            this.dataGridPending.AllowUserToDeleteRows = false;
            this.dataGridPending.AllowUserToOrderColumns = true;
            this.dataGridPending.AllowUserToResizeColumns = false;
            this.dataGridPending.AllowUserToResizeRows = false;
            this.dataGridPending.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPending.Location = new System.Drawing.Point(3, 2);
            this.dataGridPending.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridPending.Name = "dataGridPending";
            this.dataGridPending.ReadOnly = true;
            this.dataGridPending.RowHeadersWidth = 51;
            this.dataGridPending.RowTemplate.Height = 24;
            this.dataGridPending.Size = new System.Drawing.Size(623, 561);
            this.dataGridPending.TabIndex = 0;
            this.dataGridPending.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPending_CellContentClick);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage5.Controls.Add(this.dataGridShipped);
            this.tabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(633, 569);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Shipped";
            // 
            // dataGridShipped
            // 
            this.dataGridShipped.AllowUserToAddRows = false;
            this.dataGridShipped.AllowUserToDeleteRows = false;
            this.dataGridShipped.AllowUserToOrderColumns = true;
            this.dataGridShipped.AllowUserToResizeColumns = false;
            this.dataGridShipped.AllowUserToResizeRows = false;
            this.dataGridShipped.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridShipped.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridShipped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridShipped.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridShipped.Location = new System.Drawing.Point(3, 2);
            this.dataGridShipped.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridShipped.Name = "dataGridShipped";
            this.dataGridShipped.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridShipped.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridShipped.RowHeadersWidth = 51;
            this.dataGridShipped.RowTemplate.Height = 24;
            this.dataGridShipped.Size = new System.Drawing.Size(623, 561);
            this.dataGridShipped.TabIndex = 0;
            this.dataGridShipped.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridShipped_CellContentClick);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage6.Controls.Add(this.dataGridDelivered);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(633, 569);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Delivered";
            // 
            // dataGridDelivered
            // 
            this.dataGridDelivered.AllowUserToAddRows = false;
            this.dataGridDelivered.AllowUserToDeleteRows = false;
            this.dataGridDelivered.AllowUserToOrderColumns = true;
            this.dataGridDelivered.AllowUserToResizeColumns = false;
            this.dataGridDelivered.AllowUserToResizeRows = false;
            this.dataGridDelivered.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDelivered.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDelivered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDelivered.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridDelivered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDelivered.Location = new System.Drawing.Point(0, 0);
            this.dataGridDelivered.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridDelivered.Name = "dataGridDelivered";
            this.dataGridDelivered.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDelivered.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridDelivered.RowHeadersWidth = 51;
            this.dataGridDelivered.RowTemplate.Height = 24;
            this.dataGridDelivered.Size = new System.Drawing.Size(629, 565);
            this.dataGridDelivered.TabIndex = 0;
            this.dataGridDelivered.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDelivered_CellContentClick);
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.canceledDataView);
            this.tabPage10.Location = new System.Drawing.Point(4, 29);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(633, 569);
            this.tabPage10.TabIndex = 3;
            this.tabPage10.Text = "Canceled";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // canceledDataView
            // 
            this.canceledDataView.AllowUserToAddRows = false;
            this.canceledDataView.AllowUserToDeleteRows = false;
            this.canceledDataView.AllowUserToResizeColumns = false;
            this.canceledDataView.AllowUserToResizeRows = false;
            this.canceledDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.canceledDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.canceledDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canceledDataView.Location = new System.Drawing.Point(0, 0);
            this.canceledDataView.Name = "canceledDataView";
            this.canceledDataView.ReadOnly = true;
            this.canceledDataView.RowHeadersWidth = 51;
            this.canceledDataView.RowTemplate.Height = 24;
            this.canceledDataView.Size = new System.Drawing.Size(633, 569);
            this.canceledDataView.TabIndex = 0;
            this.canceledDataView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.canceledDataView_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.ItemsDataGridView);
            this.tabPage2.Controls.Add(this.itemFilter);
            this.tabPage2.Controls.Add(this.itemSearch);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1303, 643);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stock";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ItemsDataGridView
            // 
            this.ItemsDataGridView.AllowUserToAddRows = false;
            this.ItemsDataGridView.AllowUserToDeleteRows = false;
            this.ItemsDataGridView.AllowUserToResizeColumns = false;
            this.ItemsDataGridView.AllowUserToResizeRows = false;
            this.ItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ItemsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ItemsDataGridView.Location = new System.Drawing.Point(3, 79);
            this.ItemsDataGridView.Name = "ItemsDataGridView";
            this.ItemsDataGridView.ReadOnly = true;
            this.ItemsDataGridView.RowHeadersWidth = 51;
            this.ItemsDataGridView.RowTemplate.Height = 24;
            this.ItemsDataGridView.Size = new System.Drawing.Size(1293, 558);
            this.ItemsDataGridView.TabIndex = 2;
            this.ItemsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemDataGridView_CellContentClick);
            // 
            // itemFilter
            // 
            this.itemFilter.FormattingEnabled = true;
            this.itemFilter.Items.AddRange(new object[] {
            "Name",
            "ID"});
            this.itemFilter.Location = new System.Drawing.Point(6, 5);
            this.itemFilter.Name = "itemFilter";
            this.itemFilter.Size = new System.Drawing.Size(206, 37);
            this.itemFilter.TabIndex = 1;
            // 
            // itemSearch
            // 
            this.itemSearch.Location = new System.Drawing.Point(218, 6);
            this.itemSearch.Name = "itemSearch";
            this.itemSearch.Size = new System.Drawing.Size(307, 34);
            this.itemSearch.TabIndex = 0;
            this.itemSearch.TextChanged += new System.EventHandler(this.itemSearchChange);
            // 
            // tabPage7
            // 
            this.tabPage7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage7.Controls.Add(this.tabControl3);
            this.tabPage7.Location = new System.Drawing.Point(4, 44);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1303, 643);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Messages";
            this.tabPage7.UseVisualStyleBackColor = true;
            this.tabPage7.Click += new System.EventHandler(this.tabPage7_Click);
            this.tabPage7.Enter += new System.EventHandler(this.tabPage8_Enter);
            // 
            // tabControl3
            // 
            this.tabControl3.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl3.ItemSize = new System.Drawing.Size(430, 40);
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1299, 639);
            this.tabControl3.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage8.Controls.Add(this.tableLayoutPanel);
            this.tabPage8.Location = new System.Drawing.Point(4, 44);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage8.Size = new System.Drawing.Size(1291, 591);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "Transport";
            this.tabPage8.UseVisualStyleBackColor = true;
            this.tabPage8.Enter += new System.EventHandler(this.tabPage8_Enter);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1281F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1281, 583);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tabPage9
            // 
            this.tabPage9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage9.Controls.Add(this.tableLayoutSup);
            this.tabPage9.Location = new System.Drawing.Point(4, 44);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage9.Size = new System.Drawing.Size(1291, 591);
            this.tabPage9.TabIndex = 0;
            this.tabPage9.Text = "Supplier";
            this.tabPage9.UseVisualStyleBackColor = true;
            this.tabPage9.Enter += new System.EventHandler(this.tabPage9_Enter);
            // 
            // tableLayoutSup
            // 
            this.tableLayoutSup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1281F));
            this.tableLayoutSup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSup.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutSup.Name = "tableLayoutSup";
            this.tableLayoutSup.RowCount = 2;
            this.tableLayoutSup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSup.Size = new System.Drawing.Size(1281, 583);
            this.tableLayoutSup.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.info);
            this.tabPage3.Controls.Add(this.name);
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1303, 643);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Personal Area";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Campo 1";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Campo 2";
            // 
            // GridRecebidas
            // 
            this.GridRecebidas.ColumnHeadersHeight = 29;
            this.GridRecebidas.Location = new System.Drawing.Point(0, 0);
            this.GridRecebidas.Name = "GridRecebidas";
            this.GridRecebidas.RowHeadersWidth = 51;
            this.GridRecebidas.Size = new System.Drawing.Size(240, 150);
            this.GridRecebidas.TabIndex = 0;
            // 
            // GridEnviar
            // 
            this.GridEnviar.ColumnHeadersHeight = 29;
            this.GridEnviar.Location = new System.Drawing.Point(0, 0);
            this.GridEnviar.Name = "GridEnviar";
            this.GridEnviar.RowHeadersWidth = 51;
            this.GridEnviar.Size = new System.Drawing.Size(240, 150);
            this.GridEnviar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(590, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Details:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelDetails
            // 
            this.labelDetails.Location = new System.Drawing.Point(4, 0);
            this.labelDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(620, 66);
            this.labelDetails.TabIndex = 1;
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.name.Dock = System.Windows.Forms.DockStyle.Top;
            this.name.Location = new System.Drawing.Point(0, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(1299, 29);
            this.name.TabIndex = 0;
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Dock = System.Windows.Forms.DockStyle.Top;
            this.info.Location = new System.Drawing.Point(0, 29);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 29);
            this.info.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1299, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1311, 691);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManagerForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            this.ClientSizeChanged += new System.EventHandler(this.ManagerForm_Adjust);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPending)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShipped)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDelivered)).EndInit();
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canceledDataView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecebidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridEnviar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }




        private void ItemsDataGridView_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridPending;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridShipped;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridDelivered;
        private System.Windows.Forms.DataGridView dataGridItems;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.Button manageButton;
        private System.Windows.Forms.DataGridView ItemsDataGridView;
        private System.Windows.Forms.ComboBox itemFilter;
        private System.Windows.Forms.TextBox itemSearch;
        private TableLayoutPanel tableLayoutPanel;
        private TableLayoutPanel tableLayoutSup;
        private DataGridView GridRecebidas;
        private DataGridView GridEnviar;
        private Label label5;
        private Label label6;
        private TabPage tabPage10;
        private DataGridView canceledDataView;
        private Label info;
        private Label name;
        private DataGridView dataGridView1;
    }
}