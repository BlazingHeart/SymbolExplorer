using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_Sym
    {
        uint	st_name;		// Symbol name (string tbl index)
        uint	st_value;		// Symbol value
        uint	st_size;		// Symbol size
        byte	st_info;		// Symbol type and binding
        byte	st_other;		// Symbol visibility
        ushort	st_shndx;		// Section index
    }
}
