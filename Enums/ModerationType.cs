using System.ComponentModel;

namespace MyBlog.Enums
{
    public enum ModerationType
    {
        [Description("Political Propaganda")]
        Political,
        [Description("Offensive Language")]
        Language,
        [Description("Drug reference")]
        Drugs,
        [Description("Threatening Speech")]
        Threatening,
        [Description("Sexual Content")]
        Sexual,
        [Description("Hate Speech")]
        HateSpeech,
        [Description("Targeted Shaming")]
        Shaming,
        [Description("Religious Propaganda")]
        Religion
    }
}
