﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.Code
{
    public class ArchiveMember
    {
        public ArchiveMemberHeader Header { get; set; }
        
        public virtual void FromStream(Stream stream)
        {
            Header = ArchiveMemberHeader.FromStream(stream);
        }
    }
}
