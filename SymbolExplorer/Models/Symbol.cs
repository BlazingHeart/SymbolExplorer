using SymbolExplorer.Code;
using SymbolExplorer.Code.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Models
{
    public class Symbol
    {
        string _name;
        string _nameDemangled;
        string[] _namespace;
        IMAGE_SYMBOL _symbol;
        IMAGE_SYMBOL[] _auxSymbols;

        public string Name { get { return _name; } set { _name = value; } }
        public string Demangled { get { return _nameDemangled; } set { _nameDemangled = value; } }
        public string[] Namespace { get { return _namespace; } set { _namespace = value; } }

        public uint Value { get { return _symbol.Value; } }
        public short Section { get { return _symbol.SectionNumber; } }

        public IMAGE_SYM_TYPE BasicType { get { return _symbol.BasicType; } }
        public IMAGE_SYM_DTYPE DataType { get { return _symbol.DataType; } }
        public IMAGE_SYM_CLASS StorageClass { get { return _symbol.StorageClass; } }
        public byte AuxSymbols { get { return _symbol.NumberOfAuxSymbols; } }

        public Symbol(IMAGE_SYMBOL symbol, IMAGE_SYMBOL[] auxSymbols, Dictionary<long, string> stringTable)
        {
            _symbol = symbol;
            _auxSymbols = auxSymbols;

            if (symbol.UsesStringTable)
            {
                string name;
                if (stringTable.TryGetValue(symbol.StringTableOffset, out name))
                {
                    _name = name;
                }
                else
                {
                    _name = "Unavailable";
                }
            }
            else
            {
                _name = symbol.Name;
            }

            _nameDemangled = Demangler.Demangle(_name);
            string ns = Demangler.GetNamespace(_name);
            if (!string.IsNullOrEmpty(ns))
            {
                _namespace = ns.Split(new string[] { "::" }, StringSplitOptions.None);
                _namespace = _namespace.Take(_namespace.Length - 1).ToArray();
            }
            else
            {
                _namespace = new string[] { };
            }
        }

        public string BasicTypeName { get { return FriendlyEnums.FriendlyName(_symbol.BasicType); } }
        public string DataTypeName { get { return FriendlyEnums.FriendlyName(_symbol.DataType); } }
        public string StorageClassName { get { return FriendlyEnums.FriendlyName(_symbol.StorageClass); } }

        public string SectionName
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
    }
}
