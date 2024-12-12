using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPP.Models
{
    internal class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }


        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }


        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }


        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }


        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }


        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
}
