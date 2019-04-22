using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FantasyFairway.Models;
using FantasyFairway.Data;
using FantasyFairway.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FantasyFairway.Helpers;

namespace FantasyFairway.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<IdentityUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        // POST api/account
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var userIdentity = _mapper.Map<IdentityUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);
            var role = await _userManager.AddToRoleAsync(userIdentity, "User");

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.AppUser.AddAsync(new AppUser { IdentityUserForeignKey = userIdentity.Id, FirstName = model.FirstName, LastName = model.LastName, FullName = model.FirstName + " " + model.LastName });
            
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}