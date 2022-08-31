using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public class PostTag
    {     
        public int PostId { get; set; }
        public int TagId { get; set; }

        //Navigation Properties
        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
