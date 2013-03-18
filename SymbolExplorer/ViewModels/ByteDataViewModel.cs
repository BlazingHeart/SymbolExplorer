using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SymbolExplorer.ViewModels
{
    public class ByteDataViewModel : ViewModelBase
    {
        private byte[] _data;
        private int _columnCount;
        private int _dataAlignment;
        private bool _showAddress;
        private long _startingAddress;

        private string _text;

        public byte[] Data { get { return _data; } set { SetProperty(ref _data, value, "Data"); ClearText(); } }

        public long StartingAddress { get { return _startingAddress; } set { SetProperty(ref _startingAddress, value, "StartingAddress"); if (_showAddress) { ClearText(); } } }

        public bool ShowAddress { get { return _showAddress; } set { SetProperty(ref _showAddress, value, "ShowAddress"); ClearText(); } }

        public int DataAlignment { get { return _dataAlignment; } set { SetProperty(ref _dataAlignment, value, "DataAlignment"); ClearText(); } }

        public int ColumnCount { get { return _columnCount; } set { SetProperty(ref _columnCount, value, "ColumnCount"); ClearText(); } }

        public string Text { get { return _text ?? GenerateText(); } }

        public ByteDataViewModel()
        {
            ColumnCount = 16;
            ShowAddress = true;
        }

        private void ClearText()
        {
            _text = null;
            OnPropertyChanged("Text");
        }

        private char ToPrintable(byte b)
        {
            char c = Convert.ToChar(b);
            if (/*(c >= 0x80) ||*/ !(char.IsLetterOrDigit(c) || char.IsPunctuation(c) || char.IsSymbol(c) /*|| (c == ' ')*/))
            {
                c = '.';
            }

            return c;
        }

        private string GenerateText()
        {
            StringBuilder sb = new StringBuilder();
            if (_data != null)
            {
                for (int byteIndex = 0; byteIndex < _data.Length; )
                {
                    int lineBytes = Math.Min(_columnCount, _data.Length - byteIndex);
                    int pad = _columnCount - lineBytes;
                    int lineIndex = byteIndex;

                    if (_showAddress)
                    {
                        sb.AppendFormat("0x{0:X8}  ", _startingAddress + byteIndex);
                    }

                    for (int y = 0; y < lineBytes; ++y)
                    {
                        sb.AppendFormat("{0:X2} ", _data[lineIndex]);
                        ++lineIndex;
                    }
                    for (int y = 0; y < pad; ++y)
                    {
                        sb.Append("   ");
                    }

                    sb.Append(' ');

                    lineIndex = byteIndex;
                    for (int y = 0; y < lineBytes; ++y)
                    {
                        char c = ToPrintable(_data[lineIndex]);
                        sb.Append(c);
                        ++lineIndex;
                    }
                    for (int y = 0; y < pad; ++y)
                    {
                        sb.Append(' ');
                    }

                    sb.AppendLine();
                    byteIndex += lineBytes;
                }
            }

            _text = sb.ToString();
            OnPropertyChanged("Text");
            return _text;
        }
    }
}
