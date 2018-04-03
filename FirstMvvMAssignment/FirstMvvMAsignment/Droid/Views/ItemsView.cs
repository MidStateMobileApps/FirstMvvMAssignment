using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace FirstMvvMAsignment.Droid.Views
{
    [Activity(Label = "DnD Classes")]
    public class ItemsView : MvxActivity<ItemsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {
            try
            {
                SetContentView(Resource.Layout.ItemView);
            }
            catch (System.Exception ex)
            {
                string s = ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(s);
            }

        }
    }
}