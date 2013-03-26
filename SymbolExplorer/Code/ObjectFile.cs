using SymbolExplorer.Code.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Code
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

        public ANON_OBJECT_HEADER AnonHeader { get; private set; }
        public ANON_OBJECT_HEADER_V2 AnonHeaderV2 { get; private set; }
        public ANON_OBJECT_HEADER_BIGOBJ AnonHeaderBigObj { get; private set; }
        public byte[] SectionData { get; private set; }

        public OptionalHeader OptionalHeader { get; private set; }

        public ImageSection[] Sections { get; private set; }

        public IMAGE_SYMBOL[] Symbols { get; private set; }

        public Dictionary<long, string> StringTable { get; private set; }


        public void FromStream(Stream stream)
        {
            long fileStart = stream.Position;
            Header = NativeUtils.StreamToStructure<IMAGE_FILE_HEADER>(stream);

            OptionalHeader = new OptionalHeader();
            StringTable = new Dictionary<long, string>();

            if ((Header.Machine == IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_UNKNOWN) && (Header.NumberOfSections == Constants.IMAGE_SYM_SECTION_ANON))
            {
                stream.Seek(fileStart, SeekOrigin.Begin);
                AnonHeader = NativeUtils.StreamToStructure<ANON_OBJECT_HEADER>(stream);

                if (AnonHeader.Version >= 2)
                {
                    stream.Seek(fileStart, SeekOrigin.Begin);
                    AnonHeaderV2 = NativeUtils.StreamToStructure<ANON_OBJECT_HEADER_V2>(stream);

                    if (AnonHeaderV2.ClassID == Constants.ANON_OBJECT_HEADER_BIGOBJ_CLASSID)
                    {
                        stream.Seek(fileStart, SeekOrigin.Begin);
                        AnonHeaderBigObj = NativeUtils.StreamToStructure<ANON_OBJECT_HEADER_BIGOBJ>(stream);
                    }
                }

                SectionData = new byte[0];

                Sections = new ImageSection[0];
                Symbols = new IMAGE_SYMBOL[0];

                return;
            }

            // Optional header
            if (Header.SizeOfOptionalHeader != 0)
            {
                OptionalHeader.FromStream(stream, Header.SizeOfOptionalHeader);
            }

            if (Header.NumberOfSections > Constants.IMAGE_SYM_SECTION_MAX)
            {
                throw new InvalidDataException("Can't parse object file");
            }

            Sections = new ImageSection[Header.NumberOfSections];
            Symbols = new IMAGE_SYMBOL[Header.NumberOfSymbols];

            // Section table
            for (int i = 0; i < Header.NumberOfSections; ++i)
            {
                IMAGE_SECTION_HEADER sectionHeader = NativeUtils.StreamToStructure<IMAGE_SECTION_HEADER>(stream);
                Sections[i].Header = sectionHeader;
            }

            // Section data
            for (int i = 0; i < Header.NumberOfSections; ++i)
            {
                Sections[i].RawOffset = stream.Position - fileStart;
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
                    Symbols[i] = NativeUtils.StreamToStructure<IMAGE_SYMBOL>(stream);
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

            for (int i = 0; i < Sections.Length; ++i)
            {
                ImageSection section = Sections[i];
                section.Relocations = new IMAGE_RELOCATION[section.Header.NumberOfRelocations];

                if (section.Header.PointerToRelocations != 0)
                {
                    stream.Seek(fileStart + section.Header.PointerToRelocations, SeekOrigin.Begin);

                    for (int r = 0; r < section.Header.NumberOfRelocations; ++r)
                    {
                        section.Relocations[r] = NativeUtils.StreamToStructure<IMAGE_RELOCATION>(stream);
                    }
                }
            }
        }
    }
}
