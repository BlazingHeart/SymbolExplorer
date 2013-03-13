using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_Syminfo
    {
        ushort si_boundto;		// Direct bindings, symbol bound to
        ushort si_flags;			// Per symbol flags
    }
}
