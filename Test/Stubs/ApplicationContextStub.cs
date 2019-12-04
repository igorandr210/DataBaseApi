using System.Collections.Generic;
using DataBaseApi;
using DataBaseApi.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
namespace Test.Stubs
{
    public class ApplicationContextStub
    {
        public static ApplicationContext InitStub()
        {
            var connection = new SqliteConnection("DataSource=:memory:");

            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlite(connection)
                .Options;
            var context = new ApplicationContext(options);

            context.Items.AddRange(new List<ItemModel>()
            {
                new ItemModel()
                {
                    Id=1,
                    Description = "Item1 - best!",
                    InStock = 3,
                    Price = 1000.0,
                    Title = "Item1"
                },
                new ItemModel()
                {
                    Id=2,
                    Description = "Item2 - best!",
                    InStock = 3,
                    Price = 2000.0,
                    Title = "Item2"
                },
                new ItemModel()
                {
                    Id=3,
                    Description = "Item3 - best!",
                    InStock = 3,
                    Price = 3000.0,
                    Title = "Item3"
                },
                new ItemModel()
                {
                    Id=4,
                    Description = "Item4 - best!",
                    InStock = 4,
                    Price = 4000.0,
                    Title = "Item4"
                },new ItemModel()
                {
                    Id=5,
                    Description = "Item5 - best!",
                    InStock = 5,
                    Price = 5000.0,
                    Title = "Item5"
                }
            });

            context.SaveChanges();

            return context;
        }
    }
}
