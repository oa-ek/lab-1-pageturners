using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PageTurners.Core.Entities;

namespace PageTurners.Core.Context
{
    public class PageTurnersContext : IdentityDbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<BookRequest> Requests => Set<BookRequest>();
        /*public DbSet<ModeratorReview> Reviews => Set<ModeratorReview>();*/
        public DbSet<Rating> Ratings => Set<Rating>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Comments> Comment => Set<Comments>();

        /*public DbSet<Role> Roles => Set<Role>();
        public DbSet<User_Role> User_Roles => Set<User_Role>();*/

        public PageTurnersContext(DbContextOptions<PageTurnersContext> options)
            : base(options)
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PageTurners;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}