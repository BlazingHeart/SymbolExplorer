using SymbolExplorerLib.Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorerLib
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
            IMAGE_ARCHIVE_MEMBER_HEADER header = Utils.StreamToStructure<IMAGE_ARCHIVE_MEMBER_HEADER>(stream);
            return ArchiveMemberHeader.From(header);
        }

        public static ArchiveMemberHeader From(IMAGE_ARCHIVE_MEMBER_HEADER old)
        {
            string name = Encoding.ASCII.GetString(old.Name).TrimEnd(' ');
            string date = Encoding.ASCII.GetString(old.Date).TrimEnd(' ');
            string user = Encoding.ASCII.GetString(old.UserID).TrimEnd(' ');
            string group = Encoding.ASCII.GetString(old.GroupID).TrimEnd(' ');
            string mode = Encoding.ASCII.GetString(old.Mode).TrimEnd(' ');
            string size = Encoding.ASCII.GetString(old.Size).TrimEnd(' ');
            string endHeader = Encoding.ASCII.GetString(old.EndHeader);

            int dateSeconds = int.Parse(date);
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(dateSeconds);
            int? UserID = string.IsNullOrEmpty(user) ? null : (int?)int.Parse(user);
            int? GroupID = string.IsNullOrEmpty(group) ? null : (int?)int.Parse(group);

            return new ArchiveMemberHeader
            {
                Name = name,
                Date = dateTime,
                UserID = UserID,
                GroupID = GroupID,
                Mode = (ST_MODE)Convert.ToInt32(mode, 8),
                Size = string.IsNullOrEmpty(size) ? 0 : int.Parse(size)
            };
        }
    }
}
