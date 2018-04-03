using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvvMAsignment
{
    public class Service : IService
    {
        /// <summary>
        /// The list of classes to be displayed.
        /// </summary>
        public List<string> Items { get; set; }

        /// <summary>
        /// The list of descriptions to be displayed.
        /// </summary>
        public List<string> Descriptions { get; set; }

        /// <summary>
        /// The view model that is the parent.
        /// </summary>
        public ItemsViewModel Parent { get; set; }

        /// <summary>
        /// Initializes a new instance of the Service class.
        /// </summary>
        public Service()
        {
            // Sets the items list to the classes to display.
            Items = new List<string>()
            {
                    "Barbarian",
                    "Bard",
                    "Druid",
                    "Monk",
                    "Paladin",
                    "Ranger",
                    "Sorcerer",
                    "Warlock"
            };

            // Sets the descriptions to be displayed.
            Descriptions = new List<string>()
            {
                "The barbarian is based on Robert E. Howard's Conan the Barbarian, Gardner Fox's Kothar and to a lesser extent Fritz Lieber's Fafhrd.",
                "The bard first appeared in The Strategic Review Volume 2, Number 1.",
                "The druid is named for the pre-Christian Celtic priests called druids",
                "The original monk character class was created by Brian Blume, inspired by the fictional martial arts of the Destroyer series of novels.",
                "The development of the Dungeons & Dragons Paladin, first introduced in the original Greyhawk supplement, was heavily influenced by the fictional character Holger Carlson from Poul Anderson's novel",
                "The ranger was primarily based on the character Aragorn, and the Rangers of the North of J. R. R. Tolkien's Middle-earth mythos, as warriors who use tracking and other wilderness skills to hunt down their enemies",
                "The sorcerer has been included as a character class in the 5th edition Player's Handbook.",
                "The warlock has been included as a character class in the 5th edition Player's Handbook."
            };
        }

        MvxViewModel IService.Parent { get { return Parent; } set { Parent = value as ItemsViewModel; } }

        /// <summary>
        /// The implemented method to get the description that matches the passed in title.
        /// </summary>
        /// <param name="title">The title of the class to find.</param>
        /// <returns>The corresponding description for the title.</returns>
        public string GetDescription(string title)
        {
            // Getting the index of the passed in title
            int x = Items.IndexOf(title);

            if (x >= 0)
            {
                var match = Descriptions[x];
                if (match.Length >= 60)
                {
                    match = match.Substring(0, 57) + "...";
                }
                return match;
            }
            return string.Empty;
        }

        /// <summary>
        /// Method to get the items list.
        /// </summary>
        /// <returns>The list of items to be displayed.</returns>
        public List<string> GetItems()
        {
            return Items;
        }
    }
}
