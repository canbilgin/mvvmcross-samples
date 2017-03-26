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
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Platform.Platform;

namespace CubiSoft.Samples.Mvvm.Client.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IEnumerable<Type> ValueConverterHolders => new[] { typeof(Converters.Converters) };

        #region Overrides of MvxAndroidSetup

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return base.CreateViewPresenter();
        }

        #endregion
    }
}