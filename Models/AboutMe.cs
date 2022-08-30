using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public class AboutMe
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string? Description { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ContentType { get; set; }
        public bool Active { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        //Navigation Properties
        public virtual BlogUser Author { get; set; }
    }
}
