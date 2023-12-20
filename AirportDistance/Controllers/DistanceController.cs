using AirportDistance.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportDistance.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public DistanceController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet("{codeFirst}/{codeSecond}")]
        public async Task<double> GetDistanceAirports(string codeFirst, string codeSecond)
        {
            return await _airportService.GetDistance(codeFirst, codeSecond);
        }
    }
}
