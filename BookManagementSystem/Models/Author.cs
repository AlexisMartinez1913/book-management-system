using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre Es Obligatorio")]
        [DisplayName("Nombre Completo")]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "La Fecha De Nacimiento Es Obligatoria")]
        [DisplayName("Fecha De Nacimiento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "La Ciudad De Procedencia Es Obligatoria")]
        [DisplayName("Ciudad De Procedencia")]
        [MaxLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [DisplayName("Correo Electrónico")]
        [EmailAddress(ErrorMessage = "Correo Inválido")]
        [MaxLength(255)]
        public string Email { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();


    }
}
