using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre Completo")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Fecha De Nacimiento")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DisplayName("Ciudad De Procedencia")]
        public string City { get; set; }

        [Required]
        [DisplayName("Correo Electrónico")]
        public string Email { get; set; }


    }
}
