using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CubiSoft.Samples.Mvvm.Client.Core.ViewModels;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using ObjCRuntime;
using UIKit;

namespace CubiSoft.Samples.Mvvm.Client.iOS.Views
{
    public class SectionPageView : MvxTableViewController<SectionPageViewModel>
    {
        private UIBarButtonItem _editButton;

        public SectionPageView()
        {
            ViewDidLoad();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            if (ViewModel?.Items == null)
                return;

var tableSource = new EditableTableViewSource(TableView, UITableViewCellStyle.Subtitle,
    new NSString("ItemCell"), "TitleText Title;DetailText Subtitle; ImageUrl ImagePath,Converter=AssetsPath");

TableView.Source = tableSource;

var set = this.CreateBindingSet<SectionPageView, SectionPageViewModel>();
set.Bind(tableSource).To(vm => vm.Items);

set.Bind(tableSource)
    .For(s => s.SelectionChangedCommand)
    .To(vm => vm.NavigateToItemCommand);

set.Bind(tableSource)
    .For(s => s.DeleteRowCommand)
    .To(vm => vm.DeleteItemCommand);

set.Bind(tableSource)
    .For(s => s.AdditionalActions)
    .To(vm => vm.ItemActions);

            set.Bind(this).For(page => page.NavigationController.TopViewController.Title).To(vm => vm.Group.Title);

            set.Apply();

            _editButton = new UIBarButtonItem(NSBundle.MainBundle.LocalizedString("Edit", "Edit"),
                UIBarButtonItemStyle.Done, delegate
                {

                    TableView.SetEditing(!TableView.Editing, true);
                    _editButton.Title = TableView.Editing
                        ? NSBundle.MainBundle.LocalizedString("Done", "Done")
                        : NSBundle.MainBundle.LocalizedString("Edit", "Edit");

                });

            NavigationItem.RightBarButtonItem = _editButton;


            TableView.ReloadData();
        }
    }

public class EditableTableViewSource : MvxStandardTableViewSource
{
    public EditableTableViewSource(UITableView tableView) : base(tableView)
    {
    }

    public EditableTableViewSource(UITableView tableView, NSString cellIdentifier) : base(tableView, cellIdentifier)
    {
    }

    public EditableTableViewSource(UITableView tableView, string bindingText) : base(tableView, bindingText)
    {
    }

    public EditableTableViewSource(IntPtr handle) : base(handle)
    {
    }

    public EditableTableViewSource(UITableView tableView, UITableViewCellStyle style, NSString cellIdentifier, string bindingText, UITableViewCellAccessory tableViewCellAccessory = UITableViewCellAccessory.None) : base(tableView, style, cellIdentifier, bindingText, tableViewCellAccessory)
    {
    }

    public EditableTableViewSource(UITableView tableView, UITableViewCellStyle style, NSString cellIdentifier, IEnumerable<MvxBindingDescription> descriptions, UITableViewCellAccessory tableViewCellAccessory = UITableViewCellAccessory.None) : base(tableView, style, cellIdentifier, descriptions, tableViewCellAccessory)
    {
    }

    #region Overrides of UITableViewSource

public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
{
    return true;
}

public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
{ 
 	switch (editingStyle) 
 	{ 
 		case UITableViewCellEditingStyle.Delete:
            DeleteRowCommand.Execute(indexPath.Row);
 			break; 
 		case UITableViewCellEditingStyle.None: 
 			break; 
 	} 
}

public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
{
    //if (AdditionalActions.Any(command=>command.CanExecute(indexPath.Row)) || DeleteRowCommand.CanExecute(indexPath.Row))
    //{
    //    return UITableViewCellEditingStyle.Delete;
    //}

    return UITableViewCellEditingStyle.None;
}

public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
{ 
 	return false; 
}


public ICommand DeleteRowCommand { get; set; }

public List<IUICommand> AdditionalActions { get; set; }

public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
{
    var rowActions = new List<UITableViewRowAction>();

    rowActions.AddRange(
        AdditionalActions
            .Where(command=>command.CanExecute(indexPath.Row))
            .Select(
            command =>
                UITableViewRowAction.Create(
                    UITableViewRowActionStyle.Normal, 
                    command.Label,
                    (action, path) => command.Execute(indexPath.Row))));


    if (DeleteRowCommand.CanExecute(indexPath.Row))
    {
        rowActions.Add(UITableViewRowAction.Create(UITableViewRowActionStyle.Destructive, "Delete",
            (action, path) => { DeleteRowCommand.Execute(indexPath.Row); }));
    }

    return rowActions.ToArray();
}

    #endregion


}
}