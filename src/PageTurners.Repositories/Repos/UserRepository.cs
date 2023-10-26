using Microsoft.AspNetCore.Identity;
using PageTurners.Core.Context;
using PageTurners.Core.Entities;
using PageTurners.Repositories.DTOs.User;
using PageTurners.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PageTurners.Repositories.Repos
{
    public class UserRepository : IUserRepository
    {
        private PageTurnersContext _context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRepository(PageTurnersContext context, 
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = context;
        }

        public User GetById(string id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public async Task <IEnumerable<UserReadDto>> GetAll()
        {
            var users = _context.Users.ToList();
            var usersDto = new List<UserReadDto>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                usersDto.Add(
                    new UserReadDto
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Name = user.Name,
                        Login = user.Login,
                        IsConfirmed = user.EmailConfirmed,
                        Roles = roles.ToList()
            });
            }
            return usersDto;
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
