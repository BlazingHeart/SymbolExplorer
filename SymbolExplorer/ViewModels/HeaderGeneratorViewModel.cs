using SymbolExplorer.Code.Windows;
using SymbolExplorer.Models;
using SymbolExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SymbolExplorer.Code
{
    public class HeaderGeneratorViewModel : ViewModelBase
    {
        class Namespace
        {
            List<Namespace> _namespaces = new List<Namespace>();
            List<Symbol> _symbols = new List<Symbol>();
            bool _isClass = false;

            public List<Namespace> Namespaces { get { return _namespaces; } }
            public List<Symbol> Symbols { get { return _symbols; } }
            public bool IsClass { get { return _isClass; } set { _isClass = value; } }
            public string Name { get; set; }
        }

        Namespace _rootNamespace = null;
        string _headerText;

        ObjectFileViewModel _objectFile;

        public string HeaderText { get { return _headerText ?? GenerateText(); } }

        public ObjectFileViewModel ObjectFile { get { return _objectFile; } set { SetProperty(ref _objectFile, value, "ObjectFile"); _rootNamespace = null; } }

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

        void Load()
        {
            _rootNamespace = new Namespace();
            ClearText();

            ListCollectionView view = new ListCollectionView(_objectFile.Symbols);
            view.Filter = Filters.SymbolViewModel_HideLinkerSymbols;

            foreach (Symbol s in view)
            {
                //if ((s.Section == Constants.IMAGE_SYM_UNDEFINED) || (s.DataType == IMAGE_SYM_DTYPE.IMAGE_SYM_DTYPE_FUNCTION))
                if (!IsLanguageSymbol(s))
                {
                    AddSymbol(s);
                }
            }
        }

        void AddSymbol(Symbol symbol)
        {
            Namespace n = CreateNamespace(symbol.Namespace);
            if (symbol.Demangled.Contains("__thiscall"))
            {
                n.IsClass = true;
            }
            n.Symbols.Add(symbol);
        }

        void ClearText()
        {
            SetProperty(ref _headerText, null, "HeaderText");
        }

        string GenerateText()
        {
            if (_rootNamespace == null)
            {
                Load();
            }

            StringBuilder sb = new StringBuilder(4 * 1024);

            sb.AppendLine("//===========================================================================//");
            sb.AppendFormat("// Header generated for {0} by Symbol Explorer\n", _objectFile.Name);
            sb.AppendLine("//===========================================================================//");
            sb.AppendLine();
            sb.AppendLine();

            GenerateNamespace(_rootNamespace, sb);

            SetProperty(ref _headerText, sb.ToString(), "HeaderText");
            return _headerText;
        }

        void GenerateNamespace(Namespace n, StringBuilder sb)
        {
            foreach (Namespace nn in n.Namespaces)
            {
                GenerateNamespaceRecursive(nn, sb, 0);
                sb.AppendLine();
            }

            if (n.Symbols.Count > 0)
            {
                sb.AppendLine();
            }

            foreach (Symbol s in n.Symbols)
            {
                string name = s.Demangled;
                if (s.Namespace.Length > 0)
                {
                    string namespacetext = string.Join("::", s.Namespace) + "::";
                    name = name.Replace(namespacetext, "");
                }
                name = name.Replace("__thiscall ", "");
                name = name.Replace("__cdecl ", "");

                if (s.Demangled == s.Name && s.DataType == IMAGE_SYM_DTYPE.IMAGE_SYM_DTYPE_FUNCTION)
                {
                    name = name + "()";
                }

                sb.AppendFormat("{0};\n", name);
            }
        }

        void GenerateNamespaceRecursive(Namespace n, StringBuilder sb, int tabLevel)
        {
            string indent = new string(' ', tabLevel * 2);
            string indent2 = new string(' ', (tabLevel + 1) * 2);

            if (n.IsClass)
            {
                sb.Append(indent);
                sb.AppendFormat("class {0}\n", n.Name);
            }
            else
            {
                sb.Append(indent);
                sb.AppendFormat("namespace {0}\n", n.Name);
            }
            sb.Append(indent);
            sb.AppendLine("{");

            foreach (Namespace nn in n.Namespaces)
            {
                GenerateNamespaceRecursive(nn, sb, tabLevel + 1);
                sb.AppendLine();
            }

            foreach (Symbol s in n.Symbols)
            {
                string name = s.Demangled;
                if (s.Namespace.Length > 0)
                {
                    string namespacetext = string.Join("::", s.Namespace) + "::";
                    name = name.Replace(namespacetext, "");
                }
                name = name.Replace("__thiscall ", "");
                name = name.Replace("__cdecl ", "");
                sb.Append(indent2);
                sb.AppendFormat("{0};\n", name);
            }

            sb.Append(indent);
            sb.AppendLine("}");
        }

        bool IsLanguageSymbol(Symbol symbol)
        {
            string[] languageSymbolParts =
            {
                "`RTTI Complete Object Locator'",
                "`vftable'",
                "`RTTI Class Hierarchy Descriptor'",
                "`RTTI Base Class Array'",
                "`RTTI Base Class Descriptor at",
                "`RTTI Type Descriptor'",
                "`scalar deleting destructor'",
                "`vector deleting destructor'",
                "`string'",
            };

            foreach (var s in languageSymbolParts)
            {
                if (symbol.Demangled.Contains(s)) return true;
            }

            return false;
        }
    }
}
