using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Darka.Core;
using Darka.Data;

namespace Darka.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly Darka.Data.DarkaDbContext _context;

        public IndexModel(Darka.Data.DarkaDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
