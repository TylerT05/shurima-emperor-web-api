using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public int ChampionId { get; set; }
        public List<Rune> Runes { get; set; }
        public ParticipantStats Stats { get; set; }
        public int TeamId { get; set; }
        public ParticipantTimeline Timeline { get; set; }
        public int Spell1Id { get; set; }
        public int Spell2Id { get; set; }
        public string HighestAchievedSeasonTier { get; set; }
        public List<Mastery> Masteries { get; set; }
    }
}
