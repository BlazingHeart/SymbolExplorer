using SymbolExplorerLib.Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SymbolExplorerLib
{
    public class OptionalHeader
    {
        OptionalHeaderBase _optionalHeaderBase;

        public OptionalHeaderBase OptionalHeaderBase { get { return _optionalHeaderBase; } }

        public void FromStream(Stream stream, int size)
        {
            long start = stream.Position;

            BinaryReader reader = new BinaryReader(stream, Encoding.ASCII);

            ushort magic = reader.ReadUInt16();

            stream.Seek(start, SeekOrigin.Begin);

            _optionalHeaderBase = null;

            switch (magic)
            {
            case Constants.IMAGE_NT_OPTIONAL_HDR32_MAGIC:
                _optionalHeaderBase = new OptionalHeaderPE32();
                break;
            case Constants.IMAGE_NT_OPTIONAL_HDR64_MAGIC:
                _optionalHeaderBase = new OptionalHeaderPE64();
                break;
            case Constants.IMAGE_ROM_OPTIONAL_HDR_MAGIC:
                //_optionalHeaderBase = new OptionalHeaderPE32();
                //break;
            default:
                break;
            }

            if (_optionalHeaderBase != null)
            {
                _optionalHeaderBase.FromStream(stream);
            }

            stream.Seek(start + size, SeekOrigin.Begin);
        }
    }
}
