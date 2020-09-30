using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheGame.Models;

namespace TheGame.Services
{
    public class MockDataStore : IDataStore<Model>
    {
        readonly List<Model> items;

        public MockDataStore()
        {
            items = new List<Model>()
            {
                new Model { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Model { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Model { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Model { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Model { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Model { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Model item)
        {
            items.Add(item);

            return await System.Threading.Tasks.Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Model item)
        {
            var oldItem = items.Where((Model arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await System.Threading.Tasks.Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Model arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await System.Threading.Tasks.Task.FromResult(true);
        }

        public async Task<Model> GetItemAsync(string id)
        {
            return await System.Threading.Tasks.Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Model>> GetItemsAsync(bool forceRefresh = false)
        {
            return await System.Threading.Tasks.Task.FromResult(items);
        }
    }
}