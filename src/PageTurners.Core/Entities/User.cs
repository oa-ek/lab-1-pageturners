using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Core.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Book> Read_Books { get; set; }
        public virtual ICollection<Book> To_Read_List { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }

}
