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
        ObjectFile _objectFile = new ObjectFile();

        public override void FromStream(Stream stream)
        {
            long streamBaseOffset = stream.Position;

            base.FromStream(stream);

            long streamPostHeader = stream.Position;

            _objectFile.FromStream(stream);

            long offset = (streamPostHeader + Header.Size + 1) & ~0x1;

            stream.Seek(offset, SeekOrigin.Begin);
        }
    }
}
