using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorerLib.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class IMAGE_RELOCATION
    {
        public uint VirtualAddress;
        public uint SymbolTableIndex;
        public ushort Type;
    }
}
