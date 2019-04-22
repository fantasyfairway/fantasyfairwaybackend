using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFairway.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PictureURL { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityUserForeignKey { get; set; }

        [ForeignKey("IdentityUserForeignKey")]
        public IdentityUser IdentityUser { get; set; }
    }
}
