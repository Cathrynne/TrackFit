using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrackFit.Data;
using TrackFit.Models;

namespace TrackFit.Pages.Exercises
{
    public class CreateModel : PageModel
    {
        private readonly TrackFitContext _context;

        public CreateModel(TrackFitContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exercise Exercise { get; set; } = default!;

        public SelectList WorkoutOptions { get; set; } = default!;

        public async Task OnGetAsync()
        {
            WorkoutOptions = new SelectList(
                await _context.Workouts.ToListAsync(),
                "WorkoutId",
                "WorkoutType"
            );
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                WorkoutOptions = new SelectList(
                    await _context.Workouts.ToListAsync(),
                    "WorkoutId",
                    "WorkoutType"
                );
                return Page();
            }

            _context.Exercises.Add(Exercise);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
