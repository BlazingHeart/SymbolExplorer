using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SymbolExplorer.Code;
using SymbolExplorer;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorer.Tests
{
    [TestClass]
    public class ArchiveFileLibTest
    {
        [TestMethod]
        public void TestFromStream()
        {
            string fileName =
#if DEBUG
                @"..\..\..\Debug\SymbolExplorer.TestLib.lib";
#else
                @"..\..\..\Release\SymbolExplorer.TestLib.lib";
#endif

            using (Stream fileStream = new FileStream(fileName, FileMode.Open))
            {
                ArchiveFileLib file = ArchiveFileLib.FromStream(fileStream);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.first.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.second.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LongNamesMemberName, file.longnames.Header.Name);
            }
        }
    }
}
