using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorerLib
{
    public class Demangler
    {
        public enum Language
        {
            Unknown,
            C,
            CPP,
        }

        public static string Demangle(string symbolName, out Language language)
        {
            StringBuilder sb = new StringBuilder(4096);
            int result = PInvoke.UnDecorateSymbolName(symbolName, sb, sb.Capacity, PInvoke.UnDecorateFlags.UNDNAME_COMPLETE);
            if ((result == 0) || (sb.ToString() == symbolName))
            {
                language = Language.Unknown;
                return symbolName;
            }

            sb.Replace("unsigned short", "uint16_t");
            sb.Replace("short", "int16_t");
            sb.Replace("unsigned __int64", "uint64_t");
            sb.Replace("__int64", "int64_t");
            sb.Replace("unsigned __int32", "uint32_t");
            sb.Replace("__int32", "int32_t");
            sb.Replace("unsigned __int16", "uint16_t");
            sb.Replace("__int16", "int16_t");
            sb.Replace("unsigned __int8", "uint8_t");
            sb.Replace("__int8", "int8_t");
            sb.Replace("__wchar_t", "wchar_t");
            language = Language.CPP;
            return sb.ToString();
        }

        public static string Demangle(string symbolName)
        {
            Language language;
            return Demangle(symbolName, out language);
        }
    }
}
