using Microsoft.Extensions.Logging;
using System;

namespace TennisBookings.Web.Services
{
    public interface ITimeService
    {
        DateTime CurrentTime { get; }
    }

    public interface IUtcTimeService
    {
        DateTime CurrentUtcDateTime { get; }
    }

    public class TimeService : ITimeService, IUtcTimeService
    {
        private readonly ILogger<TimeService> _logger;

        public TimeService(ILogger<TimeService> logger)
        {
            _logger = logger;
        }

        public TimeService()
        {
            var guid = Guid.NewGuid();



            _logger.LogInformation($"TimeService initialised: {guid}");
        }

        public DateTime CurrentTime => DateTime.Now;

        public DateTime CurrentUtcDateTime => DateTime.UtcNow;
    }

    // public class ActionCounter // sample of torn lifetimes?
}
