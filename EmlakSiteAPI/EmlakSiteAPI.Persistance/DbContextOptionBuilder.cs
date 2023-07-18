using EmlakSiteAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakSiteAPI.Persistance
{
    public class DbContextOptionBuilder : IDesignTimeDbContextFactory<EmlakSiteDbContext>
    {
        public EmlakSiteDbContext CreateDbContext(string[] args)
        {
            //DbContextOptionsbuilder sayesinde context e konfirigasyon yapıyor
            DbContextOptionsBuilder<EmlakSiteDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5728;Database=EmlakDb;");
            //dbContextOptionsBuilder.UseSqlServer("server=GGHQ-BT059;database=emlakSiteDb;integrated security=true");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
