namespace Views.Services;

public class SimpleTimeService : ITimeService
{
    public string GetTime()
    {
        return DateTime.UtcNow.ToString("HH:mm:ss");
    }
}
