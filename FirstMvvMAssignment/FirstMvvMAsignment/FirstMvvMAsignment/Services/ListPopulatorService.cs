using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using NewProjectTemplate.Models;
using NewProjectTemplate.ViewModels;

namespace NewProjectTemplate.Services
{
    public class ListPopulatorService : IListPopulatorService
    {
        MainMenuViewModel Parent { get; set; }
        List<string> Discs { get; set; }
        List<string> Information { get; set; }
        List<string> Images { get; set; }


        public ListPopulatorService()
        {
            Discs = new List<string>()
            {
                "Daedalus",
                "Eagle",
                "Cro",
                "Rhyno"
                
            };
            Information = new List<string>()
            {
                "Distance Driver: Speed 13",
                "Fairway Driver: Speed 7",
                "Mid-Range: Speed 5",
                "Putt & Approach: Speed 2"

            };
            Images = new List<string>()
            {
                "Daedalus",
                "Eagle",
                "Cro",
                "Rhyno"
            };
        }

        MvxViewModel IListPopulatorService.Parent { get { return Parent; } set { Parent = value as MainMenuViewModel; } }

        public List<string> GetDiscs()
        {
            return Discs;
        }

        public string GetInformation(string title)
        {
            int ix = Discs.IndexOf(title);
            if (ix >= 0) return Information[ix];
            return string.Empty;
        }

        public string GetImage(string title)
        {
            int ix = Discs.IndexOf(title);
            if (ix >= 0) return Images[ix];
            return string.Empty;
        }

        public async Task<string> GetDiscDescription()
        {
            var webRequest = WebRequest.Create("http://www.wordgenerator.net/application/p.php?id=nouns&type=1");
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = await webRequest.GetResponseAsync();
            var streamResponse = response.GetResponseStream();

            if (streamResponse.CanRead)
            {
                StreamReader reader = new StreamReader(streamResponse);
                string words = reader.ReadToEnd();
                string noCommas = words.Replace(",", " ");

                return noCommas;
            }
            else
            {
                return string.Empty;
            }
        }

        List<string> IListPopulatorService.GetDiscs()
        {
            return null;
        }

        public async Task<List<MenuItem>> GetMenuItems()
        {
            List<string> Courses = GetDiscs();
            List<MenuItem> items = Courses.Select(s => new MenuItem(s, Parent)).ToList();
            // ^^ Same as below
            // foreach (string c in Courses)
            // {
            //     var item = new MenuItem(c, Parent);
            // }
            foreach (var i in items)
            {
                i.Description = await GetDiscDescription();
            }

            return items;
        }
    }
}