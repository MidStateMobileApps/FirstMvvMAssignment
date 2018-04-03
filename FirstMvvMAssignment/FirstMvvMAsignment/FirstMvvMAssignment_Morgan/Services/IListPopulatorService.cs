using FirstMvvMAsignment.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvvMAsignment.Services
{
    public interface IListPopulatorService
    {
        MvxViewModel Parent { get; set; }

        List<string> GetAvailableRobots();

        string GetInformation(string title);

        string GetImage(string title);

        Task<List<MenuItem>> GetMenuItems();
    }
}
