using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using System;
namespace FirstMvvMAsignment
{
    public class Item : MvxViewModel
    {
        public string DNDClass { get; set; }

        ItemsViewModel Parent { get; set; }
        // public string Description { get; set; }

        private string _info;

        public string Description
        {
            get { return _info; }
            set
            {
                _info = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public Item(string dndclass, ItemsViewModel parent)
        {
            Parent = parent;
            DNDClass = dndclass;
            Description = "Tap here for more info.";
            ShowCommand = new MvxCommand<Item>((Item obj) => Parent.ShowTheMenuPick(this));
            ShowMoreInfo = new MvxCommand<Item>((Item obj) => Parent.ShowMoreInfo(this));
        }

        [JsonIgnore]
        public IMvxCommand<Item> ShowCommand { get; set; }

        [JsonIgnore]
        public IMvxCommand<Item> ShowMoreInfo { get; set; }
    }
}
