using SymbolExplorer.Code.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorer.Code
{
    public class ArchiveMemberHeader
    {
        public string Name {get; set;}
        public DateTime Date { get; set; }
        public int? UserID { get; set; }
        public int? GroupID { get; set; }
        public ST_MODE Mode { get; set; }
        public int Size { get; set; }

        public const string LinkerMemberName = @"/";
        public const string LongNamesMemberName = @"//";

        public static ArchiveMemberHeader FromStream(Stream stream)
        {
            IMAGE_ARCHIVE_MEMBER_HEADER header = NativeUtils.StreamToStructure<IMAGE_ARCHIVE_MEMBER_HEADER>(stream);
            return ArchiveMemberHeader.From(header);
        }

        public static ArchiveMemberHeader From(IMAGE_ARCHIVE_MEMBER_HEADER old)
        {
            string name = Encoding.ASCII.GetString(old.Name).TrimEnd(' ');
            string date = Encoding.ASCII.GetString(old.Date).Trim(' ');
            string user = Encoding.ASCII.GetString(old.UserID).Trim(' ');
            string group = Encoding.ASCII.GetString(old.GroupID).Trim(' ');
            string mode = Encoding.ASCII.GetString(old.Mode).Trim(' ');
            string size = Encoding.ASCII.GetString(old.Size).Trim(' ');
            string endHeader = Encoding.ASCII.GetString(old.EndHeader);

            if (endHeader != Constants.IMAGE_ARCHIVE_END)
            {
                throw new InvalidDataException();
            }

            ArchiveMemberHeader header = new ArchiveMemberHeader();

            int dateSeconds = int.Parse(date);

            header.Name = name;
            header.Date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(dateSeconds);
            header.UserID = string.IsNullOrEmpty(user) ? null : (int?)int.Parse(user);
            header.GroupID = string.IsNullOrEmpty(group) ? null : (int?)int.Parse(group);
            header.Mode = (ST_MODE)Convert.ToInt32(mode, 8);
            header.Size = string.IsNullOrEmpty(size) ? 0 : int.Parse(size);

            return header;
        }
    }
}
