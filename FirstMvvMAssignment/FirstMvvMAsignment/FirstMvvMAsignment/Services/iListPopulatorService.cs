﻿using FirstMvvMAsignment.Model;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvvMAsignment.Services
{
    public interface iListPopulatorService
    {
        MvxViewModel Parent { get; set; }
        List<string> GetAvailableCourses();

        string GetInformation(string title);

        string GetImage(string title);

        Task<List<MenuItem>> GetMenuItems();
    }
}