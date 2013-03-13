using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf64_Ehdr
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.EI_NIDENT)]
        byte[]	e_ident;	    // Magic number and other info
        ushort	e_type;			// Object file type
        ushort	e_machine;		// Architecture
        uint	e_version;		// Object file version
        ulong	e_entry;		// Entry point virtual address
        ulong	e_phoff;		// Program header table file offset
        ulong	e_shoff;		// Section header table file offset
        uint	e_flags;		// Processor-specific flags
        ushort	e_ehsize;		// ELF header size in bytes
        ushort	e_phentsize;	// Program header table entry size
        ushort	e_phnum;		// Program header table entry count
        ushort	e_shentsize;	// Section header table entry size
        ushort	e_shnum;		// Section header table entry count
        ushort	e_shstrndx;		// Section header string table index
    }
}
