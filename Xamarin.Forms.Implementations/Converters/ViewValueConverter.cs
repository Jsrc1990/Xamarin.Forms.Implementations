using System;
using System.Globalization;

namespace Xamarin.Forms.Implementations
{
    /// <summary>
    /// Converter to observe the input value
    /// </summary>
    /// <remarks>
    /// Poner un punto de interrupción para observar el valor de entrada
    /// </remarks>
    public class ViewValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string line = $"{nameof(parameter)} : {parameter?.ToString()}, {nameof(value)} : {value?.ToString()}";
            Console.WriteLine(line);
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}