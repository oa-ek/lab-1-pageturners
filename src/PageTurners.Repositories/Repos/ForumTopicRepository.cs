using PageTurners.Core.Context;
using Microsoft.EntityFrameworkCore;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.Repos
{
    public class ForumTopicRepository : IForumTopicRepository
    {
        private readonly PageTurnersContext _context;

        public ForumTopicRepository(PageTurnersContext context)
        {
            _context = context;
        }

        public IEnumerable<ForumTopic> GetAllTopicsWithPosts()
        {
            return _context.ForumTopics.Include(t => t.Posts).ToList();
        }

        public void AddTopic(ForumTopic topic)
        {
            _context.ForumTopics.Add(topic);
            _context.SaveChanges();
        }

        // Додаткові методи репозиторія за потреби
    }
}
