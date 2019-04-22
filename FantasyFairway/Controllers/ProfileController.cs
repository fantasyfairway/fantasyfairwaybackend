using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FantasyFairway.Data;
using FantasyFairway.Models;
using FantasyFairway.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FantasyFairway.Helpers;

namespace FantasyFairway.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;


        public ProfileController(UserManager<IdentityUser> userManager, IMapper mapper, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _context = appDbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET api/dashboard/home
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // retrieve the user info
            //HttpContext.User
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var appuser = await _context.AppUser.Include(c => c.IdentityUser).SingleAsync(c => c.IdentityUser.Id == userId.Value);
            var users = _context.Users.ToList();
            ProfileViewModel PUVM = new ProfileViewModel();

            foreach (IdentityUser u in users)
            {
                if (appuser.IdentityUserForeignKey == u.Id)
                    PUVM.Username = u.UserName;
            }


            PUVM.FirstName = appuser.FirstName;
            PUVM.LastName = appuser.LastName;
            PUVM.Email = appuser.IdentityUserForeignKey;

            return new OkObjectResult(PUVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProfileUpateViewModel profileUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = _caller.Claims.Single(c => c.Type == "id");
            var appuser = await _context.AppUser.Include(c => c.IdentityUser).SingleAsync(c => c.IdentityUser.Id == userId.Value);
            var users = _context.Users.ToList();


            appuser.FirstName = profileUpdate.FirstName;
            appuser.LastName = profileUpdate.LastName;
            appuser.FullName = profileUpdate.FirstName + " " + profileUpdate.LastName;

            foreach (IdentityUser u in users)
            {
                if (appuser.IdentityUserForeignKey == u.Id)
                {
                    u.UserName = profileUpdate.Username;
                    var result = await _userManager.UpdateAsync(u);
                    if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
                }

            }

            _context.Entry(appuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(appuser.IdentityUserForeignKey))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new OkObjectResult("Account updated");
        }

        private bool UserExists(string id)
        {
            return _context.AppUser.Any(e => e.IdentityUserForeignKey == id);
        }

    }

}
