using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstMvvMAsignment.Models;
using MvvmCross.Core.ViewModels;
using FirstMvvMAsignment.ViewModels;
using System.Net;
using System.IO;

namespace FirstMvvMAsignment.Services
{
    class ListPopulatorService : IListPopulatorService
    {
        MainMenuViewModel thisParent { get; set; }
        List<string> Games { get; set; }
        List<string> Information { get; set; }

        public ListPopulatorService()
        {
            Games = new List<string>()
            {
                "Pandemic",
                "SW: Imperial Assult",
                "Five Tribes",
                "Game of Thrones"
            };

            Information = new List<string>()
            {
                "Cure deseases that have spread over the world",
                "Join the Alliance to fight against the Empire",
                "Align the Five Tribes to fulfill the prophecy",
                "Lead one of the great Houses and claim the throne"
            };
        }

        MvxViewModel IListPopulatorService.Parent
        {
            get
            {
                return thisParent;
            }
            set
            {
                thisParent = (MainMenuViewModel)value;
            }
        }

        public MvxViewModel Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<string> GetAvailableGames()
        {
            return Games;
        }

        public async Task<string> GetGameDescription()
        {
            var webRequest = WebRequest.Create("http://www.wordgenerator.net/application/p.php?id=nouns&type=1");
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = await webRequest.GetResponseAsync();
            var streamResponse = response.GetResponseStream();

            if (streamResponse.CanRead)
            {
                StreamReader reader = new StreamReader(streamResponse);
                string words = reader.ReadToEnd();
                string noCommas = words.Replace(',', ' ');
                return noCommas;
            }
            return string.Empty;
        }

        public async Task<List<MenuItem>> GetMenuItems()
        {
            List<string> Games = GetAvailableGames();
            List<MenuItem> items = Games.Select(s => new MenuItem(s, thisParent)).ToList();
            foreach (var item in items)
            {
                item.Description = await GetGameDescription();
            }
            return items;
        }

        public string GetInformation(string title)
        {
            int ix = Games.IndexOf(title);
            if (ix >= 0) return Information[ix];
            return string.Empty;
        }

        Task<List<MenuItem>> IListPopulatorService.GetMenuItems()
        {
            throw new NotImplementedException();
        }
    }
}
