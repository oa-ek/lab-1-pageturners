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
        public int Rating_Id { get; set; }
        public int User_Id { get; set; }
        public int Book_Id { get; set; }
        public int Value { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }

}
