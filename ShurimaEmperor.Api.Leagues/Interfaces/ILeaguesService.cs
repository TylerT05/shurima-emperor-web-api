using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Leagues.Interfaces
{
    public interface ILeaguesService
    {
        Task<(bool IsSuccess, dynamic LeagueList, string ErrorMessage)> GetChallengerLeaguesByQueue(string queue);
        Task<(bool IsSuccess, dynamic LeagueEntries, string ErrorMessage)> GetLeagueEntriesBySummoner(string summonerId);
        Task<(bool IsSuccess, dynamic LeagueEntries, string ErrorMessage)> GetAllLeagueEntries(string queue, string tier, string division);
        Task<(bool IsSuccess, dynamic LeagueList, string ErrorMessage)> GetGrandmasterLeaguesByQueue(string queue);
        Task<(bool IsSuccess, dynamic LeagueList, string ErrorMessage)> GetLeaguesByLeagueId(string leagueId);
        Task<(bool IsSuccess, dynamic LeagueList, string ErrorMessage)> GetMasterLeaguesByQueue(string queue);
    }
}
