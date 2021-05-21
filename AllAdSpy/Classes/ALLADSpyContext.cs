using AllAdSpy.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace AllAdSpy.Classes
{
    class ALLADSpyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlite(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);

        public DbSet<Account> Accounts { get; set; }

        public ALLADSpyContext()
        {
        }

        public ALLADSpyContext(DbContextOptions s)
        : base(s)
        {
        }
    }
}
