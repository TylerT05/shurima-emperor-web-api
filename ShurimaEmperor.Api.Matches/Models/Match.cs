using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class Match
    {
        public long GameId { get; set; }
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }
        public int QueueId { get; set; }
        public string GameType { get; set; }
        public long GameDuration { get; set; }
        public List<TeamStats> Teams { get; set; }
        public string PlatformId { get; set; }
        public long GameCreation { get; set; }
        public int SeasonId { get; set; }
        public string GameVersion { get; set; }
        public int MapId { get; set; }
        public string GameMode { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
