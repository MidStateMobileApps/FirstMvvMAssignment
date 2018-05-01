using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using FirstMvvMAsignment.Model;
using FirstMvvMAsignment.Services;
using System.Text;
using Newtonsoft.Json;

namespace FirstMvvMAsignment.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private iListPopulatorService populatorService;
        private string classList;
        private MenuItem _menuItem;
        private string description;
        private string title;

        public string ClassList
        {
            get
            {
                return classList;
            }
            set
            {
                classList = value;
            }
        }

        public MainViewModel(iListPopulatorService service)
        {
            populatorService = service;
        }

        public override Task Initialize()
        {
            var classes = populatorService.GetAvailableCourses();
            StringBuilder sb = new StringBuilder();
            foreach (string s in classes)
            {
                sb.Append($"{s} \n");
            }

            classList = sb.ToString();
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