using SymbolExplorer.Code.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace SymbolExplorer.Code
{
    class KnownSectionName
    {
        string SectionName;
        string ContentDescription;
        IMAGE_SCN Characteristics;

        static KnownSectionName[] KnownSectionNames = new KnownSectionName[] {
            new KnownSectionName { SectionName = ".bss", ContentDescription = "Uninitialized data (free format)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_UNINITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_WRITE },
            new KnownSectionName { SectionName = ".cormeta", ContentDescription = "CLR metadata that indicates that the object file contains managed code", Characteristics = IMAGE_SCN.IMAGE_SCN_LNK_INFO},
            new KnownSectionName { SectionName = ".data", ContentDescription = "Initialized data (free format)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_WRITE},
            new KnownSectionName { SectionName = ".debug$F", ContentDescription = "Generated FPO debug information (object only, x86 architecture only, and now obsolete)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_DISCARDABLE },
            new KnownSectionName { SectionName = ".debug$P", ContentDescription = "Precompiled debug types (object only)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_DISCARDABLE },
            new KnownSectionName { SectionName = ".debug$S", ContentDescription = "Debug symbols (object only)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_DISCARDABLE },
            new KnownSectionName { SectionName = ".debug$T", ContentDescription = "Debug types (object only)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_DISCARDABLE },
            new KnownSectionName { SectionName = ".drective", ContentDescription = "Linker options", Characteristics = IMAGE_SCN.IMAGE_SCN_LNK_INFO },
            new KnownSectionName { SectionName = ".edata", ContentDescription = "Export tables", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ },
            new KnownSectionName { SectionName = ".idata", ContentDescription = "Import tables", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_WRITE },
            new KnownSectionName { SectionName = ".idlsym", ContentDescription = "Includes registered SEH (image only) to support IDL attributes.", Characteristics = IMAGE_SCN.IMAGE_SCN_LNK_INFO },
            new KnownSectionName { SectionName = ".pdata", ContentDescription = "Exception information", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ },
            new KnownSectionName { SectionName = ".rdata", ContentDescription = "Read-only initialized data", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ },
            new KnownSectionName { SectionName = ".reloc", ContentDescription = "Image relocations", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_DISCARDABLE },
            new KnownSectionName { SectionName = ".rsrc", ContentDescription = "Resource directory", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ },
            new KnownSectionName { SectionName = ".sbss", ContentDescription = "GP-relative uninitialized data (free format)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_UNINITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_WRITE | IMAGE_SCN.IMAGE_SCN_GPREL },
            new KnownSectionName { SectionName = ".sdata", ContentDescription = "GP-relative initialized data (free format)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_WRITE | IMAGE_SCN.IMAGE_SCN_GPREL },
            new KnownSectionName { SectionName = ".srdata", ContentDescription = "GP-relative read-only data (free format)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_GPREL },
            new KnownSectionName { SectionName = ".sxdata", ContentDescription = "Registered exception handler data (free format and x86/object only)", Characteristics = IMAGE_SCN.IMAGE_SCN_LNK_INFO },
            new KnownSectionName { SectionName = ".text", ContentDescription = "Executable code (free format)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_CODE | IMAGE_SCN.IMAGE_SCN_MEM_EXECUTE | IMAGE_SCN.IMAGE_SCN_MEM_READ },
            new KnownSectionName { SectionName = ".tls", ContentDescription = "Thread-local storage (object only)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_WRITE },
            new KnownSectionName { SectionName = ".tls$", ContentDescription = "Thread-local storage (object only)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_WRITE },
            new KnownSectionName { SectionName = ".vsdata", ContentDescription = "GP-relative initialized data (free format and for ARM, SH4, and Thumb architectures only)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ | IMAGE_SCN.IMAGE_SCN_MEM_WRITE },
            new KnownSectionName { SectionName = ".xdata", ContentDescription = "Exception information (free format)", Characteristics = IMAGE_SCN.IMAGE_SCN_CNT_INITIALIZED_DATA | IMAGE_SCN.IMAGE_SCN_MEM_READ },
        };

        KnownSectionName Find(string sectionName)
        {
            var q = from section in KnownSectionNames
                    where section.SectionName == sectionName
                    select section;

            return q.SingleOrDefault();
        }
    }
}
