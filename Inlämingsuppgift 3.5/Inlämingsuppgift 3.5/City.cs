using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämingsuppgift_3._5
{
    class City
    {
        public string name;
        private int antalInvanare;
        private int medelInkomstPerInvanare;
        private int antalTuristerPerAr;
        public List<Accommodation1> allaAccommadation;
        private int antalAccommadation;
        private double medelKostnadenForEnNattpaAirBNB;




        public City(string name, int antalInvanare, int medelInkomstPerInvanare, int antalTuristerPerAr, double medelKostnadenForEnNattpaAirBNB, List<Accommodation1> ac)
        {
            this.Name = name;
            this.AntalInvanare = antalInvanare;
            this.MedelInkomstPerInvanare = medelInkomstPerInvanare;
            this.AntalTuristerPerAr = antalTuristerPerAr;
            this.MedelKostnadenForEnNattpaAirBNB = medelKostnadenForEnNattpaAirBNB;
            this.allaAccommadation = ac;
        }
        public void CreateAccomodation()
        {
            allaAccommadation = new List<Accommodation1>();
        }

        public void AddAccomodation(Accommodation1 ac)
        {
            antalAccommadation++;
            allaAccommadation.Add(ac);
        }



        //Get/set metoder för medlemsvariablerna
        public string Name { get => name; set => name = value; }
        public int AntalInvanare { get => antalInvanare; set => antalInvanare = value; }
        public int MedelInkomstPerInvanare { get => medelInkomstPerInvanare; set => medelInkomstPerInvanare = value; }
        public int AntalTuristerPerAr { get => antalTuristerPerAr; set => antalTuristerPerAr = value; }
        public int AntalAccommadation { get => antalAccommadation; set => antalAccommadation = value; }
        public double MedelKostnadenForEnNattpaAirBNB { get => medelKostnadenForEnNattpaAirBNB; set => medelKostnadenForEnNattpaAirBNB = value; }
        public List<Accommodation1> AllaAccommadation { get => allaAccommadation; set => allaAccommadation = value; }
    }
}

