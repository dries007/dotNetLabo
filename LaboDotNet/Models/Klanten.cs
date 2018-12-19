using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace LaboDotNet.Models
{
    public class Klanten
    {
        private static Klanten _instance;

        public static Klanten instance
        {
            get
            {
                if (_instance == null) _instance = new Klanten();
                return _instance;
            }
            set { _instance = value; }
        }

        private DataTable _table;
        private MySqlDataAdapter _da;

        private Klanten()
        {
            var con = DbConnect.instance.connect();
            _da = new MySqlDataAdapter("SELECT nr, naam, adress FROM klanten", con);
            _table = new DataTable("klanten");
            _da.Fill(_table);
            new MySqlCommandBuilder(_da);
            _table.Columns["nr"].AutoIncrement = true;
        }

        public DataRow Select(int nr)
        {
            var rows = _table.Select("nr = " + nr);
            return rows.Length == 0 ? null : rows[0];
        }

        public DataRow Add(string name, string address)
        {
            var r = _table.NewRow();
            r["naam"] = name;
            r["adress"] = address;
            _table.Rows.Add(r);
            _da.Update(_table);

            Console.WriteLine(r);
            
            return r;
        }
    }
}