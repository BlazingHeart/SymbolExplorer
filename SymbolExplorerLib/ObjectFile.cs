using SymbolExplorerLib.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public IMAGE_FILE_HEADER Header { get; private set; }

        public OptionalHeader OptionalHeader { get; private set; }

        public ImageSection[] Sections { get; private set; }

        public IMAGE_SYMBOL[] Symbols { get; private set; }

        public Dictionary<long, string> StringTable { get; private set; }


        public void FromStream(Stream stream)
        {
            long fileStart = stream.Position;
            Header = Utils.StreamToStructure<IMAGE_FILE_HEADER>(stream);

            OptionalHeader = new OptionalHeader();
            StringTable = new Dictionary<long, string>();

            // Optional header
            if (Header.SizeOfOptionalHeader != 0)
            {
                OptionalHeader.FromStream(stream, Header.SizeOfOptionalHeader);
            }

            if (Header.NumberOfSections > Constants.IMAGE_SYM_SECTION_MAX)
            {
                Sections = new ImageSection[0];
                Symbols = new IMAGE_SYMBOL[0];
                return;
            }

            Sections = new ImageSection[Header.NumberOfSections];
            Symbols = new IMAGE_SYMBOL[Header.NumberOfSymbols];

            // Section table
            for (int i = 0; i < Header.NumberOfSections; ++i)
            {
                IMAGE_SECTION_HEADER sectionHeader = Utils.StreamToStructure<IMAGE_SECTION_HEADER>(stream);
                Sections[i].Header = sectionHeader;
            }

            // Section data
            for (int i = 0; i < Header.NumberOfSections; ++i)
            {
                Sections[i].RawOffset = stream.Position;
                uint size = Sections[i].Header.SizeOfRawData;
                Sections[i].RawData = new byte[size];
                stream.Read(Sections[i].RawData, 0, (int)size);
            }

            // Symbol table
            if (Header.NumberOfSymbols != 0)
            {
                long offset = fileStart + Header.PointerToSymbolTable;
                stream.Seek(offset, SeekOrigin.Begin);

                long count = Header.NumberOfSymbols;
                for (int i = 0; i < count; ++i)
                {
                    Symbols[i] = Utils.StreamToStructure<IMAGE_SYMBOL>(stream);
                }
            }

            {
                BinaryReader reader = new BinaryReader(stream, Encoding.ASCII);

                long start = stream.Position;
                uint stringTableSize = reader.ReadUInt32();

                long end = start + stringTableSize;

                StringBuilder sb = new StringBuilder(1024);

                while (stream.Position < end)
                {
                    long offset = stream.Position - start;
                    char c;
                    while ((stream.Position < end) && ((c = reader.ReadChar()) != 0))
                    {
                        sb.Append(c);
                    }

                    StringTable.Add(offset, sb.ToString());
                    sb.Clear();
                }
            }


            foreach (var section in Sections)
            {
                //LoadRelocations(section);
            }
        }

        public static void LoadRelocations(ImageSection section)
        {
            section.Relocations = new IMAGE_RELOCATION[section.Header.NumberOfRelocations];

            if (section.Header.PointerToRelocations != 0)
            {
                MemoryStream stream = new MemoryStream(section.RawData);

                //Debug.Assert(section.Header.PointerToRelocations > section.RawOffset);
                //Debug.Assert(section.Header.PointerToRelocations < section.RawData.Length);

                stream.Seek(section.Header.PointerToRelocations - Constants.IMAGE_SIZEOF_SECTION_HEADER, SeekOrigin.Begin);

                for (int i = 0; i < section.Header.NumberOfRelocations; ++i)
                {
                    section.Relocations[i] = Utils.StreamToStructure<IMAGE_RELOCATION>(stream);
                }
            }
        }
    }
}
