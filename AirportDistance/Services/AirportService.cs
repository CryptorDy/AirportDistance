using AirportDistance.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AirportDistance.Services
{
    public class AirportService : IAirportService
    {
        private readonly IDistanceService _distanceService;
        private readonly AppSettings _settings;

        public AirportService(IDistanceService distanceService,
            IOptions<AppSettings> settings)
        {
            _distanceService = distanceService;
            _settings = settings.Value;
        }

        public async Task<double> GetDistance(string codeFirst, string codeSecond)
        {
            var firstAirport = await GetInfoByCode(codeFirst);
            var secondAirport = await GetInfoByCode(codeSecond);

            var dictance = _distanceService.CalculateDistance(firstAirport.Location, secondAirport.Location);

            return Math.Round(dictance, 2);
        }

        public async Task<AirportInfo> GetInfoByCode(string code)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_settings.AirportInfoUrl);

                HttpResponseMessage response = await client.GetAsync(code.ToUpper());

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var airport = JsonConvert.DeserializeObject<AirportInfo>(content);
                    return airport;
                }

                return null;
            }
        }
    }
}
