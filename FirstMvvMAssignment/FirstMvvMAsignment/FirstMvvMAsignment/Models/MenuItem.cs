using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MvvmCross.Core.ViewModels;
using FirstMvvMAsignment.ViewModels;

namespace FirstMvvMAsignment.Models
{
    public class MenuItem : MvxViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        private string _info;
        
        public string Info
        {
            get { return _info; }
            set { SetProperty(ref _info, value); }
        }

        MainMenuViewModel Parent { get; set; }

        public MenuItem(string title, MainMenuViewModel parent)
        {
            Title = title;
            Parent = parent;
            Info = "Tap here for more info";
            ShowCommand = new MvxCommand<MenuItem>((MenuItem obj) => parent.ShowTheMenuPick(this));
            ShowMoreInfo = new MvxCommand<MenuItem>((MenuItem obj) => parent.ShowMoreInfo(this));
        }

        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowCommand { get; set; }

        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowMoreInfo { get; set; }
    }
}
