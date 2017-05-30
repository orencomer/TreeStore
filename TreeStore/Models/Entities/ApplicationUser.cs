﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TreeStore.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Logo { get; set; }

    }
}
