using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer.Framework
{
    public static class EnumExtensions
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static bool IsDisplayable(this Enum enumVal)
        {
            ulong bitfield = Convert.ToUInt64(enumVal);

            if (bitfield == 0) { return false; }

            var maskAttr = enumVal.GetAttributeOfType<EnumMaskAttribute>();

            if (maskAttr != null && maskAttr.IsMask) { return false; }

            return true;
        }

        public static bool HasFlagMasked(this Enum enumVal, Enum checkVal)
        {
            ulong bitfield = Convert.ToUInt64(enumVal);

            var maskAttr = checkVal.GetAttributeOfType<EnumMaskAttribute>();

            ulong bitVal = Convert.ToUInt64(checkVal);
            ulong mask = maskAttr != null ? maskAttr.Mask : bitVal;

            if ((bitVal != 0) && ((bitfield & mask) == bitVal))
            {
                return true;
            }

            return false;
        }
    }
}
