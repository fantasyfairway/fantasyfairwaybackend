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
    public class PlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync()
        {
            var players = await _context.Players.ToListAsync();

            List<Player> sortedPlayers = players.OrderBy(r => r.Rank).ToList();

            if (players != null)
            {
                return new JsonResult(sortedPlayers);
            }

            return new OkObjectResult("No record");
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer([FromRoute] int id, [FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.PlayerID)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Players
        [HttpPost]
        public async Task<IActionResult> PostPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var allplayers = _context.Players.ToList();

            bool exists = false;

            //if a player already exists then we update them
            foreach(Player p in allplayers)
            {
                if(player.PlayerName == p.PlayerName)
                {
                    exists = true;
                    p.PlayerName = player.PlayerName;
                    p.Rank = player.Rank;
                    p.RoundOne = player.RoundOne;
                    p.RoundTwo = player.RoundTwo;
                    p.RoundThree = player.RoundThree;
                    p.RoundFour = player.RoundFour;
                    p.Value = player.Value;
                    p.TournamentTotal = player.RoundOne + player.RoundTwo + player.RoundThree + player.RoundFour;
                    _context.Entry(p).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
            }

            //or if they dont exist then we get a new one
            if (exists == false)
            {
                _context.Players.Add(player);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.PlayerID }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return Ok(player);
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerID == id);
        }
    }
}