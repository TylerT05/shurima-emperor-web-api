using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class MatchTimeline
    {
        public List<MatchFrame> Frames { get; set; }
        public long FrameInterval { get; set; }
    }
}
