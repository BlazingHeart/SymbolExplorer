using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorerLib.Native
{
    public class Constants
    {
        public const ushort IMAGE_DOS_SIGNATURE = 0x5A4D;       // MZ
        public const ushort IMAGE_OS2_SIGNATURE = 0x454E;       // NE
        public const ushort IMAGE_OS2_SIGNATURE_LE = 0x454C;    // LE
        public const ushort IMAGE_VXD_SIGNATURE = 0x454C;       // LE
        public const uint IMAGE_NT_SIGNATURE = 0x00004550;      // PE00
        
        public const int IMAGE_NUMBEROF_DIRECTORY_ENTRIES = 16;

        public const ushort IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x010b;
        public const ushort IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x020b;
        public const ushort IMAGE_ROM_OPTIONAL_HDR_MAGIC = 0x0107;

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

        public const short IMAGE_SYM_UNDEFINED = (short)0;      // Symbol is undefined or is common.
        public const short IMAGE_SYM_ABSOLUTE = (short)-1;      // Symbol is an absolute value.
        public const short IMAGE_SYM_DEBUG = (short)-2;         // Symbol is a special debug item.

        public const int IMAGE_SYM_SECTION_MAX = 0xFEFF;        // Values 0xFF00-0xFFFF are special
        public const int IMAGE_SYM_SECTION_MAX_EX = 0x7FFFFFFF;


        public const int N_BTMASK = 0x000F;
        public const int N_TMASK = 0x0030;
        public const int N_TMASK1 = 0x00C0;
        public const int N_TMASK2 = 0x00F0;
        public const int N_BTSHFT = 4;
        public const int N_TSHIFT = 2;
    }

    public enum IMAGE_FILE_MACHINE : ushort
    {
        IMAGE_FILE_MACHINE_UNKNOWN = 0,
        IMAGE_FILE_MACHINE_I386 = 0x014c, // Intel 386.
        IMAGE_FILE_MACHINE_R3000 = 0x0162, // MIPS little-endian, 0x160 big-endian
        IMAGE_FILE_MACHINE_R4000 = 0x0166, // MIPS little-endian
        IMAGE_FILE_MACHINE_R10000 = 0x0168, // MIPS little-endian
        IMAGE_FILE_MACHINE_WCEMIPSV2 = 0x0169, // MIPS little-endian WCE v2
        IMAGE_FILE_MACHINE_ALPHA = 0x0184, // Alpha_AXP
        IMAGE_FILE_MACHINE_SH3 = 0x01a2, // SH3 little-endian
        IMAGE_FILE_MACHINE_SH3DSP = 0x01a3,
        IMAGE_FILE_MACHINE_SH3E = 0x01a4, // SH3E little-endian
        IMAGE_FILE_MACHINE_SH4 = 0x01a6, // SH4 little-endian
        IMAGE_FILE_MACHINE_SH5 = 0x01a8, // SH5
        IMAGE_FILE_MACHINE_ARM = 0x01c0, // ARM Little-Endian
        IMAGE_FILE_MACHINE_THUMB = 0x01c2, // ARM Thumb/Thumb-2 Little-Endian
        IMAGE_FILE_MACHINE_ARMNT = 0x01c4, // ARM Thumb-2 Little-Endian
        IMAGE_FILE_MACHINE_AM33 = 0x01d3,
        IMAGE_FILE_MACHINE_POWERPC = 0x01F0, // IBM PowerPC Little-Endian
        IMAGE_FILE_MACHINE_POWERPCFP = 0x01f1,
        IMAGE_FILE_MACHINE_IA64 = 0x0200, // Intel 64
        IMAGE_FILE_MACHINE_MIPS16 = 0x0266, // MIPS
        IMAGE_FILE_MACHINE_ALPHA64 = 0x0284, // ALPHA64
        IMAGE_FILE_MACHINE_MIPSFPU = 0x0366, // MIPS
        IMAGE_FILE_MACHINE_MIPSFPU16 = 0x0466, // MIPS
        IMAGE_FILE_MACHINE_AXP64 = IMAGE_FILE_MACHINE_ALPHA64,
        IMAGE_FILE_MACHINE_TRICORE = 0x0520, // Infineon
        IMAGE_FILE_MACHINE_CEF = 0x0CEF,
        IMAGE_FILE_MACHINE_EBC = 0x0EBC, // EFI Byte Code
        IMAGE_FILE_MACHINE_AMD64 = 0x8664, // AMD64 (K8)
        IMAGE_FILE_MACHINE_M32R = 0x9041, // M32R little-endian
        IMAGE_FILE_MACHINE_CEE = 0xC0EE,
    }

    [Flags]
    public enum IMAGE_FILE_CHARACTARISTICS : ushort
    {
        IMAGE_FILE_RELOCS_STRIPPED = 0x0001,  // Relocation info stripped from file.
        IMAGE_FILE_EXECUTABLE_IMAGE = 0x0002,  // File is executable  (i.e. no unresolved externel references).
        IMAGE_FILE_LINE_NUMS_STRIPPED = 0x0004,  // Line nunbers stripped from file.
        IMAGE_FILE_LOCAL_SYMS_STRIPPED = 0x0008,  // Local symbols stripped from file.
        IMAGE_FILE_AGGRESIVE_WS_TRIM = 0x0010,  // Agressively trim working set
        IMAGE_FILE_LARGE_ADDRESS_AWARE = 0x0020,  // App can handle >2gb addresses
        IMAGE_FILE_BYTES_REVERSED_LO = 0x0080,  // Bytes of machine word are reversed.
        IMAGE_FILE_32BIT_MACHINE = 0x0100,  // 32 bit word machine.
        IMAGE_FILE_DEBUG_STRIPPED = 0x0200,  // Debugging info stripped from file in .DBG file
        IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP = 0x0400,  // If Image is on removable media, copy and run from the swap file.
        IMAGE_FILE_NET_RUN_FROM_SWAP = 0x0800,  // If Image is on Net, copy and run from the swap file.
        IMAGE_FILE_SYSTEM = 0x1000,  // System File.
        IMAGE_FILE_DLL = 0x2000,  // File is a DLL.
        IMAGE_FILE_UP_SYSTEM_ONLY = 0x4000,  // File should only be run on a UP machine
        IMAGE_FILE_BYTES_REVERSED_HI = 0x8000,  // Bytes of machine word are reversed.
    }

    [Flags]
    public enum IMAGE_SCN : uint
    {
        // IMAGE_SCN_TYPE_REG = 0x00000000  // Reserved.
        // IMAGE_SCN_TYPE_DSECT = 0x00000001  // Reserved.
        // IMAGE_SCN_TYPE_NOLOAD = 0x00000002  // Reserved.
        // IMAGE_SCN_TYPE_GROUP = 0x00000004  // Reserved.
        IMAGE_SCN_TYPE_NO_PAD = 0x00000008,  // Reserved.
        // IMAGE_SCN_TYPE_COPY = 0x00000010  // Reserved.

        IMAGE_SCN_CNT_CODE = 0x00000020,  // Section contains code.
        IMAGE_SCN_CNT_INITIALIZED_DATA = 0x00000040,  // Section contains initialized data.
        IMAGE_SCN_CNT_UNINITIALIZED_DATA = 0x00000080,  // Section contains uninitialized data.

        IMAGE_SCN_LNK_OTHER = 0x00000100,  // Reserved.
        IMAGE_SCN_LNK_INFO = 0x00000200,  // Section contains comments or some other type of information.
        // IMAGE_SCN_TYPE_OVER =  0x00000400  // Reserved.
        IMAGE_SCN_LNK_REMOVE = 0x00000800, // Section contents will not become part of image.
        IMAGE_SCN_LNK_COMDAT = 0x00001000, // Section contents comdat.
        // 0x00002000  // Reserved.
        // IMAGE_SCN_MEM_PROTECTED - Obsolete   0x00004000
        IMAGE_SCN_NO_DEFER_SPEC_EXC = 0x00004000, // Reset speculative exceptions handling bits in the TLB entries for this section.
        IMAGE_SCN_GPREL = 0x00008000, // Section content can be accessed relative to GP
        IMAGE_SCN_MEM_FARDATA = 0x00008000,
        // IMAGE_SCN_MEM_SYSHEAP  - Obsolete    0x00010000
        IMAGE_SCN_MEM_PURGEABLE = 0x00020000,
        IMAGE_SCN_MEM_16BIT = 0x00020000,
        IMAGE_SCN_MEM_LOCKED = 0x00040000,
        IMAGE_SCN_MEM_PRELOAD = 0x00080000,

        IMAGE_SCN_ALIGN_1BYTES = 0x00100000,
        IMAGE_SCN_ALIGN_2BYTES = 0x00200000,
        IMAGE_SCN_ALIGN_4BYTES = 0x00300000,
        IMAGE_SCN_ALIGN_8BYTES = 0x00400000,
        IMAGE_SCN_ALIGN_16BYTES = 0x00500000, // Default alignment if no others are specified.
        IMAGE_SCN_ALIGN_32BYTES = 0x00600000,
        IMAGE_SCN_ALIGN_64BYTES = 0x00700000,
        IMAGE_SCN_ALIGN_128BYTES = 0x00800000,
        IMAGE_SCN_ALIGN_256BYTES = 0x00900000,
        IMAGE_SCN_ALIGN_512BYTES = 0x00A00000,
        IMAGE_SCN_ALIGN_1024BYTES = 0x00B00000,
        IMAGE_SCN_ALIGN_2048BYTES = 0x00C00000,
        IMAGE_SCN_ALIGN_4096BYTES = 0x00D00000,
        IMAGE_SCN_ALIGN_8192BYTES = 0x00E00000,
        // Unused 0x00F00000
        IMAGE_SCN_ALIGN_MASK = 0x00F00000,

        IMAGE_SCN_LNK_NRELOC_OVFL = 0x01000000, // Section contains extended relocations.
        IMAGE_SCN_MEM_DISCARDABLE = 0x02000000, // Section can be discarded.
        IMAGE_SCN_MEM_NOT_CACHED = 0x04000000, // Section is not cachable.
        IMAGE_SCN_MEM_NOT_PAGED = 0x08000000, // Section is not pageable.
        IMAGE_SCN_MEM_SHARED = 0x10000000, // Section is shareable.
        IMAGE_SCN_MEM_EXECUTE = 0x20000000, // Section is executable.
        IMAGE_SCN_MEM_READ = 0x40000000, // Section is readable.
        IMAGE_SCN_MEM_WRITE = 0x80000000, // Section is writeable.
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
    }

    [Flags]
    public enum IMAGE_SYM_DTYPE : ushort
    {
        IMAGE_SYM_DTYPE_NULL = 0x00, // no derived type.
        IMAGE_SYM_DTYPE_POINTER = 0x01, // pointer.
        IMAGE_SYM_DTYPE_FUNCTION = 0x02, // function.
        IMAGE_SYM_DTYPE_ARRAY = 0x03, // array.
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
