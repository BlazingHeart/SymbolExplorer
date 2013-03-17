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
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (Stream fileStream = new FileStream(@"..\..\..\..\freeimaged.lib", FileMode.Open))
            {
                ArchiveFileLib file = ArchiveFileLib.FromStream(fileStream);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.first.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.second.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LongNamesMemberName, file.longnames.Header.Name);
            }
        }
    }
}
