using System;
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
using Microsoft.AspNetCore.Authorization;

namespace FantasyFairway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLeaguesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ClaimsPrincipal _caller;

        public UserLeaguesController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _context = context;
        }

        // GET: api/UserLeagues
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //HttpContext.User
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var appuser = await _context.AppUser.Include(c => c.IdentityUser).SingleAsync(c => c.IdentityUser.Id == userId.Value);
            var uLeagues = _context.UserLeagues.ToList();
            var Leagues = _context.Leagues.ToList();
            var Teams = _context.Teams.ToList();
            AllUserLeaguesViewModel AULVM = new AllUserLeaguesViewModel();
            List<AllUserLeaguesViewModel> userLeagues = new List<AllUserLeaguesViewModel>();

            foreach (UserLeague UL in uLeagues)
            {
                if(UL.AppUserForeignKey == appuser.Id)
                {
                    AULVM.userID = UL.UserLeagueID;

                    foreach(Team T in Teams)
                    {
                        if(T.TeamID == UL.TeamForeignKey)
                        {
                            AULVM.teamName = T.TeamName;
                        }
                    }

                    foreach (League L in Leagues)
                    {
                        if (UL.LeagueForeignKey == L.LeagueId)
                        {
                            AULVM.leagueName = L.LeagueName; 
                        }
                    }
                    userLeagues.Add(AULVM);
                    AULVM = new AllUserLeaguesViewModel();
                }
            }

            return Ok(userLeagues);

        }

        // GET: api/UserLeagues/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserLeague([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLeague = await _context.UserLeagues.FindAsync(id);

            if (userLeague == null)
            {
                return NotFound();
            }

            return Ok(userLeague);
        }

        // PUT: api/UserLeagues/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLeague([FromRoute] int id, [FromBody] UserLeague userLeague)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userLeague.UserLeagueID)
            {
                return BadRequest();
            }

            _context.Entry(userLeague).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLeagueExists(id))
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

        // POST: api/UserLeagues
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostUserLeague([FromBody] LeagueUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //HttpContext.User
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var appuser = await _context.AppUser.Include(c => c.IdentityUser).SingleAsync(c => c.IdentityUser.Id == userId.Value);
            bool exists = false;
            var checkLeague = _context.UserLeagues.ToList();
            var league = _context.Leagues.ToList();
            UserLeague userLeague = new UserLeague();
            Team userTeam = new Team();

            userTeam.TeamName = model.teamName;

            userLeague.LeagueForeignKey = model.leagueId;
            userLeague.AppUserForeignKey = appuser.Id;

            foreach(UserLeague CL in checkLeague)
            {
                if(CL.LeagueForeignKey == userLeague.LeagueForeignKey && CL.AppUserForeignKey == userLeague.AppUserForeignKey)
                {
                    exists = true;
                }
            }
            
            if(exists == false)
            {

                foreach (League L in league)
                {
                    if (userLeague.LeagueForeignKey == L.LeagueId)
                    {
                        L.userCount += 1;
                        _context.Entry(L).State = EntityState.Modified;
                    }
                }
                var team = _context.Teams.Add(userTeam).Entity;
                
                userLeague.Team = team;
                userLeague.TeamForeignKey = team.TeamID;
                _context.UserLeagues.Add(userLeague);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUserLeague", new { id = userLeague.UserLeagueID }, userLeague);
            }
            else
            {
                return BadRequest("User Already in League");
            }
            

        }

        // DELETE: api/UserLeagues/
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLeague([FromRoute] int id)
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var appuser = await _context.AppUser.Include(c => c.IdentityUser).SingleAsync(c => c.IdentityUser.Id == userId.Value);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teams = _context.Teams.ToList();
            var leagues = _context.Leagues.ToList();
            var userLeague = await _context.UserLeagues.FindAsync(id);

            if(userLeague.AppUserForeignKey == appuser.Id)
            {
                if (userLeague == null)
                {
                    return NotFound();
                }

                foreach (Team t in teams)
                {
                    if (t.TeamID == userLeague.TeamForeignKey)
                    {
                        _context.Teams.Remove(t);
                    }
                }

                foreach(League L in leagues)
                {
                    if(L.LeagueId == userLeague.LeagueForeignKey)
                    {
                        L.userCount -= 1;
                    }
                }

                _context.UserLeagues.Remove(userLeague);
                await _context.SaveChangesAsync();

                return Ok(userLeague);
            }
            else
            {
                return BadRequest("wrong user");
            }

        }

        private bool UserLeagueExists(int id)
        {
            return _context.UserLeagues.Any(e => e.UserLeagueID == id);
        }
    }
}