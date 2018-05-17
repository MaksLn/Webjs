using AngleSharp.Dom.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webjs.src
{
    interface IParser<T> where T : class
    {
        T Parser(IHtmlDocument htmlDocument);
    }
}
