using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SymbolExplorerLib;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SymbolExplorerLib.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (Stream fileStream = new FileStream(@"..\..\..\..\freeimaged.lib", FileMode.Open))
            {
                ArchiveFile file = ArchiveFile.FromStream(fileStream);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.first.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.second.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LongNamesMemberName, file.longnames.Header.Name);
            }
        }
    }
}
