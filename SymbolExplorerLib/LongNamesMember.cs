using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorerLib
{
    public class LongNamesMember : ArchiveMember
    {
        Dictionary<long, string> _names { get; set; }

        public string GetNameForOffset(int offset)
        {
            return _names[offset];
        }

        public override void FromStream(Stream stream)
        {
            base.FromStream(stream);

            long begin = stream.Position;
            long end = begin + Header.Size;

            BinaryReader reader = new BinaryReader(stream, Encoding.ASCII);

            var names = new Dictionary<long, string>();

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

                names.Add(offset, sb.ToString());
                sb.Clear();
            }

            _names = names;

            Debug.Assert(stream.Position == end);
        }
    }
}
