using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Schronisko.Entities
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Imię")]
        public string Name { get; set; }
        [DisplayName("Zdjęcie")]
        public string Photo { get; set; }
        [DisplayName("Numer telefonu")]
        public string Phone { get; set; }
        [DisplayName("Wiek w msc")]
        public int Age { get; set; }

    }
}