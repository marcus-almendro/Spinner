using System;

namespace Spinner.Domain.Common
{
    public static class Clock
    {
        private static DateTimeOffset TestDateTimeOffset => new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero);
        public static DateTimeOffset UtcNow => UseTestClock ? TestDateTimeOffset : DateTimeOffset.UtcNow;

        public static bool UseTestClock { get; set; }
    }
}
