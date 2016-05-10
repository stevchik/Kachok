using System.ComponentModel.DataAnnotations;

namespace Kachok.Entities
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
