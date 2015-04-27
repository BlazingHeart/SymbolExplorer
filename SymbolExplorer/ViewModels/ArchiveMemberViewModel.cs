using SymbolExplorer.Code;
using SymbolExplorer.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SymbolExplorer.ViewModels
{
    public class ArchiveMemberViewModel : ViewModelBase
    {
        ArchiveMember _member;
        string _name;

        public string Name { get { return _name; } }
        public ArchiveMember ArchiveMember { get { return _member; } }

        public ArchiveMemberViewModel(ArchiveMember member)
        {
            _member = member;
            _name = _member.Header.Name;
        }

        static readonly Regex _usesLongName = new Regex("/([0-9]+)");

        public bool ResolveName(LongNamesMember longNames)
        {
            string name = _member.Header.Name;
            Match match = _usesLongName.Match(name);
            if (match.Success)
            {
                int offset = int.Parse(match.Groups[1].Captures[0].Value);
                _name = longNames.GetNameForOffset(offset);
                return true;
            }
            else if (name.EndsWith("/"))
            {
                _name = name.Substring(0, name.Length - 1);
                return true;
            }
            return false;
        }
    }
}
