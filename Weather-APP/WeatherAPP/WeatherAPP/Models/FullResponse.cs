using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPP.Models
{
    internal class FullResponse
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }


        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }


        [JsonPropertyName("main")]
        public Main Main { get; set; }
    }
}
