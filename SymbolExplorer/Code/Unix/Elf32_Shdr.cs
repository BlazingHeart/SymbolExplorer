using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_Shdr
    {
        uint sh_name;		// Section name (string tbl index)
        uint sh_type;		// Section type
        uint sh_flags;		// Section flags
        uint sh_addr;		// Section virtual addr at execution
        uint sh_offset;		// Section file offset
        uint sh_size;		// Section size in bytes
        uint sh_link;		// Link to another section
        uint sh_info;		// Additional section information
        uint sh_addralign;		// Section alignment
        uint sh_entsize;		// Entry size if section holds table
    }
}
