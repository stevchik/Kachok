using System.ComponentModel.DataAnnotations;

namespace Kachok.Entities
{
    public class Muscle
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
