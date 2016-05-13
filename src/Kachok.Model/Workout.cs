using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Model
{
    public class Workout
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int PlanWorkoutId { get; set; }
        public int DayNumber { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
