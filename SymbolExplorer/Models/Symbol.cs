﻿using SymbolExplorer.Framework;
using SymbolExplorer.Code;
using SymbolExplorer.Code.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SymbolExplorer.Models
{
    public class Symbol
    {
        string _name;
        string _nameDemangled;
        string[] _namespace;
        IMAGE_SYMBOL _symbol;
        IMAGE_SYMBOL[] _auxSymbols;

//(?x)                  # enable comments and ignore spaces
//\s*::\s*               # match a comma possibly enclosed by spaces
//(?=                   # start positive look ahead
//  (?:[^<>]*<[^<>]*>)*   #   match an even number of double quotes with zero or more non-quotes before, or in between
//  [^<>]*               #   match zero or more non-quotes
//  $                   #   match the end of the line
//)
        static Regex namespaceSplit = new Regex(@"\s*::\s*(?=(?:[^<>]*<[^<>]*>)*[^<>]*$)");

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
                _namespace = namespaceSplit.Split(ns);
                //_namespace = ns.Split(new string[] { "::" }, StringSplitOptions.None);
                _namespace = _namespace.Take(_namespace.Length - 1).ToArray();
            }
            else
            {
                _namespace = new string[] { };
            }
        }
    }
}
