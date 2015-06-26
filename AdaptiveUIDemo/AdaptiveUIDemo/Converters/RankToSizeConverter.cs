using System;
using System.Globalization;
using System.Windows.Data;

namespace AdaptiveUIDemo.Converters
{
    public class RankToSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var rank = double.Parse(value.ToString());
            return rank + 0.75;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
