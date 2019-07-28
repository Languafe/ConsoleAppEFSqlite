using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleApp
{
    class Thing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=app.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }


    class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Thing> Things { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=app.db")
                .Options;

            var dbContext = new AppDbContext(options);

            dbContext.Database.Migrate();

            dbContext.Things.AddRange(new [] {
                new Thing { Title = "Thing" },
            });

            dbContext.SaveChanges();

            var things = dbContext.Things.ToList();
            foreach (var thing in things)
            {
                Console.WriteLine($"Id: {thing.Id}, Title: {thing.Title}");
            }
        }
    }
}