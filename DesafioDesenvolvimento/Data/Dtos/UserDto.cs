using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace DesafioDesenvolvimento.Data.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(50, ErrorMessage ="Nome pode conter ate 50 caracteres")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, ErrorMessage ="infome password ate 30 caracteres")]
        public string Password { get; set; }

    }
}
