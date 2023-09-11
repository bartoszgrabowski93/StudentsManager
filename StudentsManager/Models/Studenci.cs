using System.ComponentModel.DataAnnotations;

namespace StudentsManager.Models
{
    public class Studenci
    {
        public int IdStudent { get; set; }
        // Adnotację dotyczą tego co poniżej
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string IndexNumber { get; set; }
    }
}
