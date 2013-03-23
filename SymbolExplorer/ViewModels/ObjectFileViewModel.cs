using SymbolExplorer.Code;
using SymbolExplorer.Code.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SymbolExplorer.ViewModels
{
    public class ObjectFileViewModel : ArchiveMemberViewModel
    {
        ObservableCollection<SectionViewModel> _sections = new ObservableCollection<SectionViewModel>();
        ObservableCollection<SymbolViewModel> _symbols = new ObservableCollection<SymbolViewModel>();
        ListCollectionView _filteredSymbols;

        public IMAGE_FILE_MACHINE Machine { get { return ObjectFileMember.ObjectFile.Header.Machine; } }
        public ushort NumberOfSections { get { return ObjectFileMember.ObjectFile.Header.NumberOfSections; } }
        public uint TimeDateStamp { get { return ObjectFileMember.ObjectFile.Header.TimeDateStamp; } }
        public uint NumberOfSymbols { get { return ObjectFileMember.ObjectFile.Header.NumberOfSymbols; } }
        public ushort SizeOfOptionalHeader { get { return ObjectFileMember.ObjectFile.Header.SizeOfOptionalHeader; } }
        public IMAGE_FILE_CHARACTARISTICS Characteristics { get { return ObjectFileMember.ObjectFile.Header.Characteristics; } }

        public ObjectFileMember ObjectFileMember { get { return base.ArchiveMember as ObjectFileMember; } }

        public ObservableCollection<SectionViewModel> Sections { get { return _sections; } }

        public ObservableCollection<SymbolViewModel> Symbols { get { return _symbols; } }

        public ListCollectionView FilteredSymbols { get { return _filteredSymbols; } }

        public ObjectFileViewModel(ObjectFileMember objectFileMember)
            : base(objectFileMember)
        {
            AddSymbols();
            AddSections();

            _filteredSymbols = new ListCollectionView(_symbols);
            //_groupedSymbols.GroupDescriptions.Add(new PropertyGroupDescription(Utils.GetPropertyName<SymbolViewModel>(a => a.Section)));

            _filteredSymbols.Filter = Filters.SymbolViewModel_HideLinkerSymbols;
        }

        private void AddSections()
        {
            foreach (var section in ObjectFileMember.ObjectFile.Sections)
            {
                var model = new SectionViewModel(section);
                model.ResolveName(ObjectFileMember.ObjectFile);
                _sections.Add(model);
            }
        }

        private void AddSymbols()
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
