using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using API.Data;
using API.Data.Dtos.Banco;
using API.Data.Dtos.Bancos;
using API.Models;
using API.Services;
namespace API.Controllers
{
    [ApiController]
    [Route("/bancos")]
    public class BancosController : ControllerBase
    {
        private APIRepository _context;

        public BancosController(APIRepository db) {
            _context = db;
        }

        [HttpPost]
        public IActionResult adicionar([FromBody] BancosModel banco)
        {
            _context.Add(banco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(listar), new {conta = banco.BancoConta }, banco);
        }

        [HttpGet("{id}")]
        public IActionResult listar() 
        {
            List<BancosModel> registros = _context.Bancos.ToList();
            return Ok(registros);
        }



        [HttpPut("{conta}")]
        public IActionResult alterar(string conta, [FromBody] BancoUpdateDTO atualizado)
        {
        if (atualizado == null)
        {
            return BadRequest();
        }

        var registro = _context.Bancos.FirstOrDefault(x => x.BancoConta == conta);

        if (registro == null)
        {
            return NotFound();
        }

        // Atualize cada propriedade individualmente no objeto "registro"
        registro.BancoAgenciaDig = atualizado.BancoAgenciaDig;
        registro.BancoNome = atualizado.BancoNome;
        registro.BancoContaDig = atualizado.BancoContaDig;
        registro.BancoLiberado = atualizado.BancoLiberado;

        _context.Update(registro);
        _context.SaveChanges();
        return NoContent();
        }
    }


}
