using PageTurners.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.Interfaces
{
    public interface IForumPostRepository
    {
        void AddPost(ForumPost post);
       
    }
}
