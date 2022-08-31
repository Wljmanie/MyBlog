using MyBlog.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public class PostContentImage
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int ContentIndex { get; set; }
        public PostContentType PostContentType { get; set; }
        public string Description { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ContentType { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

        //Navigation Properties
        public virtual Post Post { get; set; }
    }
}
