using MyBlog.Enums;

namespace MyBlog.Models
{
    public class PostContentText
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int ContentIndex { get; set; }
        public PostContentType PostContentType { get; set; }
        public string ContentText { get; set; }

        //Navigation Properties
        public virtual Post Post { get; set; }
    }
}
