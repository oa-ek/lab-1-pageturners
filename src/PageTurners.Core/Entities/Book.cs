using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Core.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Author { get; set; }
        public string Genre { get; set; }
        public string? Desc { get; set; }
        public string Edition { get; set; }
        public double? AverageRating { get; set; }
        public int DatePubl { get; set; }
        
        
        public virtual ICollection<Comments> Comment { get; set; }
        [InverseProperty("UsersReadBooks")]
        public virtual ICollection<User> UsersReadBooks { get; set; }
        [InverseProperty("UsersReadLater")]
        public virtual ICollection<User> UsersReadLater { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
