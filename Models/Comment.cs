using Microsoft.AspNetCore.Identity;
using MyBlog.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int? CommentId { get; set; }
        public string? AuthorId { get; set; }
        public string? ModeratorId { get; set; }
        [Required]
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Message { get; set; }
        [Required]
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string? ModeratedMessage { get; set; }
        public ModerationType ModerationType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Update { get; set; }
        public DateTime? Moderated { get; set; }
        public DateTime? Deleted { get; set; }

        //Navigation Properties
        public virtual Post Post {get;set;}
        public virtual BlogUser? Author { get; set; }
        public virtual BlogUser? Moderator { get; set; }
    }
}
