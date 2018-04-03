using FirstMvvMAsignment.Models;
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

        public MainMenuViewModel(IListPopulatorService service)
        {
            populatorService = service;
        }

        public void ShowTheMenuPicked(MenuItem item)
        {
            string sItem = JsonConvert.SerializeObject(item);
            Dictionary<string, string> pair = new Dictionary<string, string>()
            {
                { "MenuItem", sItem}
            };

            MvxBundle bundle = new MvxBundle(pair);

            ShowViewModel<MainViewModel>(bundle);
        }

        public void ShowMoreInfo(MenuItem item)
        {
            item.Info = populatorService.GetInformation(item.Title);
            item.MyDrawable = populatorService.GetImage(item.Title);
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

        public override Task Initialize()
        {
            populatorService.Parent = this;

            return base.Initialize();
        }

        public override void Start()
        {
            base.Start();

            MenuItems = new List<MenuItem>
            {
                new MenuItem("Catapult", this) {Description = "Tap for more info" },
                new MenuItem("ASW-G-29 Gundam Astaroth", this) {Description = "Tap for more info" },
                new MenuItem("Dire Wolf", this) {Description = "Tap for more info" },
                new MenuItem("Ebon Jaguar", this) {Description = "Tap for more info" },
                new MenuItem("ASW-G-08 Gundam Barbatos", this) {Description = "Tap for more info" },
                new MenuItem("Juggernaut", this) {Description = "Tap for more info" },
                new MenuItem("Bagger 288", this) {Description = "Tap for more info" }
            };

            //await populatorService.GetMenuItems();
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

        public string Title { get; private set; }
        public List<MenuItem> MenuItems { get; private set; }
    }
}
