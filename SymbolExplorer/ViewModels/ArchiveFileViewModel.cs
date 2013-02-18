using SymbolExplorerLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.ViewModels
{
    public class ArchiveFileViewModel
    {
        ArchiveFile _file;
        ObservableCollection<SymbolExplorerLib.ArchiveMember> _members = new ObservableCollection<SymbolExplorerLib.ArchiveMember>();

        public string Name { get; set; }
        public ArchiveFile File
        {
            get { return _file; }
            set
            {
                Members.Clear();

                _file = value;

                Members.Add(File.first);
                Members.Add(File.second);
                Members.Add(File.longnames);

                foreach (var v in File.objects)
                {
                    Members.Add(v);
                }
            }
        }

        public ObservableCollection<SymbolExplorerLib.ArchiveMember> Members { get { return _members; } }

        public ArchiveFileViewModel()
        {
        }
    }
}
