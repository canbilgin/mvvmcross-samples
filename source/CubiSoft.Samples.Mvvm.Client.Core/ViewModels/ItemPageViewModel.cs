using System.Windows.Input;
using CubiSoft.Samples.Mvvm.Client.Core.Data;
using MvvmCross.Core.ViewModels;

namespace CubiSoft.Samples.Mvvm.Client.Core.ViewModels
{
    public class ItemPageViewModel: MvxViewModel
    {
        private SampleDataItem m_Item;

        public void Init(SampleDataItem item)
        {
            Item = item;
        }

        public ItemPageViewModel()
        {
        }

        public SampleDataItem Item
        {
            get { return m_Item; }
            set { m_Item = value; RaisePropertyChanged(() => Item); }
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
}
