﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Core.Entities
{
    public class ForumTopic
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<ForumPost> Posts { get; set; }
    }

}
