using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightSpot.Database {
  
    public static class DBConvert {
        public static bool ToBoolean(object value, bool bDef) { return Convert.IsDBNull(value) ? bDef : Convert.ToBoolean(value); }
        public static byte ToByte(object value, byte bDef) { return Convert.IsDBNull(value) ? bDef : Convert.ToByte(value); }
        public static char ToChar(object value, char cDef) { return Convert.IsDBNull(value) ? cDef : Convert.ToChar(value); }
        public static DateTime ToDateTime(object value, DateTime dtDef) { return Convert.IsDBNull(value) ? dtDef : Convert.ToDateTime(value); }
        public static decimal ToDecimal(object value, decimal dcDef) { return Convert.IsDBNull(value) ? dcDef : Convert.ToDecimal(value); }

        public static double ToDouble(object value, double dDef) { return Convert.IsDBNull(value) ? dDef : Convert.ToDouble(value); }
        public static short ToInt16(object value, short sDef) { return Convert.IsDBNull(value) ? sDef : Convert.ToInt16(value); }
        public static int ToInt32(object value, int iDef) { return Convert.IsDBNull(value) ? iDef : Convert.ToInt32(value); }
        public static long ToInt64(object value, long lDef) { return Convert.IsDBNull(value) ? lDef : Convert.ToInt64(value); }
        public static sbyte ToSByte(object value, sbyte sbDef) { return Convert.IsDBNull(value) ? sbDef : Convert.ToSByte(value); }
        public static float ToSingle(object value, float sDef) { return Convert.IsDBNull(value) ? sDef : Convert.ToSingle(value); }
        public static string ToString(object value, string szDef) { return Convert.IsDBNull(value) ? szDef : Convert.ToString(value); }
        public static ushort ToUInt16(object value, ushort usDef) { return Convert.IsDBNull(value) ? usDef : Convert.ToUInt16(value); }
        public static uint ToUInt32(object value, uint uiDef) { return Convert.IsDBNull(value) ? uiDef : Convert.ToUInt32(value); }
        public static ulong ToUInt64(object value, ulong ulDef) { return Convert.IsDBNull(value) ? ulDef : Convert.ToUInt64(value); }
    }

}
