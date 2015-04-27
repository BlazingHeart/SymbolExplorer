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
        public void TestFromStream_x86_vc120()
        {
            string fileName = @"..\..\..\SymbolExplorer.TestLib\libs\SymbolExplorer.TestLib.x86.vc120.lib";

            using (Stream fileStream = new FileStream(fileName, FileMode.Open))
            {
                ArchiveFileLib file = ArchiveFileLib.FromStream(fileStream);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.first.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.second.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LongNamesMemberName, file.longnames.Header.Name);
            }
        }

        [TestMethod]
        public void TestFromStream_x86_vc120_WholeProgramOptimisation()
        {
            string fileName = @"..\..\..\SymbolExplorer.TestLib\libs\SymbolExplorer.TestLib.x86.vc120.WholeProgramOptimisation.lib";

            using (Stream fileStream = new FileStream(fileName, FileMode.Open))
            {
                ArchiveFileLib file = ArchiveFileLib.FromStream(fileStream);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.first.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.second.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LongNamesMemberName, file.longnames.Header.Name);
            }
        }

        [TestMethod]
        public void TestFromStream_x64_vc120()
        {
            string fileName = @"..\..\..\SymbolExplorer.TestLib\libs\SymbolExplorer.TestLib.x64.vc120.lib";

            using (Stream fileStream = new FileStream(fileName, FileMode.Open))
            {
                ArchiveFileLib file = ArchiveFileLib.FromStream(fileStream);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.first.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LinkerMemberName, file.second.Header.Name);
                Assert.AreEqual(ArchiveMemberHeader.LongNamesMemberName, file.longnames.Header.Name);
            }
        }

        [TestMethod]
        public void TestFromStream_x64_vc120_WholeProgramOptimisation()
        {
            string fileName = @"..\..\..\SymbolExplorer.TestLib\libs\SymbolExplorer.TestLib.x64.vc120.WholeProgramOptimisation.lib";

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
