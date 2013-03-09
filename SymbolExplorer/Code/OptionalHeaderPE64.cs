using SymbolExplorerLib.Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SymbolExplorerLib
{
    public class OptionalHeaderPE64 : OptionalHeaderBase
    {
        IMAGE_OPTIONAL_HEADER64 _header;
        public override void FromStream(Stream stream)
        {
            _header = Utils.StreamToStructure<IMAGE_OPTIONAL_HEADER64>(stream);
        }
    }
}
