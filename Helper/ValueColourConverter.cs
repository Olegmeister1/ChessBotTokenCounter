using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ChessBotTokenCounter.Helper;

/// <summary>
/// Converts a high integer value to the colour red, a loew value becomes green
/// </summary>
public class ValueColourConverter : IValueConverter
{
    const int MAX_VALUE_FOR_GREEN = 1024;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is int numericValue && numericValue > MAX_VALUE_FOR_GREEN)
        {
            return Brushes.Red;

        } else
        {
            return Brushes.Green;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
