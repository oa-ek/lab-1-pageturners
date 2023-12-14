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
    public class Comments : BaseEntity<int>
	{
       
        [ForeignKey("CommentatorId")]
        public User Commentator { get; set; }
        public string CommentatorId { get; set; }

        /*public Book Book { get; set; }
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }*/

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
