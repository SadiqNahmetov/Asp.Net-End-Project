using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class AppUser : IdentityUser 
    {
        public string Fullname { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
