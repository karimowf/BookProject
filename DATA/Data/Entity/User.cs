﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Data.Entity
{
    public class User : IdentityUser<string>
    {

        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Age { get; set; }
        public string? Bio { get; set; }
        public string? Expertise { get; set; }
        public string? PortfolioUrl { get; set; }
        public ICollection<BookUser> bookUsers { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
