using Kachok.Model.Enum;

namespace Kachok.Model
{
    public class PlanWorkoutExerciseStep
    {
        public int Id { get; set; }
        public int PlanWorkoutExerciseId { get; set; }
        public int SequenceNumber { get; set; }
        public int NumberOfSets { get; set; }
        public int UnitMin { get; set; }
        public int UnitMax { get; set; }
        public ExerciseUom UnitOfMeasure { get; set; }
        public int RestInterval { get; set; }
        public int? ExerciseTechniqueId { get; set; }
        public ExerciseTechnique ExerciseTechnique { get; set; }
        public string SpecialInstructions { get; set; }
    }
}
