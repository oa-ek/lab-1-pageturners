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
        public int Request_Id { get; set; }
        public int User_Id { get; set; }
        public string Book_Title { get; set; }
        public string Book_Author { get; set; }
        public string Book_Genre { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public virtual User User { get; set; }
    }

}
