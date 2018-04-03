using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;

namespace FirstMvvMAsignment
{
    public class MainViewModel : MvxViewModel
    {
        private IService _service;
        private string _class;
        private string _description;
        private Item _item;

        public MainViewModel(IService service)
        {
            _service = service;
        }
        
        public override Task Initialize()
        {
            //TODO: Add starting logic here
		    
            return base.Initialize();
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            var item = JsonConvert.DeserializeObject<Item>(parameters.Data["Item"]);
            _item = new Item(item.DNDClass, null)
            {
                Description = item.Description,
                DNDClass = item.DNDClass
            };
            _class = _item.DNDClass;
            _description = _item.Description;

        }

        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
            Text = "DnD Classes";
        }

        private string _text = "DnD Classes";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public string DNDClass
        {
            get { return _class; }
            set { SetProperty(ref _class, value); }
        }
    }
}