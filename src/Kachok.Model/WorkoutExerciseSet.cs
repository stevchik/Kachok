using Kachok.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Model
{
    public class WorkoutExerciseSet
    {
        public int Id { get; set; }
        public int WorkoutExerciseId { get; set; }

        public DateTime CreatedDate { get; set; }
        public int SetNumber { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        
        public int? SubSequenceNumber { get; set; }
        
        public int UnitX { get; set; }
        public int UnitY { get; set; }
        public ExerciseUom UnitOfMeasure { get; set; }
        
        public int? ExerciseTechniqueId { get; set; }
        public ExerciseTechnique ExerciseTechnique { get; set; }

        public string Notes { get; set; }
    }
}
