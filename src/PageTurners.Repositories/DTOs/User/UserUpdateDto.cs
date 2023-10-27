using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.DTOs.User
{
    public class UserUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
