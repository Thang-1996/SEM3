using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace ACC_Weather.Models
{
    public class Headline
        {
            public string EffectiveDate { get; set; }
            public int EffectiveEpochDate { get; set; }
            public int Severity { get; set; }
            public string Text { get; set; }
            public string Category { get; set; }
            public string EndDate { get; set; }
            public int EndEpochDate { get; set; }
            public string MobileLink { get; set; }
            public string Link { get; set; }
        }

        public class Minimum
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Maximum
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Temperature1
        {
            public Minimum Minimum { get; set; }
            public Maximum Maximum { get; set; }
        }

        public class Day
        {
            public string Icon { get; set; }
            public string IconPhrase { get; set; }
            public bool HasPrecipitation { get; set; }
            public string PrecipitationType { get; set; }
            public string PrecipitationIntensity { get; set; }
        }

        public class Night
        {
            public int Icon { get; set; }
            public string IconPhrase { get; set; }
        }

        public class DailyForecast
        {
            public string Date { get; set; }
            public int EpochDate { get; set; }
            public Temperature1 Temperature { get; set; }
            public Day Day { get; set; }
            public Night Night { get; set; }
            public List<string> Sources { get; set; }
            public string MobileLink { get; set; }
            public string Link { get; set; }
        }

        public class WeatherEachDay
        {
            public Headline Headline { get; set; }
            public List<DailyForecast> DailyForecasts { get; set; }

            public async static Task<WeatherEachDay> GetWeatherEach(string url)
            {
                var http = new HttpClient();
                var response = await http.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var serializer = new DataContractJsonSerializer(typeof(WeatherEachDay));
                var dataStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
                var value = serializer.ReadObject(dataStream) as WeatherEachDay;
                return value;
            }

        }

    }
