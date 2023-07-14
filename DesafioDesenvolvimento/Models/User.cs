using System.ComponentModel.DataAnnotations;

namespace DesafioDesenvolvimento.Models
{
    public class User

    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(20)]
        public string? Password { get; set; }
        [Required]
        [StringLength(15, ErrorMessage ="digite Admin ou usuario")]
        public string? Role { get; set; }

    }
}
