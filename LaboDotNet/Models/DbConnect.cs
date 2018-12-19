using System;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc.Routing;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LaboDotNet.Models
{
    public class DbConnect
    {
        private static DbConnect _instance;

        public static DbConnect instance
        {
            get
            {
                if (_instance == null) _instance = new DbConnect();
                return _instance;
            }
            set { _instance = value; }
        }

        private DbConnect()
        {
        }

        public MySqlConnection connect()
        {
            var connstring = "Server=localhost; database=LaboDotNet; UID=LaboDotNet; password=JCq9WrbuRAPqr8VQ";
            var c = new MySqlConnection(connstring);
            c.Open();
            return c;
        }
    }
}