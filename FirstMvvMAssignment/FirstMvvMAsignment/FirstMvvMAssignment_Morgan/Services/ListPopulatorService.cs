using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstMvvMAsignment.Models;
using MvvmCross.Core.ViewModels;
using FirstMvvMAsignment.ViewModels;

namespace FirstMvvMAsignment.Services
{
    public class ListPopulatorService : IListPopulatorService
    {
        public ListPopulatorService()
        {
            Robots = new List<string>()
            {
                "Catapult",
                "ASW-G-29 Gundam Astaroth",
                "Dire Wolf",
                "Ebon Jaguar",
                "ASW-G-08 Gundam Barbatos",
                "Juggernaut",
                "Bagger 288"
            };
            Information = new List<string>()
            {
                "Inner Sphere, 65 ton, Heavy Battle Mech Missile Boat",
                "Tanto Tempo, 34.5 ton, General-Purpose Mobile Suit",
                "Clanner, 100 ton, Assualt Battle Mech",
                "Clanner, 65 ton, Heavy Battle Mech, aka Cauldron-Born",
                "Tekkadan, 32.1 ton, Close Quarters Combat Mobile Suit",
                "GDI, Heavy Artillery Walker",
                "A German, 13,500 ton, Excavator."
            };
            Images = new List<string>()
            {
                "catapult",
                "astaroth",
                "direwolf",
                "ebonjag",
                "barbatos",
                "juggernaut",
                "bagger288" 
            };
        }

        List<string> Robots { get; set; }

        List<string> Information { get; set; }

        List<string> Images { get; set; }

        MainMenuViewModel thisParent { get; set; }

        MvxViewModel IListPopulatorService.Parent { get { return thisParent; } set { thisParent = (MainMenuViewModel)value; } }

        public List<string> GetAvailableRobots()
        {
            return Robots;
        }

        public string GetImage(string title)
        {
            int ix = Robots.IndexOf(title);
            if (ix >= 0) return Images[ix];
            return string.Empty;
        }

        public string GetInformation(string title)
        {
            int ix = Robots.IndexOf(title);
            if (ix >= 0) return Information[ix];
            return string.Empty;
        }

        public async Task<List<MenuItem>> GetMenuItems()
        {
            List<string> Robots = GetAvailableRobots();

            List<MenuItem> Items = Robots.Select(s => new MenuItem(s, this.thisParent)).ToList();

            foreach (var item in Items)
            {
                //item.Description = await GetClassDescription();
            }

            return Items;
        }
    }
}
