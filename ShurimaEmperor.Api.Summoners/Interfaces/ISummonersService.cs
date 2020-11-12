using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Interfaces
{
    public interface ISummonersService
    {
        Task<(bool IsSuccess, dynamic Verify, string ErrorMessage)> VerifySummonerByNameAsync(string name, string server);
        Task<(bool IsSuccess, dynamic Summoner, string ErrorMessage)> GetSummonerByNameAsync(string name, string server, int index);
    }
}
