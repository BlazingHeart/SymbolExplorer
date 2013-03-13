using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf64_Shdr
    {
        uint sh_name;		// Section name (string tbl index)
        uint sh_type;		// Section type
        ulong sh_flags;		// Section flags
        ulong sh_addr;		// Section virtual addr at execution
        ulong sh_offset;		// Section file offset
        ulong sh_size;		// Section size in bytes
        uint sh_link;		// Link to another section
        uint sh_info;		// Additional section information
        ulong sh_addralign;		// Section alignment
        ulong sh_entsize;		// Entry size if section holds table
    }
}
