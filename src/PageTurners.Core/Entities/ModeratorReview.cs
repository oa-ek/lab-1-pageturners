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
        public int Review_Id { get; set; }
        public int Request_Id { get; set; }
        public int Moderator_Id { get; set; }
        public string Review_Comment { get; set; }
        public string Review_Status { get; set; }

        public virtual BookRequest Request { get; set; }
        public virtual User Moderator { get; set; }
    }

}
