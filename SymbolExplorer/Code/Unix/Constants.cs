using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Code.Unix
{
    public class Constants
    {
        public const int EI_NIDENT = 16;


        // Fields in the e_ident array.  The EI_* macros are indices into the
        // array.  The macros under each EI_* macro are the values the byte
        // may have. 

        public const int EI_MAG0 = 0;       // File identification byte 0 index
        public const int ELFMAG0 = 0x7f;    // Magic number byte 0

        public const int EI_MAG1 = 1;       // File identification byte 1 index
        public const int ELFMAG1 = 'E';     // Magic number byte 1

        public const int EI_MAG2 = 2;       // File identification byte 2 index
        public const int ELFMAG2 = 'L';     // Magic number byte 2

        public const int EI_MAG3 = 3;       // File identification byte 3 index
        public const int ELFMAG3 = 'F';     // Magic number byte 3

        // Conglomeration of the identification bytes, for easy testing as a word. 
        public const string ELFMAG = "\x7FELF";
        public const int SELFMAG = 4;

        public const int EI_CLASS = 4;      // File class byte index
        public const int ELFCLASSNONE = 0;  // Invalid class
        public const int ELFCLASS32 = 1;    // 32-bit objects
        public const int ELFCLASS64 = 2;    // 64-bit objects
        public const int ELFCLASSNUM = 3;

        public const int EI_DATA = 5;       // Data encoding byte index
        public const int ELFDATANONE = 0;   // Invalid data encoding
        public const int ELFDATA2LSB = 1;   // 2's complement, little endian
        public const int ELFDATA2MSB = 2;   // 2's complement, big endian
        public const int ELFDATANUM = 3;

        public const int EI_VERSION = 6;    // File version byte index
        // Value must be EV_CURRENT

        public const int EI_OSABI = 7;                  // OS ABI identification
        public const int ELFOSABI_NONE = 0;             // UNIX System V ABI
        public const int ELFOSABI_SYSV = 0;             // Alias. 
        public const int ELFOSABI_HPUX = 1;             // HP-UX
        public const int ELFOSABI_NETBSD = 2;           // NetBSD. 
        public const int ELFOSABI_GNU = 3;              // Object uses GNU ELF extensions. 
        public const int ELFOSABI_LINUX = ELFOSABI_GNU; // Compatibility alias. 
        public const int ELFOSABI_SOLARIS = 6;          // Sun Solaris. 
        public const int ELFOSABI_AIX = 7;              // IBM AIX. 
        public const int ELFOSABI_IRIX = 8;             // SGI Irix. 
        public const int ELFOSABI_FREEBSD = 9;          // FreeBSD. 
        public const int ELFOSABI_TRU64 = 10;           // Compaq TRU64 UNIX. 
        public const int ELFOSABI_MODESTO = 11;         // Novell Modesto. 
        public const int ELFOSABI_OPENBSD = 12;         // OpenBSD. 
        public const int ELFOSABI_ARM_AEABI = 64;       // ARM EABI
        public const int ELFOSABI_ARM = 97;             // ARM
        public const int ELFOSABI_STANDALONE = 255;     // Standalone (embedded) application

        public const int EI_ABIVERSION = 8;     // ABI version

        public const int EI_PAD = 9;            // Byte index of padding bytes

        // Legal values for e_type (object file type). 

        public const int ET_NONE = 0;           // No file type
        public const int ET_REL = 1;            // Relocatable file
        public const int ET_EXEC = 2;           // Executable file
        public const int ET_DYN = 3;            // Shared object file
        public const int ET_CORE = 4;           // Core file
        public const int ET_NUM = 5;            // Number of defined types
        public const int ET_LOOS = 0xfe00;      // OS-specific range start
        public const int ET_HIOS = 0xfeff;      // OS-specific range end
        public const int ET_LOPROC = 0xff00;    // Processor-specific range start
        public const int ET_HIPROC = 0xffff;    // Processor-specific range end

        // Legal values for e_machine (architecture). 

        public const int EM_NONE = 0;           // No machine
        public const int EM_M32 = 1;            // AT&T WE 32100
        public const int EM_SPARC = 2;          // SUN SPARC
        public const int EM_386 = 3;            // Intel 80386
        public const int EM_68K = 4;            // Motorola m68k family
        public const int EM_88K = 5;            // Motorola m88k family
        public const int EM_860 = 7;            // Intel 80860
        public const int EM_MIPS = 8;           // MIPS R3000 big-endian
        public const int EM_S370 = 9;           // IBM System/370
        public const int EM_MIPS_RS3_LE = 10;   // MIPS R3000 little-endian

        public const int EM_PARISC = 15;        // HPPA
        public const int EM_VPP500 = 17;        // Fujitsu VPP500
        public const int EM_SPARC32PLUS = 18;   // Sun's "v8plus"
        public const int EM_960 = 19;           // Intel 80960
        public const int EM_PPC = 20;           // PowerPC
        public const int EM_PPC64 = 21;         // PowerPC 64-bit
        public const int EM_S390 = 22;          // IBM S390

        public const int EM_V800 = 36;          // NEC V800 series
        public const int EM_FR20 = 37;          // Fujitsu FR20
        public const int EM_RH32 = 38;          // TRW RH-32
        public const int EM_RCE = 39;           // Motorola RCE
        public const int EM_ARM = 40;           // ARM
        public const int EM_FAKE_ALPHA = 41;    // Digital Alpha
        public const int EM_SH = 42;            // Hitachi SH
        public const int EM_SPARCV9 = 43;       // SPARC v9 64-bit
        public const int EM_TRICORE = 44;       // Siemens Tricore
        public const int EM_ARC = 45;           // Argonaut RISC Core
        public const int EM_H8_300 = 46;        // Hitachi H8/300
        public const int EM_H8_300H = 47;       // Hitachi H8/300H
        public const int EM_H8S = 48;           // Hitachi H8S
        public const int EM_H8_500 = 49;        // Hitachi H8/500
        public const int EM_IA_64 = 50;         // Intel Merced
        public const int EM_MIPS_X = 51;        // Stanford MIPS-X
        public const int EM_COLDFIRE = 52;      // Motorola Coldfire
        public const int EM_68HC12 = 53;        // Motorola M68HC12
        public const int EM_MMA = 54;           // Fujitsu MMA Multimedia Accelerator*/
        public const int EM_PCP = 55;           // Siemens PCP
        public const int EM_NCPU = 56;          // Sony nCPU embeeded RISC
        public const int EM_NDR1 = 57;          // Denso NDR1 microprocessor
        public const int EM_STARCORE = 58;      // Motorola Start*Core processor
        public const int EM_ME16 = 59;          // Toyota ME16 processor
        public const int EM_ST100 = 60;         // STMicroelectronic ST100 processor
        public const int EM_TINYJ = 61;         // Advanced Logic Corp. Tinyj emb.fam*/
        public const int EM_X86_64 = 62;        // AMD x86-64 architecture
        public const int EM_PDSP = 63;          // Sony DSP Processor

        public const int EM_FX66 = 66;          // Siemens FX66 microcontroller
        public const int EM_ST9PLUS = 67;       // STMicroelectronics ST9+ 8/16 mc
        public const int EM_ST7 = 68;           // STmicroelectronics ST7 8 bit mc
        public const int EM_68HC16 = 69;        // Motorola MC68HC16 microcontroller
        public const int EM_68HC11 = 70;        // Motorola MC68HC11 microcontroller
        public const int EM_68HC08 = 71;        // Motorola MC68HC08 microcontroller
        public const int EM_68HC05 = 72;        // Motorola MC68HC05 microcontroller
        public const int EM_SVX = 73;           // Silicon Graphics SVx
        public const int EM_ST19 = 74;          // STMicroelectronics ST19 8 bit mc
        public const int EM_VAX = 75;           // Digital VAX
        public const int EM_CRIS = 76;          // Axis Communications 32-bit embedded processor
        public const int EM_JAVELIN = 77;       // Infineon Technologies 32-bit embedded processor
        public const int EM_FIREPATH = 78;      // Element 14 64-bit DSP Processor
        public const int EM_ZSP = 79;           // LSI Logic 16-bit DSP Processor
        public const int EM_MMIX = 80;          // Donald Knuth's educational 64-bit processor
        public const int EM_HUANY = 81;         // Harvard University machine-independent object files
        public const int EM_PRISM = 82;         // SiTera Prism
        public const int EM_AVR = 83;           // Atmel AVR 8-bit microcontroller
        public const int EM_FR30 = 84;          // Fujitsu FR30
        public const int EM_D10V = 85;          // Mitsubishi D10V
        public const int EM_D30V = 86;          // Mitsubishi D30V
        public const int EM_V850 = 87;          // NEC v850
        public const int EM_M32R = 88;          // Mitsubishi M32R
        public const int EM_MN10300 = 89;       // Matsushita MN10300
        public const int EM_MN10200 = 90;       // Matsushita MN10200
        public const int EM_PJ = 91;            // picoJava
        public const int EM_OPENRISC = 92;      // OpenRISC 32-bit embedded processor
        public const int EM_ARC_A5 = 93;        // ARC Cores Tangent-A5
        public const int EM_XTENSA = 94;        // Tensilica Xtensa Architecture
        public const int EM_AARCH64 = 183;      // ARM AARCH64
        public const int EM_TILEPRO = 188;      // Tilera TILEPro
        public const int EM_TILEGX = 191;       // Tilera TILE-Gx
        public const int EM_NUM = 192;

        // If it is necessary to assign new unofficial EM_* values, please
        // pick large random numbers (0x8523, 0xa7f2, etc.) to minimize the
        // chances of collision with official or non-GNU unofficial values. 

        public const int EM_ALPHA = 0x9026;

        // Legal values for e_version (version). 

        public const int EV_NONE = 0;       // Invalid ELF version
        public const int EV_CURRENT = 1;    // Current version
        public const int EV_NUM = 2;

    }
}
