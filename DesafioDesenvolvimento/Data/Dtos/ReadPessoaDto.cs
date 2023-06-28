using System.ComponentModel.DataAnnotations;

namespace DesafioDesenvolvimento.Data.Dtos
{
    public class ReadPessoaDto
    {
             
               
        public string Nome { get; set; }
        public string Cpf { get; set; }        
        public string Uf { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateNascimento { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
