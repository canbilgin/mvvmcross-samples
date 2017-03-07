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
using CubiSoft.Samples.Mvvm.Client.Core.ViewModels;
using CubiSoft.Samples.Mvvm.Client.Droid.Views.Fragments;
using MvvmCross.Droid.FullFragging;

namespace CubiSoft.Samples.Mvvm.Client.Droid.Views
{
    [Activity(Label = "Main", MainLauncher = true, Icon = "@drawable/icon")]
    public class HubPageView : MvxTabsFragmentActivity
    {
        public HubPageViewModel ViewModel
        {
            get { return (HubPageViewModel) base.ViewModel; }
        }

        public HubPageView() : base(Resource.Layout.HubPageView, Resource.Id.actualtabcontent)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        protected override void AddTabs(Bundle args)
        {
            AddTab<GroupsFragment>("1", "Groups", args, this.ViewModel);
            AddTab<FirstSectionFragment>("2", "Group 1", args, this.ViewModel);
            AddTab<SecondSectionFragment>("3", "Group 2", args, this.ViewModel);
        }
    }
}