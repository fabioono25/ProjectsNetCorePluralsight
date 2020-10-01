using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Entities
{
    public class DataEvents
    {
        public static EventId GetMany = new EventId(10001, "GetManyFromProc");
    }
}
