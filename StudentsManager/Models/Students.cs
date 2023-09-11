using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsManager.Models
{
    [Table("Studenci")]
    public class Students
    {
        [Key]
        public int StudentId { get; set; }

        // Adnotację dotyczą tego co poniżej
        [Required(ErrorMessage = "Imię jest wymagane.")]
        [MaxLength(100,ErrorMessage = "Maksymalna długość imienia wynosi 100 znaków")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(100,ErrorMessage = "Maksymalna długość nazwiska wynosi 100 znaków")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email jest wymagany.")]
        [MaxLength(100, ErrorMessage = "Maksymalna adresu email wynosi 100 znaków")]
        [EmailAddress(ErrorMessage = "Niepoprawny email. Proszę wprowadzić poprawny email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Numer indeksu jest wymagany")]
        [MaxLength(10, ErrorMessage = "Maksymalna długość numer indeksu wynosi 10 znaków")]
        public string IndexNumber { get; set; }
    }
}
