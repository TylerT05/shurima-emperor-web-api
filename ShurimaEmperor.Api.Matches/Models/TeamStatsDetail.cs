using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class TeamStatsDetail
    {
        public int TowerKills { get; set; }
        public int RiftHeraldKills { get; set; }
        public int InhibitorKills { get; set; }
        public int DragonKills { get; set; }
        public int BaronKills { get; set; }
        public int TeamId { get; set; }
        public string Win { get; set; }
        public long TotalDamageDealtToChampions { get; set; }
        public int TotalGoldEarned { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalAssists { get; set; }
    }
}
