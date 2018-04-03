using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvvMAsignment
{
    public class ItemsViewModel : MvxViewModel
    {
        /// <summary>
        /// The private service field.
        /// </summary>
        private IService _service;

        /// <summary>
        /// Initializes a new instance of the ItemsViewModel class.
        /// </summary>
        /// <param name="service">The service for the view model.</param>
        public ItemsViewModel(IService service)
        {
            _service = service;
            _service.Parent = this;
        }
        public override Task Initialize()
        {
            _service.Parent = this;
            return base.Initialize();
        }

        /// <summary>
        /// Show the item that was picked.
        /// </summary>
        /// <param name="item">Thje item to show on screen.</param>
        public void ShowTheMenuPick(Item item)
        {
            string sItem = JsonConvert.SerializeObject(item);
            Dictionary<string, string> pair = new Dictionary<string, string>()
            {
                {"Item", sItem }
            };
            MvxBundle bundle = new MvxBundle(pair);
        }

        /// <summary>
        /// The method to show more information on the selected item.
        /// </summary>
        /// <param name="item">The item to show more info on.</param>
        public void ShowMoreInfo(Item item)
        {
            item.Description = _service.GetDescription(item.DNDClass);
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

        public async override void Start()
        {
            base.Start();
            Items = new List<Item>()
            { new Item("Barbarian", this) {Description="Tap for more info"},
           new Item("Bard", this) {Description="Tap for more info"},
            new Item("Druid", this) {Description="Tap for more info"},
            new Item("Monk", this) {Description="Tap for more info"},
            new Item("Paladin", this) {Description="Tap for more info" },
            new Item("Ranger", this) {Description="Tap for more info" },
            new Item("Sorcerer", this) {Description="Tap for more info" },
            new Item("Warlock", this) {Description="Tap for more info" }};
            InvokeOnMainThread(() => RaiseAllPropertiesChanged());
        }

        public string Class { get; private set; }
        public List<Item> Items { get; private set; }
        public IMvxAsyncCommand ShowCommand { get; set; }
    }
}
