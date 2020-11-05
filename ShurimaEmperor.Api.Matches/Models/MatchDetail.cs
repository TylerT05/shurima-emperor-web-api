using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class MatchDetail
    {
        public long GameId { get; set; }
        public int QueueId { get; set; }
        public string GameType { get; set; }
        public long GameDuration { get; set; }
        public List<TeamStatsDetail> Teams { get; set; }
        public long GameCreation { get; set; }
        public int SeasonId { get; set; }
        public string GameVersion { get; set; }
        public int MapId { get; set; }
        public string GameMode { get; set; }
        public List<ParticipantDetail> Participants { get; set; }
        public List<TeamBans> Bans { get; set; }
        public long LargestDamageDealtToChampions { get; set; }
    }
}
