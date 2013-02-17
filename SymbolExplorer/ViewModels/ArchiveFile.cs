using SymbolExplorerLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.ViewModels
{
    public class ArchiveFileViewModel
    {
        public ArchiveFile File;

        public ObservableCollection<SymbolExplorerLib.ArchiveMember> Members = new ObservableCollection<SymbolExplorerLib.ArchiveMember>();

        public ArchiveFileViewModel(SymbolExplorerLib.ArchiveFile file)
        {
            File = file;

            Members.Add(File.first);
            Members.Add(File.first);
            Members.Add(File.first);

            foreach (var v in File.objects)
            {
                Members.Add(v);
            }
        }
    }
}
