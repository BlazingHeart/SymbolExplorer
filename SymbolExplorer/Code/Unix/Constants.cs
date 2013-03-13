using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    public class Constants
    {
        public const int EI_NIDENT = 16;


        public const int ELFMAG0 = 0x7f;    // Magic number byte 0
        public const int ELFMAG1 = 'E';     // Magic number byte 1
        public const int ELFMAG2 = 'L';     // Magic number byte 2
        public const int ELFMAG3 = 'F';     // Magic number byte 3

        // Conglomeration of the identification bytes, for easy testing as a word. 
        public const string ELFMAG = "\x7FELF";
        public const int SELFMAG = 4;
    }

    // Fields in the e_ident array.  The EI_* macros are indices into the array.
    public enum EIDENT
    {
        EI_MAG0 = 0,        // File identification byte 0 index
        EI_MAG1 = 1,        // File identification byte 1 index
        EI_MAG2 = 2,        // File identification byte 2 index
        EI_MAG3 = 3,        // File identification byte 3 index
        EI_CLASS = 4,       // File class byte index
        EI_DATA = 5,        // Data encoding byte index
        EI_VERSION = 6,     // File version byte index (Value must be EV_CURRENT)
        EI_OSABI = 7,       // OS ABI identification
        EI_ABIVERSION = 8,  // ABI version
        EI_PAD = 9,         // Byte index of padding bytes
    }

    // for EI_CLASS
    public enum ELFCLASS : byte
    {
        ELFCLASSNONE = 0,  // Invalid class
        ELFCLASS32 = 1,    // 32-bit objects
        ELFCLASS64 = 2,    // 64-bit objects
        ELFCLASSNUM = 3,
    }

    // for EI_DATA
    public enum ELFDATA : byte
    {
        ELFDATANONE = 0,   // Invalid data encoding
        ELFDATA2LSB = 1,   // 2's complement, little endian
        ELFDATA2MSB = 2,   // 2's complement, big endian
        ELFDATANUM = 3,
    }

    // for EI_VERSION
    public enum ELFVERSION : byte
    {
        EV_NONE = 0,        // Invalid ELF version
        EV_CURRENT = 1,     // Current version
        EV_NUM = 2,
    }

    // Legal values for e_version (version). 
    public enum EVERSION : uint
    {
        EV_NONE = 0,        // Invalid ELF version
        EV_CURRENT = 1,     // Current version
        EV_NUM = 2,
    }

    // for EI_OSABI
    public enum ELFOSABI : byte
    {
        ELFOSABI_SYSV = 0,             // UNIX System V ABI 
        ELFOSABI_HPUX = 1,             // HP-UX
        ELFOSABI_NETBSD = 2,           // NetBSD. 
        ELFOSABI_GNU = 3,              // Object uses GNU ELF extensions. 
        ELFOSABI_LINUX = ELFOSABI_GNU, // Compatibility alias. 
        ELFOSABI_SOLARIS = 6,          // Sun Solaris. 
        ELFOSABI_AIX = 7,              // IBM AIX. 
        ELFOSABI_IRIX = 8,             // SGI Irix. 
        ELFOSABI_FREEBSD = 9,          // FreeBSD. 
        ELFOSABI_TRU64 = 10,           // Compaq TRU64 UNIX. 
        ELFOSABI_MODESTO = 11,         // Novell Modesto. 
        ELFOSABI_OPENBSD = 12,         // OpenBSD. 
        ELFOSABI_ARM_AEABI = 64,       // ARM EABI
        ELFOSABI_ARM = 97,             // ARM
        ELFOSABI_STANDALONE = 255,     // Standalone (embedded) application
    }

    // Legal values for e_type (object file type). 
    public enum ETYPE : ushort
    {
        ET_NONE = 0,           // No file type
        ET_REL = 1,            // Relocatable file
        ET_EXEC = 2,           // Executable file
        ET_DYN = 3,            // Shared object file
        ET_CORE = 4,           // Core file
        ET_NUM = 5,            // Number of defined types
        ET_LOOS = 0xfe00,      // OS-specific range start
        ET_HIOS = 0xfeff,      // OS-specific range end
        ET_LOPROC = 0xff00,    // Processor-specific range start
        ET_HIPROC = 0xffff,    // Processor-specific range end
    }

    // Legal values for e_machine (architecture). 
    public enum EMACHINE : ushort
    {
        EM_NONE = 0,           // No machine
        EM_M32 = 1,            // AT&T WE 32100
        EM_SPARC = 2,          // SUN SPARC
        EM_386 = 3,            // Intel 80386
        EM_68K = 4,            // Motorola m68k family
        EM_88K = 5,            // Motorola m88k family
        EM_860 = 7,            // Intel 80860
        EM_MIPS = 8,           // MIPS R3000 big-endian
        EM_S370 = 9,           // IBM System/370
        EM_MIPS_RS3_LE = 10,   // MIPS R3000 little-endian

        EM_PARISC = 15,        // HPPA
        EM_VPP500 = 17,        // Fujitsu VPP500
        EM_SPARC32PLUS = 18,   // Sun's "v8plus"
        EM_960 = 19,           // Intel 80960
        EM_PPC = 20,           // PowerPC
        EM_PPC64 = 21,         // PowerPC 64-bit
        EM_S390 = 22,          // IBM S390

        EM_V800 = 36,          // NEC V800 series
        EM_FR20 = 37,          // Fujitsu FR20
        EM_RH32 = 38,          // TRW RH-32
        EM_RCE = 39,           // Motorola RCE
        EM_ARM = 40,           // ARM
        EM_FAKE_ALPHA = 41,    // Digital Alpha
        EM_SH = 42,            // Hitachi SH
        EM_SPARCV9 = 43,       // SPARC v9 64-bit
        EM_TRICORE = 44,       // Siemens Tricore
        EM_ARC = 45,           // Argonaut RISC Core
        EM_H8_300 = 46,        // Hitachi H8/300
        EM_H8_300H = 47,       // Hitachi H8/300H
        EM_H8S = 48,           // Hitachi H8S
        EM_H8_500 = 49,        // Hitachi H8/500
        EM_IA_64 = 50,         // Intel Merced
        EM_MIPS_X = 51,        // Stanford MIPS-X
        EM_COLDFIRE = 52,      // Motorola Coldfire
        EM_68HC12 = 53,        // Motorola M68HC12
        EM_MMA = 54,           // Fujitsu MMA Multimedia Accelerator*/
        EM_PCP = 55,           // Siemens PCP
        EM_NCPU = 56,          // Sony nCPU embeeded RISC
        EM_NDR1 = 57,          // Denso NDR1 microprocessor
        EM_STARCORE = 58,      // Motorola Start*Core processor
        EM_ME16 = 59,          // Toyota ME16 processor
        EM_ST100 = 60,         // STMicroelectronic ST100 processor
        EM_TINYJ = 61,         // Advanced Logic Corp. Tinyj emb.fam*/
        EM_X86_64 = 62,        // AMD x86-64 architecture
        EM_PDSP = 63,          // Sony DSP Processor

        EM_FX66 = 66,          // Siemens FX66 microcontroller
        EM_ST9PLUS = 67,       // STMicroelectronics ST9+ 8/16 mc
        EM_ST7 = 68,           // STmicroelectronics ST7 8 bit mc
        EM_68HC16 = 69,        // Motorola MC68HC16 microcontroller
        EM_68HC11 = 70,        // Motorola MC68HC11 microcontroller
        EM_68HC08 = 71,        // Motorola MC68HC08 microcontroller
        EM_68HC05 = 72,        // Motorola MC68HC05 microcontroller
        EM_SVX = 73,           // Silicon Graphics SVx
        EM_ST19 = 74,          // STMicroelectronics ST19 8 bit mc
        EM_VAX = 75,           // Digital VAX
        EM_CRIS = 76,          // Axis Communications 32-bit embedded processor
        EM_JAVELIN = 77,       // Infineon Technologies 32-bit embedded processor
        EM_FIREPATH = 78,      // Element 14 64-bit DSP Processor
        EM_ZSP = 79,           // LSI Logic 16-bit DSP Processor
        EM_MMIX = 80,          // Donald Knuth's educational 64-bit processor
        EM_HUANY = 81,         // Harvard University machine-independent object files
        EM_PRISM = 82,         // SiTera Prism
        EM_AVR = 83,           // Atmel AVR 8-bit microcontroller
        EM_FR30 = 84,          // Fujitsu FR30
        EM_D10V = 85,          // Mitsubishi D10V
        EM_D30V = 86,          // Mitsubishi D30V
        EM_V850 = 87,          // NEC v850
        EM_M32R = 88,          // Mitsubishi M32R
        EM_MN10300 = 89,       // Matsushita MN10300
        EM_MN10200 = 90,       // Matsushita MN10200
        EM_PJ = 91,            // picoJava
        EM_OPENRISC = 92,      // OpenRISC 32-bit embedded processor
        EM_ARC_A5 = 93,        // ARC Cores Tangent-A5
        EM_XTENSA = 94,        // Tensilica Xtensa Architecture
        EM_AARCH64 = 183,      // ARM AARCH64
        EM_TILEPRO = 188,      // Tilera TILEPro
        EM_TILEGX = 191,       // Tilera TILE-Gx
        EM_NUM = 192,

        // If it is necessary to assign new unofficial EM_* values, please
        // pick large random numbers (0x8523, 0xa7f2, etc.) to minimize the
        // chances of collision with official or non-GNU unofficial values. 

        EM_ALPHA = 0x9026,
    }
}
