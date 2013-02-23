using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorerLib.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct IMAGE_SYMBOL
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] ShortName;

        uint Value;
        short SectionNumber;
        IMAGE_SYM_TYPE Type;
        IMAGE_SYM_CLASS StorageClass;
        byte NumberOfAuxSymbols;


        bool UsesStringTable { get { return ((ShortName[0] == 0) && (ShortName[1] == 0) && (ShortName[2] == 0) && (ShortName[3] == 0)); } }

        uint StringTableOffset { get { return (uint)((ShortName[4] << 24) | (ShortName[5] << 16) | (ShortName[6] << 8) | ShortName[7]); } }

        string Name
        {
            get
            {
                if (UsesStringTable) throw new InvalidOperationException();
                return Encoding.UTF8.GetString(ShortName);
            }
        }
    }
}
