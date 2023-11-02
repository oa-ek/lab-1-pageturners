using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Core.Entities
{
    public class BookRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /*public User Owner { get; set; }
        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; }*/
        public string Title { get; set; }
        public string Author { get; set; }
        public int DatePubl { get; set; }
        public string? Genre { get; set; }
        public string? Desc { get; set; }
        public string? Edition { get; set; }
        public string OwnerId { get; set; }
        public virtual ICollection<ModeratorReview> Reviews { get; set; }
        [ForeignKey("OwnerId")]
        public User Owner { get; set; }
    }

}
