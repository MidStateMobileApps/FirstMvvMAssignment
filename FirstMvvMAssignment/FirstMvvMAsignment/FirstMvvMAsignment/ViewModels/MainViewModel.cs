using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Text;
using Newtonsoft.Json;
using FirstMvvMAsignment.Models;
using FirstMvvMAsignment.Services;

namespace FirstMvvMAsignment.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IListPopulatorService populatorService;
        private string gameList;
        private MenuItem _menuItem;
        private string description;
        private string title;

        public string ClassList
        {
            get
            {
                return gameList;
            }
            set
            {
                gameList = value;
            }
        }

        public MainViewModel(IListPopulatorService service)
        {
            populatorService = service;
        }

        public override Task Initialize()
        {
            var games = populatorService.GetAvailableGames();
            StringBuilder sb = new StringBuilder();
            foreach (string s in games)
            {
                sb.Append($"{s} \n");
            }
            // classes.Select(c => sb.Append($"{c} \n"));
            gameList = sb.ToString();
            return base.Initialize();
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            var item = JsonConvert.DeserializeObject<MenuItem>(parameters.Data["MenuItem"]);
            _menuItem = new MenuItem(item.Title, null)
            {
                Description = item.Description,
                Title = item.Title
            };
            title = _menuItem.Title;
            description = _menuItem.Description;
        }

        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
            Title = "Hello MvvmCross";
        }

        private string _text = "Hello MvvmCross";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}