using SymbolExplorer.Code.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SymbolExplorer
{
    public class SectionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) { return null; }
            if (value.GetType() != typeof(short)) { throw new InvalidOperationException(); }
            if (targetType != typeof(string)) { throw new InvalidOperationException(); }

            short val = (short)value;

            switch (val)
            {
            case Constants.IMAGE_SYM_UNDEFINED: return "Common";
            case Constants.IMAGE_SYM_ABSOLUTE: return "Absolute";
            case Constants.IMAGE_SYM_DEBUG: return "Debug";
            }

            return val.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) { return null; }
            if (value.GetType() != typeof(string)) { throw new InvalidOperationException(); }
            if (targetType != typeof(short)) { throw new InvalidOperationException(); }

            string val = (string)value;

            switch (val)
            {
            case "Common": return Constants.IMAGE_SYM_UNDEFINED;
            case "Absolute": return Constants.IMAGE_SYM_ABSOLUTE;
            case "Debug": return Constants.IMAGE_SYM_DEBUG;
            }

            return short.Parse(val);
        }
    }
}
