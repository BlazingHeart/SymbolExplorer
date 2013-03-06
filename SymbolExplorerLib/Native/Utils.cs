using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SymbolExplorerLib.Native
{
    public static class Utils
    {
        public static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return stuff;
        }

        public static T ByteArrayToStructure<T>(byte[] bytes, int offset, int length) where T : struct
        {
            byte[] b = new byte[length];
            Array.Copy(bytes, offset, b, 0, length);
            return ByteArrayToStructure<T>(b);
        }

        public static T StreamToStructure<T>(Stream s) where T : struct
        {
            int structSize = Marshal.SizeOf(typeof(T));
            byte[] b = new byte[structSize];
            s.Read(b, 0, structSize);
            return ByteArrayToStructure<T>(b);
        }

        public static uint SwapEndian(uint i)
        {
            return (uint)((i << 24) | ((i << 8) & 0x00FF0000) | ((i >> 8) & 0x0000FF00) | (i >> 24));
        }

        public static string GetString(byte[] text)
        {
            // need to trim off any nulls
            int length = 0;
            for (int i = 0; i < text.Length; ++i)
            {
                length = i;
                if (text[i] == '\0') break;
            }
            return Encoding.UTF8.GetString(text, 0, length);
        }
    }
}
