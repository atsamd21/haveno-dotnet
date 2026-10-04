namespace Haveno.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ToDateTime(this long date)
    {
        return DateTime.UnixEpoch.AddMilliseconds(date);
    }

    public static DateTime ToDateTime(this ulong date)
    {
        return ((long)date).ToDateTime();
    }
}
