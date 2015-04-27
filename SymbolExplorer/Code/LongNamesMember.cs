using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.Code
{
    public class LongNamesMember : ArchiveMember
    {
        Dictionary<long, string> _names = new Dictionary<long, string>();

        public Dictionary<long, string> Names { get { return _names; } }

        public string GetNameForOffset(int offset)
        {
            return _names[offset];
        }

        public override void FromStream(Stream stream)
        {
            base.FromStream(stream);

            long endOffset = (stream.Position + Header.Size + 1) & ~0x1;

            long begin = stream.Position;
            long end = begin + Header.Size;

            BinaryReader reader = new BinaryReader(stream, Encoding.ASCII);

            _names.Clear();

            StringBuilder sb = new StringBuilder(1024);

            long start = stream.Position;

            while (stream.Position < end)
            {
                long offset = stream.Position - start;
                char c;
                while ((stream.Position < end) && ((c = reader.ReadChar()) != 0))
                {
                    sb.Append(c);
                }

                _names.Add(offset, sb.ToString());
                sb.Clear();
            }


            Debug.Assert(stream.Position == end);

            stream.Seek(endOffset, SeekOrigin.Begin);
        }
    }
}
