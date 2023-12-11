using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Domain.Common;

namespace PageTurners.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string? Author { get; set; }
        public string Genre { get; set; }
        public string? Desc { get; set; }
        public string Edition { get; set; }
        public double? AverageRating { get; set; }
        public int DatePubl { get; set; }
        
        
        public virtual ICollection<Comments> Comment { get; set; }
    //    [InverseProperty("UsersReadBooks")]
        public virtual ICollection<UserBook> UsersReadBooks { get; set; }
      //  [InverseProperty("UsersReadLater")]
        public virtual ICollection<UserBook> UsersReadLater { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
