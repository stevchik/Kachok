using System.ComponentModel.DataAnnotations;

namespace Kachok.Model
{
    public class Muscle
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
