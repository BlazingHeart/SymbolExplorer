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
        public string[] Names;

        public override void FromStream(Stream stream)
        {
            base.FromStream(stream);

            long begin = stream.Position;
            long end = begin + Header.Size;

            BinaryReader reader = new BinaryReader(stream);

            List<string> names = new List<string>();

            StringBuilder sb = new StringBuilder(1024);

            while (stream.Position < end)
            {
                char c;
                while ((stream.Position < end) && ((c = reader.ReadChar()) != 0))
                {
                    sb.Append(c);
                }

                names.Add(sb.ToString());
                sb.Clear();
            }

            Names = names.ToArray();

            Debug.Assert(stream.Position == end);
        }
    }
}
