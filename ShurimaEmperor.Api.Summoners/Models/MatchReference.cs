﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Models
{
    public class MatchReference
    {
        public long GameId { get; set; }
        public string Role { get; set; }
        public int Season { get; set; }
        public string PlatformId { get; set; }
        public int Champion { get; set; }
        public int Queue { get; set; }
        public string Lane { get; set; }
        public long Timestamp { get; set; }
    }
}
