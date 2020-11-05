using Microsoft.Extensions.Logging;
using ShurimaEmperor.Api.Leagues.Interfaces;
using ShurimaEmperor.Api.Leagues.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Leagues.Services
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

        public async Task<(bool IsSuccess, dynamic LeagueEntries, string ErrorMessage)> GetAllLeagueEntries(string queue, string tier, string division)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                var response = await client.GetAsync($"/lol/league/v4/entries/{queue}/{tier}/{division}");
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

        public async Task<(bool IsSuccess, dynamic LeagueList, string ErrorMessage)> GetChallengerLeaguesByQueue(string queue)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                var response = await client.GetAsync($"/lol/league/v4/challengerleagues/by-queue/{queue}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<LeagueList>(content, options);

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

        public async Task<(bool IsSuccess, dynamic LeagueList, string ErrorMessage)> GetGrandmasterLeaguesByQueue(string queue)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                var response = await client.GetAsync($"/lol/league/v4/grandmasterleagues/by-queue/{queue}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<LeagueList>(content, options);

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

        public async Task<(bool IsSuccess, dynamic LeagueEntries, string ErrorMessage)> GetLeagueEntriesBySummoner(string summonerId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                var response = await client.GetAsync($"/lol/league/v4/entries/by-summoner/{summonerId}");
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

        public async Task<(bool IsSuccess, dynamic LeagueList, string ErrorMessage)> GetLeaguesByLeagueId(string leagueId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                var response = await client.GetAsync($"/lol/league/v4/leagues/{leagueId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<LeagueList>(content, options);

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

        public async Task<(bool IsSuccess, dynamic LeagueList, string ErrorMessage)> GetMasterLeaguesByQueue(string queue)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                var response = await client.GetAsync($"/lol/league/v4/masterleagues/by-queue/{queue}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<LeagueList>(content, options);

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
