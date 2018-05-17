using System;
using System.Collections.Generic;
using System.Text;
using Webjs.src;

namespace Webjs.Parser.NewsParser
{
    class NewsSettings : ISettings
    {
        public NewsSettings(int start,int end)
        {
            StartPoint = start;
            Endpoint = end;
        } 

        public string ParseURL { get; set; } = "https://news.google.com/gn/news/headlines/section/topic/SCITECH.ru_ru/Наука%20и%20техника?ned=ru_ru&hl=ru&gl=RU";
        public string Prefix { get; set; }
        public int StartPoint { get; set; }
        public int Endpoint { get; set; }
    }
}
