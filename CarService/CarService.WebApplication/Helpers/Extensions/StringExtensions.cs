namespace CarService.WebApplication.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return char.ToUpper(value[0]) + value.Substring(1);
        }
    }
}