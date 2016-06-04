using Kachok.Model.Enum;
using System.Collections.Generic;

namespace Kachok.Model
{
    public class PlanWorkoutExercise
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public Status Status { get; set; }

        public int SequenceNumber { get; set; }
        //Used for SuperSet
        public int? SubSequenceNumber { get; set; }

        public List<PlanWorkoutExerciseStep> PlanWorkoutExerciseSteps { get; set; }

        public string SpecialInstructions { get; set; }
    }
}
