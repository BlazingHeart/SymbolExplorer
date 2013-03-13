using SymbolExplorer.Code.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.Code
{
    public class FirstLinkerMember : ArchiveMember
    {
        public struct SymbolOffset
        {
            public string Name;
            public uint Offset;
        }

        public SymbolOffset[] SymbolsOffsets { get; set; }

        public override void FromStream(Stream stream)
        {
            base.FromStream(stream);

            long endOffset = (stream.Position + Header.Size + 1) & ~0x1;

            BinaryReader reader = new BinaryReader(stream);

            uint symbolCount = NativeUtils.SwapEndian(reader.ReadUInt32());

            SymbolsOffsets = new SymbolOffset[symbolCount];

            for (uint i = 0; i < symbolCount; ++i)
            {
                SymbolsOffsets[i].Offset = reader.ReadUInt32();
            }

            StringBuilder sb = new StringBuilder(1024);
            for (uint i = 0; i < symbolCount; ++i)
            {
                char c;
                while ((c = reader.ReadChar()) != 0)
                {
                    sb.Append(c);
                }

                SymbolsOffsets[i].Name = sb.ToString();
                sb.Clear();
            }

            stream.Seek(endOffset, SeekOrigin.Begin);
        }
    }
}
