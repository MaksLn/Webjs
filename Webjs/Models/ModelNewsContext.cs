using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webjs.Models
{
    public class ModelNewsContext:DbContext
    {
        public DbSet<NewsModel> newsModels { get; set; }

        public ModelNewsContext(DbContextOptions<ModelNewsContext> dbContext) : base(dbContext)
        {
           
        }
    }
}
