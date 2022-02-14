using System;
using System.Globalization;

namespace Xamarin.Forms.Implementations
{
    /// <summary>
    /// Converter to negate a boolean
    /// </summary>
    public class NotBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //This converter is supposed to be consumed only by properties of type boolean
            if (value == null) return false;
            return !System.Convert.ToBoolean(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}