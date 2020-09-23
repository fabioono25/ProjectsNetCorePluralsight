using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisBookings.Web.Configuration
{
    public class BookingConfiguration : IBookingConfiguration
    {
        public int MaxRegularBookingLengthInHours { get; set; }

        public int MaxPeakBookingLengthInHours { get; set; }
    }
}
