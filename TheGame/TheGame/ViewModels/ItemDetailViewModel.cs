using System;

using TheGame.Models;

namespace TheGame.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Model Item { get; set; }
        public ItemDetailViewModel(Model item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
