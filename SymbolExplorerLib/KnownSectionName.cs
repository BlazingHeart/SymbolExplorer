using SymbolExplorerLib.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace SymbolExplorerLib
{
    class KnownSectionName
    {
        string SectionName;
        string ContentDescription;
        SectionCharacteristics Characteristics;

        static KnownSectionName[] KnownSectionNames = new KnownSectionName[] {
            new KnownSectionName { SectionName = ".bss", ContentDescription = "Uninitialized data (free format)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_UNINITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_WRITE },
            new KnownSectionName { SectionName = ".cormeta", ContentDescription = "CLR metadata that indicates that the object file contains managed code", Characteristics = SectionCharacteristics.IMAGE_SCN_LNK_INFO},
            new KnownSectionName { SectionName = ".data", ContentDescription = "Initialized data (free format)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_WRITE},
            new KnownSectionName { SectionName = ".debug$F", ContentDescription = "Generated FPO debug information (object only, x86 architecture only, and now obsolete)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_DISCARDABLE },
            new KnownSectionName { SectionName = ".debug$P", ContentDescription = "Precompiled debug types (object only)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_DISCARDABLE },
            new KnownSectionName { SectionName = ".debug$S", ContentDescription = "Debug symbols (object only)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_DISCARDABLE },
            new KnownSectionName { SectionName = ".debug$T", ContentDescription = "Debug types (object only)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_DISCARDABLE },
            new KnownSectionName { SectionName = ".drective", ContentDescription = "Linker options", Characteristics = SectionCharacteristics.IMAGE_SCN_LNK_INFO },
            new KnownSectionName { SectionName = ".edata", ContentDescription = "Export tables", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ },
            new KnownSectionName { SectionName = ".idata", ContentDescription = "Import tables", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_WRITE },
            new KnownSectionName { SectionName = ".idlsym", ContentDescription = "Includes registered SEH (image only) to support IDL attributes.", Characteristics = SectionCharacteristics.IMAGE_SCN_LNK_INFO },
            new KnownSectionName { SectionName = ".pdata", ContentDescription = "Exception information", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ },
            new KnownSectionName { SectionName = ".rdata", ContentDescription = "Read-only initialized data", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ },
            new KnownSectionName { SectionName = ".reloc", ContentDescription = "Image relocations", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_DISCARDABLE },
            new KnownSectionName { SectionName = ".rsrc", ContentDescription = "Resource directory", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ },
            new KnownSectionName { SectionName = ".sbss", ContentDescription = "GP-relative uninitialized data (free format)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_UNINITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_WRITE | SectionCharacteristics.IMAGE_SCN_GPREL },
            new KnownSectionName { SectionName = ".sdata", ContentDescription = "GP-relative initialized data (free format)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_WRITE | SectionCharacteristics.IMAGE_SCN_GPREL },
            new KnownSectionName { SectionName = ".srdata", ContentDescription = "GP-relative read-only data (free format)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_GPREL },
            new KnownSectionName { SectionName = ".sxdata", ContentDescription = "Registered exception handler data (free format and x86/object only)", Characteristics = SectionCharacteristics.IMAGE_SCN_LNK_INFO },
            new KnownSectionName { SectionName = ".text", ContentDescription = "Executable code (free format)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_CODE | SectionCharacteristics.IMAGE_SCN_MEM_EXECUTE | SectionCharacteristics.IMAGE_SCN_MEM_READ },
            new KnownSectionName { SectionName = ".tls", ContentDescription = "Thread-local storage (object  only)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_WRITE },
            new KnownSectionName { SectionName = ".tls$", ContentDescription = "Thread-local storage (object only)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_WRITE },
            new KnownSectionName { SectionName = ".vsdata", ContentDescription = "GP-relative initialized data (free format and for ARM, SH4, and Thumb architectures only)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ | SectionCharacteristics.IMAGE_SCN_MEM_WRITE },
            new KnownSectionName { SectionName = ".xdata", ContentDescription = "Exception information (free format)", Characteristics = SectionCharacteristics.IMAGE_SCN_CNT_INITIALIZED_DATA | SectionCharacteristics.IMAGE_SCN_MEM_READ },
        };
    }
}
