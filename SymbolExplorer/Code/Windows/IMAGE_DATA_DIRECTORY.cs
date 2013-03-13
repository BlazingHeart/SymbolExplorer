using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Code.Windows
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct IMAGE_DATA_DIRECTORY
    {
        public uint VirtualAddress;
        public uint Size;
    }
}
