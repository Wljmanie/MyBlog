using MyBlog.Data;
using MyBlog.Services.Interfaces;
using System.Text;

namespace MyBlog.Services
{
    public class SlugService : ISlugService
    {
        private readonly ApplicationDbContext _dbContext;

        public SlugService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsUniqueBlog(string slug)
        {
            return !_dbContext.Blogs.Any(b => b.Slug == slug);
        }

        public bool IsUniquePost(string slug)
        {
            return !_dbContext.Posts.Any(p => p.Slug == slug);
        }

        public string UrlFriendly(string slug, string title)
        {
            if (slug == null || slug == "")
            {
                return UrlFriendly(title);
            }
            else
            {
                return UrlFriendly(slug);
            }
        }

        public string UrlFriendly(string slug)
        {
            if (slug == null || slug == "") return "";
            
            const int maxLen = 100;
            bool prevdash = false;
            var sb = new StringBuilder(slug.Length);
            char c;

            for (int i = 0; i < slug.Length; i++)
            {
                c = slug[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                        c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if (c == '#')
                {
                    if (i > 0)
                        if (slug[i - 1] == 'C' || slug[i - 1] == 'F')
                            sb.Append("-sharp");
                }
                else if (c == '+')
                {
                    sb.Append("-plus");
                }
                else if ((int)c >= 128)
                {
                    int prevlen = sb.Length;
                    sb.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length) prevdash = false;
                }
                if (sb.Length == maxLen) break;
            }
            if (prevdash)
                return sb.ToString().Substring(0, sb.Length - 1);
            else
                return sb.ToString();
        }

        private string RemapInternationalCharToAscii(char c)
        {
            string s = c.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(s)) 
                return "a";
            else if ("èéêëę".Contains(s)) 
                return "e";
            else if ("ìíîïı".Contains(s)) 
                return "i";          
            else if ("òóôõöøőð".Contains(s)) 
                return "o";           
            else if ("ùúûüŭů".Contains(s)) 
                return "u";
            else if ("çćčĉ".Contains(s)) 
                return "c";         
            else if ("żźž".Contains(s)) 
                return "z";          
            else if ("śşšŝ".Contains(s)) 
                return "s";       
            else if ("ñń".Contains(s)) 
                return "n";           
            else if ("ýÿ".Contains(s)) 
                return "y";            
            else if ("ğĝ".Contains(s)) 
                return "g";           
            else if (c == 'ř') 
                return "r";           
            else if (c == 'ł') 
                return "l";           
            else if (c == 'đ') 
                return "d";            
            else if (c == 'ß') 
                return "ss";            
            else if (c == 'Þ') 
                return "th";            
            else if (c == 'ĥ') 
                return "h";          
            else if (c == 'ĵ') 
                return "j";           
            else if (c == 'æ') 
                return "ae";
            else 
                return "";           
        }
    }
}
