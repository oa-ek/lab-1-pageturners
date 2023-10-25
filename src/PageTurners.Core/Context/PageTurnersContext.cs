using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PageTurners.Core.Entities;

namespace PageTurners.Core.Context
{
    public class PageTurnersContext : IdentityDbContext<User>
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<BookRequest> Requests => Set<BookRequest>();
        public DbSet<ModeratorReview> Reviews => Set<ModeratorReview>();
        public DbSet<Rating> Ratings => Set<Rating>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Comments> Comment => Set<Comments>();

        public PageTurnersContext(DbContextOptions<PageTurnersContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            // Вимкнути автоматичну генерацію таблиць Identity
            modelBuilder.Ignore<IdentityUser>();
            modelBuilder.Ignore<IdentityRole>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();

        }
    }
}