using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorerLib
{
    public class Demangler
    {
        public static string Demangle(string symbolName)
        {
            StringBuilder sb = new StringBuilder(4096);
            int result = PInvoke.UnDecorateSymbolName(symbolName, sb, sb.Capacity, PInvoke.UnDecorateFlags.UNDNAME_COMPLETE);
            if (result > 0)
            {
                return sb.ToString();
            }

            return symbolName;
        }
    }
}
