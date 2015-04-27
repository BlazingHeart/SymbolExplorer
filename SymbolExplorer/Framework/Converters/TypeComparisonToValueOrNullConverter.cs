using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace SymbolExplorer.Framework.Converters
{
    public class TypeComparisonToValueOrNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((parameter == null) || !typeof(Type).IsAssignableFrom(parameter.GetType())) { throw new InvalidOperationException("Invalid parameter"); }

            if (value == null) { return null; }

            return (value.GetType() == (Type)parameter) ? value : null ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
