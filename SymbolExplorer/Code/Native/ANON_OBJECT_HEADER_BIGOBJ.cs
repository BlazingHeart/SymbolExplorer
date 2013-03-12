using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct ANON_OBJECT_HEADER_BIGOBJ
    {
        /* same as ANON_OBJECT_HEADER_V2 */
        public ushort Sig1;            // Must be IMAGE_FILE_MACHINE_UNKNOWN
        public ushort Sig2;            // Must be 0xffff
        public ushort Version;         // >= 1 (implies the CLSID field is present)
        public ushort Machine;
        public uint TimeDateStamp;
        public Guid ClassID;         // Used to invoke CoCreateInstance
        public uint SizeOfData;      // Size of data that follows the header

        public uint Flags;           // 0x1 -> contains metadata
        public uint MetaDataSize;    // Size of CLR metadata
        public uint MetaDataOffset;  // Offset of CLR metadata

        /* bigobj specifics */
        public uint NumberOfSections; // extended from WORD
        public uint PointerToSymbolTable;
        public uint NumberOfSymbols;
    }
}
