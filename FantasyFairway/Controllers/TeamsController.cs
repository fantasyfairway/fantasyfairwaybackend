﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyFairway.Data;
using FantasyFairway.Models;
using System.Security.Claims;
using FantasyFairway.ViewModels;

namespace FantasyFairway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ClaimsPrincipal _caller;

        public TeamsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<IActionResult> GetTeam()
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var appuser = await _context.AppUser.Include(c => c.IdentityUser).SingleAsync(c => c.IdentityUser.Id == userId.Value);

            var userLeagues = _context.UserLeagues.ToList();
            var playerTeams = _context.PlayerTeam.ToList();
            var players = _context.Players.ToList();
            var teams = _context.Teams.ToList();
            var leagues = _context.Leagues.ToList();

            UserLeague userInLeagues = new UserLeague();

            PlayerTeamsViewModel ptvm = new PlayerTeamsViewModel();
            ptvm.players = new List<Player>();
            List<PlayerTeamsViewModel> ptvmList = new List<PlayerTeamsViewModel>();

            foreach(UserLeague UL in userLeagues)
            {
                if(UL.AppUserForeignKey == appuser.Id)
                {
                    userInLeagues = UL;
                    foreach(League L in leagues)
                    {
                        if(userInLeagues.LeagueForeignKey == L.LeagueId)
                        {
                            ptvm.leagueName = L.LeagueName;
                        }
                    }

                    foreach (Team T in teams)
                    {
                        if (T.TeamID == UL.TeamForeignKey)
                        {
                            ptvm.teamName = T.TeamName;
                            ptvm.teamID = T.TeamID;
                        }
                    }

                    foreach (PlayerTeam PT in playerTeams)
                    {
                        if(userInLeagues.TeamForeignKey == PT.TeamForeignKey)
                        {

                            foreach (Player P in players)
                            {
                                if(P.PlayerID == PT.PlayerForeignKey)
                                {
                                    ptvm.players.Add(P);
                                }
                            }

                        }
                    }
                    ptvmList.Add(ptvm);
                    ptvm = new PlayerTeamsViewModel();
                    ptvm.players = new List<Player>();
                }
            }

            return Ok(ptvmList);
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        // PUT: api/Teams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam([FromRoute] int id, [FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.TeamID)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teams
        [HttpPost]
        public async Task<IActionResult> PostTeam([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.TeamID }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return Ok(team);
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }
    }
}