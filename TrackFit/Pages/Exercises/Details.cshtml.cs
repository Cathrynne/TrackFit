using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrackFit.Data;
using TrackFit.Models;

namespace TrackFit.Pages_Exercises
{
    public class DetailsModel : PageModel
    {
        private readonly TrackFit.Data.TrackFitContext _context;

        public DetailsModel(TrackFit.Data.TrackFitContext context)
        {
            _context = context;
        }

        public Exercise Exercise { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises.FirstOrDefaultAsync(m => m.ExerciseId == id);

            if (exercise is not null)
            {
                Exercise = exercise;

                return Page();
            }

            return NotFound();
        }
    }
}
