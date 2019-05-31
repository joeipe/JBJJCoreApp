using System;
using System.Globalization;

namespace SharedKernel.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        static readonly string dateFormat = "dd/MM/yyyy";

        public static DateTime ParseDate(this string date)
        {
            DateTime res = DateTime.ParseExact(date, dateFormat, CultureInfo.InvariantCulture);
            return res;
        }

        public static string ParseDate(this DateTime date)
        {
            string res = date.ToString(dateFormat);
            return res;
        }
    }
}
