using System.Collections.Generic;

namespace LaboDotNet.Models
{
    public class Auto
    {
        private static IList<Auto> _autos;
        
        private int _id;
        private string _naam;

        public int id
        {
            get { return _id; }
        }

        public string naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        private Auto(int id, string naam)
        {
            this._id = id;
            this._naam = naam;
        }

        public static IList<Auto> Autos
        {
            get
            {
                if (_autos == null)
                {
                    int i = 0;
                    _autos = new List<Auto>
                    {
                        new Auto(i++,"Auto 1"),
                        new Auto(i++,"Auto 2"),
                        new Auto(i++,"Auto 3"),
                        new Auto(i++,"Auto 4"),
                        new Auto(i++,"Auto 5"),
                    };
                }
                return _autos;
            }
        }
        
        
        public static string getNameById(int i)
        {
            foreach (var item in Autos)
            {
                if (item.id == i) return item.naam;
            }

            return "--Kapot--";
        }
    }
}