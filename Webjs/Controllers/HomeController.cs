using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webjs.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Webjs.Controllers
{
    public class HomeController : Controller
    {
        private ModelNewsContext Db;
        private src.IUpdateNews update;
        private src.IUpdateDB updateDB;
        private static DateTime LastUpdate=DateTime.Now;

        public HomeController(ModelNewsContext DbContext, src.IUpdateNews updateNews, src.IUpdateDB dB)
        {
            update = updateNews;
            Db = DbContext;
            updateDB = dB;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            try
            {
                return View(await Db.newsModels.OrderBy(e => e.id).ToListAsync());
            }
            catch
            {
                List<NewsModel> news = new List<NewsModel>();
                news.Add(new NewsModel() { Url = "fdsa", TimeOf = DateTime.Now, Header = "fsd" });
                return View(news);
            }
        }

        [HttpGet]
        public string Update()
        {
            if (LastUpdate.Minute <= DateTime.Now.Minute - 1&&LastUpdate.Hour==DateTime.Now.Hour)
            {
                LastUpdate = DateTime.Now;
                updateDB.UpdateDb(update.Update());
                return "Get last news";
            }
            else if(LastUpdate.Hour != DateTime.Now.Hour)
            {
                LastUpdate = DateTime.Now;
                updateDB.UpdateDb(update.Update());
                return "Get last news";
            }

            return "";
        }
    }
}