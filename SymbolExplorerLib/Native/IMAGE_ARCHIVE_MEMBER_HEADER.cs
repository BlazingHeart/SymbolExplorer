using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorerLib.Native
{
    [Flags]
    public enum ST_MODE
    {
        None = 0,

        _S_IFMT = 0xF000, // File type mask
        _S_IFDIR = 0x4000, // Directory
        _S_IFCHR = 0x2000, // Character special (indicates a device if set)
        _S_IFIFO = 0x1000, // Pipe
        _S_IFREG = 0x8000, // Regular
        _S_IREAD = 0x0100, // Read permission, owner
        _S_IWRITE = 0x0080, // Write permission, owner
        _S_IEXEC = 0x0040, // Execute/search permission, owner


        _S_1 = 0x0001,
        _S_2 = 0x0002,
        _S_3 = 0x0004,
        _S_4 = 0x0008,
        _S_5 = 0x0010,
        _S_6 = 0x0020,
    };

    [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Ansi)]
    public struct IMAGE_ARCHIVE_MEMBER_HEADER
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Name;                            // File member name - `/' terminated.

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] Date;                          // File member date - decimal.

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] UserID;                         // File member user id - decimal.

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] GroupID;                        // File member group id - decimal.

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Mode;                           // File member mode - octal.

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] Size;                          // File member size - decimal.

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] EndHeader;                      // String to end header.
    }
}
