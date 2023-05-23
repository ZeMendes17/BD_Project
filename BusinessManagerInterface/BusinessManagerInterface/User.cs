using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagerInterface
{

    internal class User : Person
    {

        private int _ID;
        private string _registerDate;
        private string _username;
        private string _password;
        private double _salary;


        public User(string NIF, int ID) : base(NIF)
        {
            this.NIF = NIF;
            this._ID = ID;
        }

        public int ID 
        { 
            get { return this._ID; }
            set { this._ID = value; }
        }

        public string RegisterDate
        {
            get { return this._registerDate; }
            set { this._registerDate = value; }
        }

        public string Username
        {
            get { return this._username; } 
            set { this._username = value; }
        }

        public string Password
        {
            get { return this._password; }
            set
            {
                this._password = value;
            }
        }

        public double Salary
        {
            get { return this._salary; }
            set
            {
                this._salary = value;
            }
        }


    }
}
