using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf_Options
    {
        byte kind;		// Determines interpretation of the variable part of descriptor. 
        byte size;		// Size of descriptor, including header. 
        ushort section;	// Section header index of section affected, 0 for global options. 
        uint info;		// Kind-specific information. 
    }
}
