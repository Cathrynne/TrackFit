using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackFit.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }

        [Required]
        public string ExerciseName { get; set; } = string.Empty;

        public int Sets { get; set; }

        public int Reps { get; set; }

        // 🔥 THIS WAS THE CRASH
        public double Weight { get; set; }

        public string? ExerciseNotes { get; set; }

        [Required]
        public int WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout? Workout { get; set; }
    }
}
