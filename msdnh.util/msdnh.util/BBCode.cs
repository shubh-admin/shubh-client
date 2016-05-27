using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace msdnh.util
{
    /// <summary>
    ///     Allows Formatting of Text for HTMLs
    /// </summary>
    public class BbCode
    {
        #region Format

        public static string Format(string data)
        {
            return Formatters.Aggregate(data, (current, formatter) => formatter.Format(current));
        }

        #endregion

        #region BBCODE Class

        private interface IHtmlFormatter
        {
            string Format(string data);
        }

        protected class RegexFormatter : IHtmlFormatter
        {
            private readonly Regex _regex;
            private readonly string _replace;

            public RegexFormatter(string pattern, string replace)
                : this(pattern, replace, true)
            {
            }

            public RegexFormatter(string pattern, string replace, bool ignoreCase)
            {
                var options = RegexOptions.Compiled;

                if (ignoreCase)
                {
                    options |= RegexOptions.IgnoreCase;
                }

                _replace = replace;
                _regex = new Regex(pattern, options);
            }

            public string Format(string data)
            {
                return _regex.Replace(data, _replace);
            }
        }

        protected class SearchReplaceFormatter : IHtmlFormatter
        {
            private readonly string _pattern;
            private readonly string _replace;

            public SearchReplaceFormatter(string pattern, string replace)
            {
                _pattern = pattern;
                _replace = replace;
            }

            public string Format(string data)
            {
                return data.Replace(_pattern, _replace);
            }
        }

        #endregion

        #region BBCode

        private static readonly List<IHtmlFormatter> Formatters;

        static BbCode()
        {
            Formatters = new List<IHtmlFormatter>
            {
                new RegexFormatter(@"<(.|\n)*?>", string.Empty),
                new SearchReplaceFormatter("\r", ""),
                new SearchReplaceFormatter("\n\n", "</p><p>"),
                new SearchReplaceFormatter("\n", "<br />"),
                new RegexFormatter(@"\[b(?:\s*)\]((.|\n)*?)\[/b(?:\s*)\]", "<b>$1</b>"),
                new RegexFormatter(@"\[i(?:\s*)\]((.|\n)*?)\[/i(?:\s*)\]", "<i>$1</i>"),
                new RegexFormatter(@"\[s(?:\s*)\]((.|\n)*?)\[/s(?:\s*)\]", "<strike>$1</strike>"),
                new RegexFormatter(@"\[left(?:\s*)\]((.|\n)*?)\[/left(?:\s*)]",
                    "<div style=\"text-align:left\">$1</div>"),
                new RegexFormatter(@"\[center(?:\s*)\]((.|\n)*?)\[/center(?:\s*)]",
                    "<div style=\"text-align:center\">$1</div>"),
                new RegexFormatter(@"\[right(?:\s*)\]((.|\n)*?)\[/right(?:\s*)]",
                    "<div style=\"text-align:right\">$1</div>")
            };





            var quoteStart = "<blockquote><b>$1 said:</b></p><p>";
            var quoteEmptyStart = "<blockquote>";
            var quoteEnd = "</blockquote>";

            Formatters.Add(new RegexFormatter(@"\[quote=((.|\n)*?)(?:\s*)\]", quoteStart));
            Formatters.Add(new RegexFormatter(@"\[quote(?:\s*)\]", quoteEmptyStart));
            Formatters.Add(new RegexFormatter(@"\[/quote(?:\s*)\]", quoteEnd));

            Formatters.Add(new RegexFormatter(@"\[url(?:\s*)\]www\.(.*?)\[/url(?:\s*)\]",
                "<a class=\"bbcode-link\" href=\"http://www.$1\" target=\"_blank\" title=\"$1\">$1</a>"));
            Formatters.Add(new RegexFormatter(@"\[url(?:\s*)\]((.|\n)*?)\[/url(?:\s*)\]",
                "<a class=\"bbcode-link\" href=\"$1\" target=\"_blank\" title=\"$1\">$1</a>"));
            Formatters.Add(new RegexFormatter(@"\[url=""((.|\n)*?)(?:\s*)""\]((.|\n)*?)\[/url(?:\s*)\]",
                "<a class=\"bbcode-link\" href=\"$1\" target=\"_blank\" title=\"$1\">$3</a>"));
            Formatters.Add(new RegexFormatter(@"\[url=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/url(?:\s*)\]",
                "<a class=\"bbcode-link\" href=\"$1\" target=\"_blank\" title=\"$1\">$3</a>"));
            Formatters.Add(new RegexFormatter(@"\[link(?:\s*)\]((.|\n)*?)\[/link(?:\s*)\]",
                "<a class=\"bbcode-link\" href=\"$1\" target=\"_blank\" title=\"$1\">$1</a>"));
            Formatters.Add(new RegexFormatter(@"\[link=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/link(?:\s*)\]",
                "<a class=\"bbcode-link\" href=\"$1\" target=\"_blank\" title=\"$1\">$3</a>"));

            Formatters.Add(new RegexFormatter(@"\[img(?:\s*)\]((.|\n)*?)\[/img(?:\s*)\]",
                "<img src=\"$1\" border=\"0\" alt=\"\" />"));
            Formatters.Add(new RegexFormatter(@"\[img align=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/img(?:\s*)\]",
                "<img src=\"$3\" border=\"0\" align=\"$1\" alt=\"\" />"));
            Formatters.Add(new RegexFormatter(@"\[img=((.|\n)*?)x((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/img(?:\s*)\]",
                "<img width=\"$1\" height=\"$3\" src=\"$5\" border=\"0\" alt=\"\" />"));

            Formatters.Add(new RegexFormatter(@"\[color=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/color(?:\s*)\]",
                "<span style=\"color=$1;\">$3</span>"));

            Formatters.Add(new RegexFormatter(@"\[hr(?:\s*)\]", "<hr />"));

            Formatters.Add(new RegexFormatter(@"\[email(?:\s*)\]((.|\n)*?)\[/email(?:\s*)\]",
                "<a href=\"mailto:$1\">$1</a>"));

            Formatters.Add(new RegexFormatter(@"\[size=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/size(?:\s*)\]",
                "<span style=\"font-size:$1\">$3</span>"));
            Formatters.Add(new RegexFormatter(@"\[font=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/font(?:\s*)\]",
                "<span style=\"font-family:$1;\">$3</span>"));
            Formatters.Add(new RegexFormatter(@"\[align=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/align(?:\s*)\]",
                "<span style=\"text-align:$1;\">$3</span>"));
            Formatters.Add(new RegexFormatter(@"\[float=((.|\n)*?)(?:\s*)\]((.|\n)*?)\[/float(?:\s*)\]",
                "<span style=\"float:$1;\">$3</div>"));

            var sListFormat = "<ol class=\"bbcode-list\" style=\"list-style:{0};\">$1</ol>";

            Formatters.Add(new RegexFormatter(@"\[\*(?:\s*)]\s*([^\[]*)", "<li>$1</li>"));
            Formatters.Add(new RegexFormatter(@"\[list(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]",
                "<ul class=\"bbcode-list\">$1</ul>"));
            Formatters.Add(new RegexFormatter(@"\[list=1(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]",
                string.Format(sListFormat, "decimal"), false));
            Formatters.Add(new RegexFormatter(@"\[list=i(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]",
                string.Format(sListFormat, "lower-roman"), false));
            Formatters.Add(new RegexFormatter(@"\[list=I(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]",
                string.Format(sListFormat, "upper-roman"), false));
            Formatters.Add(new RegexFormatter(@"\[list=a(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]",
                string.Format(sListFormat, "lower-alpha"), false));
            Formatters.Add(new RegexFormatter(@"\[list=A(?:\s*)\]((.|\n)*?)\[/list(?:\s*)\]",
                string.Format(sListFormat, "upper-alpha"), false));
        }

        #endregion
    }
}