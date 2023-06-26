using DesafioDesenvolvimento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioDesenvolvimento.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private static List<Pessoa> pessoas = new List<Pessoa>();
    private static int id = 0;




    [HttpPost]
    public IActionResult IActinResult([FromBody] Pessoa pessoa)
    {
        pessoa.Date = DateTime.Now; 
        pessoas.Add(pessoa);
        pessoa.Id = id++;
        return CreatedAtAction(nameof(ConsultaPessoasId), new { id = pessoa.Id }, pessoa);
        Console.WriteLine(pessoa.Nome);
        Console.WriteLine(pessoa.Cpf);
        Console.WriteLine(pessoa.UF);
        Console.WriteLine(pessoa.DateNascimento);
        Console.WriteLine(pessoa.Date);

    }
    [HttpGet]
    public IEnumerable<Pessoa> ConsultaPessoas([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return pessoas.Skip(skip).Take(take);
    }
    [HttpGet("{id}")]
    public IActionResult ConsultaPessoasId(int id) 
    {
       var pessoa = pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
        if(pessoa == null) return NotFound();
        return Ok(pessoa);

    }
        
}
