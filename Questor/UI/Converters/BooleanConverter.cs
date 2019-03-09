using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Questor.UI.Converters
{
    public class BooleanConverter : BaseConverter, IValueConverter
    {
        public static readonly IValueConverter Instance = new BooleanConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DoConvert(value, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string parameterString = parameter as string;
            if (parameterString == null)
            {
                return DependencyProperty.UnsetValue;
            }

            return Enum.Parse(targetType, parameterString);
        }
    }
}