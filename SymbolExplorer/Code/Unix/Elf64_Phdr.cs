using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf64_Phdr
    {
        uint p_type;			// Segment type
        uint p_flags;		// Segment flags
        ulong p_offset;		// Segment file offset
        ulong p_vaddr;		// Segment virtual address
        ulong p_paddr;		// Segment physical address
        ulong p_filesz;		// Segment size in file
        ulong p_memsz;		// Segment size in memory
        ulong p_align;		// Segment alignment
    }
}
