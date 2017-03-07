using System;
using System.Reflection.Emit;
using MvvmCross.iOS.Views;
using CubiSoft.Samples.Mvvm.Client.Core.ViewModels;
using Foundation;
using MvvmCross.Core.ViewModels;
using ObjCRuntime;
using UIKit;

namespace CubiSoft.Samples.Mvvm.Client.iOS.Views
{
    [Register("HubPageView")]
    public partial class HubPageView : MvxTabBarViewController
    {
        private int _createdSoFarCount = 0;

        public HubPageView() : base()
        {
            ViewDidLoad();
        }

        protected new HubPageViewModel ViewModel
        {
            get { return base.ViewModel as HubPageViewModel; }
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            if (ViewModel == null)
                return;

            var viewControllers = new UIViewController[]
                                  {
                                    CreateTabFor("Section 1", "Icon_TabBar_Home_25x24", ViewModel.GroupsViewModel),
                                    CreateTabFor("Section 2", "Icon_TabBar_Home_25x24", ViewModel.GroupsViewModel[0]),
                                    CreateTabFor("Section 3", "Icon_TabBar_Home_25x24", ViewModel.GroupsViewModel[1])
                                  };
            ViewControllers = viewControllers;
            CustomizableViewControllers = new UIViewController[] { };
            SelectedViewController = ViewControllers[0];
        }

        private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
        {
            var controller = new UINavigationController();
            var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
            SetTitleAndTabBarItem(screen, title, imageName);
            controller.PushViewController(screen, false);
            return controller;
        }

        private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
        {
            screen.Title = title;
            screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle("Images/Icons/" + imageName + ".png"), _createdSoFarCount);
            _createdSoFarCount++;
        }
    }
}
