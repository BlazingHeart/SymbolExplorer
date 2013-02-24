using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorerLib.Native
{
    public class Constants
    {
        public const int IMAGE_ARCHIVE_START_SIZE = 8;
        public const string IMAGE_ARCHIVE_START = "!<arch>\n";
        public const string IMAGE_ARCHIVE_END = "`\n";
        public const string IMAGE_ARCHIVE_PAD = "\n";
        public const string IMAGE_ARCHIVE_LINKER_MEMBER = "/               ";
        public const string IMAGE_ARCHIVE_LONGNAMES_MEMBER = "//              ";

        public const int IMAGE_SIZEOF_ARCHIVE_MEMBER_HDR = 60;

        public const int IMAGE_SIZEOF_FILE_HEADER = 20;

        public const int IMAGE_SIZEOF_SHORT_NAME = 8;
        public const int IMAGE_SIZEOF_SECTION_HEADER = 40;

        public const short IMAGE_SYM_UNDEFINED = (short)0;          // Symbol is undefined or is common.
        public const short IMAGE_SYM_ABSOLUTE = (short)-1;         // Symbol is an absolute value.
        public const short IMAGE_SYM_DEBUG = (short)-2;        // Symbol is a special debug item.
        public const int IMAGE_SYM_SECTION_MAX = 0xFEFF;        // Values 0xFF00-0xFFFF are special
        public const int IMAGE_SYM_SECTION_MAX_EX = 0x7FFFFFFF;


        public const int N_BTMASK = 0x000F;
        public const int N_TMASK = 0x0030;
        public const int N_TMASK1 = 0x00C0;
        public const int N_TMASK2 = 0x00F0;
    }

    [Flags]
    public enum ST_MODE : ushort
    {
        None = 0,

        S_IFMT = 0xF000, // File type mask
        S_IFDIR = 0x4000, // Directory
        S_IFCHR = 0x2000, // Character special (indicates a device if set)
        S_IFIFO = 0x1000, // Pipe
        S_IFREG = 0x8000, // Regular
        S_IREAD = 0x0100, // Read permission, owner
        S_IWRITE = 0x0080, // Write permission, owner
        S_IEXEC = 0x0040, // Execute/search permission, owner

        //S_IRUSR = 0x0100,
        //S_IWUSR = 0x0080,
        //S_IXUSR = 0x0040,
        //S_IRGRP = 0x0020,
        //S_IWGRP = 0x0010,
        //S_IXGRP = 0x0008,
        //S_IROTH = 0x0004,
        //S_IWOTH = 0x0002,
        //S_IXOTH = 0x0001,

        S_1 = 0x0001,
        S_2 = 0x0002,
        S_3 = 0x0004,
        S_4 = 0x0008,
        S_5 = 0x0010,
        S_6 = 0x0020,
    };

    [Flags]
    public enum IMAGE_SYM_TYPE : ushort
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
    }

    public enum IMAGE_SYM_CLASS : byte
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
}
