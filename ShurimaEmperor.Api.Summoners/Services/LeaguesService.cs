using Microsoft.Extensions.Logging;
using ShurimaEmperor.Api.Summoners.Interfaces;
using ShurimaEmperor.Api.Summoners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Services
{
    public class LeaguesService : ILeaguesService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<LeaguesService> logger;

        public LeaguesService(IHttpClientFactory httpClientFactory, ILogger<LeaguesService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, dynamic LeagueEntries, string ErrorMessage)> GetLeagueEntriesBySummoner(string summonerId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                var response = await client.GetAsync($"api/leagues/entries/by-summoner/{summonerId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<HashSet<LeagueEntry>>(content, options);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
