using BMA.Domain.DTOs;
using BMA.Domain.Models;
using BMA.Repository.Repository;
using BMA.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BMA.WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        public readonly IBmaPessoaService _service;

        public PessoaController(IBmaPessoaService service)
        {
            _service = service;
        }

        #region Rotas de Listagem de pessoas

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pessoas = await _service.GetAllPersonsAsync();

                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [Route("idosos")]
        [HttpGet("idoso")]
        public async Task<ActionResult> GetIdosos(bool idoso)
        {
            try
            {
                var pessoas = await _service.GetAllPersonsAsync();

                return Ok(pessoas.Where(w => w.Idoso.Equals(idoso)));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        #endregion Rotas de Listagem de pessoas

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaDTO model)
        {
            try
            {
                PessoaModel pessoa = new PessoaModel
                {
                    Nome = model.Nome,
                    Altura = model.Altura,
                    Idade = model.Idade,
                    Peso = model.Peso,
                    Sexo = model.Sexo,
                    Idoso = model.Idoso
                };

                if (await _service.AddPersonAsync(pessoa).ConfigureAwait(false))
                    return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Ocorreu um erro ao cadastrar a pessoa.");
        }

        // PUT: api/Pessoa
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PessoaDTO model)
        {
            try
            {
                var pessoa = await _service.GetPersonByIdAsync(id);
                if (pessoa != null)
                {
                    pessoa.Nome = model.Nome;
                    pessoa.Altura = model.Altura;
                    pessoa.Idade = model.Idade;
                    pessoa.Peso = model.Peso;
                    pessoa.Sexo = model.Sexo;
                    pessoa.Idoso = model.Idoso;

                    if (await _service.UpdatePersonAsync(pessoa).ConfigureAwait(false))
                        return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Ocorreu um erro ao atualizar o cadastro da pessoa!");
        }

        // DELETE: api/Pessoa
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var pessoa = await _service.GetPersonByIdAsync(id);
                if (pessoa != null)
                {
                    if (await _service.RemovePersonAsync(pessoa))
                        return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não Deletado!");
        }
    }
}