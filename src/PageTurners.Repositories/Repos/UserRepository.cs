using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly PageTurnersContext _context;
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

        public async Task<UserReadDto> GetAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            var roles = await userManager.GetRolesAsync(user);
            return
                new UserReadDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Login = user.Login,
                    IsConfirmed = user.EmailConfirmed,
                    Roles = roles.ToList()
                };
        }

        public async Task <IEnumerable<UserReadDto>> GetAllAsync()
        {
            var userIds = _context.Users.Select(x=>x.Id).ToList();
            var usersDto = new List<UserReadDto>();

            foreach (var id in userIds)
                usersDto.Add(await GetAsync(id));

            return usersDto;
        }

        public async Task<string> CreateAsync(UserCreateDto user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                UserName = user.Name,
                Login = user.Login,
                NormalizedEmail = user.Email.ToUpper(),
                NormalizedUserName = user.Email.ToUpper(),
                EmailConfirmed = true
            };

            await userManager.CreateAsync(newUser, user.Password);

            return  _context.Users.First(x=> x.Email == user.Email).Id;
        }

        public async Task UpdateAsync(UserReadDto model, string[] roles)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (user.Email != model.Email)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                user.NormalizedUserName = model.Email.ToUpper();
                user.NormalizedEmail = model.Email.ToUpper();
            }

            if (user.Name != model.Name) user.Name = model.Name;
            if (user.Login != model.Login) user.Login = model.Login;
            if (user.EmailConfirmed != model.IsConfirmed) user.EmailConfirmed = model.IsConfirmed;

            if ((await userManager.GetRolesAsync(user)).Any())
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            }

            if (roles.Any())
            {
                await userManager.AddToRolesAsync(user, roles.ToList());
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string?>> GetRolesAsync()
        {
            return _context.Roles.Select(x => x.Name).ToList();
        }

        public async Task DeleteAsync(string id)
        {
            var user = _context.Users.Find(id);
            if ((await userManager.GetRolesAsync(user)).Any())
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            }
            await userManager.DeleteAsync(user);
        }
    }

}
