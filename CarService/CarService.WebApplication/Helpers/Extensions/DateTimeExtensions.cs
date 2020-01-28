using System;

namespace CarService.WebApplication.Helpers.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToShortedDateByYear(this DateTime date)
        {
            if (date == null || date == default(DateTime))
                return string.Empty;

            return date.ToString("yyyy.MM.dd");
        }
    }
}