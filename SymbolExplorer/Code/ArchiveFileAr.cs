using SymbolExplorer.Code.Unix;
using SymbolExplorer.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.Code
{
    public class ArchiveFileAr
    {
        public FirstLinkerMember first = new FirstLinkerMember();
        public ElfMember second = new ElfMember();

        public static ArchiveFileAr FromStream(Stream stream)
        {
            ArchiveFileAr file = new ArchiveFileAr();


            byte[] buffer = new byte[Windows.Constants.IMAGE_ARCHIVE_START_SIZE];
            stream.Read(buffer, 0, Windows.Constants.IMAGE_ARCHIVE_START_SIZE);

            bool valid = Encoding.ASCII.GetString(buffer) == Windows.Constants.IMAGE_ARCHIVE_START;
            if (!valid) throw new InvalidDataException("Not a valid archive file");

            file.first.FromStream(stream);
            file.second.FromStream(stream);
            
            return file;
        }
    }
}
