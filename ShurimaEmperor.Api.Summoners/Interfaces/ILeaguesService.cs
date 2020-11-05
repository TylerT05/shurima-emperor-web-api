using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Interfaces
{
    public interface ILeaguesService
    {
        Task<(bool IsSuccess, dynamic LeagueEntries, string ErrorMessage)> GetLeagueEntriesBySummoner(string summonerId);
    }
}
