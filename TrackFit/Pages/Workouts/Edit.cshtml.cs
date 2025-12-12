using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrackFit.Data;
using TrackFit.Models;

namespace TrackFit.Pages_Workouts
{
    public class EditModel : PageModel
    {
        private readonly TrackFit.Data.TrackFitContext _context;

        public EditModel(TrackFit.Data.TrackFitContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Workout Workout { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout =  await _context.Workouts.FirstOrDefaultAsync(m => m.WorkoutId == id);
            if (workout == null)
            {
                return NotFound();
            }
            Workout = workout;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(Workout.WorkoutId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workouts.Any(e => e.WorkoutId == id);
        }
    }
}
