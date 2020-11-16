using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Leagues.Models
{
    public class LeagueItemDetail
    {
        public int Wins { get; set; }
        public string SummonerName { get; set; }
        public string Rank { get; set; }
        public int LeaguePoints { get; set; }
        public int Losses { get; set; }
    }
}
