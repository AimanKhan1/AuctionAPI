using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Helper
{
    public static class Validate
    {
        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }

        public static string CheckSubString(this object obj)
        {
            return obj.ToString().Substring(0, Math.Min(50, obj.ToString().Length));
        }

        public static string CheckStringNull(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            if (obj == DBNull.Value)
            {
                return string.Empty;
            }
            return obj.ToString();

        }

        public static string IsCheckStringNull(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return null;
            }

            return obj.ToString();

        }
        public static string IsCheckStringEmpty(object obj)
        {
            if (obj == null || obj == DBNull.Value || string.IsNullOrEmpty(Convert.ToString(obj)))
            {
                return null;
            }

            return obj.ToString();

        }

        public static int CheckIntegerNull(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            if (obj == DBNull.Value || obj is string && string.IsNullOrEmpty((string)obj))
            {
                return 0;
            }

            return Convert.ToInt32(obj);

        }
        public static Guid CheckGuidNull(object obj)
        {
            if (obj == DBNull.Value || obj == null)
            {
                return new Guid();
            }
            return new Guid(obj.ToString());

        }
        public static int? IsCheckIntegerNull(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            if (obj == DBNull.Value || obj is string && string.IsNullOrEmpty((string)obj))
            {
                return null;
            }

            return Convert.ToInt32(obj);

        }
        public static short CheckSmallIntegerNull(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            if (obj == DBNull.Value || obj is string && string.IsNullOrEmpty((string)obj))
            {
                return 0;
            }
            return Convert.ToInt16(obj);

        }
        public static byte CheckByteNull(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            if (obj == DBNull.Value || obj is string && string.IsNullOrEmpty((string)obj))
            {
                return 0;
            }
            return Convert.ToByte(obj);

        }
        public static long CheckLongNull(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            if (obj == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt64(obj);

        }
        public static double CheckDoubleNull(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            if (obj == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDouble(obj);

        }
        public static bool CheckBooleanNull(object obj)
        {

            if (obj == null)
            {
                return false;
            }
            if (obj == DBNull.Value)
            {
                return false;
            }
            return Convert.ToBoolean(obj);

        }
        public static bool? IsCheckBooleanNull(object obj)
        {

            if (obj == null)
            {
                return null;
            }
            if (obj == DBNull.Value)
            {
                return null;
            }
            return Convert.ToBoolean(obj);

        }
        public static short? IsCheckShortNull(object obj)
        {

            if (obj == null)
            {
                return null;
            }
            if (obj == DBNull.Value)
            {
                return null;
            }
            return Convert.ToInt16(obj);

        }
        public static short CheckShortNull(object obj)
        {

            if (obj == null)
            {
                return 0;
            }
            if (obj == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt16(obj);
        }
        public static DateTime CheckDateTimeNull(object obj)
        {

            if (obj == null)
            {
                return DateTime.UtcNow;
            }
            if (obj == DBNull.Value)
            {
                return DateTime.UtcNow;
            }
            return Convert.ToDateTime(obj);

        }
        public static DateTime? IsCheckDateTimeNull(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            if (obj == DBNull.Value)
            {
                return null;
            }
            return Convert.ToDateTime(obj);
        }

        public static decimal? IsCheckDecimalNull(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            if (obj == DBNull.Value)
            {
                return null;
            }
            return Convert.ToDecimal(obj);

        }
        public static decimal CheckDecimalNull(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            if (obj == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(obj);

        }
        public static float CheckfloatNull(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            if (obj == DBNull.Value)
            {
                return 0;
            }
            return float.Parse(obj.ToString());

        }
        public static TimeSpan CheckTimeSpanNull(object obj)
        {
            if (obj == null)
            {
                return DateTime.UtcNow.TimeOfDay;
            }
            if (obj == DBNull.Value)
            {
                return DateTime.UtcNow.TimeOfDay;
            }
            return (TimeSpan)obj;
        }
        public static TimeSpan? IsCheckTimeSpanNull(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            if (obj == DBNull.Value)
            {
                return null;
            }
            return (TimeSpan)obj;
        }
        public static byte[] CheckImageNull(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return null;
                }
                if (obj == DBNull.Value)
                {
                    return null;
                }
                return (byte[])obj;
            }
            catch (Exception ex)
            {
                throw new Exception("CheckfloatNull", ex);
            }
        }
        public static Guid CheckGUIDNull(object obj)
        {
            try
            {
                if (obj == null)
                    return Guid.Empty;
                if (obj == DBNull.Value)
                    return Guid.Empty;
                return (Guid)obj;
            }
            catch (Exception ex)
            {
                throw new Exception("CheckGUIDNull", ex);
            }
        }
    }
}
