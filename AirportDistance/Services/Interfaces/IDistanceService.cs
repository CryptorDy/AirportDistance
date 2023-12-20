using AirportDistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportDistance.Services
{
    public interface IDistanceService
    {
        double CalculateDistance(Location point1, Location point2);
    }
}
