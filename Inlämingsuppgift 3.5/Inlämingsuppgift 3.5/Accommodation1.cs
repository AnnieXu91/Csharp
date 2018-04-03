using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämingsuppgift_3._5
{
    class Accommodation1
    {
        private int room_Id;
        private int host_Id;
        private string room_type;
        private string borough;
        private string neighbourhood;
        private int reviews;
        private double overall_satisfaction;
        private int accommadation;
        private int bedrooms;
        private int price;
        private int minStay;
        private double latitude;
        private double longitude;
        private string lastModified;

        public Accommodation1(int room_Id, int host_Id, string room_type, string borough, string neighbourhood, int reviews, double overall_satisfaction, int accommadation, int bedrooms, int price, int minStay, double latitude, double longitude, string lastModified)
        {
            this.Room_Id = room_Id;
            this.Room_type = room_type;
            this.Borough = borough;
            this.Neighbourhood = neighbourhood;
            this.Reviews = reviews;
            this.Overall_satisfaction = overall_satisfaction;
            this.Accommadation = accommadation;
            this.bedrooms = bedrooms;
            this.price = price;
            MinStay = minStay;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.LastModified = lastModified;
        }


        //Get/set metoder för medlemsvariablerna
        public int Room_Id { get => room_Id; set => room_Id = value; }
        public int Host_Id { get => host_Id; set => host_Id = value; }
        public string Room_type { get => room_type; set => room_type = value; }
        public string Borough { get => borough; set => borough = value; }
        public string Neighbourhood { get => neighbourhood; set => neighbourhood = value; }
        public int Reviews { get => reviews; set => reviews = value; }
        public double Overall_satisfaction { get => overall_satisfaction; set => overall_satisfaction = value; }
        public int Accommadation { get => accommadation; set => accommadation = value; }
        public int Bedrooms { get => bedrooms; set => bedrooms = value; }
        public int Price { get => price; set => price = value; }
        public int MinStay { get => minStay; set => minStay = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public string LastModified { get => lastModified; set => lastModified = value; }
    }
}
