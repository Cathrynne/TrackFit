using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrackFit.Data;
using TrackFit.Models;

namespace TrackFit.Pages.Workouts
{
    public class IndexModel : PageModel
    {
        private readonly TrackFitContext _context;

        public IndexModel(TrackFitContext context)
        {
            _context = context;
        }

        public IList<Workout> Workout { get; set; } = new List<Workout>();

        public async Task OnGetAsync()
        {
            Workout = await _context.Workouts.ToListAsync();
        }
    }
}
