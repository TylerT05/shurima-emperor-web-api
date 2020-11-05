using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Models
{
    public class Summoner
    {
        public string AccountId { get; set; }
        public int ProfileIconId { get; set; }
        public long RevisionDate { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string PUUID { get; set; }
        public long SummonerLevel { get; set; }
        public MatchList MatchList { get; set; }
        public List<LeagueEntry> LeagueEntries { get; set; }
        public List<MatchOverall> matchOveralls { get; set; }
        public long LastPlayed { get; set; }
    }
}
