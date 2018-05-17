using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webjs.Models;

namespace Webjs.src
{
    public interface IUpdateNews
    {
        List<NewsModel> Update();
    }
}
