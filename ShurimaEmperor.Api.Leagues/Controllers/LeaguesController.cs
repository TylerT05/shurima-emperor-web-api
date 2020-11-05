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

        [HttpGet("entries/{queue}/{tier}/{division}")]
        public async Task<IActionResult> GetAllLeagueEntries(string queue, string tier, string division)
        {
            var result = await leaguesService.GetAllLeagueEntries(queue, tier, division);
            if (result.IsSuccess)
            {
                return Ok(result.LeagueEntries);
            }

            return NotFound();
        }

        [HttpGet("challengerleagues/by-queue/{queue}")]
        public async Task<IActionResult> GetChallengerLeaguesByQueue(string queue)
        {
            var result = await leaguesService.GetChallengerLeaguesByQueue(queue);
            if (result.IsSuccess)
            {
                return Ok(result.LeagueList);
            }

            return NotFound();
        }

        [HttpGet("grandmasterleagues/by-queue/{queue}")]
        public async Task<IActionResult> GetGrandmasterLeaguesByQueue(string queue)
        {
            var result = await leaguesService.GetGrandmasterLeaguesByQueue(queue);
            if (result.IsSuccess)
            {
                return Ok(result.LeagueList);
            }

            return NotFound();
        }

        [HttpGet("entries/by-summoner/{summonerId}")]
        public async Task<IActionResult> GetLeagueEntriesBySummoner(string summonerId)
        {
            var result = await leaguesService.GetLeagueEntriesBySummoner(summonerId);
            if (result.IsSuccess)
            {
                return Ok(result.LeagueEntries);
            }

            return NotFound();
        }

        [HttpGet("{leagueId}")]
        public async Task<IActionResult> GetLeaguesByLeagueId(string leagueId)
        {
            var result = await leaguesService.GetLeaguesByLeagueId(leagueId);
            if (result.IsSuccess)
            {
                return Ok(result.LeagueList);
            }

            return NotFound();
        }

        [HttpGet("masterleagues/by-queue/{queue}")]
        public async Task<IActionResult> GetMasterLeaguesByQueue(string queue)
        {
            var result = await leaguesService.GetMasterLeaguesByQueue(queue);
            if (result.IsSuccess)
            {
                return Ok(result.LeagueList);
            }

            return NotFound();
        }
    }
}
