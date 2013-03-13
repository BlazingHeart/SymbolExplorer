using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_Phdr
    {
        uint p_type;			// Segment type
        uint p_offset;		// Segment file offset
        uint p_vaddr;		// Segment virtual address
        uint p_paddr;		// Segment physical address
        uint p_filesz;		// Segment size in file
        uint p_memsz;		// Segment size in memory
        uint p_flags;		// Segment flags
        uint p_align;		// Segment alignment
    }
}
