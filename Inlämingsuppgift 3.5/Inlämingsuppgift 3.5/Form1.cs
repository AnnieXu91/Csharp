using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Inlämingsuppgift_3._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Här har jag alla mina grafer.
            chart1.Titles.Add("Barcelona price");
            chart1.ChartAreas[0].AxisX.Title = "Room";
            chart1.ChartAreas[0].AxisY.Title = "Price";


            chart2.Titles.Add("Amsterdam price");
            chart2.ChartAreas[0].AxisX.Title = "Room";
            chart2.ChartAreas[0].AxisY.Title = "Price";

            chart3.Titles.Add("Boston price");
            chart3.ChartAreas[0].AxisX.Title = "Room";
            chart3.ChartAreas[0].AxisY.Title = "Price";

            chart4.Titles.Add("Barcelona price/overall satisfaction");
            chart4.ChartAreas[0].AxisX.Title = "Price";
            chart4.ChartAreas[0].AxisY.Title = "Overall Satisfation";
            chart4.Series["Series1"].ChartType = SeriesChartType.Point;

            chart5.Titles.Add("Amsterdam price/overall satisfaction");
            chart5.ChartAreas[0].AxisX.Title = "Price";
            chart5.ChartAreas[0].AxisY.Title = "Overall Satisfation";
            chart5.Series["Series1"].ChartType = SeriesChartType.Point;

            chart6.Titles.Add("Boston price/overall_satisfaction");
            chart6.ChartAreas[0].AxisX.Title = "Price";
            chart6.ChartAreas[0].AxisY.Title = "Overall_satisfation";
            chart6.Series["Series1"].ChartType = SeriesChartType.Point;


            // jag har inte skapat några metoder utan börjar "koda direkt" 
            // här lägger jag in världen i min City lista.
            List<string> citynames = new List<string> { "Amsterdam", "Barcelona", "Boston" };
            List<City> allCities = new List<City>();


            // en loop som kommer köras så länge det finns ett värde. här kopplar jag även till SQL med conn.connectionstring
            foreach (var item in citynames)
            {
                // Nu arbetar vi från C# till SQL server. 
                SqlConnection conn = new SqlConnection();

                conn.ConnectionString = "Data Source=DESKTOP-82O043O\\KURS6;Initial Catalog=AirBnB;Integrated Security=True";

                List<Accommodation1> AccommodationList = new List<Accommodation1>();

                // lägger in nya världen i klassen Accommodation1. 

                try
                {
                    conn.Open();// vi öppnar länken mellan C# och SQL

                    SqlCommand myQuery = new SqlCommand("Select * From " + item + ";", conn);
                    // kopplar till SQL genom att välja allt från datasetet och item blir landet. 
                

                    SqlDataReader myReader = myQuery.ExecuteReader();
                    List<Accommodation1> accommodationlistan = new List<Accommodation1>();

                    while (myReader.Read())
                    {

                        int room_id = (int)myReader["Room_id"];
                        int host_id = (int)myReader["Host_id"];
                        string room_type = (string)myReader["Room_type"];
                        // då det innehåller Nullvärde gör vi en IF sats. Om de är ett string värde så skriv ut 
                        // om inte så skriv ut det som är mellan " "; 
                        string borough = " ";
                        if (myReader["borough"] is String)
                        {
                            borough = (string)myReader["borough"];
                        }
                        else
                        {
                            borough = "";
                        }

                        string neighborhood = (string)myReader["Neighborhood"];
                        int reviews = (int)myReader["Reviews"];
                        double overall_satisfaction = (double)(myReader["overall_satisfaction"]);
                        int accommadation = (int)myReader["accommodates"];
                        double temp = temp = (double)myReader["bedrooms"];
                        int bedrooms = (int)Math.Round(temp);
                        temp = (double)myReader["price"];
                        int price = (int)Math.Round(temp);

                        int minstay = 0;
                        Int32.TryParse(myReader["minstay"].ToString(), out minstay);

                        double latitude = (double)myReader["latitude"];
                        double longitude = (double)myReader["longitude"];
                        string last_modified = myReader["last_modified"].ToString();
                        //Lastmodified måste ni sätta ToString() eftersom det är ett datumvärde i SQL.


                        Accommodation1 accommodation = new Accommodation1(
                             room_id,
                             host_id,
                             room_type,
                             borough,
                             neighborhood,
                             reviews,
                             overall_satisfaction,
                             accommadation,
                             bedrooms,
                             price,
                             minstay,
                             latitude,
                             longitude,
                             last_modified
                             );

                        accommodationlistan.Add(accommodation);
                    }
                    City city = new City(item, 0, 0, 0, 0, accommodationlistan);
                    allCities.Add(city);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    conn.Close();

                }
                //Console.ReadLine();
            }
            foreach (City c in allCities)  // För att kunna plocka fram önskad stad till de olika charterna.
            {
                switch (c.name) //utgår från mina olika städer som finns i klassen City så vi kan dela upp datan efter önskad stad.
                {
                    case "Boston":  //Om staden är Boston
                        foreach (Accommodation1 ac in c.allaAccommadation.Where(y => y.Room_type == "Private room"))
                        {

                            chart1.Series["Series1"].Points.AddY(ac.Price);
                        };
                        break;
                    case "Amsterdam": // Om staden är Amsterdam
                        foreach (Accommodation1 ac in c.allaAccommadation.Where(y => y.Room_type == "Private room"))
                        {

                            chart2.Series["Series1"].Points.AddY(ac.Price);
                        };
                        break;
                    case "Barcelona": // Om staden är Barcelona
                        foreach (Accommodation1 ac in c.allaAccommadation.Where(y => y.Room_type == "Private room"))
                        {

                            chart3.Series["Series1"].Points.AddY(ac.Price);


                        };
                        break;
                    default:
                        break;
                }
            }
            foreach (City c in allCities)

            // eftersom vi använder oss av en switch, ska man även ha en break, man använder switch när 3:dje if-sats som testar  har samma uttryck
            {
                switch (c.name)
                {
                    case "Boston":
                        foreach (Accommodation1 ac in c.AllaAccommadation.Where(y => y.Overall_satisfaction != 0 && y.Overall_satisfaction < 4.5))
                        {

                            chart4.Series["Series1"].Points.AddXY(ac.Overall_satisfaction, ac.Price);
                        };
                        break;
                    case "Amsterdam":
                        foreach (Accommodation1 ac in c.AllaAccommadation.Where(y => y.Overall_satisfaction != 0 && y.Overall_satisfaction < 4.5))
                        {

                            chart5.Series["Series1"].Points.AddXY(ac.Overall_satisfaction, ac.Price);
                        };
                        break;
                    case "Barcelona":
                        foreach (Accommodation1 ac in c.AllaAccommadation.Where(y => y.Overall_satisfaction != 0 && y.Overall_satisfaction < 4.5))
                        {

                            chart6.Series["Series1"].Points.AddXY(ac.Overall_satisfaction, ac.Price);
                        };
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
