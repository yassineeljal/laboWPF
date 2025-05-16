using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using IdeaManager.Data.Db;

namespace IdeaManager.Data
{
    //https://stackoverflow.com/a/72415994
    public class BloggingContextFactory : IDesignTimeDbContextFactory<IdeaDbContext>
    {
        public IdeaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdeaDbContext>();
            optionsBuilder.UseSqlite("Data Source=idea.db");

            return new IdeaDbContext(optionsBuilder.Options);
        }
    }
}
