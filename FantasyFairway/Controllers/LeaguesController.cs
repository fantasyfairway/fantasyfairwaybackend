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
using Microsoft.AspNetCore.Authorization;

namespace FantasyFairway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeaguesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leagues = _context.Leagues.ToList();
            return Ok(leagues);
        }

        // GET: api/Leagues 
        //[HttpGet("Name")]
        //public async Task<IActionResult<String>> GetNames()
        //{ 
            // retrieve the user info
            //HttpContext.User


        //    var userId = _caller.Claims.Single(c => c.Type == "id");
        //    var appuser = await _context.AppUser.Include(c => c.IdentityUser).SingleAsync(c => c.IdentityUser.Id == userId.Value);

        //    foreach (League league in appuser.league)
        //    {
        //        appuser.Leagues[];
        //    }
//            return new OkObjectResult(new
        //    {
         //       this.league.LeagueName
        //    });
       // } 

        // GET: api/Leagues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeague([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var league = await _context.Leagues.FindAsync(id);

            if (league == null)
            {
                return NotFound();
            }

            return Ok(league);
        }

        // PUT: api/Leagues/5
        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeague([FromRoute] int id, [FromBody]League league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != league.LeagueId)
            {
                return BadRequest();
            }

            _context.Entry(league).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueExists(id))
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

        // POST: api/Leagues
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostLeague([FromBody]League league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Leagues.Add(league);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeague", new { id = league.LeagueId }, league);
        }

        // DELETE: api/Leagues/5
        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeague([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var league = await _context.Leagues.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }

            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();

            return Ok(league);
        }

        private bool LeagueExists(int id)
        {
            return _context.Leagues.Any(e => e.LeagueId == id);
        }
    }
}