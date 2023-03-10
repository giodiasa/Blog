using Blog.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Text { get; set; } = string.Empty;
        public BlogUser User { get; set; } = null!;
        public string? UserId { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
