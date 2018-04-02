using MvvmCross.Core.ViewModels;
using FirstMvvMAsignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FirstMvvMAsignment.Models;

namespace FirstMvvMAsignment.ViewModels
{
    public class MainMenuViewModel : MvxViewModel
    {
        IListPopulatorService _populatorService;

        public MainMenuViewModel(IListPopulatorService service)
        {
            _populatorService = service;
        }

        public override Task Initialize()
        {
            _populatorService.Parent = this;
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
            item.Info = _populatorService.GetGoodBoyInformation(item.Title);
            item.MyDrawable = _populatorService.GetGoodBoyImage(item.Title);
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

        public override void Start()
        {
            base.Start();
            MenuItems = new List<MenuItem>()
            {
                new MenuItem("Air Bud", this) {Description = "Tap for more information."},
                new MenuItem("Lassie", this) {Description = "Tap for more information."},
                new MenuItem("Rin Tin Tin", this) {Description = "Tap for more information."},
                new MenuItem("Wishbone", this) {Description = "Tap for more information."}
            };
        }
        public string Title { get; private set; }
        public List<MenuItem> MenuItems { get; private set; }

        public IMvxAsyncCommand ShowCommand { get; set; }
    }
}