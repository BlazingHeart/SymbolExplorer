using SymbolExplorer.Code;
using SymbolExplorer.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SymbolExplorer.ViewModels
{
    public class LongNamesMemberViewModel : ViewModelBase
    {
        public class LongName
        {
            public long Offset { get; set; }
            public string Name { get; set; }
        }

        List<LongName> m_longNames = new List<LongName>();

        public List<LongName> LongNames { get { return m_longNames; } }

        public LongNamesMemberViewModel(LongNamesMember longNames)
        {
            foreach (var kvp in longNames.Names)
            {
                m_longNames.Add(new LongName() { Offset = kvp.Key, Name = kvp.Value });
            }

            m_longNames.Sort((longName1, longName2) => longName1.Offset.CompareTo(longName2.Offset));
        }
    }
}
