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
        public User User { get; set; }
        public BookRequest BookRequest { get; set; }
        public string ReviewComment { get; set; }
        public string Status { get; set; }

        public virtual User Moderator { get; set; }
    }

}
