using Blog.Areas.Identity.Data;
using Blog.Entities;
using Blog.Interfaces;
using Blog.Models;

namespace Blog.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly BlogDbContext _context;
        public readonly IMapper<BlogPost, BlogPostModel> _blogPostMapper;
        public BlogPostService(BlogDbContext context, IMapper<BlogPost, BlogPostModel> mapper)
        {
            _context = context;
            _blogPostMapper = mapper;
        }

        public List<BlogPostModel> GetAllPosts()
        {
            return _context.BlogPosts.Select(x => _blogPostMapper.MapFromEntityToModel(x)).ToList();
        }

        public BlogPostModel GetBlogPost(int Id)
        {
            var entity = _context.BlogPosts.Find(Id);
            if (entity == null)
            {
                return new BlogPostModel() { };
            }
            return _blogPostMapper.MapFromEntityToModel(entity);
        }

        public BlogPostModel CreateBlogPost(BlogPostModel blogPost)
        {
            var blogPostEntity = _blogPostMapper.MapFromModelToEntity(blogPost);
            blogPostEntity.CreateDate = DateTime.Now;
            _context.BlogPosts.Add(blogPostEntity);
            _context.SaveChanges();
            blogPost = _blogPostMapper.MapFromEntityToModel(blogPostEntity);
            return blogPost;
        }

        public BlogPostModel UpdateBlogPost(BlogPostModel blogPost)
        {
            _context.BlogPosts.Update(_blogPostMapper.MapFromModelToEntity(blogPost));
            _context.SaveChanges();
            return blogPost;
        }

        public void DeleteBlogPost(int Id)
        {
            var post = _context.BlogPosts.Find(Id);
            if (post == null)
            {
                throw new Exception();
            }
            _context.BlogPosts.Remove(post);
            _context.SaveChanges();
        }
    }
}
