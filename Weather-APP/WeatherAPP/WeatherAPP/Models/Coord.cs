using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPP.Models
{
    internal class Coord
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }


        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }
}
