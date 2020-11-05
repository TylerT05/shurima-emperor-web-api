using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class ParticipantIdentity
    {
        public int ParticipantId { get; set; }
        public Player Player { get; set; }
    }
}
