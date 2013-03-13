using SymbolExplorer.Code.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolExplorer
{
    class FriendlyEnums
    {
        public static string FriendlyName(IMAGE_SYM_TYPE e)
        {
            switch (e)
            {
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_NULL: return "None";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_VOID: return "Void";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_CHAR: return "Char";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_SHORT: return "Short";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_INT: return "Int";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_LONG: return "Long";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_FLOAT: return "Float";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_DOUBLE: return "Double";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_STRUCT: return "Struct";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_UNION: return "Union";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_ENUM: return "Enum";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_MOE: return "Member of Enum";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_BYTE: return "Byte";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_WORD: return "Word";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_UINT: return "UInt";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_DWORD: return "DWord";
            case IMAGE_SYM_TYPE.IMAGE_SYM_TYPE_PCODE: return "PCode";
            }
            return "[Unknown]";
        }

        public static string FriendlyName(IMAGE_SYM_DTYPE e)
        {
            switch (e)
            {
            case IMAGE_SYM_DTYPE.IMAGE_SYM_DTYPE_NULL: return "None";
            case IMAGE_SYM_DTYPE.IMAGE_SYM_DTYPE_POINTER: return "Pointer";
            case IMAGE_SYM_DTYPE.IMAGE_SYM_DTYPE_FUNCTION: return "Function";
            case IMAGE_SYM_DTYPE.IMAGE_SYM_DTYPE_ARRAY: return "Array";
            }
            return "[Unknown]";
        }

        public static string FriendlyName(IMAGE_SYM_CLASS e)
        {
            switch (e)
            {
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_END_OF_FUNCTION: return "End of function";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_NULL: return "Null";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_AUTOMATIC: return "Automatic";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_EXTERNAL: return "External";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_STATIC: return "Static";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_REGISTER: return "Register";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_EXTERNAL_DEF: return "External Def";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_LABEL: return "Label";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_UNDEFINED_LABEL: return "Undefined Label";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_MEMBER_OF_STRUCT: return "Member of Struct";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_ARGUMENT: return "Argument";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_STRUCT_TAG: return "Struct Tag";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_MEMBER_OF_UNION: return "Member of Union";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_UNION_TAG: return "Union Tag";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_TYPE_DEFINITION: return "Type Definition";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_UNDEFINED_STATIC: return "Undefined Static";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_ENUM_TAG: return "Enum Tag";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_MEMBER_OF_ENUM: return "Member of Enum";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_REGISTER_PARAM: return "Register Param";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_BIT_FIELD: return "Bit Field";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_FAR_EXTERNAL: return "Far External";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_BLOCK: return "Block";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_FUNCTION: return "Function";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_END_OF_STRUCT: return "End of Struct";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_FILE: return "File";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_SECTION: return "Section";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_WEAK_EXTERNAL: return "Weak External";
            case IMAGE_SYM_CLASS.IMAGE_SYM_CLASS_CLR_TOKEN: return "CLR Token";
            }
            return "[Unknown]";
        }
    }
}
