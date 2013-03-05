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
        public static void SymbolViewModel_NonLinker(object sender, FilterEventArgs e)
        {
            e.Accepted = SymbolViewModel_NonLinker(e.Item);
        }

        public static bool SymbolViewModel_NonLinker(object o)
        {
            SymbolViewModel symbol = o as SymbolViewModel;
            if (symbol != null)
            {
                if (symbol.Name.StartsWith(".") || symbol.Name.StartsWith("@"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
