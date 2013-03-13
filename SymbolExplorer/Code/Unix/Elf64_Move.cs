using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf64_Move
    {
        ulong m_value;		// Symbol value. 
        ulong m_info;		// Size and index. 
        ulong m_poffset;	// Symbol offset. 
        ushort m_repeat;		// Repeat count. 
        ushort m_stride;		// Stride info. 
    }
}
