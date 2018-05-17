using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webjs.Models;
using Webjs.Parser.NewsParser;
using Microsoft.EntityFrameworkCore;
namespace Webjs.src
{
    public class UpdateNews : IUpdateNews
    {
        private ModelNewsContext DbContext;
        private IUpdateDB update;
        List<NewsModel> list = new List<NewsModel>();
        bool IsComplited = false;

        public UpdateNews(ModelNewsContext model, IUpdateDB update)
        {
            DbContext = model;

            this.update = update;
        }
        public List<NewsModel> Update()
        {
            Task task = new Task(() =>
            {
                    try
                    {
                        ParserWorker<NewsModel[]> parserWorker1 = new ParserWorker<NewsModel[]>(new LinkParser());
                        parserWorker1.Settings = new NewsSettings(1, 5);
                        parserWorker1.OnNewData += (e, x) =>
                        {
                            foreach (var i in x)
                            {
                                list.Add(i);
                            }
                            IsComplited = true;
                        };
                        parserWorker1.Start();
                    }
                    finally
                    {

                    }
            });
            task.Start();
            while (true)
            {
                if (IsComplited == true)
                {
                    return list;
                }
            }
        }
    }
}
