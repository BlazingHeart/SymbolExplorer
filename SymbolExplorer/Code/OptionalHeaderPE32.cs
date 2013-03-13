using SymbolExplorer.Code.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Code
{
    public class OptionalHeaderPE32 : OptionalHeaderBase
    {
        IMAGE_OPTIONAL_HEADER32 _header;
        public override void FromStream(Stream stream)
        {
            _header = NativeUtils.StreamToStructure<IMAGE_OPTIONAL_HEADER32>(stream);
        }
    }
}
