namespace MyBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public virtual ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
    }
}
