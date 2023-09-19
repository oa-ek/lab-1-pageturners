using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PageTurners.Core.Context
{
    public class PageTurnersContext : IdentityDbContext
    {
        public PageTurnersContext(DbContextOptions<PageTurnersContext> options)
            : base(options)
        {
        }
    }
}