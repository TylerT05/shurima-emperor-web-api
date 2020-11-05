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
    public class MatchesService : IMatchesService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<MatchesService> logger;

        public MatchesService(IHttpClientFactory httpClientFactory, ILogger<MatchesService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, dynamic MatchList, string ErrorMessage)> GetMatchListByAccountIdAsync(string accountId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("MatchesService");
                var response = await client.GetAsync($"api/match-list/by-account/{accountId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<MatchList>(content, options);

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
