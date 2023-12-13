using PageTurners.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Domain.Entities
{
    public class UserBook : BaseEntity<int>
	{
        // Оголошуємо поля для відповідності ключам інших сутностей
        public string UserId { get; set; }
        public int BookId { get; set; }

        // Оголошуємо навігаційні властивості для зв'язків
        public User User { get; set; }
        public Book Book { get; set; }
    }

}
