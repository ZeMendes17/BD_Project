using System;
using System.Collections;
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
    public partial class StaffManageOrder : Form
    {
        private SqlConnection cn;
        String dbServer = "tcp:mednat.ieeta.pt\\SQLSERVER,8101";
        String dbName = "p5g4";
        String userName = "p5g4";
        String userPass = "Bz105107!";
        
        public int OrderID { get; set; }

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

        public ArrayList items = new ArrayList();

        public StaffManageOrder()
        {
            InitializeComponent();
        }

        private void StaffManageOrder_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            verifySGBDConnection();
            this.confirm.Hide();
            this.cancel.Hide();
        }

        public void addItem(OrderedItem i)
        {
            items.Add(i);
        }

        private void avail_Click(object sender, EventArgs e)
        {
            bool result = true;

            foreach(OrderedItem i in items)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Project.ITEM WHERE ID=@itemID", cn);
                cmd.Parameters.AddWithValue("@itemID", i.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (int.Parse(reader["Quantity"].ToString()) < i.Quantity) { result = false; break; }
                }
                reader.Close();

                if(!result)
                {
                    break;
                }
            }

            if(result)
            {
                this.confirm.Show();
                this.cancel.Show();
                displayTxt.Text = "All the items on this Order are available for sale";
                displayTxt.ForeColor = Color.Green;
            }
            else
            {
                this.cancel.Show();
                displayTxt.Text = "Items from this Order might be unavailable at the moment, check the availability";
                displayTxt.ForeColor= Color.Red;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Project.[ORDER] SET OrderState=@newState WHERE OrderNumber=@id", cn);
            cmd.Parameters.AddWithValue("@newState", "Canceled");
            cmd.Parameters.AddWithValue("@id", OrderID);

            int rowsAffected = cmd.ExecuteNonQuery();

            // Check the number of rows affected by the update
            if (rowsAffected > 0)
            {
                displayTxt.Text = "Ordered is now in Canceled State";
                displayTxt.ForeColor = Color.Green;
            }
            else
            {
                displayTxt.Text = "Operation could not be executed";
                displayTxt.ForeColor = Color.Red;
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            ArrayList items = new ArrayList();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Project.ITEM_ORDER WHERE OrderNumber=@oNum", cn);
            cmd.Parameters.AddWithValue("@oNum", OrderID);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int[] itemInfo = new int[2];
                itemInfo[0] = int.Parse(rdr["ItemID"].ToString());
                itemInfo[1] = int.Parse(rdr["Quantity"].ToString());
                items.Add(itemInfo);
            }
            rdr.Close();

            foreach (int[] i in items)
            {
                cmd = new SqlCommand("Project.updateOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemId", i[0]);
                cmd.Parameters.AddWithValue("@AmountToRemove", i[1]);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE Project.[ORDER] SET OrderState='Shipped' WHERE OrderNumber=@OrderNumber", cn);
                cmd.Parameters.AddWithValue("@OrderNumber", OrderID);
                cmd.ExecuteNonQuery();

                displayTxt.Text = "Updated the stock and Order is now in Shipped State";
            }
                
        }
    }
}
