﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessManagerInterface
{
    public partial class StaffForm : Form
    {

        private SqlConnection cn;
        String dbServer = "tcp:mednat.ieeta.pt\\SQLSERVER,8101";
        String dbName = "p5g4";
        String userName = "p5g4";
        String userPass = "Bz105107!";

        public Staff St { get; set; }
        public StaffForm()
        {
            InitializeComponent();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data Source = " + dbServer + " ;" + "initial Catalog = " + dbName + ";" + "uid = " + userName + ";" + "password = " + userPass);
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            // fullscreen
            this.WindowState = FormWindowState.Maximized;
            cn = getSGBDConnection();
            verifySGBDConnection();
            SqlCommand cmd = new SqlCommand("Project.getOrdersFromStore", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@store", St.Url);
            cmd.Parameters.AddWithValue("@state", "Pending");
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridPending.DataSource = dt;

            cmd = new SqlCommand("Project.getOrdersFromStore", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@store", St.Url);
            cmd.Parameters.AddWithValue("@state", "Shipped");
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridShipped.DataSource = dt;

            cmd = new SqlCommand("Project.getOrdersFromStore", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@store", St.Url);
            cmd.Parameters.AddWithValue("@state", "Delivered");
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridDelivered.DataSource = dt;

            // items in stock
            cmd = new SqlCommand("SELECT ID, ItemDescription AS Product, Quantity AS InStock, Price FROM Project.ITEM WHERE StoreURL=@store", cn);
            cmd.Parameters.AddWithValue("@store", St.Url);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            ItemsDataGridView.DataSource = dt;

            // items gridView
            dataGridItems.Hide();
        }

        private void StaffForm_Adjust(object sender, EventArgs e)
        {
            this.tabControl1.ItemSize = new Size((tabControl1.Width / tabControl1.TabCount) - 4
                , tabControl1.ItemSize.Height);

            this.tabControl2.Width = this.Width / 2;

            this.panel1.Width = this.Width / 2;
            this.panel1.Location = new Point(Width / 2, 69);
            this.tabControl2.Location = new Point(0, 69 - 28);
            
            this.ItemsDataGridView.Height = this.tabControl1.Height - 100;
        }


        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridPending_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridPending.Rows[e.RowIndex];
                String costumerNIF = selectedRow.Cells["CostumerNIF"].Value.ToString();
                String orderNum = selectedRow.Cells["OrderNumber"].Value.ToString();
                bool flag = false;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Project.PERSON", cn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["NIF"].ToString() == costumerNIF)
                    {
                        labelDetails.AutoSize = true;
                        labelDetails.Text = "Name: " + rdr["Pname"].ToString() + "\n\n";
                        labelDetails.Text += "NIF: " + costumerNIF + "\n\n";
                        labelDetails.Text += "Address: " + rdr["Address"].ToString() + "\n\n";
                        labelDetails.Text += "Phone Number: " + rdr["PhoneNumb"].ToString() + "\n\n";
                        labelDetails.Text += "Email: " + rdr["Email"].ToString() + "\n\n\n";
                        flag = true;
                    }
                }
                rdr.Close();

                if (flag)
                {
                    labelDetails.Text += "\n" + "Ordered Items (click on product to check availability):";
                    panel1.Controls.Add(labelDetails);

                    dataGridItems.Show();
                    dataGridItems.Height = panel1.Height - labelDetails.Height - 20;

                    cmd = new SqlCommand("SELECT ItemID, ItemDescription, Quantity, Price FROM Project.ItemsInOrderView WHERE OrderNumber=@order", cn);
                    cmd.Parameters.AddWithValue("@order", int.Parse(orderNum));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridItems.DataSource = dt;

                    flag = false;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void dataGridShipped_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridShipped.Rows[e.RowIndex];
                String costumerNIF = selectedRow.Cells["CostumerNIF"].Value.ToString();
                String orderNum = selectedRow.Cells["OrderNumber"].Value.ToString();
                bool flag = false;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Project.PERSON", cn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["NIF"].ToString() == costumerNIF)
                    {
                        labelDetails.AutoSize = true;
                        labelDetails.Text = "Name: " + rdr["Pname"].ToString() + "\n\n";
                        labelDetails.Text += "NIF: " + costumerNIF + "\n\n";
                        labelDetails.Text += "Address: " + rdr["Address"].ToString() + "\n\n";
                        labelDetails.Text += "Phone Number: " + rdr["PhoneNumb"].ToString() + "\n\n";
                        labelDetails.Text += "Email: " + rdr["Email"].ToString() + "\n\n\n";
                        flag = true;
                    }
                }
                rdr.Close();

                if (flag)
                {
                    cmd = new SqlCommand("SELECT * FROM Project.TRANSPORT", cn);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["OrderNumber"].ToString() == orderNum)
                        {
                            labelDetails.Text += "Delivery Company: " + rdr["CompanyName"] + ", " + rdr["CompanyEmail"] + "\n\n";
                            labelDetails.Text += "Transportation Method: " + rdr["Method"] + "\n\n";
                            labelDetails.Text += "Transport Number: " + rdr["TransportNumber"] + "\n\n";
                        }
                    }
                    rdr.Close();


                    labelDetails.Text += "\n" + "Ordered Items:";
                    panel1.Controls.Add(labelDetails);

                    dataGridItems.Show();
                    dataGridItems.Height = panel1.Height - labelDetails.Height - 20;

                    cmd = new SqlCommand("SELECT ItemID, ItemDescription, Quantity, Price FROM Project.ItemsInOrderView WHERE OrderNumber=@order", cn);
                    cmd.Parameters.AddWithValue("@order", int.Parse(orderNum));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridItems.DataSource = dt;

                    flag = false;
                }
            }
            catch(System.ArgumentOutOfRangeException)
            {

            }
        }

        private void dataGridDelivered_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridDelivered.Rows[e.RowIndex];
                String costumerNIF = selectedRow.Cells["CostumerNIF"].Value.ToString();
                String orderNum = selectedRow.Cells["OrderNumber"].Value.ToString();
                bool flag = false;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Project.PERSON", cn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["NIF"].ToString() == costumerNIF)
                    {
                        labelDetails.AutoSize = true;
                        labelDetails.Text = "Name: " + rdr["Pname"].ToString() + "\n\n";
                        labelDetails.Text += "NIF: " + costumerNIF + "\n\n";
                        labelDetails.Text += "Address: " + rdr["Address"].ToString() + "\n\n";
                        labelDetails.Text += "Phone Number: " + rdr["PhoneNumb"].ToString() + "\n\n";
                        labelDetails.Text += "Email: " + rdr["Email"].ToString() + "\n\n\n";
                        flag = true;
                    }
                }
                rdr.Close();

                if (flag)
                {
                    cmd = new SqlCommand("SELECT * FROM Project.TRANSPORT", cn);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["OrderNumber"].ToString() == orderNum)
                        {
                            labelDetails.Text += "Delivery Company: " + rdr["CompanyName"] + ", " + rdr["CompanyEmail"] + "\n\n";
                            labelDetails.Text += "Transportation Method: " + rdr["Method"] + "\n\n";
                            labelDetails.Text += "Transport Number: " + rdr["TransportNumber"] + "\n\n";
                        }
                    }
                    rdr.Close();


                    labelDetails.Text += "\n" + "Ordered Items:";
                    panel1.Controls.Add(labelDetails);

                    dataGridItems.Show();
                    dataGridItems.Height = panel1.Height - labelDetails.Height - 20;

                    cmd = new SqlCommand("SELECT ItemID, ItemDescription, Quantity, Price FROM Project.ItemsInOrderView WHERE OrderNumber=@order", cn);
                    cmd.Parameters.AddWithValue("@order", int.Parse(orderNum));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridItems.DataSource = dt;

                    flag = false;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            dataGridItems.Height = panel1.Height - labelDetails.Height - 20;
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tabPage4)
            {
                manageButton.Visible = true;
            }
            else
            {
                manageButton.Visible = false;
            }
        }

        // for stock items display
        private void itemDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ItemForm form = new ItemForm();
                DataGridViewRow selectedRow = ItemsDataGridView.Rows[e.RowIndex];
                int itemID = int.Parse(selectedRow.Cells["ID"].Value.ToString());
                Console.WriteLine(itemID);
                Item i = new Item(itemID);
                i.Name = selectedRow.Cells["Product"].Value.ToString();
                i.Price = double.Parse(selectedRow.Cells["Price"].Value.ToString());
                i.Quantity = int.Parse(selectedRow.Cells["InStock"].Value.ToString());
                form.item = i;
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void itemSearchChange(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ItemsDataGridView.Rows)
            {
                row.Visible = true;
            }

            string searchTerm = itemSearch.Text.ToLower();
            string selected = itemFilter.Text;
            int colIndex;

            if (selected == null)
            {
                return;
            }
            else
            {
                if(selected.Equals("ID"))
                {
                    colIndex = 0;
                } else {
                    colIndex = 1;
                }
            }
            foreach (DataGridViewRow row in ItemsDataGridView.Rows)
            {
                bool rowVisible = false;
                if (row.Cells[colIndex].Value.ToString().ToLower().Contains(searchTerm))
                {
                    Console.WriteLine(searchTerm + " --> " + row.Cells[colIndex].Value.ToString());
                    rowVisible = true;
                }

                if (!rowVisible)
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ItemsDataGridView.DataSource];
                    currencyManager1.SuspendBinding();

                    row.Visible = rowVisible;
                }
            }
        }

        private void dataGridItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ItemForm form = new ItemForm();
                DataGridViewRow selectedRow = dataGridItems.Rows[e.RowIndex];
                int itemID = int.Parse(selectedRow.Cells["ItemID"].Value.ToString());
                Console.WriteLine(itemID);
                Item i = new Item(itemID);
                i.Name = selectedRow.Cells["ItemDescription"].Value.ToString();
                i.Price = double.Parse(selectedRow.Cells["Price"].Value.ToString());
                i.Quantity = int.Parse(selectedRow.Cells["Quantity"].Value.ToString());
                form.item = i;
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }
    }
}
