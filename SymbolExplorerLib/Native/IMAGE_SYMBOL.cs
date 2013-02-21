using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorerLib.Native
{
    [Flags]
    enum ImageSymbolType : ushort
    {
        IMAGE_SYM_TYPE_NULL = 0x0000,  // no type.
        IMAGE_SYM_TYPE_VOID = 0x0001,
        IMAGE_SYM_TYPE_CHAR = 0x0002,  // type character.
        IMAGE_SYM_TYPE_SHORT = 0x0003,  // type short integer.
        IMAGE_SYM_TYPE_INT = 0x0004,
        IMAGE_SYM_TYPE_LONG = 0x0005,
        IMAGE_SYM_TYPE_FLOAT = 0x0006,
        IMAGE_SYM_TYPE_DOUBLE = 0x0007,
        IMAGE_SYM_TYPE_STRUCT = 0x0008,
        IMAGE_SYM_TYPE_UNION = 0x0009,
        IMAGE_SYM_TYPE_ENUM = 0x000A,  // enumeration.
        IMAGE_SYM_TYPE_MOE = 0x000B,  // member of enumeration.
        IMAGE_SYM_TYPE_BYTE = 0x000C,
        IMAGE_SYM_TYPE_WORD = 0x000D,
        IMAGE_SYM_TYPE_UINT = 0x000E,
        IMAGE_SYM_TYPE_DWORD = 0x000F,
        IMAGE_SYM_TYPE_PCODE = 0x8000,
    
        IMAGE_SYM_DTYPE_NULL = 0x0000, // no derived type.
        IMAGE_SYM_DTYPE_POINTER = 0x0100, // pointer.
        IMAGE_SYM_DTYPE_FUNCTION = 0x0200, // function.
        IMAGE_SYM_DTYPE_ARRAY = 0x0300, // array.

        N_BTMASK = 0x000F,
        N_TMASK = 0x0030,
        N_TMASK1 = 0x00C0,
        N_TMASK2 = 0x00F0,
    }

    enum ImageSymbolStorageClass : byte
    {
        IMAGE_SYM_CLASS_END_OF_FUNCTION = 0xFF,
        IMAGE_SYM_CLASS_NULL = 0x00,
        IMAGE_SYM_CLASS_AUTOMATIC = 0x01,
        IMAGE_SYM_CLASS_EXTERNAL = 0x02,
        IMAGE_SYM_CLASS_STATIC = 0x03,
        IMAGE_SYM_CLASS_REGISTER = 0x04,
        IMAGE_SYM_CLASS_EXTERNAL_DEF = 0x05,
        IMAGE_SYM_CLASS_LABEL = 0x06,
        IMAGE_SYM_CLASS_UNDEFINED_LABEL = 0x07,
        IMAGE_SYM_CLASS_MEMBER_OF_STRUCT = 0x08,
        IMAGE_SYM_CLASS_ARGUMENT = 0x09,
        IMAGE_SYM_CLASS_STRUCT_TAG = 0x0A,
        IMAGE_SYM_CLASS_MEMBER_OF_UNION = 0x0B,
        IMAGE_SYM_CLASS_UNION_TAG = 0x0C,
        IMAGE_SYM_CLASS_TYPE_DEFINITION = 0x0D,
        IMAGE_SYM_CLASS_UNDEFINED_STATIC = 0x0E,
        IMAGE_SYM_CLASS_ENUM_TAG = 0x0F,
        IMAGE_SYM_CLASS_MEMBER_OF_ENUM = 0x10,
        IMAGE_SYM_CLASS_REGISTER_PARAM = 0x11,
        IMAGE_SYM_CLASS_BIT_FIELD = 0x12,
        IMAGE_SYM_CLASS_FAR_EXTERNAL = 0x44,
        IMAGE_SYM_CLASS_BLOCK = 0x64,
        IMAGE_SYM_CLASS_FUNCTION = 0x65,
        IMAGE_SYM_CLASS_END_OF_STRUCT = 0x66,
        IMAGE_SYM_CLASS_FILE = 0x67,
        IMAGE_SYM_CLASS_SECTION = 0x68,
        IMAGE_SYM_CLASS_WEAK_EXTERNAL = 0x69,
        IMAGE_SYM_CLASS_CLR_TOKEN = 0x6B,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class IMAGE_SYMBOL
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] ShortName;

        uint Value;
        short SectionNumber;
        ImageSymbolType Type;
        ImageSymbolStorageClass StorageClass;
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
