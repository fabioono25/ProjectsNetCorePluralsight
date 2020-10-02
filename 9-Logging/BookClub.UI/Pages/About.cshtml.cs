using BookClub.Infrastructure.BaseClasses;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookClub.UI.Pages
{
    public class AboutModel : BasePageModel
    {
        //Serilog static log method
        public AboutModel(ILogger<AboutModel> logger): base(logger)
        {

        }

        public void OnGet()
        {

        }
    }
}