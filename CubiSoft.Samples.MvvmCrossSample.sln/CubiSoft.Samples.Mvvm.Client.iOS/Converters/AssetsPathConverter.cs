using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using MvvmCross.Platform.Converters;

namespace CubiSoft.Samples.Mvvm.Client.iOS.Converters
{
    public class AssetsPathConverter: IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Replace("../", "res:");
        }

        #region Implementation of IMvxValueConverter

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}