using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyFairway.Data;
using FantasyFairway.Models;

namespace FantasyFairway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ULTTController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ULTTController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserLeagueTeamTournaments
        //[HttpGet]
        //public IEnumerable<UserLeagueTeamTournament> GetUserLeagueTeamTournaments()
        //{
        //    return _context.UserLeagueTeamTournaments;
       // }

        // GET: api/UserLeagueTeamTournaments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserLeagueTeamTournament([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLeagueTeamTournament = await _context.UserLeagueTeamTournaments.FindAsync(id);

            if (userLeagueTeamTournament == null)
            {
                return NotFound();
            }

            return Ok(userLeagueTeamTournament);
        }

        // PUT: api/UserLeagueTeamTournaments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLeagueTeamTournament([FromRoute] int id, [FromBody] UserLeagueTeamTournament userLeagueTeamTournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userLeagueTeamTournament.UserLeagueTeamTournamentID)
            {
                return BadRequest();
            }

            _context.Entry(userLeagueTeamTournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLeagueTeamTournamentExists(id))
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

        // POST: api/UserLeagueTeamTournaments
        [HttpPost]
        public async Task<IActionResult> PostUserLeagueTeamTournament([FromBody] UserLeagueTeamTournament userLeagueTeamTournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserLeagueTeamTournaments.Add(userLeagueTeamTournament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLeagueTeamTournament", new { id = userLeagueTeamTournament.UserLeagueTeamTournamentID }, userLeagueTeamTournament);
        }

        // DELETE: api/UserLeagueTeamTournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLeagueTeamTournament([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLeagueTeamTournament = await _context.UserLeagueTeamTournaments.FindAsync(id);
            if (userLeagueTeamTournament == null)
            {
                return NotFound();
            }

            _context.UserLeagueTeamTournaments.Remove(userLeagueTeamTournament);
            await _context.SaveChangesAsync();

            return Ok(userLeagueTeamTournament);
        }

        private bool UserLeagueTeamTournamentExists(int id)
        {
            return _context.UserLeagueTeamTournaments.Any(e => e.UserLeagueTeamTournamentID == id);
        }
    }
}