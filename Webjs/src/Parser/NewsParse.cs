using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp.Dom.Html;
using System.Linq;
using Webjs.src;

namespace Webjs.Parser.NewsParser
{
    class NewsParse : IParser<string[]>
    {
        public string[] Parser(IHtmlDocument htmlDocument)
        {
           
            var list = new List<string>();
            var items = htmlDocument.QuerySelectorAll("a").Where(item => item.ClassName != null &&
            item.GetAttribute("aria-level") == 2.ToString() &&
                item.GetAttribute("aria-level") != null &&
            item.ClassName.Contains("nuEeue hzdq5d ME7ew"));
            
            foreach (var i in items)
            {
                list.Add(i.TextContent);
            }

            return list.ToArray();
        }
    }
}
