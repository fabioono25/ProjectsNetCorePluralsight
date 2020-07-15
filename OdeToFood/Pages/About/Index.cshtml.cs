using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.About
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration config;
        public string Message { get; set; }

        public IndexModel(IConfiguration config)
        {
            this.config = config;
        }

        public void OnGet()
        {
            //Message = "Hello World!";
            Message = config["Message"];
        }
    }
}
