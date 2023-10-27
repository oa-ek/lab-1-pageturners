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
        /*public DbSet<User> Users => Set<User>();*/
        public DbSet<Comments> Comment => Set<Comments>();

        public PageTurnersContext(DbContextOptions<PageTurnersContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUser>();
            modelBuilder.Ignore<IdentityRole>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();*/

            modelBuilder.Entity<Comments>()
            .HasOne(c => c.Сommentator)
            .WithMany(u => u.Comment)
            .HasForeignKey(c => c.CommentatorId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rating>()
            .HasOne(r => r.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rating>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Ratings)
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookRequest>()
            .HasOne(br => br.Owner)
            .WithMany(u => u.BookRequests)
            .HasForeignKey(br => br.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ModeratorReview>()
            .HasOne(mr => mr.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(mr => mr.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ModeratorReview>()
            .HasOne(mr => mr.Moderator)
            .WithMany()
            .HasForeignKey(mr => mr.ModeratorId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}