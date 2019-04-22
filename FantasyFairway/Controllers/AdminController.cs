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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetUserLeagues()
        {
            AllUserLeaguesViewModel LUVM = new AllUserLeaguesViewModel();
            List<AllUserLeaguesViewModel> LUVMList = new List<AllUserLeaguesViewModel>();
            List<League> leagues = _context.Leagues.ToList();
            List<Team> teams = _context.Teams.ToList();
            List<AppUser> users = _context.AppUser.ToList();
            List<UserLeague> userLeagues = _context.UserLeagues.ToList();

            foreach(UserLeague UL in userLeagues)
            {
                foreach(League L in leagues)
                {
                    if(L.LeagueId == UL.LeagueForeignKey)
                    {
                        LUVM.leagueName = L.LeagueName;
                    }
                }

                foreach(AppUser AU in users)
                {
                    if(AU.Id == UL.AppUserForeignKey)
                    {
                        LUVM.userName = AU.FullName;
                        LUVM.userID = AU.Id;
                    }
                }

                foreach(Team T in teams)
                {
                    if(T.TeamID == UL.TeamForeignKey)
                    {
                        LUVM.teamName = T.TeamName;
                    }
                }
                LUVMList.Add(LUVM);
                LUVMList = LUVMList.OrderBy(id => id.userID).ToList();
                LUVM = new AllUserLeaguesViewModel();
            }

            return Ok(LUVMList);
        }

        [HttpPost]
        public async Task<IActionResult> EndWeek()
        {
                //allows the admin to delete all the players that exist
                List<Player> player = _context.Players.ToList();
                List<PlayerTeam> playerTeams = _context.PlayerTeam.ToList();
                var teams = _context.Teams.ToList();
                var ultts = _context.UserLeagueTeamTournaments.ToList();
                int endScore = 0;
                foreach (UserLeagueTeamTournament ULTT in ultts)
                {
                    foreach (Team T in teams)
                    {
                        if (T.TeamID == ULTT.TeamForeignKey)
                        {
                            foreach (PlayerTeam pt in playerTeams)
                            {
                                if (pt.TeamForeignKey == T.TeamID)
                                {
                                    foreach (Player P in player)
                                    {
                                        if (P.PlayerID == pt.PlayerForeignKey)
                                        {
                                            int playerscore = 0;
                                            //Calculate their score so far in the tournament.
                                            if (P.RoundOne != 0 && P.RoundTwo == 0 && P.RoundThree == 0 && P.RoundFour == 0)
                                            {
                                                playerscore += P.RoundOne - 72;
                                            }
                                            else if (P.RoundOne != 0 && P.RoundTwo != 0 && P.RoundThree == 0 && P.RoundFour == 0)
                                            {
                                                playerscore += P.RoundOne + P.RoundTwo - 144;
                                            }
                                            else if (P.RoundOne != 0 && P.RoundTwo != 0 && P.RoundThree != 0 && P.RoundFour == 0)
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
                                            endScore += playerscore;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    ULTT.TournamentScore = endScore;
                    _context.Update(ULTT);
                    endScore = 0;
                }

                foreach (Player P in player)
                {
                    _context.Players.Remove(P);
                }

                foreach (PlayerTeam PT in playerTeams)
                {
                    _context.PlayerTeam.Remove(PT);
                }

                await _context.SaveChangesAsync();

                return Ok("Players deleted");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePlayers()
        {
            List<Player> player = _context.Players.ToList();
            List<PlayerTeam> playerTeams = _context.PlayerTeam.ToList();

            foreach (Player P in player)
            {
                _context.Players.Remove(P);
            }

            foreach (PlayerTeam PT in playerTeams)
            {
                _context.PlayerTeam.Remove(PT);
            }


            await _context.SaveChangesAsync();

            return Ok("Players deleted");
        }


    }
}