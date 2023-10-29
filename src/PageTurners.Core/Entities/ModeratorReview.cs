using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Core.Entities
{
    public class ModeratorReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("BookRequest")]
        public int BookRequestId { get; set; }
        public BookRequest BookRequest { get; set; }
        public string ReviewComment { get; set; }
        public string Status { get; set; }
        [ForeignKey("Moderator")]
        public string ModeratorId { get; set; }
        public User Moderator { get; set; }
    }

}
