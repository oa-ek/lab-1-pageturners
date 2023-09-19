using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Core.Entities
{
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
