using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorerLib.Native
{
    [Flags]
    public enum SectionCharacteristics : uint
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

    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_SECTION_HEADER
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.IMAGE_SIZEOF_SHORT_NAME)]
        public byte[] Name;

        public uint PhysicalAddressOrVirtualSize;
        public uint VirtualAddress;
        public uint SizeOfRawData;
        public uint PointerToRawData;
        public uint PointerToRelocations;
        public uint PointerToLinenumbers;
        public ushort NumberOfRelocations;
        public ushort NumberOfLinenumbers;
        public SectionCharacteristics Characteristics;
    }
}
