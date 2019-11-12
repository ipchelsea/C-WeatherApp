using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    string city;
                    Console.WriteLine("Welcome! ");

                    Console.Write("Please pick a city: ");

                    city = Console.ReadLine();


                    while (string.IsNullOrEmpty(city))
                    {
                        Console.WriteLine("Name of city cannot be empty");
                        break;
                    }

                    if (city == "Exit")
                    {
                        Console.WriteLine("bye!");
                        break;
                    }

                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
                        HttpResponseMessage response = client.GetAsync("weather?q=" + city + "&APPID=ENTERID").Result; //takes in city

                        response.EnsureSuccessStatusCode();

                        string result = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine("Result :" + result);

                        Console.WriteLine("Deserialising JSON");
                        Rootobject weatherDetails = JsonConvert.DeserializeObject<Rootobject>(result);
                        float kelvinTemp = weatherDetails.main.temp;
                        float tempMin = weatherDetails.main.temp_min;
                        float tempMax = weatherDetails.main.temp_max;

                        float lon = weatherDetails.coord.lon;
                        float lat = weatherDetails.coord.lat;
                        float speed = weatherDetails.wind.speed;
                        float deg = weatherDetails.wind.deg;
                        int pressure = weatherDetails.main.pressure;
                        int humidity = weatherDetails.main.humidity;
                        int clouds = weatherDetails.clouds.all;
                        int visibility = weatherDetails.visibility;

                        //string country = weatherDetails.main.country;

                        int temp_min = (int)((int)(kelvinTemp - 273.15) * 1.8 + 32);
                        int temp_max = (int)((int)(kelvinTemp - 273.15) * 1.8 + 32);
                        int temp = (int)((int)(kelvinTemp - 273.15) * 1.8 + 32);

                        Console.WriteLine("----------------WEATHER DETAILS-----------------");
                        Console.WriteLine("Lattitude in " + city + ": " + lat);
                        Console.WriteLine("Longtitude in " + city + ": " + lon);
                        Console.WriteLine("Wind speed in " + city + ": " + speed);
                        Console.WriteLine("Wind degree in " + city + ": " + deg);

                        Console.WriteLine("Temperature in " + city + ": " + temp + " Farenheit");
                        Console.WriteLine("Pressure in " + city + ": " + pressure + "milibars");
                        Console.WriteLine("Humidity in " + city + ": " + humidity);
                        Console.WriteLine("Cloud in " + city + ": " + clouds);
                        Console.WriteLine("Visibility in " + city + ": " + visibility + "Km");

                        Console.WriteLine("Minimum Temperature in " + city + ": " + temp_min + " Farenheit");
                        Console.WriteLine("Maximum Temperature in " + city + ": " + temp_max + " Farenheit");
                        Console.WriteLine("Type Exit to close program");
                    }

                }
            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}

