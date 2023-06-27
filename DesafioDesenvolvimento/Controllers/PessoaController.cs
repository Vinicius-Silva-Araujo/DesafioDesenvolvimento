using AutoMapper;
using DesafioDesenvolvimento.Data;
using DesafioDesenvolvimento.Data.Dtos;
using DesafioDesenvolvimento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace DesafioDesenvolvimento.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private PessoaContext _context;
    private IMapper _mapper;

    public PessoaController(PessoaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicinarPessoa([FromBody] CreatePessoaDto pessoaDto)
    {
        Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
        pessoa.Date = DateTime.Now; 
        _context.Add(pessoa);
        _context.SaveChanges();       
        return CreatedAtAction(nameof(ConsultaPessoasId), new { id = pessoa.Id }, pessoa);
       
    }

    [HttpGet]
    public IEnumerable<Pessoa> ConsultaPessoas([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var listaDePessoa = _context.Pessoas.ToList();
        return _context.Pessoas.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ConsultaPessoasId(int id) 
    {
       var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
        if(pessoa == null) throw new Exception("Id buscado não encontrado");
        return Ok(pessoa);

    }

    [HttpPut("{id}")]
    public IActionResult AtualizaPessoa(int id, [FromBody] UpdatePessoaDto pessoaDto)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(
            pessoa => pessoa.Id == id);
        if (pessoa == null) return NotFound();
        _mapper.Map(pessoaDto, pessoa);
        _context.SaveChanges();
        return NoContent();
    }
        
}
