using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Schronisko.Models
{
    public class DogModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Imię")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Zdjęcie")]
        public string Photo { get; set; }
        [Required]
        [DisplayName("Numer telefonu")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Wiek w msc")]
        public int Age { get; set; }
    }
}