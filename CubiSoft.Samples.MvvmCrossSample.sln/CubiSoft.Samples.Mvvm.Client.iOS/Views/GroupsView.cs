using System.Collections.Generic;
using System.Drawing;
using CubiSoft.Samples.Mvvm.Client.Core.ViewModels;
using CubiSoft.Samples.Mvvm.Client.iOS.Converters;
using Foundation;
using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using ObjCRuntime;
using UIKit;

namespace CubiSoft.Samples.Mvvm.Client.iOS.Views
{
    public class GroupsView : MvxTableViewController<GroupsViewModel> 
    {
        public GroupsView()
        {
            ViewDidLoad();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            if (ViewModel?.Data == null)
                return;

            var tableSource = new MvxStandardTableViewSource(
                TableView, 
                UITableViewCellStyle.Default, 
                new NSString("ItemCell"),  
                "TitleText Title");
            TableView.Source = tableSource;
            

            var set = this.CreateBindingSet<GroupsView, GroupsViewModel>();
            set.Bind(tableSource).To(vm => vm.Data);

            set.Bind(tableSource).For(s => s.SelectionChangedCommand).To(s => s.NavigateCommand);

            set.Apply();

            TableView.ReloadData();
        } 
    }
}