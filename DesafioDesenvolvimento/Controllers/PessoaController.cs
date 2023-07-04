using AutoMapper;
using DesafioDesenvolvimento.Data;
using DesafioDesenvolvimento.Data.Dtos;
using DesafioDesenvolvimento.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

    /// <summary>
    /// Adiciona uma pessoa ao banco de dados
    /// </summary>
    /// <param name="pessoaDto"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicinarPessoa([FromBody] CreatePessoaDto pessoaDto)
    {
        Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
        pessoa.Date = DateTime.Now; 
        _context.Add(pessoa);
        _context.SaveChanges();       
        return CreatedAtAction(nameof(ConsultaPessoasId), new { id = pessoa.Id }, pessoa);
       
    }

    /// <summary>
    /// Busca pessoas no banco de dados utilizando skip e take
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ReadPessoaDto> ConsultaPessoas([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var listaDePessoa = _context.Pessoas.ToList();
        return _mapper.Map<List<ReadPessoaDto>>( _context.Pessoas.Skip(skip).Take(take));
    }

    /// <summary>
    /// Busca pessoa por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult ConsultaPessoasId(int id) 
    {
       var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
        if(pessoa == null) return NotFound();
        var pessoaDto = _mapper.Map<ReadPessoaDto>(pessoa);
        return Ok(pessoaDto);

    }

    /// <summary>
    /// Busca pelo UF
    /// </summary>
    /// <param name="uf"></param>
    /// <returns></returns>
    [HttpGet("uf/{Uf}")]
    public IEnumerable<ReadPessoaDto> ConsultaPessoasUf(string uf)
    {
        var listaPessoa = _context.Pessoas.Where(pessoa => pessoa.Uf.ToUpper().Contains(uf.ToUpper())).ToList();
        var listPessoa = listaPessoa.Where(pessoa => pessoa.Uf.Contains(uf)).ToList(); 
        return _mapper.Map<List<ReadPessoaDto>>(listaPessoa);
    }
      
    /// <summary>        
    /// Altera todo cadasto passando todos os paramentos      
    /// </summary>      
    /// <param name="id"></param>     
    /// <param name="pessoaDto"></param>        
    /// <returns></returns>
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

    /// <summary>
    /// Altera determinado campo do cadastro 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patch"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public IActionResult AtualizaPessoaParcial(int id, JsonPatchDocument<UpdatePessoaDto> patch)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(
            pessoa => pessoa.Id == id);
        if (pessoa == null) return NotFound();
        var PessoaParaAtualiza = _mapper.Map<UpdatePessoaDto>(pessoa);
        patch.ApplyTo(PessoaParaAtualiza, ModelState);

        if(!TryValidateModel(PessoaParaAtualiza))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(PessoaParaAtualiza, pessoa);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um cadastro pelo Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult DeletaPessoa(int id)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(
            pessoa => pessoa.Id == id);
        if (pessoa == null) return NotFound();
        _context.Remove(pessoa);
        _context.SaveChanges();
        return NoContent();
    }
}
