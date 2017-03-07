using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Binding.Bindings;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace CubiSoft.Samples.Mvvm.Client.iOS.Views
{
    [Register("StandardLocalImageViewCell")]
    public class StandardLocalImageViewCell : MvxStandardTableViewCell
    {
        public StandardLocalImageViewCell(IntPtr handle) : base(handle)
        {
        }

        public StandardLocalImageViewCell(string bindingText, IntPtr handle) : base(bindingText, handle)
        {
        }

        public StandardLocalImageViewCell(IEnumerable<MvxBindingDescription> bindingDescriptions, IntPtr handle) : base(bindingDescriptions, handle)
        {
        }

        public StandardLocalImageViewCell(string bindingText, UITableViewCellStyle cellStyle, NSString cellIdentifier, UITableViewCellAccessory tableViewCellAccessory = UITableViewCellAccessory.None) : base(bindingText, cellStyle, cellIdentifier, tableViewCellAccessory)
        {
        }

        public StandardLocalImageViewCell(IEnumerable<MvxBindingDescription> bindingDescriptions, UITableViewCellStyle cellStyle, NSString cellIdentifier, UITableViewCellAccessory tableViewCellAccessory = UITableViewCellAccessory.None) : base(bindingDescriptions, cellStyle, cellIdentifier, tableViewCellAccessory)
        {
        }
    }
}