using SymbolExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SymbolExplorer
{
    class Filters
    {
        static bool _symbolViewModel_HideLinkerSymbols_Enabled = true;
        
        public static bool SymbolViewModel_HideLinkerSymbols_Enabled { get { return _symbolViewModel_HideLinkerSymbols_Enabled; } set { _symbolViewModel_HideLinkerSymbols_Enabled = value; OnFilterChanged(); } }
        

        public static EventHandler FilterUpdated { get; set; }


        public static void OnFilterChanged()
        {
            if (FilterUpdated != null)
            {
                FilterUpdated(null, EventArgs.Empty);
            }
        }

        public static void SymbolViewModel_HideLinkerSymbols(object sender, FilterEventArgs e)
        {
            e.Accepted = SymbolViewModel_HideLinkerSymbols(e.Item);
        }

        public static bool SymbolViewModel_HideLinkerSymbols(object o)
        {
            SymbolViewModel symbol = o as SymbolViewModel;

            if (SymbolViewModel_HideLinkerSymbols_Enabled)
            {
                if (symbol != null)
                {
                    if (symbol.Demangled.StartsWith(".") || symbol.Demangled.StartsWith("@"))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
