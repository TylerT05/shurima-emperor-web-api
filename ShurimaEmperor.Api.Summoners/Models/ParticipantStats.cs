using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Models
{
    public class ParticipantStats
    {
        public int Deaths { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public long TotalDamageDealtToChampions { get; set; }
        public int TotalMinionsKilled { get; set; }
        public bool Win { get; set; }
        public long VisionScore { get; set; }
    }
}
