using System;
using System.Data.OleDb;
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
            var originalSize = double.Parse(parameter.ToString());
            // Control size will be between 75% and 175% of the "default" size.
            // The "default" size is passed into the parameter variable.
            return originalSize * (rank + 0.75);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
