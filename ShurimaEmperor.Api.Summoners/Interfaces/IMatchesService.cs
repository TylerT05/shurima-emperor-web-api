using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Interfaces
{
    public interface IMatchesService
    {
        Task<(bool IsSuccess, dynamic MatchList, string ErrorMessage)> GetMatchListByAccountIdAsync(string accountId);
    }
}
