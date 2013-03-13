using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_Rela
    {
        uint r_offset;		// Address
        uint r_info;			// Relocation type and symbol index
        int r_addend;		// Addend
    }
}
