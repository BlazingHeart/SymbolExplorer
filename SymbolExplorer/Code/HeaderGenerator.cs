using SymbolExplorer.Code.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Code
{
    public class HeaderGenerator
    {
        class Namespace
        {
            List<Namespace> _namespaces = new List<Namespace>();
            List<IMAGE_SYMBOL> _symbols = new List<IMAGE_SYMBOL>();
            bool _isClass = false;

            public List<Namespace> Namespaces { get { return _namespaces; } }
            public List<IMAGE_SYMBOL> Symbols { get { return _symbols; } }
            public bool IsClass { get { return _isClass; } set { _isClass = value; } }
            public string Name { get; set; }
        }

        Namespace _rootNamespace = new Namespace();


        Namespace CreateNamespace(string[] names)
        {
            if (names.Length == 0)
            {
                return _rootNamespace;
            }

            Namespace top = _rootNamespace;
            foreach (var name in names)
            {
                Namespace n = top.Namespaces.Find(f => f.Name == name);
                if (n == null)
                {
                    n = new Namespace();
                    n.Name = name;
                    top.Namespaces.Add(n);
                }

                top = n;
            }

            return top;
        }


        bool ParseNamespaces(string symbolName, out string[] names)
        {
            StringBuilder sb = new StringBuilder(4096);
            int result = NativeMethods.UnDecorateSymbolName(symbolName, sb, sb.Capacity, NativeMethods.UnDecorateFlags.UNDNAME_NAME_ONLY);
            if ((result == 0) || (sb.ToString() == symbolName))
            {
                names = null;
                return false;
            }

            var demang = sb.ToString();

            names = demang.Split(new string[] { "::" }, StringSplitOptions.None);
            names = names.Take(names.Length - 1).ToArray();


            result = NativeMethods.UnDecorateSymbolName(symbolName, sb, sb.Capacity, NativeMethods.UnDecorateFlags.UNDNAME_COMPLETE);

            return true;
        }

        void AddSymbol(IMAGE_SYMBOL symbol)
        {
            string[] names = null;
            if (ParseNamespaces(symbol.Name, out names))
            {
                Namespace n = CreateNamespace(names);
                n.Symbols.Add(symbol);
            }
        }
    }
}
