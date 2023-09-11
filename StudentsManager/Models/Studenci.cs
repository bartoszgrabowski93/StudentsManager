using System.ComponentModel.DataAnnotations;

namespace StudentsManager.Models
{
    public class Studenci
    {
        public int IdStudent { get; set; }
        // Adnotację dotyczą tego co poniżej
        [Required(ErrorMessage = "Imię jest wymagane.")]
        [MaxLength(50)(ErrorMessage = "Maksymalna długość imienia wynosi 50 znaków")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(50)(ErrorMessage = "Maksymalna długość nazwiska wynosi 50 znaków")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email jest wymagany.")]
        [EmailAddress(ErrorMessage = "Niepoprawny email. Proszę wprowadzić poprawny email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Numer indeksu jest wymagany")]
        public string IndexNumber { get; set; }
    }
}
