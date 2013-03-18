using SymbolExplorer.Code;
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
        ArchiveFileLib _file;
        ObservableCollection<ObjectFileViewModel> _members = new ObservableCollection<ObjectFileViewModel>();

        public string Name { get; set; }
        public ArchiveFileLib File
        {
            get { return _file; }
            set
            {
                _members.Clear();

                _file = value;

                //Members.Add(new ArchiveMemberViewModel(File.first));
                //Members.Add(new ArchiveMemberViewModel(File.second));
                //Members.Add(new ArchiveMemberViewModel(File.longnames));

                foreach (var v in _file.objects)
                {
                    var model = new ObjectFileViewModel(v);
                    model.ResolveName(_file.longnames);
                    _members.Add(model);
                }
            }
        }

        public ObservableCollection<ObjectFileViewModel> Members { get { return _members; } }

        public ArchiveFileViewModel()
        {
        }
    }
}
