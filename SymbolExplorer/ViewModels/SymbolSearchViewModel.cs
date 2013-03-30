using SymbolExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer.ViewModels
{
    public class SymbolSearchViewModel : ViewModelBase
    {
        string _searchTerm = string.Empty;
        ArchiveFileViewModel _file;

        #region Properties

        public ArchiveFileViewModel File { get { return _file; } set { SetProperty(ref _file, value, "File"); OnPropertyChanged("Symbols"); } }

        public string SearchTerm { get { return _searchTerm; } set { SetProperty(ref _searchTerm, value, "SearchTerm"); OnPropertyChanged("Symbols"); } }

        public IEnumerable<Symbol> Symbols { get { return FindSymbol(SearchTerm); } }

        #endregion

        public IEnumerable<Symbol> FindSymbol(string nameText)
        {
            string[] words = nameText.Split(new char[] { ' ' });

            var query = from obj in File.Members
                        from sym in obj.Symbols
                        where sym.Name.Contains(nameText)
                        select sym;
            return query.AsEnumerable();
        }
    }
}
