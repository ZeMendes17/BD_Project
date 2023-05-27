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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace BusinessManagerInterface
{
    public partial class ItemForm : Form
    {

        private SqlConnection cn;
        String dbServer = "tcp:mednat.ieeta.pt\\SQLSERVER,8101";
        String dbName = "p5g4";
        String userName = "p5g4";
        String userPass = "Bz105107!";

        public Item item { get; set; }

        public ItemForm()
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

        private void SupplierDataGridView_Adjust(object sender, EventArgs e)
        {
            this.Suppliers.Height = this.Height - this.ItemName.Height - this.ItemDescription.Height - 20;
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            verifySGBDConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Project.ItemSupplierView WHERE ItemID=@id", cn);
            cmd.Parameters.AddWithValue("@id", item.ID);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Suppliers.DataSource = dt;

            this.ItemName.Text = item.Name;
            this.ItemDescription.AutoSize = true;
            this.ItemDescription.Text = "ID: " + item.ID + "\n\n";
            this.ItemDescription.Text += "In Stock: " + item.Quantity + "\n\n";
            this.ItemDescription.Text += "Price: " + item.Price + " euros" + "\n\n";
            this.ItemDescription.Text += "Suppliers:" + "\n";

            this.Suppliers.Height = this.Height - this.ItemName.Height - this.ItemDescription.Height - 20;
        }
    }
}
