using Blog.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Text { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
