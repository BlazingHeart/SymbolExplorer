using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.Code
{
    public class ArchiveFileLib
    {
        public FirstLinkerMember first = new FirstLinkerMember();
        public SecondLinkerMember second = new SecondLinkerMember();
        public LongNamesMember longnames = new LongNamesMember();

        public ObjectFileMember[] objects;

        public bool Errors;

        public static ArchiveFileLib FromStream(Stream stream)
        {
            ArchiveFileLib file = new ArchiveFileLib();

            byte[] buffer = new byte[Windows.Constants.IMAGE_ARCHIVE_START_SIZE];
            stream.Read(buffer, 0, Windows.Constants.IMAGE_ARCHIVE_START_SIZE);

            bool valid = Encoding.ASCII.GetString(buffer) == Windows.Constants.IMAGE_ARCHIVE_START;
            if (!valid) throw new InvalidDataException("Not a valid archive file");

            file.first.FromStream(stream);
            file.second.FromStream(stream);
            file.longnames.FromStream(stream);

            List<ObjectFileMember> objects = new List<ObjectFileMember>();
            
            while (stream.CanRead && (stream.Position < stream.Length))
            {
                try
                {
                    var ofm = new ObjectFileMember();
                    ofm.FromStream(stream);
                    objects.Add(ofm);
                }
                catch
                {
                    file.Errors = true;
                    break;
                }
            }

            file.objects = objects.ToArray();

            return file;
        }
    }
}
