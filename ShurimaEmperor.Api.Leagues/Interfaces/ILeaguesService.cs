using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Leagues.Interfaces
{
    public interface ILeaguesService
    {
        Task<(bool IsSuccess, dynamic LeagueListDetail, string ErrorMessage)> GetChallengerLeaguesByQueue(string queue, string server, int index);
        Task<(bool IsSuccess, dynamic LeagueListDetail, string ErrorMessage)> GetAllLeagueEntries(string queue, string tier, string division, string server, int index);
        Task<(bool IsSuccess, dynamic LeagueListDetail, string ErrorMessage)> GetGrandmasterLeaguesByQueue(string queue, string server, int index);
        Task<(bool IsSuccess, dynamic LeagueListDetail, string ErrorMessage)> GetMasterLeaguesByQueue(string queue, string server, int index);
    }
}
