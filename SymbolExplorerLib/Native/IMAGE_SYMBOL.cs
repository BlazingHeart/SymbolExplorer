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
        public byte[] ShortName;

        public uint Value;
        public short SectionNumber;
        public ushort Type;
        public IMAGE_SYM_CLASS StorageClass;
        public byte NumberOfAuxSymbols;


        public IMAGE_SYM_TYPE BasicType { get { return (IMAGE_SYM_TYPE)((int)Type & Constants.N_BTMASK); } }
        public IMAGE_SYM_DTYPE DataType { get { return (IMAGE_SYM_DTYPE)(((int)Type & Constants.N_TMASK) >> Constants.N_BTSHFT); } }

        public bool UsesStringTable { get { return ((ShortName[0] == 0) && (ShortName[1] == 0) && (ShortName[2] == 0) && (ShortName[3] == 0)); } }

        public uint StringTableOffset { get { return (uint)((ShortName[7] << 24) | (ShortName[6] << 16) | (ShortName[5] << 8) | ShortName[4]); } }

        public string Name
        {
            get
            {
                if (UsesStringTable) throw new InvalidOperationException();
                // need to trim off any nulls
                int length = 0;
                for (int i = 0; i < ShortName.Length; ++i)
                {
                    if (ShortName[i] == '\0') break;
                    length = i;
                }
                return Encoding.UTF8.GetString(ShortName, 0, length);
            }
        }
    }
}
