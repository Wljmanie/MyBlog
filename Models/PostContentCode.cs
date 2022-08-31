using MyBlog.Enums;

namespace MyBlog.Models
{
    public class PostContentCode
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int ContentIndex { get; set; }
        public PostContentType PostContentType { get; set; }
        public CodeLanguage CodeLanguage { get; set; }      
        //Plugins -> LineNumbers, AutoLinker, CopyToClipBoardButton, MatchBraces, ShowLanguage.
        public string ContentCode { get; set; }

        //Navigation Properties
        public virtual Post Post { get; set; }
    }
}
