using Microsoft.AspNetCore.Mvc;
using ShurimaEmperor.Api.Summoners.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Summoners.Controllers
{
    [ApiController]
    [Route("api/summoners")]
    public class SummonersController : ControllerBase
    {
        private readonly ISummonersService summonersService;

        public SummonersController(ISummonersService summonersService)
        {
            this.summonersService = summonersService;
        }

        [HttpGet("{server}/{name}")]
        public async Task<IActionResult> GetSummonerByNameAsync(string name, string server, int index)
        {
            var result = await summonersService.GetSummonerByNameAsync(name, server, index);
            if (result.IsSuccess)
            {
                return Ok(result.Summoner);
            }

            return NotFound();
        }

        [HttpGet("{server}/verify/{name}")]
        public async Task<IActionResult> VerifySummonerByNameAsync(string name, string server)
        {
            var result = await summonersService.VerifySummonerByNameAsync(name, server);
            if (result.IsSuccess)
            {
                return Ok(result.Verify);
            }

            return NotFound();
        }
    }
}
