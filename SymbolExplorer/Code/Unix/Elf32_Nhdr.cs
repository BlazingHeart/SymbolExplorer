using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_Nhdr
    {
        uint n_namesz;			// Length of the note's name. 
        uint n_descsz;			// Length of the note's descriptor. 
        uint n_type;			// Type of the note. 
    }
}
