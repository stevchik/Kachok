namespace Kachok.Model
{
    public class WorkoutExercise
    {
        public int Id { get; set; }

        public int WorkoutId { get; set; }

        public int PlanWorkoutExerciseId { get; set; }

        public PlanWorkoutExercise PlanWorkoutExercise { get; set; }

        public int SequenceNumber { get; set; }
        
        public string Notes { get; set; }
    }
}
