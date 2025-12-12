using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrackFit.Data;
using TrackFit.Models;

namespace TrackFit.Pages_Workouts
{
    public class DetailsModel : PageModel
    {
        private readonly TrackFit.Data.TrackFitContext _context;

        public DetailsModel(TrackFit.Data.TrackFitContext context)
        {
            _context = context;
        }

        public Workout Workout { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workouts.FirstOrDefaultAsync(m => m.WorkoutId == id);

            if (workout is not null)
            {
                Workout = workout;

                return Page();
            }

            return NotFound();
        }
    }
}
