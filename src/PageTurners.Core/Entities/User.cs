﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PageTurners.Core.Entities
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Photo { get; set; }

     
        public virtual ICollection<UserBook> ReadBooks { get; set; }

     
        public virtual ICollection<UserBook> ToReadList { get; set; }

        public virtual ICollection<BookRequest> BookRequests { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Comments> Comment { get; set; }
        public virtual ICollection<ModeratorReview> Reviews { get; set; }
    }

}
