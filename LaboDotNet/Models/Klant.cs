using System.Collections;
using System.Collections.Generic;

namespace LaboDotNet.Models
{
    public class Klant
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

        private Klant(string naam)
        {
            this.naam = naam;
        }

        public static IList<Klant> Klanten
        {
            get
            {
                return new List<Klant> {new Klant("TestKlant1")};
            }
        }
    }
}