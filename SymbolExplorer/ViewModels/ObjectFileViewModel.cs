using SymbolExplorerLib;
using SymbolExplorerLib.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SymbolExplorer.ViewModels
{
    class ObjectFileViewModel : ArchiveMemberViewModel
    {
        ObservableCollection<SymbolViewModel> _symbols = new ObservableCollection<SymbolViewModel>();
        ListCollectionView _groupedSymbols;

        public ObjectFileMember ObjectFileMember { get { return base.ArchiveMember as ObjectFileMember; } }

        public ObservableCollection<SymbolViewModel> Symbols { get { return _symbols; } }

        public ListCollectionView GroupedSymbols { get { return _groupedSymbols; } }

        public ObjectFileViewModel(ObjectFileMember objectFileMember)
            : base(objectFileMember)
        {
            AddSymbols();

            _groupedSymbols = new ListCollectionView(_symbols);
            _groupedSymbols.GroupDescriptions.Add(new PropertyGroupDescription(Utils.GetPropertyName<SymbolViewModel>(a => a.Section)));
        }

        void AddSymbols()
        {
            var stringTable = ObjectFileMember.ObjectFile.StringTable;
            var symbols = ObjectFileMember.ObjectFile.Symbols;

            for (int i = 0; i < symbols.Length; ++i)
            {
                var symbol = symbols[i];
                IMAGE_SYMBOL[] auxSymbols = null;

                if (symbol.NumberOfAuxSymbols > 0)
                {
                    auxSymbols = new IMAGE_SYMBOL[symbol.NumberOfAuxSymbols];
                    for (int a = 0; a < auxSymbols.Length; ++a)
                    {
                        auxSymbols[a] = symbols[i + a];
                    }
                }

                var model = new SymbolViewModel(symbol, auxSymbols);
                if (symbol.UsesStringTable)
                {
                    string name;
                    if (stringTable.TryGetValue(symbol.StringTableOffset, out name))
                    {
                        model.Name = name;
                    }
                    else
                    {
                        model.Name = "Unavailable";
                    }
                    model.Demangled = Demangler.Demangle(model.Name);
                }

                _symbols.Add(model);

                i += symbol.NumberOfAuxSymbols;
            }
        }
    }
}
