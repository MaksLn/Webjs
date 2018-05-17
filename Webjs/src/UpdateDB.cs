using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webjs.Models;

namespace Webjs.src
{
    public interface IUpdateDB
    {
        void UpdateDb(List<NewsModel> newsModels);
    }

    public class UpdateDB : IUpdateDB
    {
        ModelNewsContext db;

        public UpdateDB(ModelNewsContext context)
        {
            db = context;
        }

        private static int index=0;
        public void UpdateDb(List<NewsModel> newModels)
        {
            var list = newModels;
           
            try
            {
                db.RemoveRange(db.newsModels);
                db.SaveChanges();
                for(int i=0;i<newModels.Count;i++)
                {
                    try
                    {
                       
                            newModels[i].id = index;
                            db.newsModels.Add(newModels[i]);
                            index++;
                     
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
            try
            {
                db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "   dsfagdfsgdfsgdfsg\n\n\n\n\n\n\n\n");
            }
        }
    }
}
