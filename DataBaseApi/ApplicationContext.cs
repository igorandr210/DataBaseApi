using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseApi
{
    public class ApplicationContext:DbContext
    {
        public DbSet<ItemModel> Items { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
