using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_RegInfo
    {
        uint ri_gprmask;		// General registers used. 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        uint[] ri_cprmask;		// Coprocessor registers used. 
        int ri_gp_value;		// $gp register value. 
    }
}
