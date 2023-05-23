﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagerInterface
{
    internal class Staff : User
    {
        private string _url;

        public Staff(string NIF, int ID) : base(NIF, ID)
        {
            this.ID = ID;
            this.NIF = NIF;
        }

        public string Url
        {
            get { return this._url; }
            set { this._url = value; }
        }
    }
}
