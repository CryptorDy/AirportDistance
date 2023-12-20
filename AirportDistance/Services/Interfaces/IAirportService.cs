using AirportDistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportDistance.Services
{
    public interface IAirportService
    {
        Task<double> GetDistance(string codeFirst, string codeSecond);
        Task<AirportInfo> GetInfoByCode(string code);
    }
}
