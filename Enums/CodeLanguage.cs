using System.ComponentModel;

namespace MyBlog.Enums
{
    public enum CodeLanguage
    {
        [Description("HTML")]
        html,
        [Description("CSS")]
        css,
        [Description("C#")]
        csharp,
        [Description("JavaScript")]
        javascript,
        [Description("SQL")]
        sql,
        [Description("Markdown")]
        markdown,
        [Description("Razor C#")]
        cshtml,
        [Description("PowerShell")]
        powershell
    }
}
