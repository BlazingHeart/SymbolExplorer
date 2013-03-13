using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_Vernaux
    {
        uint vna_hash;		// Hash value of dependency name
        ushort vna_flags;		// Dependency specific information
        ushort vna_other;		// Unused
        uint vna_name;		// Dependency name string offset
        uint vna_next;		// Offset in bytes to next vernaux entry
    }
}
