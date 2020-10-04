using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TennisBookings.Web.Data
{
    public class TennisBookingsUser : IdentityUser
    {
        public virtual ICollection<CourtBooking> CourtBookings { get; set; }

        public virtual Member Member { get; set; }

        public DateTime LastRequestUtc { get; set; }
    }
}
