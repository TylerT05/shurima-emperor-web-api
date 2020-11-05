using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Leagues.Models
{
    public class LeagueList
    {
        public string LeagueId { get; set; }
        public List<LeagueItem> Entries { get; set; }
        public string Tier { get; set; }
        public string Name { get; set; }
        public string Queue { get; set; }
    }
}
