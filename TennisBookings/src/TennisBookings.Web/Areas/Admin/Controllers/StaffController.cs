using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TennisBookings.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Staff")]
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        [Route("Add")]
        public ViewResult AddStaffMember()
        {
            return View();
        }
    }
}
