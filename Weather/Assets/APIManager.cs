using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Assets
{
   
    public class APIManager
    {
        // bất đồng bộ c#
        public async Task<Root> getWeather(double lat, double lon)
        {
            // hàm parse từ url để đọc dữ liệu như parameter
            var http  =new HttpClient();
            var url = string.Format(
                "http://api.openweathermap.org/data/2.5/weather?q=hanoi&appid=2c320dd8b168114bb44aa9f2f4de69ac");
            var response = await http.GetAsync(url); // nhận data từ json đọc theo kiểu bất đồng bộ
            return null;
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public int deg { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Root
        {
            public Coord coord { get; set; }
            public List<Weather> weather { get; set; }
           // public string base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int timezone { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }


}
}
