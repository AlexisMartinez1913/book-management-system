using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es requerido")]
        [DisplayName("Titulo")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        [DisplayName("Año")]
        [Range(0, 2025, ErrorMessage = "Año inválido")]
        public int Year { get; set; }

        [Required(ErrorMessage = "El Género es obligatorio")]
        [DisplayName("Género")]
        [MaxLength(100)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "El número de páginas es obligatorio")]
        [DisplayName("Número De Páginas")]
        [Range(1, int.MaxValue, ErrorMessage = "El Número de páginas debe ser mayor a 0")]
        public int PageCount { get; set; }

        [ForeignKey("Author")]
        public int AuthorId {  get; set; }
        public Author Author { get; set; }


    }
}
