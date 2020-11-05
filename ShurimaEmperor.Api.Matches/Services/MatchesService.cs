using AutoMapper;
using Microsoft.Extensions.Logging;
using ShurimaEmperor.Api.Matches.Interfaces;
using ShurimaEmperor.Api.Matches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Services
{
    public class MatchesService : IMatchesService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<MatchesService> logger;
        private readonly IMapper mapper;

        public MatchesService(IHttpClientFactory httpClientFactory, ILogger<MatchesService> logger, IMapper mapper)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<(bool IsSuccess, dynamic Match, string ErrorMessage)> GetMatchByMatchIdAsync(long matchId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("MatchesService");
                var response = await client.GetAsync($"/lol/match/v4/matches/{matchId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<Match>(content, options);

                    var matchDetail = mapper.Map<Models.Match, Models.MatchDetail>(result);

                    int totalGold1 = 0;
                    int totalGold2 = 0;
                    long totalDmg1 = 0;
                    long totalDmg2 = 0;
                    int totalKills1 = 0;
                    int totalDeaths1 = 0;
                    int totalAssists1 = 0;
                    int totalKills2 = 0;
                    int totalDeaths2 = 0;
                    int totalAssists2 = 0;

                    long largestDamage = 0;

                    foreach (var p in matchDetail.Participants)
                    {
                        if(p.Stats.TotalDamageDealtToChampions > largestDamage)
                        {
                            largestDamage = p.Stats.TotalDamageDealtToChampions;
                        } 

                        var pi = result.ParticipantIdentities.Find(i => i.ParticipantId == p.ParticipantId);
                        p.ProfileIcon = pi.Player.ProfileIcon;
                        p.AccountId = pi.Player.AccountId;
                        p.CurrentAccountId = pi.Player.CurrentAccountId;
                        p.SummonerName = pi.Player.SummonerName;
                        p.SummonerId = pi.Player.SummonerId;

                        if(p.TeamId == 100)
                        {
                            totalGold1 += p.Stats.GoldEarned;
                            totalDmg1 += p.Stats.TotalDamageDealtToChampions;
                            totalKills1 += p.Stats.Kills;
                            totalDeaths1 += p.Stats.Deaths;
                            totalAssists1 += p.Stats.Assists;
                        } else
                        {
                            totalGold2 += p.Stats.GoldEarned;
                            totalDmg2 += p.Stats.TotalDamageDealtToChampions;
                            totalKills2 += p.Stats.Kills;
                            totalDeaths2 += p.Stats.Deaths;
                            totalAssists2 += p.Stats.Assists;
                        }

                        p.Role = result.Participants.Find(pp => pp.ParticipantId == p.ParticipantId).Timeline.Role;
                        p.Lane = result.Participants.Find(pp => pp.ParticipantId == p.ParticipantId).Timeline.Lane;
                    }

                    foreach(var t in matchDetail.Teams)
                    {
                        if(t.TeamId == 100)
                        {
                            t.TotalGoldEarned = totalGold1;
                            t.TotalDamageDealtToChampions = totalDmg1;
                            t.TotalKills = totalKills1;
                            t.TotalDeaths = totalDeaths1;
                            t.TotalAssists = totalAssists1;
                        } else
                        {
                            t.TotalGoldEarned = totalGold2;
                            t.TotalDamageDealtToChampions = totalDmg2;
                            t.TotalKills = totalKills2;
                            t.TotalDeaths = totalDeaths2;
                            t.TotalAssists = totalAssists2;
                        }
                    }

                    matchDetail.Bans = new List<TeamBans>();
                    foreach(var t in result.Teams)
                    {
                        matchDetail.Bans.AddRange(t.Bans);
                    }

                    matchDetail.LargestDamageDealtToChampions = largestDamage;

                    return (true, matchDetail, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, dynamic MatchList, string ErrorMessage)> GetMatchListByAccountIdAsync(string accountId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("MatchesService");
                var response = await client.GetAsync($"/lol/match/v4/matchlists/by-account/{accountId}");
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

        public async Task<(bool IsSuccess, dynamic MatchTimeline, string ErrorMessage)> GetMatchTimelineByMatchIdAsync(long matchId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("MatchesService");
                var response = await client.GetAsync($"/lol/match/v4/timelines/by-match/{matchId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<MatchTimeline>(content, options);

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
