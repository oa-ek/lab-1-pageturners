using Microsoft.AspNetCore.Identity;
using PageTurners.Core.Context;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.Repos
{
    public class UserRepository : IUserRepository
    {
        private PageTurnersContext _context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRepository(PageTurnersContext context)
        {
            _context = context;
        }

        public User GetById(string id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }

}
