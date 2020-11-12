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
    public class SummonersService : ISummonersService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<SummonersService> logger;

        public SummonersService(IHttpClientFactory httpClientFactory, ILogger<SummonersService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, dynamic Summoner, string ErrorMessage)> GetSummonerByNameAsync(string name, string server, int index)
        {
            try
            {
                var client = httpClientFactory.CreateClient("SummonersService");
                client.BaseAddress = new Uri($"https://{server}.api.riotgames.com");
                var response = await client.GetAsync($"/lol/summoner/v4/summoners/by-name/{name}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<Summoner>(content, options);

                    result.matchOveralls = new List<MatchOverall>();

                    var matchesResponse = await client.GetAsync($"/lol/match/v4/matchlists/by-account/{result.AccountId}");
                    if (matchesResponse.IsSuccessStatusCode)
                    {
                        var matchesContent = await matchesResponse.Content.ReadAsByteArrayAsync();
                        var matchesResult = JsonSerializer.Deserialize<MatchList>(matchesContent, options);

                        long lastPlayed = 0;
                        foreach(var m in matchesResult.Matches)
                        {
                            if(m.Timestamp > lastPlayed)
                            {
                                lastPlayed = m.Timestamp;
                            }
                        }
                        result.LastPlayed = lastPlayed;

                        for(int i = index - 10; i < (index < matchesResult.Matches.Count() ? index : matchesResult.Matches.Count()); i++)
                        {
                            var matchResponse = await client.GetAsync($"/lol/match/v4/matches/{matchesResult.Matches[i].GameId}");
                            if (matchResponse.IsSuccessStatusCode)
                            {
                                var matchContent = await matchResponse.Content.ReadAsByteArrayAsync();
                                var matchResult = JsonSerializer.Deserialize<Match>(matchContent, options);

                                var stats = matchResult.Participants.Find(p => p.ParticipantId == matchResult.ParticipantIdentities.Find(pi => pi.Player.AccountId == result.AccountId).ParticipantId).Stats;

                                result.matchOveralls.Add(new MatchOverall
                                {
                                    GameId = matchesResult.Matches[i].GameId,
                                    Role = matchesResult.Matches[i].Role,
                                    Champion = matchesResult.Matches[i].Champion,
                                    Queue = matchesResult.Matches[i].Queue,
                                    Lane = matchesResult.Matches[i].Lane,
                                    Timestamp = matchesResult.Matches[i].Timestamp,
                                    GameDuration = matchResult.GameDuration,
                                    Assists = stats.Assists,
                                    Deaths = stats.Deaths,
                                    Kills = stats.Kills,
                                    TotalDamageDealtToChampions = stats.TotalDamageDealtToChampions,
                                    TotalMinionsKilled = stats.TotalMinionsKilled,
                                    VisionScore = stats.VisionScore,
                                    Win = stats.Win
                                });
                            }
                        }

                        result.MatchList = matchesResult;
                    }

                    var leaguesRepsonse = await client.GetAsync($"/lol/league/v4/entries/by-summoner/{result.Id}");
                    if (leaguesRepsonse.IsSuccessStatusCode)
                    {
                        var leaguesContent = await leaguesRepsonse.Content.ReadAsByteArrayAsync();
                        var leaguesResult = JsonSerializer.Deserialize<List<LeagueEntry>>(leaguesContent, options);

                        result.LeagueEntries = leaguesResult;
                    }

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

        public async Task<(bool IsSuccess, dynamic Verify, string ErrorMessage)> VerifySummonerByNameAsync(string name, string server)
        {
            try
            {
                var client = httpClientFactory.CreateClient("SummonersService");
                client.BaseAddress = new Uri($"https://{server}.api.riotgames.com");
                var response = await client.GetAsync($"/lol/summoner/v4/summoners/by-name/{name}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<Summoner>(content, options);

                    if(result.Name == name)
                    {
                        return (true, true, null);
                    }
                    else
                    {
                        return (true, false, null);
                    }
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
