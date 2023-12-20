using AirportDistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportDistance.Services
{
    public class DistanceService : IDistanceService
    {
        private const double EarthRadiusMiles = 3958.8;

        public double CalculateDistance(Location point1, Location point2)
        {
            var dLat = DegreesToRadians(point2.Lat - point1.Lat);
            var dLon = DegreesToRadians(point2.Lon - point1.Lon);
            var lat1 = DegreesToRadians(point1.Lat);
            var lat2 = DegreesToRadians(point2.Lat);

            var chordLengthSquared = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                                 Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var angularDistance = 2 * Math.Atan2(Math.Sqrt(chordLengthSquared), Math.Sqrt(1 - chordLengthSquared));
            var dictance = EarthRadiusMiles * angularDistance;
            return dictance;
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

    }
}
