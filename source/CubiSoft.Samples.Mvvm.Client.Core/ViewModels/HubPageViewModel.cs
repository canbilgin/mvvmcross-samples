using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CubiSoft.Samples.Mvvm.Client.Core.Data;
using MvvmCross.Core.ViewModels;

namespace CubiSoft.Samples.Mvvm.Client.Core.ViewModels
{
    public class HubPageViewModel: MvxViewModel
    {
        private SampleDataGroup m_Section3Items;

        private ObservableCollection<SampleDataGroup> m_Groups; 

        public HubPageViewModel()
        {
            SampleDataSource.GetGroupsAsync().ContinueWith((task) =>
            {
                Groups = new ObservableCollection<SampleDataGroup>(task.Result);
                Section3Items = task.Result.First();
            });

            m_NavigateToItemCommand = new MvxCommand<SampleDataItem>(ExecNavigateToItem);
        }

        public SampleDataGroup Section3Items
        {
            get { return m_Section3Items;}
            set { m_Section3Items = value; RaisePropertyChanged(()=>Section3Items); }
        }

        public ObservableCollection<SampleDataGroup> Groups
        {
            get { return m_Groups; }
            set
            {
                m_Groups = value;
                RaisePropertyChanged(() => Groups);
                RaisePropertyChanged(() => GroupsViewModel);
            }
        }

        public GroupsViewModel GroupsViewModel => new GroupsViewModel(this);

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
            ShowViewModel<ItemPageViewModel>(item);
        }

        private MvxCommand<SampleDataGroup> m_NavigateToGroupCommand;

        public ICommand NavigateToGroupCommand
        {
            get
            {
                return m_NavigateToGroupCommand ?? (m_NavigateToGroupCommand = new MvxCommand<SampleDataGroup>(ExecNavigateToGroup));
            }
        }

        public void ExecNavigateToGroup(SampleDataGroup group)
        {
            ShowViewModel<SectionPageViewModel>(group);
        }
    }

public class GroupsViewModel : MvxViewModel
{
    private HubPageViewModel _parentViewModel;

    public ObservableCollection<SampleDataGroup> Data => _parentViewModel.Groups;

    public ICommand NavigateCommand => _parentViewModel.NavigateToGroupCommand;

    public SectionPageViewModel this[int ordinal] => new SectionPageViewModel(Data[ordinal]);

    public GroupsViewModel(HubPageViewModel parent)
    {
        _parentViewModel = parent;
    }
}

    public class GroupDetailViewModel : MvxViewModel
    {
        private HubPageViewModel _parentViewModel;

        private int _ordinal;

        public List<SampleDataItem> Data => _parentViewModel.Groups[_ordinal].Items;

        public ICommand NavigateCommand => _parentViewModel.NavigateToItemCommand;

        public GroupDetailViewModel(HubPageViewModel parent, int ordinal)
        {
            _parentViewModel = parent;
            _ordinal = ordinal;
        }
    }
}
