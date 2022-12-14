using MyBlog.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? AuthorId { get; set; }
        public BlogStatus BlogStatus { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required]
        [StringLength(1024, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime? Created { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ContentType { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

        //Navigation Properties
        public virtual BlogUser? Author { get; set; }
        public virtual ICollection<Post>? Posts { get; set; } = new HashSet<Post>();
    }
}
