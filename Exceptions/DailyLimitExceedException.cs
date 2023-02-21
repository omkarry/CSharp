using System;

namespace ConsoleApp2.Exceptions
{
    public class DailyLimitExceedException : Exception
    {
        public DailyLimitExceedException() { }

        public DailyLimitExceedException(string message) : base(message) { }
    }
}
