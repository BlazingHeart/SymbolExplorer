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
        public string Section
        {
            get
            {
                switch (_symbol.SectionNumber)
                {
                    case Constants.IMAGE_SYM_UNDEFINED: return "Common";
                    case Constants.IMAGE_SYM_ABSOLUTE: return "Absolute";
                    case Constants.IMAGE_SYM_DEBUG: return "Debug";
                }
                return _symbol.SectionNumber.ToString();
            }
        }
        public string BasicType { get { return FriendlyEnums.FriendlyName(_symbol.BasicType); } }
        public string DataType { get { return FriendlyEnums.FriendlyName(_symbol.DataType); } }
        public string StorageClass { get { return FriendlyEnums.FriendlyName(_symbol.StorageClass); } }
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
