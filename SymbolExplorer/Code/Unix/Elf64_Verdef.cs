using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf64_Verdef
    {
        ushort vd_version;		// Version revision
        ushort vd_flags;		// Version information
        ushort vd_ndx;			// Version Index
        ushort vd_cnt;			// Number of associated aux entries
        uint vd_hash;		// Version name hash value
        uint vd_aux;			// Offset in bytes to verdaux array
        uint vd_next;		// Offset in bytes to next verdef entry
    }
}
