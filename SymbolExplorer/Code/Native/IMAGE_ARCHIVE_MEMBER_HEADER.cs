using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorerLib.Native
{
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
