namespace SAPINT.Linq
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    public static class SAPExtensions
    {
        public static bool InList(this string s, params string[] values)
        {
            if (values.Length > 0)
            {
                foreach (string str in values)
                {
                    if (str.Equals(s))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static int ToSAPDate(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException();
            }
            try
            {
                DateTime time;
                if (DateTime.TryParseExact(s, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
                {
                    return Convert.ToInt32(time.ToString("yyyyMMdd"));
                }
            }
            catch
            {
            }
            return -1;
        }
    }
}

