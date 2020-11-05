using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class TeamStats
    {
        public int TowerKills { get; set; }
        public int RiftHeraldKills { get; set; }
        public bool FirstBlood { get; set; }
        public int InhibitorKills { get; set; }
        public List<TeamBans> Bans { get; set; }
        public bool FirstBaron { get; set; }
        public bool FirstDragon { get; set; }
        public int DominionVictoryScore { get; set; }
        public int DragonKills { get; set; }
        public int BaronKills { get; set; }
        public bool FirstInhibitor { get; set; }
        public bool FirstTower { get; set; }
        public int VilemawKills { get; set; }
        public bool FirstRiftHerald { get; set; }
        public int TeamId { get; set; }
        public string Win { get; set; }
    }
}
