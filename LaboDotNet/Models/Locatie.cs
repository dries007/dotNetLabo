using System.Collections;
using System.Collections.Generic;

namespace LaboDotNet.Models
{
    public class Locatie
    {
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
                return new List<Locatie>
                {
                    new Locatie(1, "Mechelen"),
                    new Locatie(1, "Antwerpen"),
                    new Locatie(1, "Brussel"),
                    new Locatie(1, "Charlerois"),
                    new Locatie(1, "Schiphol"),
                };
            }
        }
    }
}