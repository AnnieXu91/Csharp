using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämingsuppgift_3._5
{
    class Country
    {
        private string name;
        private string antalInvanare;
        private int BNPpercapita;
        public List<City> allCities;

        // objekt 
        public Country(string name, string antalInvanare, int BNPpercapita, List<City> allCities)
        {
            this.Name = name;
            this.AntalInvanare = antalInvanare;
            this.BNPpercapita1 = BNPpercapita;
            // skapaCity();
            this.allCities = AllCities;
        }



        //Get/set metoder för medlemsvariablerna
        public string Name { get => name; set => name = value; }
        public string AntalInvanare { get => antalInvanare; set => antalInvanare = value; }
        public int BNPpercapita1 { get => BNPpercapita; set => BNPpercapita = value; }
        internal List<City> AllCities { get => allCities; set => allCities = value; }
    }
}

