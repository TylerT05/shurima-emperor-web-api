using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Profiles
{
    public class MatchProfile : AutoMapper.Profile
    {
        public MatchProfile()
        {
            CreateMap<Models.Match, Models.MatchDetail>();
            CreateMap<Models.Participant, Models.ParticipantDetail>();
            CreateMap<Models.ParticipantStats, Models.ParticipantStatsDetail>();
            CreateMap<Models.TeamStats, Models.TeamStatsDetail>();
        }
    }
}
