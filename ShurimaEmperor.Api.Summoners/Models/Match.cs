using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Models
{
    public class Match
    {
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }
        public long GameDuration { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
