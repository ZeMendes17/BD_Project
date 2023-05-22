using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BusinessManagerInterface
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            bool a = verifySGBDConnection();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= DESKTOP-TT1ASJK\\SQLEXPRESS2019;integrated security=true;initial catalog=p5g4");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            String username = usernameBox.Text;
            String password = passwordBox.Text;
            String NIF = null;
            bool manager = false;
            bool staff = false;

            //Console.WriteLine(username + ":" + password);
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Project.[USER]", cn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                //Console.WriteLine(rdr["NIF"].ToString() + " ----> " + rdr["PName"]);
                String dbname = rdr["UserName"].ToString();
                String dbpass = rdr["UserPassword"].ToString();

                if(dbname == username && dbpass == password)
                {

                    NIF = rdr["UserNIF"].ToString();
                    break;
                }
            }
            rdr.Close();
            if(NIF != null)
            {
                showBox.Text = "Found user" + NIF;

                cmd = new SqlCommand("SELECT * FROM Project.MANAGER", cn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    String dbNIF = rdr["ManagerNIF"].ToString();

                    if (dbNIF == NIF)
                    {
                        showBox.Text = showBox.Text + " --> MANAGER";
                    }
                }
                rdr.Close();

                cmd = new SqlCommand("SELECT * FROM Project.STAFF", cn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    String dbNIF = rdr["StaffNIF"].ToString();

                    if (dbNIF == NIF)
                    {
                        showBox.Text = showBox.Text + " --> STAFF";
                    }
                }
                rdr.Close();
            } else { showBox.Text = "";}

            cn.Close();
        }
    }
}
