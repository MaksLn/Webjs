using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngleSharp.Dom.Html;
using Webjs.Models;
using Webjs.src;

namespace Webjs.Parser.NewsParser
{
    class LinkParser : IParser<NewsModel[]>
    {
        public NewsModel[] Parser(IHtmlDocument htmlDocument)
        {
            var items1 = new List<string>();
            var list = new List<NewsModel>();
            try
            {
                items1 = htmlDocument.QuerySelectorAll("a").Where(item => item.ClassName != null &&
                item.Attributes["href"].Value != null &&
                item.GetAttribute("aria-level") ==2.ToString()&&
                item.GetAttribute("aria-level") !=null&&
                item.ClassName.Contains("nuEeue hzdq5d ME7ew")).Select(item => item.Attributes["href"].Value).ToList();

             
            }
            catch
            {
                Console.WriteLine("error");
            }

            foreach (var i in items1)
            {
                list.Add(new NewsModel() { Url = i, TimeOf = DateTime.Now, Header = "fasd" });
            }

            var items = htmlDocument.QuerySelectorAll("a").Where(item => item.ClassName != null &&
            item.GetAttribute("aria-level") == 2.ToString() &&
                item.GetAttribute("aria-level") != null &&
            item.ClassName.Contains("nuEeue hzdq5d ME7ew"));

           
            int j = 0;
            foreach (var i in items)
            {
                list[j].Header=i.TextContent;
                j++;
            }

            var itemsFoImage = htmlDocument.QuerySelectorAll("img").Where(item => item.ClassName != null &&
                item.ClassName.Contains("lmFAjc")).Select(item => item.Attributes["src"].Value).ToList();

            j = 0;
            foreach (var i in itemsFoImage)
            {
                list[j].Text = i;
                j++;
            }

            return list.ToArray();
        }
    }
}
