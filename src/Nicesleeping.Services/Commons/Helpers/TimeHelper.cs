using Nicesleeping.Domain.Constants;

namespace Nicesleeping.Services.Commons.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var dtTime = DateTime.UtcNow;
        dtTime.AddHours(TimeConstant.UTC);
        return dtTime;
    }
}
