using Blog.Areas.Identity.Data;

namespace Blog.Models
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
