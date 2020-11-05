﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Models
{
    public class MatchEvent
    {
        public string LaneType { get; set; }
        public int SkillSlot { get; set; }
        public string AscendedType { get; set; }
        public int CreatorId { get; set; }
        public int AfterId { get; set; }
        public string EventType { get; set; }
        public string Type { get; set; }
        public string LevelUpType { get; set; }
        public string WardType { get; set; }
        public int ParticipantId { get; set; }
        public string TowerType { get; set; }
        public int ItemId { get; set; }
        public int BeforeId { get; set; }
        public string PointCaptured { get; set; }
        public string MonsterSubType { get; set; }
        public int TeamId { get; set; }
        public MatchPosition Position { get; set; }
        public int KillerId { get; set; }
        public long Timestamp { get; set; }
        public List<int> AssistingParticipantIds { get; set; }
        public string BuildingType { get; set; }
        public int VictimId { get; set; }
    }
}
