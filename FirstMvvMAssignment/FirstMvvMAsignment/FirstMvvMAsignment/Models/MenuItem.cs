﻿using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstMvvMAsignment.ViewModels;
using Newtonsoft.Json;

namespace FirstMvvMAsignment.Models
{
    public class MenuItem : MvxViewModel
    {
        public string Title { get; set; }
        MainMenuViewModel Parent { get; set; }
        public string Description { get; set; }
        private string _info;
        public string Info
        {
            get { return _info; }
            set { SetProperty(ref _info, value); }
        }

        private string _myDrawable;
        public string MyDrawable
        {
            get { return _myDrawable; }
            set
            {
                RaisePropertyChanged(() => MyDrawable);
            }
        }

        public MenuItem(string title, MainMenuViewModel parent)
        {
            Parent = parent;
            Title = title;
            Info = "Tap here for more information.";
            ShowCommand = new MvxCommand<MenuItem>((MenuItem obj) => parent.ShowTheMenuPick(this));
            ShowMoreInfo = new MvxCommand<MenuItem>((MenuItem obj) => parent.ShowMoreInfo(this));
            _myDrawable = "placeholder";
        }
        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowCommand { get; set; }

        [JsonIgnore]
        public IMvxCommand<MenuItem> ShowMoreInfo { get; set; }
    }
}
