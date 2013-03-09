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

        public ObjectFile ObjectFile { get { return _objectFile; } }


        public override void FromStream(Stream stream)
        {
            base.FromStream(stream);

            long endOffset = (stream.Position + Header.Size + 1) & ~0x1;

            _objectFile.FromStream(stream);
            
            stream.Seek(endOffset, SeekOrigin.Begin);
        }
    }
}
