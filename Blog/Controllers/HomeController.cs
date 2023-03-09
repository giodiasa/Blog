using Blog.Interfaces;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostService _blogPostService;

        public HomeController(ILogger<HomeController> logger, IBlogPostService blogPostService)
        {
            _logger = logger;
            _blogPostService = blogPostService;
        }

        public IActionResult Index()
        {
            var model = _blogPostService.GetAllPosts().OrderByDescending(r => r.CreateDate).ToList();
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}