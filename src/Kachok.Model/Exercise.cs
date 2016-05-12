using Kachok.Model.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kachok.Model
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        public Status Status { get; set; }

        [Required]
        public MuscleGroup TargetMuscleGroup { get; set; }
        public Experience Experience { get; set; }
        public ExerciseTarget ExerciseTarget { get; set; }

        public List<ExerciseEquipment> ExerciseEquipments { get; set; }
        public List<ExerciseTag> ExerciseTags { get; set; }
        public List<ExerciseImage> ExerciseImages { get; set; }

        public string CreatedBy { get; set; }
        public DataType CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DataType UpdatedDate { get; set; }
    }
}
