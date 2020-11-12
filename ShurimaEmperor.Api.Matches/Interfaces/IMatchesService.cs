using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Interfaces
{
    public interface IMatchesService
    {
        Task<(bool IsSuccess, dynamic MatchList, string ErrorMessage)> GetMatchListByAccountIdAsync(string accountId, string server);
        Task<(bool IsSuccess, dynamic Match, string ErrorMessage)> GetMatchByMatchIdAsync(long matchId, string server);
        Task<(bool IsSuccess, dynamic MatchTimeline, string ErrorMessage)> GetMatchTimelineByMatchIdAsync(long matchId, string server);
    }
}
