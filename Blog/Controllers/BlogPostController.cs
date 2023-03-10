using Blog.Areas.Identity.Data;
using Blog.Entities;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Blog.Controllers
{
    public class BlogPostController : Controller
    {
        public readonly IBlogPostService _blogPostService;
        public readonly UserManager<BlogUser> _userManager;
        public BlogPostController(IBlogPostService blogPostService, UserManager<BlogUser> userManager)
        {
            _blogPostService = blogPostService;
            _userManager = userManager;
        }

        //GET all posts
        [HttpGet("[controller]/Index")]
        public IActionResult Index()
        {
            var model = _blogPostService.GetAllPosts().OrderByDescending(r => r.CreateDate);
            return View(model);
        }
        //GET by Id
        [HttpGet("BlogPost/{Id}")]
        public IActionResult GetBlogPost(int Id)
        {
            BlogPostModel model = _blogPostService.GetBlogPost(Id);
            return View(model);
        }

        //Create GET
        [HttpGet("CreateBlogPost")]
        [Authorize]
        public IActionResult CreateBlogPost()
        {
            return View();
        }

        //Create POST
        [HttpPost("CreateBlogPost")]
        [Authorize]
        public IActionResult CreateBlogPost(BlogPostModel blogPost)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                blogPost.UserId = userId;
                _blogPostService.CreateBlogPost(blogPost);
                return RedirectToAction("Index");
            }
            return View(blogPost);
            
        }

        //Update GET
        [HttpGet("UpdateBlogPost")]
        [Authorize]
        public IActionResult UpdateBlogPost(int? Id)
        {
            if (Id is null || Id == 0)
            {
                return NotFound();
            }
            var blogPost = _blogPostService.GetBlogPost((int)Id);
            if (blogPost is null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        //Update POST
        [HttpPost("UpdateBlogPost")]
        [Authorize]
        public IActionResult UpdateBlogPost(BlogPostModel blogPost)
        {
            if (blogPost.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                _blogPostService.UpdateBlogPost(blogPost);
                return RedirectToAction("Index");
            }
            return View(blogPost);
            
        }

        // Delete GET
        [HttpGet("DeleteBlogPost")]
        [Authorize]
        public IActionResult DeleteBlogPost(int? Id)
        {
            if (Id is null || Id == 0)
            {
                return NotFound();
            }
            var blogPost = _blogPostService.GetBlogPost((int)Id);
            if (blogPost is null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        // Delete POST
        [HttpPost("DeleteBlogPost")]
        [Authorize]
        public IActionResult Delete(int Id)
        {
            var blogPost = _blogPostService.GetBlogPost(Id);
            if (blogPost.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return RedirectToAction("Index");
            }
            _blogPostService.DeleteBlogPost(Id);
            return RedirectToAction("Index");
        }

    }
}
