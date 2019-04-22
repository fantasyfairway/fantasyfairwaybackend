using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyFairway.Data;
using FantasyFairway.Models;
using FantasyFairway.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FantasyFairway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerTeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ClaimsPrincipal _caller;

        public PlayerTeamsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _context = context;
        }

        // GET: api/PlayerTeams
        [HttpGet]
        public IEnumerable<PlayerTeam> GetPlayerTeam()
        {
            return _context.PlayerTeam;
        }

        // GET: api/PlayerTeams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerTeam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerTeam = await _context.PlayerTeam.FindAsync(id);

            if (playerTeam == null)
            {
                return NotFound();
            }

            return Ok(playerTeam);
        }

        // PUT: api/PlayerTeams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerTeam([FromRoute] int id, [FromBody] PlayerTeam playerTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerTeam.PlayerTeamID)
            {
                return BadRequest();
            }

            _context.Entry(playerTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerTeamExists(id))
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

        // POST: api/PlayerTeams
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostPlayerTeam([FromBody] PlayerTeamViewModel model)
        {
            if(DateTime.Now.DayOfWeek == DayOfWeek.Monday || DateTime.Now.DayOfWeek == DayOfWeek.Tuesday || DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                //gets the user
                var userId = _caller.Claims.Single(c => c.Type == "id");
                var appuser = await _context.AppUser.Include(c => c.IdentityUser).SingleAsync(c => c.IdentityUser.Id == userId.Value);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var players = _context.Players.ToList();
                var playerteams = _context.PlayerTeam.ToList();
                var userLeagues = _context.UserLeagues.ToList();
                var tournaments = _context.Tournaments.ToList();
                var userltt = _context.UserLeagueTeamTournaments.ToList();
                var newultt = new UserLeagueTeamTournament();

                foreach (UserLeague UL in userLeagues)
                {
                    if (UL.TeamForeignKey == model.teamID && UL.AppUserForeignKey == appuser.Id)
                    {
                        newultt.UserLeagueForeignKey = UL.UserLeagueID;
                        newultt.TeamForeignKey = UL.TeamForeignKey;

                        foreach (Tournament TM in tournaments)
                        {
                            if (TM.TournamentName == model.tournamentName)
                            {
                                newultt.TournamentForeignKey = TM.TournamentID;
                            }
                        }
                        bool exists = false;
                        foreach (UserLeagueTeamTournament ULTT in userltt)
                        {
                            if (ULTT.TournamentForeignKey == newultt.TournamentForeignKey
                                && ULTT.TeamForeignKey == newultt.TeamForeignKey
                                && ULTT.UserLeagueForeignKey == newultt.UserLeagueForeignKey)
                            {
                                exists = true;
                            }
                        }
                        if (exists == false)
                        {
                            _context.UserLeagueTeamTournaments.Add(newultt);
                        }

                        foreach (PlayerTeam ptd in playerteams)
                        {
                            if (ptd.TeamForeignKey == model.teamID)
                            {
                                _context.PlayerTeam.Remove(ptd);
                            }
                        }

                        PlayerTeam pt = new PlayerTeam();
                        foreach (Player p in players)
                        {
                            foreach (string s in model.playerNames)
                            {
                                if (p.PlayerName == s)
                                {
                                    pt.PlayerForeignKey = p.PlayerID;
                                    pt.TeamForeignKey = model.teamID;
                                    _context.PlayerTeam.Add(pt);
                                }
                                pt = new PlayerTeam();
                            }

                        }
                    }
                    else if (UL.TeamForeignKey == model.teamID && UL.AppUserForeignKey != appuser.Id)
                    {
                        return BadRequest("Wrong user");
                    }
                }


                await _context.SaveChangesAsync();

                return Ok("Players added to team");
            }
            else
            {
                return BadRequest("Too late in the week to add team");
            }

        }

        // DELETE: api/PlayerTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerTeam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerTeam = await _context.PlayerTeam.FindAsync(id);
            if (playerTeam == null)
            {
                return NotFound();
            }

            _context.PlayerTeam.Remove(playerTeam);
            await _context.SaveChangesAsync();

            return Ok(playerTeam);
        }

        private bool PlayerTeamExists(int id)
        {
            return _context.PlayerTeam.Any(e => e.PlayerTeamID == id);
        }
    }
}