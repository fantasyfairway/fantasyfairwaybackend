using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FantasyFairway.Data;

namespace FantasyFairway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentPlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TournamentPlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TournamentPlayers
        [HttpGet]
        public IEnumerable<TournamentPlayer> GetTournamentPlayer()
        {
            return _context.TournamentPlayer;
        }

        // GET: api/TournamentPlayers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournamentPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tournamentPlayer = await _context.TournamentPlayer.FindAsync(id);

            if (tournamentPlayer == null)
            {
                return NotFound();
            }

            return Ok(tournamentPlayer);
        }

        // PUT: api/TournamentPlayers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamentPlayer([FromRoute] int id, [FromBody] TournamentPlayer tournamentPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tournamentPlayer.TournamentPlayerID)
            {
                return BadRequest();
            }

            _context.Entry(tournamentPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentPlayerExists(id))
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

        // POST: api/TournamentPlayers
        [HttpPost]
        public async Task<IActionResult> PostTournamentPlayer([FromBody] TournamentPlayer tournamentPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TournamentPlayer.Add(tournamentPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournamentPlayer", new { id = tournamentPlayer.TournamentPlayerID }, tournamentPlayer);
        }

        // DELETE: api/TournamentPlayers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tournamentPlayer = await _context.TournamentPlayer.FindAsync(id);
            if (tournamentPlayer == null)
            {
                return NotFound();
            }

            _context.TournamentPlayer.Remove(tournamentPlayer);
            await _context.SaveChangesAsync();

            return Ok(tournamentPlayer);
        }

        private bool TournamentPlayerExists(int id)
        {
            return _context.TournamentPlayer.Any(e => e.TournamentPlayerID == id);
        }
    }
}