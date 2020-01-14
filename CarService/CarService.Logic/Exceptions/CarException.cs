using System;

namespace CarService.Logic.Exceptions
{
    public class CarException : Exception
    {
        public CarException() : base()
        {
        }
        public CarException(string message) : base(message)
        {
        }
        public CarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}