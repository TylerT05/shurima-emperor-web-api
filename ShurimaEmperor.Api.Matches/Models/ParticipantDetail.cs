using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class ParticipantDetail
    {
        public int ParticipantId { get; set; }
        public int ChampionId { get; set; }
        public ParticipantStatsDetail Stats { get; set; }
        public int TeamId { get; set; }
        public int Spell1Id { get; set; }
        public int Spell2Id { get; set; }
        public string HighestAchievedSeasonTier { get; set; }
        public int ProfileIcon { get; set; }
        public string AccountId { get; set; }
        public string CurrentAccountId { get; set; }
        public string SummonerName { get; set; }
        public string SummonerId { get; set; }
        public string Role { get; set; }
        public string Lane { get; set; }
    }
}
