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

        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetSummonerByNameAsync(string name, int index)
        {
            var result = await summonersService.GetSummonerByNameAsync(name, index);
            if (result.IsSuccess)
            {
                return Ok(result.Summoner);
            }

            return NotFound();
        }

        [HttpGet("verify-by-name/{name}")]
        public async Task<IActionResult> VerifySummonerByNameAsync(string name)
        {
            var result = await summonersService.VerifySummonerByNameAsync(name);
            if (result.IsSuccess)
            {
                return Ok(result.Verify);
            }

            return NotFound();
        }
    }
}
