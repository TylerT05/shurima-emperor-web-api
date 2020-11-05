using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class MatchList
    {
        public int StartIndex { get; set; }
        public int TotalGames { get; set; }
        public int EndIndex { get; set; }
        public List<MatchReference> Matches { get; set; }
    }
}
