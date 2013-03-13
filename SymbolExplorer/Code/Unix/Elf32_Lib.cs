using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_Lib
    {
        uint l_name;		// Name (string table index)
        uint l_time_stamp;	// Timestamp
        uint l_checksum;	// Checksum
        uint l_version;		// Interface version
        uint l_flags;		// Flags
    }
}
