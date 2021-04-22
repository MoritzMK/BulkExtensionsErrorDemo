using BulkExtensionsDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkExtensionsDemo
{
    public sealed class Context :  DbContext
    {
        public DbSet<TableA> TableAs { get; private set; }
        public DbSet<TableB> TableBs { get; private set; }
        public DbSet<TableAToTableB> TableAToTableBs { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=BulkExtensionsDemo;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;Max Pool Size=400;Application Name=BulkExtensionsDemo");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
