using Android.App;
using Android.Content.PM;

using MvvmCross.Droid.FullFragging.Views;

namespace CubiSoft.Samples.Mvvm.Client.Droid.Views
{
    [Activity(Label = "Section View", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SectionPageView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            this.SetContentView(Resource.Layout.SectionPageView);
        }
    }
}