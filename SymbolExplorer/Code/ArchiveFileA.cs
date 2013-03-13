using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.Code
{
    public class ArchiveFileA
    {
        public FirstLinkerMember first = new FirstLinkerMember();

        public static ArchiveFileA FromStream(Stream stream)
        {
            ArchiveFileA file = new ArchiveFileA();

            byte[] buffer = new byte[Windows.Constants.IMAGE_ARCHIVE_START_SIZE];
            stream.Read(buffer, 0, Windows.Constants.IMAGE_ARCHIVE_START_SIZE);

            bool valid = Encoding.ASCII.GetString(buffer) == Windows.Constants.IMAGE_ARCHIVE_START;
            if (!valid) throw new InvalidDataException("Not a valid archive file");

            file.first.FromStream(stream);
            
            return file;
        }
    }
}
