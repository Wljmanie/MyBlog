namespace MyBlog.Services.Interfaces
{
    public interface ISlugService
    {
        string UrlFriendly(string slug);
        string UrlFriendly(string slug, string title);
        bool IsUniquePost(string slug);
        bool IsUniqueBlog(string slug);
    }
}
