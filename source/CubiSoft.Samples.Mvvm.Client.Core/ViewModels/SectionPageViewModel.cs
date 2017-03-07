using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CubiSoft.Samples.Mvvm.Client.Core.Data;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace CubiSoft.Samples.Mvvm.Client.Core.ViewModels
{
    public class SectionPageViewModel : MvxViewModel
    {
        private ObservableCollection<SampleDataItem> m_Items = new ObservableCollection<SampleDataItem>();

        private SampleDataGroup m_DataGroup;

        public void Init(SampleDataGroup group)
        {
            Group = group;
            SampleDataSource.GetGroupAsync(group.UniqueId).ContinueWith(task =>
            {
                Items = new ObservableCollection<SampleDataItem>(task.Result.Items);
            });
        }

        public SectionPageViewModel()
        {
        }

        public SectionPageViewModel(SampleDataGroup group): base()
        {
            Init(group);
        }

        public ObservableCollection<SampleDataItem> Items
        {
            get { return m_Items; }
            set { m_Items = value; RaisePropertyChanged(() => Items); }
        }

private List<IUICommand> m_ItemCommands = null;

public List<IUICommand> ItemActions {
    get
    {
        if (m_ItemCommands == null)
        {
            m_ItemCommands = new List<IUICommand>();
            m_ItemCommands.Add(new MvxUICommand<int>(ExecuteFavouriteAction, CanExecuteFavouriteAction, "Favourite"));
        }

        return m_ItemCommands;
    }
}

        public void ExecuteFavouriteAction(int rowIndex)
        {
            if (rowIndex > -1 && rowIndex < Items.Count)
            {
                // TODO: Do something with the row.
            }
        }

public bool CanExecuteFavouriteAction(int rowIndex)
{
    return rowIndex % 2 == 0;
}

        public SampleDataGroup Group
        {
            get { return m_DataGroup; }
            set 
            { 
                m_DataGroup = value; 
                RaisePropertyChanged(()=>Group);
                RaisePropertyChanged(()=>Items);
            }
        }

        private MvxCommand<SampleDataItem> m_NavigateToItemCommand;

        public ICommand NavigateToItemCommand
        {
            get
            {
                return m_NavigateToItemCommand ?? (m_NavigateToItemCommand = new MvxCommand<SampleDataItem>(ExecNavigateToItem));
            }
        }

        public void ExecNavigateToItem(SampleDataItem item)
        {
            //ShowViewModel<ItemPageViewModel>(item);
        }

private MvxCommand<int> m_DeleteItemCommand;

public ICommand DeleteItemCommand
{
    get { return m_DeleteItemCommand ?? (m_DeleteItemCommand = new MvxCommand<int>(ExecDeleteItem, CanExecDeleteItem)); }
}

public void ExecDeleteItem(int index)
{
    Mvx.Trace($"Deleting item at {index}");
}

public bool CanExecDeleteItem(int index)
{
    Mvx.Trace($"Checking removal at {index}");

    return index > 0;
}

        private MvxCommand m_NavigateBackCommand;

        public ICommand NavigateBackCommand
        {
            get
            {
                return m_NavigateBackCommand ?? (m_NavigateBackCommand = new MvxCommand(ExecGoBack));
            }
        }

        public void ExecGoBack()
        {
            Close(this);
        }
    }

    public interface IUICommand : ICommand
    {
        string Label { get; }
    }

public class MvxUICommand<T> : MvxCommand<T>, IUICommand
{
    public MvxUICommand(Action<T> execute, Func<T, bool> canExecute = null, string label = "") : base(execute, canExecute)
    {
        Label = label;
    }

    #region Implementation of IUICommand

    public string Label { get; }

    #endregion
}
}
