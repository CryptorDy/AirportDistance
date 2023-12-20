using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportDistance.Models
{
    public class AirportInfo
    {
        public string Iata { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string City_iata { get; set; }
        public string Country { get; set; }
        public string Country_iata { get; set; }
        public Location Location { get; set; }
        public int Rating { get; set; }
        public int Hubs { get; set; }
        public string Timezone_region_name { get; set; }
        public string Type { get; set; }
    }
}
