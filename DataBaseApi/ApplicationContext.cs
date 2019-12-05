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

        public async Task<bool> UpdateItem(ItemModel item)
        {
            Items.Update(item);
            return (await this.SaveChangesAsync()>0);
        }

        public async Task<bool> AddItem(ItemModel item)
        {
            Items.Add(item);
            return (await this.SaveChangesAsync() > 0);
        }

        public async Task<bool> DeleteItem(ItemModel item)
        {
            Items.Remove(item);
            return (await this.SaveChangesAsync() > 0);
        }

        public IEnumerable<ItemModel> GetAllItems()
        {
            return Items;
        }

        public async Task<ItemModel> GetItem(int Id)
        {
            return await Items.FirstOrDefaultAsync(x=>x.Id==Id);
        }
    }
}
