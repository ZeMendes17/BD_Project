using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagerInterface
{
    internal class Person
    {
        private String _NIF;
        private String _address;
        private String _name;
        private String _phone;
        private String _email;
        private String _birthdate;


        public Person(String NIF) 
        {
            this._NIF = NIF;
        }

        public String NIF
        { 
            get { return this._NIF; }
            set { this._NIF = value; }
        }

        public String Address
        { 
            get { return this._address; }
            set { this._address = value; } 
        }

        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public String Phone
        {
            get { return this._phone; }
            set { this._phone = value; }
        }

        public String Email
        {
            get { return this._email; }
            set { this._email= value; }
        }

        public String Birthdate
        {
            get { return this._birthdate; }
            set { this._birthdate = value; }
        }
    }
}
