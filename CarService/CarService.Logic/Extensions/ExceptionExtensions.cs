using System;
using System.Text;

namespace CarService.Logic.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetMessage(this Exception exception, Guid guid = default(Guid))
        {
            if (guid == default(Guid))
                guid = Guid.NewGuid();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{guid} Message: {exception.Message}, Type: {exception.GetType()}");
            stringBuilder.AppendLine($"{guid} Stack trace: {exception.StackTrace}");

            return stringBuilder.ToString();
        }
    }
}