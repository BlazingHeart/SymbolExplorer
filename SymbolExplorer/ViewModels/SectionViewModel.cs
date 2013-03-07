using SymbolExplorerLib;
using SymbolExplorerLib.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer.ViewModels
{
    public class SectionViewModel
    {
        string _name;
        ObjectFile.ImageSection _imageSection;
        ByteDataViewModel _byteData = new ByteDataViewModel();

        public string Name { get { return _name; } set { _name = value; } }

        public uint PhysicalAddressOrVirtualSize { get { return _imageSection.Header.PhysicalAddressOrVirtualSize; } }
        public uint VirtualAddress { get { return _imageSection.Header.VirtualAddress; } }
        public uint SizeOfRawData { get { return _imageSection.Header.SizeOfRawData; } }
        public IMAGE_SCN Characteristics { get { return _imageSection.Header.Characteristics; } }

        public long RawOffset { get { return _imageSection.RawOffset; } }
        //public byte[] RawData { get { return _imageSection.RawData; } }

        public IMAGE_RELOCATION[] Relocations;

        public ByteDataViewModel RawData { get { return _byteData; } }

        public SectionViewModel(ObjectFile.ImageSection imageSection)
        {
            _imageSection = imageSection;
            _name = SymbolExplorerLib.Native.Utils.GetString(_imageSection.Header.Name);
            _byteData.Data = _imageSection.RawData;
        }

        public void ResolveName(ObjectFile file)
        {
            if (_name.StartsWith("/"))
            {
                long result = 0;
                if (long.TryParse(_name.Substring(1), out result))
                {
                    file.StringTable.TryGetValue(result, out _name);
                }
            }
        }
    }
}
