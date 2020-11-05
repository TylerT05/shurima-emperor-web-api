using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class MatchFrame
    {
        public Dictionary<string, MatchParticipantFrame> ParticipantFrames { get; set; }
        public List<MatchEvent> Events { get; set; }
        public long Timestamp { get; set; }
    }
}
