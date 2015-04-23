using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Framework
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : DisplayNameAttribute
    {
        public EnumDisplayNameAttribute()
        {
        }

        public EnumDisplayNameAttribute(string displayName)
        {
            DisplayNameValue = displayName;
        }
    }
}
