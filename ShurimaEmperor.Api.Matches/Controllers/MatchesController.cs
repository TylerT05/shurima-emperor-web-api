using Microsoft.AspNetCore.Mvc;
using ShurimaEmperor.Api.Matches.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShurimaEmperor.Api.Matches.Controllers
{
    [ApiController]
    [Route("api")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchesService matchesService;

        public MatchesController(IMatchesService matchesService)
        {
            this.matchesService = matchesService;
        }

        [HttpGet("{server}/match-list/by-account/{accountId}")]
        public async Task<IActionResult> GetMatchListByAccountIdAsync(string accountId, string server)
        {
            var result = await matchesService.GetMatchListByAccountIdAsync(accountId, server);
            if (result.IsSuccess)
            {
                return Ok(result.MatchList);
            }

            return NotFound();
        }

        [HttpGet("{server}/matches/{matchId}")]
        public async Task<IActionResult> GetMatchByMatchIdAsync(long matchId, string server)
        {
            var result = await matchesService.GetMatchByMatchIdAsync(matchId, server);
            if (result.IsSuccess)
            {
                return Ok(result.Match);
            }

            return NotFound();
        }

        [HttpGet("{server}/timelines/by-match/{matchId}")]
        public async Task<IActionResult> GetMatchTimelineByMatchIdAsync(long matchId, string server)
        {
            var result = await matchesService.GetMatchTimelineByMatchIdAsync(matchId, server);
            if (result.IsSuccess)
            {
                return Ok(result.MatchTimeline);
            }

            return NotFound();
        }
    }
}
