﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Leagues.Models
{
    public class LeagueItem
    {
        public bool FreshBlood { get; set; }
        public int Wins { get; set; }
        public string SummonerName { get; set; }
        public MiniSeries MiniSeries { get; set; }
        public bool Inactive { get; set; }
        public bool Veteran { get; set; }
        public bool HotStreak { get; set; }
        public string Rank { get; set; }
        public int LeaguePoints { get; set; }
        public int Losses { get; set; }
        public string SummonerId { get; set; }
    }
}
