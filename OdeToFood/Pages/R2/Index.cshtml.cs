using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdeToFood.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly OdeToFood.Data.OdeToFoodDbContext _context;

        public IndexModel(OdeToFood.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get; set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
