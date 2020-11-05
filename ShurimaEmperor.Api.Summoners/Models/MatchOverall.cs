using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Models
{
    public class MatchOverall
    {
        public long GameId { get; set; }
        public int Champion { get; set; }
        public long GameDuration { get; set; }
        public bool Win { get; set; }
        public string Role { get; set; }
        public string Lane { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public long TotalDamageDealtToChampions { get; set; }
        public int TotalMinionsKilled { get; set; }
        public long VisionScore { get; set; }
        public int Queue { get; set; }
        public long Timestamp { get; set; }
    }
}
