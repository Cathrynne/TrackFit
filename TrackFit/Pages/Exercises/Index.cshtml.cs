using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrackFit.Data;
using TrackFit.Models;

namespace TrackFit.Pages.Exercises
{
    public class IndexModel : PageModel
    {
        private readonly TrackFitContext _context;

        public IndexModel(TrackFitContext context)
        {
            _context = context;
        }

        public IList<Exercise> Exercise { get; set; } = new List<Exercise>();

        public async Task OnGetAsync()
        {
            Exercise = await _context.Exercises
                .Include(e => e.Workout)   // 🔴 THIS WAS MISSING
                .ToListAsync();
        }
    }
}
