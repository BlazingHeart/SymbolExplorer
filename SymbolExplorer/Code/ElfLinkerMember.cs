using SymbolExplorer.Code.Unix;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Code
{
    public class ElfLinkerMember : ArchiveMember
    {
        Elf32_Ehdr ElfHeader = new Elf32_Ehdr();

        public override void FromStream(Stream stream)
        {
            base.FromStream(stream);

            //long endOffset = (stream.Position + Header.Size + 1) & ~0x1;

            ElfHeader = NativeUtils.StreamToStructure<Elf32_Ehdr>(stream);

            if ((ElfHeader.e_ident[0] != Constants.ELFMAG0) ||
                (ElfHeader.e_ident[1] != Constants.ELFMAG1) ||
                (ElfHeader.e_ident[2] != Constants.ELFMAG2) ||
                (ElfHeader.e_ident[3] != Constants.ELFMAG3))
            {
                throw new InvalidDataException("not an elf file");
            }

            ELFCLASS fileClass = (ELFCLASS)ElfHeader.e_ident[(int)EIDENT.EI_CLASS];
            ELFDATA dataClass = (ELFDATA)ElfHeader.e_ident[(int)EIDENT.EI_DATA];
            ELFVERSION version = (ELFVERSION)ElfHeader.e_ident[(int)EIDENT.EI_VERSION];
            ELFOSABI osAbi = (ELFOSABI)ElfHeader.e_ident[(int)EIDENT.EI_OSABI];
            byte abiVersion = ElfHeader.e_ident[(int)EIDENT.EI_ABIVERSION];

            if ((fileClass == ELFCLASS.ELFCLASSNONE) || (dataClass == ELFDATA.ELFDATANONE) || (version == ELFVERSION.EV_NONE))
            {
                throw new InvalidDataException("not an elf file");
            }

            // is big endian
            if (dataClass == ELFDATA.ELFDATA2MSB)
            {
                ElfHeader.e_type = (ETYPE)NativeUtils.SwapEndian((ushort)ElfHeader.e_type);
                ElfHeader.e_machine = (EMACHINE)NativeUtils.SwapEndian((ushort)ElfHeader.e_machine);
                ElfHeader.e_version = (EVERSION)NativeUtils.SwapEndian((uint)ElfHeader.e_version);
                ElfHeader.e_entry = NativeUtils.SwapEndian(ElfHeader.e_entry);
                ElfHeader.e_phoff = NativeUtils.SwapEndian(ElfHeader.e_phoff);
                ElfHeader.e_shoff = NativeUtils.SwapEndian(ElfHeader.e_shoff);
                ElfHeader.e_flags = NativeUtils.SwapEndian(ElfHeader.e_flags);
                ElfHeader.e_ehsize = NativeUtils.SwapEndian(ElfHeader.e_ehsize);
                ElfHeader.e_phentsize = NativeUtils.SwapEndian(ElfHeader.e_phentsize);
                ElfHeader.e_phnum = NativeUtils.SwapEndian(ElfHeader.e_phnum);
                ElfHeader.e_shentsize = NativeUtils.SwapEndian(ElfHeader.e_shentsize);
                ElfHeader.e_shnum = NativeUtils.SwapEndian(ElfHeader.e_shnum);
                ElfHeader.e_shstrndx = NativeUtils.SwapEndian(ElfHeader.e_shstrndx);
            }
            
            //stream.Seek(endOffset, SeekOrigin.Begin);
        }
    }
}
