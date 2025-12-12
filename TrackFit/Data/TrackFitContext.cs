using Microsoft.EntityFrameworkCore;
using TrackFit.Models;

namespace TrackFit.Data
{
    public class TrackFitContext : DbContext
    {
        public TrackFitContext(DbContextOptions<TrackFitContext> options)
            : base(options)
        {
        }

        public DbSet<Workout> Workouts { get; set; } = default!;
        public DbSet<Exercise> Exercises { get; set; } = default!;
    }
}
