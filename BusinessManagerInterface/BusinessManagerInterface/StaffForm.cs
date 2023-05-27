using System;
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

        int orderID = 0;

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

            cmd = new SqlCommand("Project.getOrdersFromStore", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@store", St.Url);
            cmd.Parameters.AddWithValue("@state", "Canceled");
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridViewCanceled.DataSource = dt;

            // items in stock
            cmd = new SqlCommand("SELECT ID, ItemDescription AS Product, Quantity AS InStock, Price FROM Project.ITEM WHERE StoreURL=@store", cn);
            cmd.Parameters.AddWithValue("@store", St.Url);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            ItemsDataGridView.DataSource = dt;

            // items gridView
            dataGridItems.Hide();

            // call Personal Area
            PersonalArea(sender, e);
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
                orderID = int.Parse(orderNum);
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
            orderID = 0;

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
            orderID = 0;

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

        private void dataGridViewCanceled_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            orderID = 0;

            try
            {
                DataGridViewRow selectedRow = dataGridViewCanceled.Rows[e.RowIndex];
                String costumerNIF = selectedRow.Cells["CostumerNIF"].Value.ToString();
                String orderNum = selectedRow.Cells["OrderNumber"].Value.ToString();
                orderID = int.Parse(orderNum);
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

        private void manageButton_Click(object sender, EventArgs e)
        {
            // fazer query com o orderID que vai buscar os items da order e os mete no array
            // po-lo publico
            // de seguida comparar com o stock do produto a quantidade, se puder aparece aproved
            // se nao aparece no stock
            // bloquear os botoes ou assim
            // depois alterar o estado do pedido "shipping, canceled"
            // e ta, depois é so a personal area
            if(orderID == 0)
                { return; }

            SqlCommand cmd = new SqlCommand("SELECT * FROM Project.[ITEM_ORDER] WHERE OrderNumber=@on", cn);
            cmd.Parameters.AddWithValue("@on", orderID.ToString());
            SqlDataReader rdr = cmd.ExecuteReader();

            StaffManageOrder form = new StaffManageOrder();
            form.OrderID = orderID;
            form.FormClosed += closeManage;
            while (rdr.Read())
            {
                OrderedItem i = new OrderedItem(int.Parse(rdr["ItemID"].ToString()), int.Parse(rdr["Quantity"].ToString()));
                form.addItem(i);
            }
            rdr.Close();

            form.Show();
        }

        private void closeManage(object sender, EventArgs e)
        {
            this.StaffForm_Load(sender, e);
        }

        private void PersonalArea(object sender, EventArgs e)
        {
            // add side scroll in this labe

            this.StaffName.Text = "Welcome, " + St.Name + " (" + St.Username + ")"; // name
            this.StaffInfo.Text = "ID: " + St.ID + "\n\n";
            this.StaffInfo.Text += "NIF: " + St.NIF + "\n\n";
            this.StaffInfo.Text += "Email: " + St.Email + "\n\n";
            this.StaffInfo.Text += "Phone Number: " + St.Phone + "\n\n";
            this.StaffInfo.Text += "Address: " + St.Address + "\n\n";
            this.StaffInfo.Text += "Salary: " + St.Salary + " euros" + "\n\n";
            this.StaffInfo.Text += "Register Date: " + St.RegisterDate + "\n\n";
            this.StaffInfo.Text += "Birth Date: " + St.Birthdate + "\n\n";
            this.StaffInfo.Text += "Store: " + St.Url + "\n\n\n";

            this.StaffInfo.Text += "STATS: " + "\n\n";

            SqlCommand cmd = new SqlCommand("SELECT * FROM Project.StaffTotalStatsView WHERE StaffNIF=@nif", cn);
            cmd.Parameters.AddWithValue("@nif", St.NIF);
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                this.StaffInfo.Text += "Total Orders: " + rdr["TotalOrders"].ToString() + "\n\n";
                this.StaffInfo.Text += "Total Revenue: " + rdr["TotalMoney"].ToString() + "\n\n";
            }   
            rdr.Close();

            cmd = new SqlCommand("SELECT * FROM Project.StaffStatsPerMonthView WHERE StaffNIF=@nif", cn);
            cmd.Parameters.AddWithValue("@nif", St.NIF);
            rdr = cmd.ExecuteReader();
            double best = 0;
            int bestMonth = 0;
            while (rdr.Read())
            {
                if (double.Parse(rdr["TotalPrice"].ToString()) > best)
                {
                    best = double.Parse(rdr["TotalPrice"].ToString());
                    bestMonth = int.Parse(rdr["Month"].ToString());
                }
            }

            if(best != 0)
            {
                DateTime date = new DateTime(DateTime.Now.Year, bestMonth, 1);
                this.StaffInfo.Text += "Best Month: " + date.ToString("MMMM") + ", Total Revenue of: " + best.ToString() + " euros" + "\n\n";
            }
            rdr.Close();

            cmd = new SqlCommand("SELECT * FROM Project.StaffItemStatsView WHERE StaffNIF=@nif", cn);
            cmd.Parameters.AddWithValue("@nif", St.NIF);
            rdr = cmd.ExecuteReader();
            int bestSeller = 0;
            String bestSellerName = "";
            double mostRevenue = 0;
            String mostRevenueName = "";
            while (rdr.Read())
            {
                if (int.Parse(rdr["TotalNumItems"].ToString()) > bestSeller)
                {
                    bestSeller = int.Parse(rdr["TotalNumItems"].ToString());
                    bestSellerName = rdr["ItemDescription"].ToString();
                }
                if (double.Parse(rdr["TotalItemSales"].ToString()) > mostRevenue)
                {
                    mostRevenue = double.Parse(rdr["TotalItemSales"].ToString());
                    mostRevenueName = rdr["ItemDescription"].ToString();
                }
            }
            if(bestSeller != 0 && mostRevenue != 0)
            {
                this.StaffInfo.Text += "Best Seller: " + bestSellerName + ", Total Number of Sales: " + bestSeller.ToString() + "\n\n";
                this.StaffInfo.Text += "Most Revenue: " + mostRevenueName + ", Total Revenue of: " + mostRevenue.ToString() + " euros" + "\n\n";
            }
            
            rdr.Close();
        }
    }
}
