using Microsoft.AspNetCore.Mvc;
using ShurimaEmperor.Api.Leagues.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Leagues.Controllers
{
    [ApiController]
    [Route("api/leagues")]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeaguesService leaguesService;

        public LeaguesController(ILeaguesService leaguesService)
        {
            this.leaguesService = leaguesService;
        }

        [HttpGet("{server}/entries/{queue}/{tier}/{division}")]
        public async Task<IActionResult> GetAllLeagueEntries(string queue, string tier, string division, string server, int index)
        {
            if(tier == "CHALLENGER")
            {
                var result = await leaguesService.GetChallengerLeaguesByQueue(queue, server, index);

                if (result.IsSuccess)
                {
                    return Ok(result.LeagueListDetail);
                }
            }
            else if(tier == "GRANDMASTER")
            {
                var result = await leaguesService.GetGrandmasterLeaguesByQueue(queue, server, index);

                if (result.IsSuccess)
                {
                    return Ok(result.LeagueListDetail);
                }
            }
            else if(tier == "MASTER")
            {
                var result = await leaguesService.GetMasterLeaguesByQueue(queue, server, index);

                if (result.IsSuccess)
                {
                    return Ok(result.LeagueListDetail);
                }
            }
            else
            {
                var result = await leaguesService.GetAllLeagueEntries(queue, tier, division, server, index);

                if (result.IsSuccess)
                {
                    return Ok(result.LeagueListDetail);
                }
            }

            return NotFound();
        }
    }
}
