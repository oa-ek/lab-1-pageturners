using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Core.Entities
{
    public class ForumPost
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int ForumTopicId { get; set; }
        public ForumTopic Topic { get; set; }
    }

}
