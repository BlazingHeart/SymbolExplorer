using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf_Options_Hw
    {
        uint hwp_flags1;	// Extra flags. 
        uint hwp_flags2;	// Extra flags. 
    }
}
