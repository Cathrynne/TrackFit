using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackFit.Data;
using TrackFit.Models;

namespace TrackFit.Pages.Workouts
{
    public class CreateModel : PageModel
    {
        private readonly TrackFitContext _context;

        public CreateModel(TrackFitContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Workout Workout { get; set; } = new Workout();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workouts.Add(Workout);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
