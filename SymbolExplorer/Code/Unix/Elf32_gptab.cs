using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_gptab
    {
        uint gt_g_value;		// -G value used for compilation / If this value were used for -G. 
        uint gt_bytes;		// This many bytes would be used. 
    }
}
