using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TheGame.Models;
using TheGame.Views;

namespace TheGame.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Model> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Model>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Model>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Model;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async System.Threading.Tasks.Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}