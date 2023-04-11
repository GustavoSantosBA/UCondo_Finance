using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace CrossCutting_Extensions
{
    public static class Extensions
    {
        public static int ToInt(this string value)
        {
            try { return Convert.ToInt32(value); }
            catch (Exception) { return 0; }
        }
        public static DateTime ToDate(this string value)
        {
            try { return Convert.ToDateTime(value); }
            catch (Exception) { return DateTime.MinValue; }
        }
        public static decimal ToDecimal(this string value)
        {
            try { return Convert.ToDecimal(value); }
            catch (Exception) { return 0; }
        }
        public static bool ToBool(this string value)
        {
            if (!string.IsNullOrEmpty(value) && value.ToLower() == "true") { return true; }
            return false;
        }
        public static string BoolToString(this bool value)
        {
            if (value) { return "true"; }
            return "false";
        }
        public static int ToInt(this long value)
        {
            try { return Convert.ToInt32(value); }
            catch (Exception) { return 0; }
        }
        public static T ParseEnum<T>(this string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch (Exception)
            {
                return default;
            }
        }
        public static T ParseEnum<T>(this int value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value.ToString(), true);
            }
            catch (Exception)
            {
                return default;
            }
        }
        public static int EnumToInt(this object value)
        {
            return (int)value;
        }
    }
}
