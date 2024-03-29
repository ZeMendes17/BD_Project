﻿using System;
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
    public partial class Login : Form
    {
        private SqlConnection cn;
        String dbServer = "tcp:mednat.ieeta.pt\\SQLSERVER,8101";
        String dbName = "p5g4";
        String userName = "p5g4";
        String userPass = "Bz105107!";

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            bool a = verifySGBDConnection();
            Console.WriteLine(a);
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
                //Console.WriteLine(dbname);
                if (dbname == username && dbpass == password)
                {
                    NIF = rdr["UserNIF"].ToString();
                    break;
                }
            }
            rdr.Close();
            if (NIF != null)
            {
                //showBox.Text = "Found user" + NIF;

                cmd = new SqlCommand("SELECT * FROM Project.MANAGER", cn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    String dbNIF = rdr["ManagerNIF"].ToString();

                    if (dbNIF == NIF)
                    {
                        //showBox.Text = showBox.Text + " --> MANAGER";
                        manager = true;
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
                        //showBox.Text = showBox.Text + " --> STAFF";
                        staff = true;
                    }
                }
                rdr.Close();
            } // else { showBox.Text = "";}

            if (staff)
            {
                cmd = new SqlCommand("SELECT * FROM Project.getStaffInfo(@param)", cn);
                cmd.Parameters.AddWithValue("@param", NIF);
                //cn.Open();

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Staff S = new Staff(rdr["NIF"].ToString(), Convert.ToInt32(rdr["ID"]));
                    S.Address = rdr["Address"].ToString();
                    S.Name = rdr["PName"].ToString();
                    S.Phone = rdr["PhoneNumb"].ToString();
                    S.Email = rdr["Email"].ToString();
                    S.Birthdate = rdr["BirthDate"].ToString();
                    S.RegisterDate = rdr["RegisterDate"].ToString();
                    S.Password = rdr["UserPassword"].ToString();
                    S.Username = rdr["UserName"].ToString();
                    S.Salary = Convert.ToDouble(rdr["Salary"]);
                    S.Url = rdr["StoreURL"].ToString();
                    //showBox.Text = " --> " + S.Name + " " + S.Email;
                    staff = false;
                    // para abrir a janela da Staff (esconde esta entretanto e fecha quando este fechar também)
                    this.Hide();
                    StaffForm form = new StaffForm();
                    form.St = S;
                    form.FormClosed += (s, args) => this.Close();
                    form.Show();
                }
                rdr.Close();
            }
            if (manager)
            {
                cmd = new SqlCommand("SELECT * FROM Project.getManagerInfo(@param)", cn);
                cmd.Parameters.AddWithValue("@param", NIF);
                //cn.Open();

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Manager M = new Manager(rdr["NIF"].ToString(), Convert.ToInt32(rdr["ID"]));
                    M.Address = rdr["Address"].ToString();
                    M.Name = rdr["PName"].ToString();
                    M.Phone = rdr["PhoneNumb"].ToString();
                    M.Email = rdr["Email"].ToString();
                    M.Birthdate = rdr["BirthDate"].ToString();
                    M.RegisterDate = rdr["RegisterDate"].ToString();
                    M.Password = rdr["UserPassword"].ToString();
                    M.Username = rdr["UserName"].ToString();
                    M.Salary = Convert.ToDouble(rdr["Salary"]);
                    M.Url = rdr["StoreURL"].ToString();
                    //showBox.Text = " --> " + S.Name + " " + S.Email;
                    manager = false;
                    // para abrir a janela do manager (esconde esta entretanto e fecha quando este fechar também)
                    this.Hide();
                    ManagerForm form = new ManagerForm();
                    form.St = M;
                    form.FormClosed += (s, args) => this.Close();
                    form.Show();
                }
                rdr.Close();
            }

            cn.Close();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                but.PerformClick();
            }
        }

        private void showBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
