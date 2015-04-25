using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace SymbolExplorer.Framework.Converters
{
    public class TypeComparisonToVisibilityConverter : IValueConverter
    {
        //public Visibility? DesignTimeVisibility { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((parameter == null) || !typeof(Type).IsAssignableFrom(parameter.GetType())) { throw new InvalidOperationException("Invalid parameter"); }
            if (targetType != typeof(Visibility)) { throw new InvalidOperationException("Must be used for Visibility"); }

            if (value == null) { return Visibility.Collapsed; }

            //if (DesignTimeVisibility.HasValue && DesignerProperties.GetIsInDesignMode(this))
            //{
            //    return DesignTimeVisibility.Value;
            //}

            return (value.GetType() == (Type)parameter) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
