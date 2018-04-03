using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvvMAsignment
{
    public interface IService
    {
        /// <summary>
        /// Gets or sets the parent view model.
        /// </summary>
        MvxViewModel Parent { get; set; }

        /// <summary>
        /// Method to get the Items to be displayed in the list.
        /// </summary>
        /// <returns></returns>
        List<string> GetItems();

        /// <summary>
        /// Method to get the description matching the passed in title.
        /// </summary>
        /// <param name="title">The title of the class to look for.</param>
        /// <returns>The corresponding description for the title.</returns>
        string GetDescription(string title);
    }
}
