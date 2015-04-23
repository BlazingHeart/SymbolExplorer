using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Framework
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumMaskAttribute : Attribute
    {
        ulong m_mask = 0;

        public bool IsMask { get { return m_mask == 0; } }

        public bool IsMasked { get { return m_mask != 0; } }

        public ulong Mask { get { return m_mask; } }

        /// <summary>
        /// The Enum field is a mask value and should not be used for comparisons
        /// </summary>
        public EnumMaskAttribute()
        {
        }

        /// <summary>
        /// The Enum field is value that requires a mask for comparison
        /// </summary>
        /// <param name="mask">The mask required for comparison</param>
        public EnumMaskAttribute(uint mask)
        {
            if (mask == 0) { throw new InvalidOperationException("Mask cannot be 0."); }
            m_mask = mask;
        }
    }
}
