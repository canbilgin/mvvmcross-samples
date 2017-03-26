
using System;
using CubiSoft.Samples.Mvvm.Client.Core.ViewModels;
using CubiSoft.Samples.Mvvm.Client.Forms.Helpers;
using CubiSoft.Samples.Mvvm.Client.Forms.Views;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Views.iOS;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;

namespace CubiSoft.Samples.Mvvm.Client.Forms.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : MvxFormsApplicationDelegate
	{
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, Window);
            setup.Initialize();

            Mvx.Resolve<IMvxViewsContainer>()?.Add(typeof(HubPageViewModel), typeof(HubPagePage));

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
