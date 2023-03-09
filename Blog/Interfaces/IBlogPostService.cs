using Blog.Models;

namespace Blog.Interfaces
{
    public interface IBlogPostService
    {
        List<BlogPostModel> GetAllPosts();
        BlogPostModel GetBlogPost(int Id);
        BlogPostModel CreateBlogPost(BlogPostModel blogPost);
        BlogPostModel UpdateBlogPost(BlogPostModel blogPost);
        void DeleteBlogPost(int Id);
    }
}
