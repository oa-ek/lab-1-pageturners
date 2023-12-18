using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PageTurners.Core.Context;
using Microsoft.AspNetCore.Identity;
using PageTurners.Repositories.Repos;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace PageTurners.WebApp.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumTopicRepository _topicRepository;
        private readonly IForumPostRepository _postRepository;

        public ForumController(IForumTopicRepository topicRepository, IForumPostRepository postRepository)
        {
            _topicRepository = topicRepository;
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            var topics = _topicRepository.GetAllTopicsWithPosts();
            return View(topics);
        }

        [HttpGet]
        public IActionResult CreateTopic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTopic(ForumTopic topic)
        {
            if (ModelState.IsValid)
            {
                _topicRepository.AddTopic(topic);
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        // Додати інші методи для перегляду конкретної теми та додавання повідомлень
    }

}
