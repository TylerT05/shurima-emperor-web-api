using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Models
{
    public class ParticipantIdentity
    {
        public int ParticipantId { get; set; }
        public Player Player { get; set; }
    }
}
