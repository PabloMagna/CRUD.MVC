using System.ComponentModel.DataAnnotations;

namespace MVC_FirstPracticeCRUD.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
