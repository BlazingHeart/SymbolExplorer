using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorerLib.Native
{
    public class Constants
    {
        public const int IMAGE_ARCHIVE_START_SIZE = 8;
        public const string IMAGE_ARCHIVE_START = "!<arch>\n";
        public const string IMAGE_ARCHIVE_END = "`\n";
        public const string IMAGE_ARCHIVE_PAD = "\n";
        public const string IMAGE_ARCHIVE_LINKER_MEMBER = "/               ";
        public const string IMAGE_ARCHIVE_LONGNAMES_MEMBER = "//              ";

        public const int IMAGE_SIZEOF_ARCHIVE_MEMBER_HDR = 60;

        public const int IMAGE_SIZEOF_FILE_HEADER = 20;

        public const int IMAGE_SIZEOF_SHORT_NAME = 8;
        public const int IMAGE_SIZEOF_SECTION_HEADER = 40;

        public const short IMAGE_SYM_UNDEFINED = (short)0;          // Symbol is undefined or is common.
        public const short IMAGE_SYM_ABSOLUTE = (short)-1;         // Symbol is an absolute value.
        public const short IMAGE_SYM_DEBUG = (short)-2;        // Symbol is a special debug item.
        public const int IMAGE_SYM_SECTION_MAX = 0xFEFF;        // Values 0xFF00-0xFFFF are special
        public const int IMAGE_SYM_SECTION_MAX_EX = 0x7FFFFFFF;
    }
}
