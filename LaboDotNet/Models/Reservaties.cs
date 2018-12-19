using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace LaboDotNet.Models
{
    public class Reservaties
    {
        private static Reservaties _instance;

        public static Reservaties instance
        {
            get
            {
                if (_instance == null) _instance = new Reservaties();
                return _instance;
            }
            set { _instance = value; }
        }

        private DataTable _table;
        private MySqlDataAdapter _da;

        private Reservaties()
        {
            var con = DbConnect.instance.connect();
            _da = new MySqlDataAdapter("SELECT nr, klant, van, naar, datum, dagen, auto FROM reservaties", con);
            _table = new DataTable("reservaties");
            _da.Fill(_table);
            new MySqlCommandBuilder(_da);
            _table.Columns["nr"].AutoIncrement = true;
        }

        public DataRow Select(int nr)
        {
            var rows = _table.Select("nr = " + nr);
            return rows.Length == 0 ? null : rows[0];
        }
        
        public DataRow[] SelectByKlant(int klant)
        {
            return _table.Select("klant = " + klant);
        }

        public DataRow Add(int klant, int van, int naar, DateTime datum, int dagen, int auto)
        {
            var r = _table.NewRow();
            r["klant"] = klant;
            r["van"] = van;
            r["naar"] = naar;
            r["datum"] = datum;
            r["dagen"] = dagen;
            r["auto"] = auto;
            _table.Rows.Add(r);
            _da.Update(_table);

            Console.WriteLine(r);
            
            return r;
        }
    }
}