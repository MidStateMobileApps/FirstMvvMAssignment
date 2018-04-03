using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using FirstMvvMAsignment.ViewModels;

namespace FirstMvvMAsignment.Droid.Views
{
    [Activity(Label = "Favorite Giant Robots")]
    public class MainMenuView : MvxActivity<MainMenuViewModel>
    {
        protected override void OnViewModelSet()
        {
            try
            {
                SetContentView(Resource.Layout.MainMenuView);
            }
            catch (System.Exception ex)
            {
                string s = ex.StackTrace;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }
}