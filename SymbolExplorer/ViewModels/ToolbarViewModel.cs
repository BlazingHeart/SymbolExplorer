using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer.ViewModels
{
    public class ToolbarViewModel : ViewModelBase
    {
        bool _hideLinkerMembers = false;
        public bool HideLinkerMembers { get { return _hideLinkerMembers; } set { SetProperty(ref _hideLinkerMembers, value, "HideLinkerMembers"); } }
    }
}
