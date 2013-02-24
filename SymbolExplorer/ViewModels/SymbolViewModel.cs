using SymbolExplorerLib.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer.ViewModels
{
    public class SymbolViewModel
    {
        string _name;
        IMAGE_SYMBOL _symbol;
        IMAGE_SYMBOL[] _auxSymbols;

        public string Name { get { return _name; } set { _name = value; } }

        public uint Value { get { return _symbol.Value; } }
        public short SectionNumber { get { return _symbol.SectionNumber; } }
        public IMAGE_SYM_TYPE Type { get { return _symbol.Type; } }
        public IMAGE_SYM_CLASS StorageClass { get { return _symbol.StorageClass; } }
        public byte NumberOfAuxSymbols { get { return _symbol.NumberOfAuxSymbols; } }

        public SymbolViewModel(IMAGE_SYMBOL symbol, IMAGE_SYMBOL[] auxSymbols = null)
        {
            _symbol = symbol;
            _auxSymbols = auxSymbols;
            if (!symbol.UsesStringTable)
            {
                _name = symbol.Name;
            }
        }
    }
}
