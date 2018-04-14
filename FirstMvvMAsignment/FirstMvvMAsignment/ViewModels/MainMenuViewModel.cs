﻿using FirstMvvMAsignment.Model;
using FirstMvvMAsignment.Services;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvvMAsignment.ViewModels
{
    public class MainMenuViewModel : MvxViewModel
    {
        IListPopulatorService populatorService;
        public string Title { get; private set; }
        public List<MenuItem> MenuItems { get; private set; }

        public MainMenuViewModel(IListPopulatorService service)
        {
            populatorService = service;
        }

        public override Task Initialize()
        {
            populatorService.Parent = this;

            return base.Initialize();
        }

        public void ShowTheMenuPick(MenuItem item)
        {
            string sItem = JsonConvert.SerializeObject(item);
            Dictionary<string, string> pair = new Dictionary<string, string>()
            {
                {"MenuItem", sItem }
            };
            MvxBundle bundle = new MvxBundle(pair);
            ShowViewModel<MainViewModel>(bundle);
        }

        public void ShowMoreInfo(MenuItem item)
        {
            item.Info = populatorService.GetInformation(item.Title);
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

        public async override void Start()
        {
            base.Start();
            MenuItems = new List<MenuItem>()
            {
                new MenuItem("Pandemic", this) {Description="Tap for more info"},
                new MenuItem("SW: Imperial Assult", this) {Description="Tap for more info"},
                new MenuItem("Five Tribes", this) {Description="Tap for more info"},
                new MenuItem("Game of Thrones", this) {Description="Tap for more info"}
            };
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

    }
}