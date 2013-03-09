using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Code
{
    public class Demangler
    {
        private static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public enum Language
        {
            Unknown,
            C,
            CPP,
        }

        public static string DemangleMsvc(string symbolName, out Language language)
        {
            language = Language.Unknown;

            if (symbolName.StartsWith("?"))
                language = Language.CPP;

            StringBuilder sb = new StringBuilder(4096);
            int result = NativeMethods.UnDecorateSymbolName(symbolName, sb, sb.Capacity, NativeMethods.UnDecorateFlags.UNDNAME_COMPLETE);
            if ((result == 0) || (sb.ToString() == symbolName))
            {
                return symbolName;
            }

            List<string> parts = new List<string>();

            using (var reader = new StringReader(symbolName))
            {
                StringBuilder part = new StringBuilder(1024);
                int c = reader.Read();
                if (c == '?')
                {
                    c = reader.Read();
                    for (; ; )
                    {
                        part.Clear();
                        while ((c = reader.Read()) != -1)
                        {
                            part.Append((char)c);
                            if (c == '@')
                            {
                                if (reader.Peek() == '@') part.Append((char)(c = reader.Read()));
                                break;
                            }
                        }

                        if (c == -1) break;

                        parts.Add(part.ToString());
                    }
                }
            }

            // use more compact type names
            //sb.Replace("unsigned short", "uint16_t");
            //sb.Replace("short", "int16_t");
            //sb.Replace("unsigned __int64", "uint64_t");
            //sb.Replace("__int64", "int64_t");
            //sb.Replace("unsigned __int32", "uint32_t");
            //sb.Replace("__int32", "int32_t");
            //sb.Replace("unsigned __int16", "uint16_t");
            //sb.Replace("__int16", "int16_t");
            //sb.Replace("unsigned __int8", "uint8_t");
            //sb.Replace("__int8", "int8_t");
            //sb.Replace("__wchar_t", "wchar_t");

            return sb.ToString();
        }

        public static string Demangle(string symbolName, out Language language)
        {
            if (symbolName[0] == '?')
                return DemangleMsvc(symbolName, out language);

            language = Language.Unknown;
            return symbolName;
        }

        public static string Demangle(string symbolName)
        {
            Language language;
            return Demangle(symbolName, out language);
        }
    }
}
