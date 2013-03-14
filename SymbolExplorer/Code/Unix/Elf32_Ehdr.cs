using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct Elf32_Ehdr
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.EI_NIDENT)]
        public byte[] e_ident;	        // Magic number and other info
        public ETYPE e_type;			// Object file type
        public EMACHINE e_machine;		// Architecture
        public EVERSION e_version;		// Object file version
        public uint e_entry;		    // Entry point virtual address
        public uint e_phoff;		    // Program header table file offset
        public uint e_shoff;		    // Section header table file offset
        public uint e_flags;		    // Processor-specific flags
        public ushort e_ehsize;		    // ELF header size in bytes
        public ushort e_phentsize;	    // Program header table entry size
        public ushort e_phnum;		    // Program header table entry count
        public ushort e_shentsize;	    // Section header table entry size
        public ushort e_shnum;		    // Section header table entry count
        public ushort e_shstrndx;		// Section header string table index

        public void SwapEndian()
        {
            e_type = (ETYPE)NativeUtils.SwapEndian((ushort)e_type);
            e_machine = (EMACHINE)NativeUtils.SwapEndian((ushort)e_machine);
            e_version = (EVERSION)NativeUtils.SwapEndian((uint)e_version);
            e_entry = NativeUtils.SwapEndian(e_entry);
            e_phoff = NativeUtils.SwapEndian(e_phoff);
            e_shoff = NativeUtils.SwapEndian(e_shoff);
            e_flags = NativeUtils.SwapEndian(e_flags);
            e_ehsize = NativeUtils.SwapEndian(e_ehsize);
            e_phentsize = NativeUtils.SwapEndian(e_phentsize);
            e_phnum = NativeUtils.SwapEndian(e_phnum);
            e_shentsize = NativeUtils.SwapEndian(e_shentsize);
            e_shnum = NativeUtils.SwapEndian(e_shnum);
            e_shstrndx = NativeUtils.SwapEndian(e_shstrndx);
        }
    }
}
