using Windows.Phone.UI.Input;
using MvvmCross.WindowsCommon.Views;
using CubiSoft.Samples.Mvvm.Client.Core.ViewModels;

// The Universal Hub Application project template is documented at http://go.microsoft.com/fwlink/?LinkID=391955

namespace CubiSoft.Samples.Mvvm.Client.Views
{
    /// <summary>
    /// A page that displays details for a single item within a group.
    /// </summary>
    public sealed partial class ItemPageView : MvxWindowsPage
    {
        public ItemPageView()
        {
            this.InitializeComponent();

            Loaded += (sender, e) => HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            Unloaded += (sender, e) => HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            ((ItemPageViewModel)this.DataContext).ExecGoBack();
            e.Handled = true;
        }
    }
}