using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Core.Entities
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User User { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public Book Book { get; set; }
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public int Value { get; set; }
    }

}
