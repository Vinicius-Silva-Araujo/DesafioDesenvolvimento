using System.ComponentModel.DataAnnotations;

namespace DesafioDesenvolvimento.Data.Dtos
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }    

    }
}
