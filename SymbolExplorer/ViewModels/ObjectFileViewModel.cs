using SymbolExplorer.Code;
using SymbolExplorer.Code.Windows;
using SymbolExplorer.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace SymbolExplorer.ViewModels
{
    public class ObjectFileViewModel : ArchiveMemberViewModel
    {
        ObservableCollection<SectionViewModel> _sections = new ObservableCollection<SectionViewModel>();
        ObservableCollection<SymbolViewModel> _symbols = new ObservableCollection<SymbolViewModel>();
        CollectionViewSource _filteredSymbols = new CollectionViewSource();

        string _symbolSearchText = String.Empty;
        bool _symbolSearchTextAdded = false;

        public IMAGE_FILE_MACHINE Machine { get { return ObjectFileMember.ObjectFile.Header.Machine; } }
        public ushort NumberOfSections { get { return ObjectFileMember.ObjectFile.Header.NumberOfSections; } }
        public uint TimeDateStamp { get { return ObjectFileMember.ObjectFile.Header.TimeDateStamp; } }
        public uint NumberOfSymbols { get { return ObjectFileMember.ObjectFile.Header.NumberOfSymbols; } }
        public ushort SizeOfOptionalHeader { get { return ObjectFileMember.ObjectFile.Header.SizeOfOptionalHeader; } }
        public IMAGE_FILE_CHARACTARISTICS Characteristics { get { return ObjectFileMember.ObjectFile.Header.Characteristics; } }

        public ObjectFileMember ObjectFileMember { get { return base.ArchiveMember as ObjectFileMember; } }

        public ObservableCollection<SectionViewModel> Sections { get { return _sections; } }

        public ObservableCollection<SymbolViewModel> Symbols { get { return _symbols; } }

        public ICollectionView FilteredSymbols { get { return _filteredSymbols.View; } }

        public ICommand ClearSearch { get { return new RelayCommand(ClearSearchExecute, CanClearSearchExecute); } }
        
        public string SymbolSearchText
        {
            get
            {
                return _symbolSearchText;
            }
            set
            {
                SetProperty(ref _symbolSearchText, value, "SymbolSearchText");

                if (_symbolSearchTextAdded) { _filteredSymbols.Filter -= new FilterEventHandler(FilterSymbolSearchText); _symbolSearchTextAdded = false; }
                if (!string.IsNullOrEmpty(_symbolSearchText)) { _filteredSymbols.Filter += new FilterEventHandler(FilterSymbolSearchText); _symbolSearchTextAdded = true; }

                _filteredSymbols.View.Refresh();
            }
        }


        private bool CanClearSearchExecute()
        {
            return !string.IsNullOrEmpty(_symbolSearchText);
        }

        private void ClearSearchExecute()
        {
            SymbolSearchText = string.Empty;
        }



        public ObjectFileViewModel(ObjectFileMember objectFileMember)
            : base(objectFileMember)
        {
            AddSymbols();
            AddSections();

            _filteredSymbols.Source = _symbols;
            _filteredSymbols.Filter += new FilterEventHandler(Filters.SymbolViewModel_HideLinkerSymbols);
            Filters.FilterUpdated += new EventHandler(RefreshView);
        }

        ~ObjectFileViewModel()
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(() =>
            {
                _filteredSymbols.Filter -= new FilterEventHandler(Filters.SymbolViewModel_HideLinkerSymbols);
                Filters.FilterUpdated -= new EventHandler(RefreshView);
            });
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

        public void FilterSymbolSearchText(object sender, FilterEventArgs e)
        {
            SymbolViewModel symbol = e.Item as SymbolViewModel;

            if (!string.IsNullOrEmpty(_symbolSearchText))
            {
                if (!symbol.Demangled.Contains(_symbolSearchText))
                {
                    e.Accepted = false;
                }
            }
        }

        private void RefreshView(object o, EventArgs e)
        {
            _filteredSymbols.View.Refresh();
        }
    }
}
