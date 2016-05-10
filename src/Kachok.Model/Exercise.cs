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
        [Required]
        public Muscle TargetMuscle { get; set; }
    }
}
