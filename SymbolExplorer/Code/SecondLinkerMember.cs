using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.Code
{
    public class SecondLinkerMember : ArchiveMember
    {
        public struct SymbolIndex
        {
            public string Name;
            public ushort Index;
        }

        public uint[] MemberOffsets { get; set; }
        public SymbolIndex[] SymbolIndices { get; set; }

        public long MemberCount { get { return MemberOffsets.Length; } }
        public long SymbolCount { get { return SymbolIndices.Length; } }

        public override void FromStream(Stream stream)
        {
            base.FromStream(stream);

            long endOffset = (stream.Position + Header.Size + 1) & ~0x1;

            BinaryReader reader = new BinaryReader(stream);

            uint memberCount = reader.ReadUInt32();

            MemberOffsets = new uint[memberCount];

            for (uint i = 0; i < MemberOffsets.Length; ++i)
            {
                MemberOffsets[i] = reader.ReadUInt32();
            }

            uint symbolCount = reader.ReadUInt32();

            SymbolIndices = new SymbolIndex[symbolCount];

            for (uint i = 0; i < SymbolIndices.Length; ++i)
            {
                SymbolIndices[i].Index = reader.ReadUInt16();
            }

            StringBuilder sb = new StringBuilder(1024);
            for (uint i = 0; i < SymbolIndices.Length; ++i)
            {
                char c;
                while ((c = reader.ReadChar()) != 0)
                {
                    sb.Append(c);
                }

                SymbolIndices[i].Name = sb.ToString();
                sb.Clear();
            }

            stream.Seek(endOffset, SeekOrigin.Begin);
        }
    }
}
