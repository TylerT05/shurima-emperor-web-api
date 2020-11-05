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

        [HttpGet("match-list/by-account/{accountId}")]
        public async Task<IActionResult> GetMatchListByAccountIdAsync(string accountId)
        {
            var result = await matchesService.GetMatchListByAccountIdAsync(accountId);
            if (result.IsSuccess)
            {
                return Ok(result.MatchList);
            }

            return NotFound();
        }

        [HttpGet("matches/{matchId}")]
        public async Task<IActionResult> GetMatchByMatchIdAsync(long matchId)
        {
            var result = await matchesService.GetMatchByMatchIdAsync(matchId);
            if (result.IsSuccess)
            {
                return Ok(result.Match);
            }

            return NotFound();
        }

        [HttpGet("timelines/by-match/{matchId}")]
        public async Task<IActionResult> GetMatchTimelineByMatchIdAsync(long matchId)
        {
            var result = await matchesService.GetMatchTimelineByMatchIdAsync(matchId);
            if (result.IsSuccess)
            {
                return Ok(result.MatchTimeline);
            }

            return NotFound();
        }
    }
}
