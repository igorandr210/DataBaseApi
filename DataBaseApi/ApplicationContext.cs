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

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            var isCreated=this.Database.EnsureCreated();
            if (!isCreated)
            {
                Database.Migrate();
            }
        }

        public async Task<bool> UpdateItem(ItemModel item)
        {
            var itemInDb = await Items.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (itemInDb != null)
            {
                itemInDb.Title = item.Title ;
                itemInDb.Description = item.Description ;
                itemInDb.InStock = item.InStock ;
                itemInDb.Price = item.Price;

                Entry(itemInDb).State = EntityState.Modified;

                Items.Update(itemInDb);
            }

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

        public async Task<bool> DeleteItem(int id)
        {
            var item = await Items.FirstOrDefaultAsync(x => x.Id == id);

            if(item!=null)
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
