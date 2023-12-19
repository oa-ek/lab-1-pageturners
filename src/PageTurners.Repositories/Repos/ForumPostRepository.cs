using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using System;
using PageTurners.Core.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.Repos
{
    public class ForumPostRepository : IForumPostRepository
    {
        private readonly PageTurnersContext _context;

        public ForumPostRepository(PageTurnersContext context)
        {
            _context = context;
        }

        public void AddPost(ForumPost post)
        {
            _context.ForumPosts.Add(post);
            _context.SaveChanges();
        }

       
    }
}
