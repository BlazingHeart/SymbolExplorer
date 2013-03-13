using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf64_Verneed
    {
        ushort vn_version;		// Version of structure
        ushort vn_cnt;			// Number of associated aux entries
        uint vn_file;		// Offset of filename for this dependency
        uint vn_aux;			// Offset in bytes to vernaux array
        uint vn_next;		// Offset in bytes to next verneed entry
    }
}
