using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstMvvMAsignment.Models;
using FirstMvvMAsignment.ViewModels;
using MvvmCross.Core.ViewModels;

namespace FirstMvvMAsignment.Services
{
    public class ListPopulatorService :IListPopulatorService
    {
        MainMenuViewModel Parent { get; set; }
        List<string> GoodBoys { get; set; }
        List<string> GoodBoyInfo { get; set; }
        List<string> GoodBoyImages { get; set; }

        public ListPopulatorService()
        {
            GoodBoys = new List<string>()
            {
                "",
                "",
                "",
                ""
            };
            GoodBoyInfo = new List<string>()
            {
                "",
                "",
                "",
                ""
            };
            GoodBoyImages = new List<string>()
            {
                "",
                "",
                "",
                ""
            };
        }

        MvxViewModel IListPopulatorService.Parent { get { return Parent; } set { Parent = value as MainMenuViewModel; } }

        public List<string> GetGoodBoys()
        {
            return GoodBoys;
        }

        public string GetGoodBoyInformation(string title)
        {
            int gb = GoodBoys.IndexOf(title);
            if (gb >= 0) return GoodBoyInfo[gb];
            return string.Empty;
        }

        public string GetGoodBoyImage(string title)
        {
            int gb = GoodBoys.IndexOf(title);
            if (gb >= 0) return GoodBoyImages[gb];
            return string.Empty;
        }
    }
}
