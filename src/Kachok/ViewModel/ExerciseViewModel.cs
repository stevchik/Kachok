using Kachok.Model;
using Kachok.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.ViewModel
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        public Status Status { get; set; }

        public ExerciseUom DefaultExerciseUom { get; set; }

        [Required]
        public string TargetMuscleGroupName { get; set; }
        public Experience Experience { get; set; }
        [Required]
        public ExerciseTarget ExerciseTarget { get; set; }

        public IList<ExerciseEquipmentViewModel> ExerciseEquipments { get; set; }
        public List<ExerciseTagViewModel> ExerciseTags { get; set; }
        public List<ExerciseImage> ExerciseImages { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
