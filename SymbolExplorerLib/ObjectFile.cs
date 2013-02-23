using SymbolExplorerLib.Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SymbolExplorerLib
{
    public class ObjectFile
    {
        public struct ImageSection
        {
            public IMAGE_SECTION_HEADER Header;

            public long RawOffset;
            public byte[] RawData;

            public IMAGE_RELOCATION[] Relocations;
        }

        public IMAGE_FILE_HEADER objHeader { get; set; }

        public byte[] OptionalHeader { get; set; }

        public ImageSection[] Sections { get; set; }

        public IMAGE_SYMBOL[] Symbols { get; set; }


        public void FromStream(Stream stream)
        {
            long fileStart = stream.Position;
            objHeader = Utils.StreamToStructure<IMAGE_FILE_HEADER>(stream);

            OptionalHeader = new byte[objHeader.SizeOfOptionalHeader];
            Sections = new ImageSection[objHeader.NumberOfSections];
            Symbols = new IMAGE_SYMBOL[objHeader.NumberOfSymbols];

            // Optional header
            if (objHeader.SizeOfOptionalHeader != 0)
            {
                stream.Read(OptionalHeader, 0, objHeader.SizeOfOptionalHeader);
            }

            // Section table
            for (int i = 0; i < objHeader.NumberOfSections; ++i)
            {
                IMAGE_SECTION_HEADER sectionHeader = Utils.StreamToStructure<IMAGE_SECTION_HEADER>(stream);
                Sections[i].Header = sectionHeader;
            }

            // Section data
            for (int i = 0; i < objHeader.NumberOfSections; ++i)
            {
                Sections[i].RawOffset = stream.Position;
                uint size = Sections[i].Header.SizeOfRawData;
                Sections[i].RawData = new byte[size];
                stream.Read(Sections[i].RawData, 0, (int)size);
            }
            
            // Symbol table
            if (objHeader.NumberOfSymbols != 0)
            {
                long offset = fileStart + objHeader.PointerToSymbolTable;
                stream.Seek(offset, SeekOrigin.Begin);

                long count = objHeader.NumberOfSymbols;
                for (int i = 0; i < count; ++i)
                {
                    Symbols[i] = Utils.StreamToStructure<IMAGE_SYMBOL>(stream);
                }
            }

            foreach (var section in Sections)
            {
                //LoadRelocations(section);
            }
        }

        public static void LoadRelocations(ImageSection section)
        {
            if (section.Header.PointerToRelocations != 0)
            {
                MemoryStream stream = new MemoryStream(section.RawData);

                stream.Seek(section.Header.PointerToRelocations - Constants.IMAGE_SIZEOF_SECTION_HEADER, SeekOrigin.Begin);

                int count = section.Header.NumberOfRelocations;

                section.Relocations = new IMAGE_RELOCATION[count];

                for (int i = 0; i < count; ++i)
                {
                    section.Relocations[i] = Utils.StreamToStructure<IMAGE_RELOCATION>(stream);
                }
            }
            else
            {
                section.Relocations = new IMAGE_RELOCATION[0];
            }
        }
    }
}
