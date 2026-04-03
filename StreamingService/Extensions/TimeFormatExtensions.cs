namespace StreamingService.Extensions
{
    public static class TimeFormatExtensions
    {
        public static string ToMinutesSeconds(this int totalSeconds)
        {
            var ts = TimeSpan.FromSeconds(totalSeconds);
            return $"{ts.Minutes:D2}:{ts.Seconds:D2}";
        }

        public static string ToHoursMinutes(this int totalSeconds)
        {
            var ts = TimeSpan.FromSeconds(totalSeconds);
            return ts.Hours > 0
                ? $"{ts.Hours} год {ts.Minutes} хв"
                : $"{ts.Minutes} хв";
        }
    }
}
