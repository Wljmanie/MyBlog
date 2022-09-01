using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public class BlogUser : IdentityUser
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
        public string? TwitterUrl { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ContentType { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        //Navigation Properties
        public virtual ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
