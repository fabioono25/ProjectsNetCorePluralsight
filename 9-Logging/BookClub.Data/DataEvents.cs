using Microsoft.Extensions.Logging;

namespace BookClub.Data
{
    public class DataEvents
    {
        public static EventId GetMany = new EventId(10001, "GetManyFromProc");
    }
}
