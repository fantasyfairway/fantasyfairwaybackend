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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FantasyFairway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AppUsers
        [Authorize(Policy = "Admin")]
        [HttpGet]
        public IEnumerable<UserDetailsViewModel> GetAppUser()
        {

            List<UserDetailsViewModel> models = new List<UserDetailsViewModel>();
            var appusers = _context.AppUser.ToList();
            var identityUsers = _context.Users.ToList();

            foreach(AppUser appuser in appusers)
            {
                foreach(IdentityUser user in identityUsers)
                {
                    if(user.Id == appuser.IdentityUserForeignKey) 
                    {
                        UserDetailsViewModel model = new UserDetailsViewModel();
                        model.Id = appuser.Id;
                        model.FirstName = appuser.FirstName;
                        model.LastName = appuser.LastName;
                        model.Username = user.UserName;
                        model.PictureUrl = appuser.PictureURL;
                        model.Email = user.Email;
                        models.Add(model);
                    }
                }
            }
            return models;
        }

        //// GET: api/AppUsers/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAppUser([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var appUser = await _context.AppUser.FindAsync(id);

        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(appUser);
        //}

        //// PUT: api/AppUsers/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAppUser([FromRoute] int id, [FromBody] AppUser appUser)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != appUser.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(appUser).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AppUserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/AppUsers
        //[HttpPost]
        //public async Task<IActionResult> PostAppUser([FromBody] AppUser appUser)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.AppUser.Add(appUser);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
        //}

        //// DELETE: api/AppUsers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAppUser([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var appUser = await _context.AppUser.FindAsync(id);
        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.AppUser.Remove(appUser);
        //    await _context.SaveChangesAsync();

        //    return Ok(appUser);
        //}

        //private bool AppUserExists(int id)
        //{
        //    return _context.AppUser.Any(e => e.Id == id);
        //}
    }
}