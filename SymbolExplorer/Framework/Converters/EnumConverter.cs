using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SymbolExplorer.Framework.Converters
{
    public class EnumDisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) { return null; }
            if (!value.GetType().IsEnum) { throw new InvalidOperationException(); }
            if (targetType != typeof(string)) { throw new InvalidOperationException(); }

            return ((Enum)value).GetDisplayName();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) { return null; }
            if (value.GetType() != typeof(string)) { throw new InvalidOperationException(); }
            if (!targetType.IsEnum) { throw new InvalidOperationException(); }

            return Enum.Parse(targetType, (string)value);
        }
    }
}
