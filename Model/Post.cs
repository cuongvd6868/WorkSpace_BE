using System.ComponentModel.DataAnnotations;

namespace WorkSpace.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentMarkdown { get; set; }
        public string ContentHtml { get; set; }
        public string ImageData { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        // Navigation property
        public virtual AppUser User { get; set; }
    }
}
