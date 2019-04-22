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

namespace FantasyFairway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TournamentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<IActionResult> GetTournaments()
        {
            var userLeagues = _context.UserLeagues.ToList();
            var tournaments = _context.Tournaments.ToList();
            var players = _context.Players.ToList();
            var teams = _context.Teams.ToList();
            var leagues = _context.Leagues.ToList();
            var users = _context.AppUser.ToList();
            var ulttList = _context.UserLeagueTeamTournaments.ToList();

            UserLeague userInLeagues = new UserLeague();

            PastTournamentViewModel tournVM = new PastTournamentViewModel();
            TourneyLeagueViewModel tlvm = new TourneyLeagueViewModel();
            tlvm.teams = new List<TourneyTeamViewModel>();
            TourneyTeamViewModel ttvm = new TourneyTeamViewModel();
            tournVM.leagues = new List<TourneyLeagueViewModel>();

            List<PastTournamentViewModel> tournVMList = new List<PastTournamentViewModel>();

            foreach(Tournament T in tournaments)
            {
                tournVM.tournamentName = T.TournamentName;
                tournVM.tournamentID = T.TournamentID;
                foreach (League L in leagues)
                {
                    tlvm.leagueName = L.LeagueName;
                    tlvm.leagueID = L.LeagueId;
                    foreach (UserLeague UL in userLeagues)
                    {
                        if (UL.LeagueForeignKey == L.LeagueId)
                        {
                            foreach (UserLeagueTeamTournament ULTT in ulttList)
                            {
                                foreach(AppUser AU in users)
                                {
                                    if(UL.AppUserForeignKey == AU.Id)
                                    {
                                        ttvm.userName = AU.FullName;
                                    }
                                }

                                if (ULTT.UserLeagueForeignKey == UL.UserLeagueID && ULTT.TournamentForeignKey == tournVM.tournamentID) 
                                {
                                    foreach (Team Te in teams)
                                    {
                                        if (Te.TeamID == ULTT.TeamForeignKey)
                                        {
                                            ttvm.team = Te.TeamName;
                                            ttvm.teamID = Te.TeamID;
                                            ttvm.finalScore = ULTT.TournamentScore;
                                            tlvm.teams.Add(ttvm);
                                            ttvm = new TourneyTeamViewModel();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    tlvm.teams = tlvm.teams.OrderBy(score => score.finalScore).ToList();
                    if(tlvm.teams.Count != 0)
                    {
                        tournVM.leagues.Add(tlvm);
                    }
                    tlvm = new TourneyLeagueViewModel();
                    tlvm.teams = new List<TourneyTeamViewModel>();
                }

                if(tournVM.leagues.Count != 0)
                {
                    tournVMList.Add(tournVM);
                }

                tournVM = new PastTournamentViewModel();
                tournVM.leagues = new List<TourneyLeagueViewModel>();
            }



            return Ok(tournVMList);
        }
    

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournament([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return Ok(tournament);
        }

        // PUT: api/Tournaments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament([FromRoute] int id, [FromBody] Tournament tournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tournament.TournamentID)
            {
                return BadRequest();
            }

            _context.Entry(tournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
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

        // POST: api/Tournaments
        [HttpPost]
        public async Task<IActionResult> PostTournament([FromBody] Tournament tournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var allTourneys = _context.Tournaments.ToList();

            bool exists = false;

            foreach (Tournament t in allTourneys)
            {
                if (tournament.TournamentName == t.TournamentName)
                {
                    exists = true;
                    t.TournamentName = tournament.TournamentName;
                    t.TournamentDates = tournament.TournamentDates;
                    _context.Entry(t).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
            }

            if (exists == false)
            {
                _context.Tournaments.Add(tournament);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournament", new { id = tournament.TournamentID }, tournament);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();

            return Ok(tournament);
        }

        private bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(e => e.TournamentID == id);
        }
    }
}