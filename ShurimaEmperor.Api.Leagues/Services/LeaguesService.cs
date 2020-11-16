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

        public async Task<(bool IsSuccess, dynamic LeagueListDetail, string ErrorMessage)> GetAllLeagueEntries(string queue, string tier, string division, string server, int index)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                client.BaseAddress = new Uri($"https://{server}.api.riotgames.com/");
                var response = await client.GetAsync($"/lol/league/v4/entries/{queue}/{tier}/{division}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<HashSet<LeagueEntry>>(content, options);

                    var leagueList = new LeagueListDetail();
                    leagueList.Tier = tier;
                    leagueList.Queue = queue;
                    leagueList.Entries = new List<LeagueItemDetail>();
                    
                    foreach(var e in result.OrderByDescending(x => x.LeaguePoints).Skip(index - 10).Take(10))
                    {
                        leagueList.Entries.Add(new LeagueItemDetail
                        {
                            SummonerName = e.SummonerName,
                            Wins = e.Wins,
                            Losses = e.Losses,
                            LeaguePoints = e.LeaguePoints,
                            Rank = e.Rank
                        });
                    }

                    return (true, leagueList, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, dynamic LeagueListDetail, string ErrorMessage)> GetChallengerLeaguesByQueue(string queue, string server, int index)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                client.BaseAddress = new Uri($"https://{server}.api.riotgames.com/");
                var response = await client.GetAsync($"/lol/league/v4/challengerleagues/by-queue/{queue}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<LeagueList>(content, options);

                    var leagueList = new LeagueListDetail();
                    leagueList.Tier = result.Tier;
                    leagueList.Queue = result.Queue;
                    leagueList.Entries = new List<LeagueItemDetail>();

                    foreach (var e in result.Entries.OrderByDescending(x => x.LeaguePoints).Skip(index - 10).Take(10))
                    {
                        leagueList.Entries.Add(new LeagueItemDetail
                        {
                            SummonerName = e.SummonerName,
                            Wins = e.Wins,
                            Losses = e.Losses,
                            LeaguePoints = e.LeaguePoints,
                            Rank = e.Rank
                        });
                    }

                    return (true, leagueList, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, dynamic LeagueListDetail, string ErrorMessage)> GetGrandmasterLeaguesByQueue(string queue, string server, int index)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                client.BaseAddress = new Uri($"https://{server}.api.riotgames.com/");
                var response = await client.GetAsync($"/lol/league/v4/grandmasterleagues/by-queue/{queue}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<LeagueList>(content, options);

                    var leagueList = new LeagueListDetail();
                    leagueList.Tier = result.Tier;
                    leagueList.Queue = result.Queue;
                    leagueList.Entries = new List<LeagueItemDetail>();

                    foreach (var e in result.Entries.OrderByDescending(x => x.LeaguePoints).Skip(index - 10).Take(10))
                    {
                        leagueList.Entries.Add(new LeagueItemDetail
                        {
                            SummonerName = e.SummonerName,
                            Wins = e.Wins,
                            Losses = e.Losses,
                            LeaguePoints = e.LeaguePoints,
                            Rank = e.Rank
                        });
                    }

                    return (true, leagueList, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, dynamic LeagueListDetail, string ErrorMessage)> GetMasterLeaguesByQueue(string queue, string server, int index)
        {
            try
            {
                var client = httpClientFactory.CreateClient("LeaguesService");
                client.BaseAddress = new Uri($"https://{server}.api.riotgames.com/");
                var response = await client.GetAsync($"/lol/league/v4/masterleagues/by-queue/{queue}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<LeagueList>(content, options);

                    var leagueList = new LeagueListDetail();
                    leagueList.Tier = result.Tier;
                    leagueList.Queue = result.Queue;
                    leagueList.Entries = new List<LeagueItemDetail>();

                    foreach (var e in result.Entries.OrderByDescending(x => x.LeaguePoints).Skip(index - 10).Take(10))
                    {
                        leagueList.Entries.Add(new LeagueItemDetail
                        {
                            SummonerName = e.SummonerName,
                            Wins = e.Wins,
                            Losses = e.Losses,
                            LeaguePoints = e.LeaguePoints,
                            Rank = e.Rank
                        });
                    }

                    return (true, leagueList, null);
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
