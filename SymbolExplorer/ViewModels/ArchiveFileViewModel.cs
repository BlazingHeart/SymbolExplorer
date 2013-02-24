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
        ObservableCollection<ArchiveMemberViewModel> _members = new ObservableCollection<ArchiveMemberViewModel>();

        public string Name { get; set; }
        public ArchiveFile File
        {
            get { return _file; }
            set
            {
                Members.Clear();

                _file = value;

                Members.Add(new ArchiveMemberViewModel(File.first));
                Members.Add(new ArchiveMemberViewModel(File.second));
                Members.Add(new ArchiveMemberViewModel(File.longnames));

                foreach (var v in File.objects)
                {
                    var model = new ObjectFileViewModel(v);
                    model.ResolveName(File.longnames);
                    Members.Add(model);
                }
            }
        }

        public ObservableCollection<ArchiveMemberViewModel> Members { get { return _members; } }

        public ArchiveFileViewModel()
        {
        }
    }
}
