using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace garpunkal.EntityFrameworkSandbox.Web.AutoMapper
{
    public class AutoMapperTypeConverters
    {
        public const string UkDateFormat = "dd/MM/yyyy";
        public const string UkDateTimeFormat = "dd/MM/yyyy HH:mm";
        public const string UKDateDayFormat = "dddd dd/MM/yyyy";
        public const string UKDateDayTimeFormat = "dddd dd/MM/yyyy HH:mm";
        public const string TimeFormat = "HH:mm";

        public static long ConvertToInt64(string input)
        {
            long output = 0;

            if (input == null)
                return output;

            long.TryParse(input, out output);
            return output;
        }

        public static short ConvertToInt16(string input)
        {
            short output = 0;

            if (input == null)
                return output;

            short.TryParse(input, out output);
            return output;
        }

        public static int ConvertToInt32(string input)
        {
            int output = 0;

            if (input == null)
                return output;

            int.TryParse(input, out output);
            return output;
        }

        public static int? ConvertToNullableInt32(string input)
        {
            int output = 0;

            if (input == null)
                return null;

            int.TryParse(input, out output);
            return new int?(output);
        }

        public static DateTime ConvertToDateTime(string input)
        {
            var output = DateTime.MinValue;

            return input == null ? output : Convert.ToDateTime(input);

            //TODO: Check length of input to determine if it's a datetime or just a date
        }

        public static DateTime? ConvertToNullableDateTime(string input)
        {
            DateTime? output = null;

            return input == null ? output : Convert.ToDateTime(input);

            //TODO: Check length of input to determine if it's a datetime or just a date
        }

        public static string ConvertDateTimeToString(DateTime input)
        {
            string output = null;

            if (input == DateTime.MinValue)
                return output;

            return input.ToString(input.TimeOfDay == TimeSpan.Zero ? UkDateFormat : UkDateTimeFormat);
        }
    }
}