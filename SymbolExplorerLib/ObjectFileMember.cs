using SymbolExplorerLib.Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SymbolExplorerLib
{
    public class ObjectFileMember : ArchiveMember
    {
        public struct ImageSection
        {
            public IMAGE_SECTION_HEADER Header;
            public byte[] RawData;
        }
        
        public IMAGE_FILE_HEADER objHeader;

        public byte[] OptionalHeader;

        public ImageSection[] Sections;

        public override void FromStream(Stream stream)
        {
            long streamBaseOffset = stream.Position;

            base.FromStream(stream);

            long streamPostHeader = stream.Position;

            long streamEndOffset = streamPostHeader + Header.Size;
            
            objHeader = Utils.StreamToStructure<IMAGE_FILE_HEADER>(stream);

            if (objHeader.SizeOfOptionalHeader != 0)
            {
                int size = objHeader.SizeOfOptionalHeader;
                OptionalHeader = new byte[size];
                stream.Read(OptionalHeader, 0, size);
            }

            Sections = new ImageSection[objHeader.NumberOfSections];

            for (int i = 0; i < objHeader.NumberOfSections; ++i)
            {
                IMAGE_SECTION_HEADER sectionHeader = Utils.StreamToStructure<IMAGE_SECTION_HEADER>(stream);
                Sections[i].Header = sectionHeader;
            }

            for (int i = 0; i < objHeader.NumberOfSections; ++i)
            {
                uint size = Sections[i].Header.SizeOfRawData;
                Sections[i].RawData = new byte[size];
                stream.Read(Sections[i].RawData, 0, (int)size);
            }
        }
    }
}
