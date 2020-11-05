using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public ParticipantStats Stats { get; set; }
    }
}
