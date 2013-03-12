using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public struct ANON_OBJECT_HEADER
    {
        public ushort Sig1;            // Must be IMAGE_FILE_MACHINE_UNKNOWN
        public ushort Sig2;            // Must be 0xffff
        public ushort Version;         // >= 1 (implies the CLSID field is present)
        public ushort Machine;
        public uint TimeDateStamp;
        public Guid ClassID;         // Used to invoke CoCreateInstance
        public uint SizeOfData;      // Size of data that follows the header
    }
}
