using System;
using System.Collections.Generic;

namespace LaboDotNet.Models
{
    public class Locatie
    {
        private static IList<Locatie> _locaties;
        
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

        private Locatie(int id, string naam)
        {
            _id = id;
            _naam = naam;
        }

        public static IList<Locatie> Locaties
        {
            get
            {
                if (_locaties == null)
                {
                    int i = 0;
                    _locaties = new List<Locatie>
                    {
                        new Locatie(i++, "Mechelen"),
                        new Locatie(i++, "Antwerpen"),
                        new Locatie(i++, "Brussel"),
                        new Locatie(i++, "Charlerois"),
                        new Locatie(i++, "Schiphol"),
                    };
                }
                return _locaties;
            }
        }

        public static string getNameById(int i)
        {
            foreach (var item in Locaties)
            {
                if (item.id == i) return item.naam;
            }

            return "--Kapot--";
        }
    }
}