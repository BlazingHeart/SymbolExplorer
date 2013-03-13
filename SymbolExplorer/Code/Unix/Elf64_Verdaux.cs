using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf64_Verdaux
    {
        uint vda_name;		// Version or dependency names
        uint vda_next;		// Offset in bytes to next verdaux entry
    }
}
