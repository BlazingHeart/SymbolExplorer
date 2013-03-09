using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.Code
{
    public class ArchiveFile
    {
        public FirstLinkerMember first = new FirstLinkerMember();
        public SecondLinkerMember second = new SecondLinkerMember();
        public LongNamesMember longnames = new LongNamesMember();

        public ObjectFileMember[] objects;

        public bool Errors;

        public static ArchiveFile FromStream(Stream stream)
        {
            ArchiveFile file = new ArchiveFile();

            byte[] buffer = new byte[Native.Constants.IMAGE_ARCHIVE_START_SIZE];
            stream.Read(buffer, 0, Native.Constants.IMAGE_ARCHIVE_START_SIZE);

            bool valid = Encoding.ASCII.GetString(buffer) == Native.Constants.IMAGE_ARCHIVE_START;
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
