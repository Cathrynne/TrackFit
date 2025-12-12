using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackFit.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }

        [Required]
        public DateTime WorkoutDate { get; set; }

        [Required]
        [Range(1, 600)]
        public int Duration { get; set; }

        [Required]
        public string WorkoutType { get; set; } = string.Empty;

        [Required]
        public string IntensityLevel { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
