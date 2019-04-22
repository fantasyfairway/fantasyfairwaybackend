using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyFairway.Data;
using FantasyFairway.Models;
using FantasyFairway.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyFairway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dashboard/Get
        [HttpGet]
        public async Task<IActionResult> get()
        {

            var userLeagues = _context.UserLeagues.ToList();
            var playerTeams = _context.PlayerTeam.ToList();
            var players = _context.Players.ToList();
            var teams = _context.Teams.ToList();
            var leagues = _context.Leagues.ToList();
            var users = _context.AppUser.ToList();

            UserLeague userInLeagues = new UserLeague();

            DashboardViewModel dvm = new DashboardViewModel();
            PlayerTeamsViewModel ptvm = new PlayerTeamsViewModel();
            ptvm.players = new List<Player>();
            ptvm.scoreSoFar = 0;
            dvm.teams = new List<PlayerTeamsViewModel>();
            List<DashboardViewModel> dvmList = new List<DashboardViewModel>();

            foreach (League L in leagues)
            {
                if(L.Active == true)
                {
                    dvm.leagueName = L.LeagueName;
                    dvm.leagueID = L.LeagueId;

                    foreach (UserLeague UL in userLeagues)
                    {

                        if (UL.LeagueForeignKey == dvm.leagueID)
                        {
                            foreach (AppUser AU in users)
                            {
                                if (UL.AppUserForeignKey == AU.Id)
                                {
                                    ptvm.userName = AU.FullName;
                                }
                            }
                            ptvm.teamID = UL.TeamForeignKey;

                            foreach (Team T in teams)
                            {
                                if (ptvm.teamID == T.TeamID)
                                {
                                    ptvm.teamName = T.TeamName;
                                }
                            }

                            foreach (PlayerTeam PT in playerTeams)
                            {
                                if (ptvm.teamID == PT.TeamForeignKey)
                                {
                                    foreach (Player P in players)
                                    {
                                        if (PT.PlayerForeignKey == P.PlayerID)
                                        {
                                            int playerscore = 0;
                                            //Calculate their score so far in the tournament.
                                            if (P.RoundOne != 0 && P.RoundTwo == 0 && P.RoundThree == 0 && P.RoundFour == 0 )
                                            {
                                                playerscore += P.RoundOne - 72;
                                            }
                                            else if(P.RoundOne != 0 && P.RoundTwo != 0 && P.RoundThree == 0 && P.RoundFour == 0)
                                            {
                                                playerscore += P.RoundOne + P.RoundTwo - 144;
                                            }
                                            else if(P.RoundOne != 0 && P.RoundTwo != 0 && P.RoundThree != 0 && P.RoundFour == 0)
                                            {
                                                playerscore += P.RoundOne + P.RoundTwo + P.RoundThree - 216;
                                            }
                                            else if (P.RoundOne != 0 && P.RoundTwo != 0 && P.RoundThree != 0 && P.RoundFour != 0)
                                            {
                                                playerscore += P.RoundOne + P.RoundTwo + P.RoundThree + P.RoundFour - 288;
                                            }
                                            else
                                            {
                                                playerscore = 0;
                                            }
                                            ptvm.scoreSoFar += playerscore;
                                            ptvm.players.Add(P);
                                        }

                                    }
                                }
                            }
                        }
                        if (ptvm.teamName != null)
                        {
                            dvm.teams.Add(ptvm);
                            ptvm = new PlayerTeamsViewModel();
                            ptvm.players = new List<Player>();
                            ptvm.scoreSoFar = 0;
                        }
                    }
                    dvm.teams = dvm.teams.OrderBy(p => p.scoreSoFar).ToList();
                    dvmList.Add(dvm);
                    dvm = new DashboardViewModel();
                    dvm.teams = new List<PlayerTeamsViewModel>();
                }
                
            }

            return Ok(dvmList);
        }


    }
}
