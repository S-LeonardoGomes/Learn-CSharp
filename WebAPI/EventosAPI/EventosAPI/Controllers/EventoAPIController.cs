using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace EventosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoAPIController : ControllerBase
    {
        private readonly IServicoAplicacaoEvento _servicoAplicacaoEvento;

        #region Construtor
        public EventoAPIController(IServicoAplicacaoEvento servicoAplicacaoEvento)
        {
            _servicoAplicacaoEvento = servicoAplicacaoEvento;
        }
        #endregion

        #region GetAll
        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            try
            {
                return Ok(_servicoAplicacaoEvento.ObterTodos());
            }

            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region GetById
        [HttpGet, Route("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                return Ok(_servicoAplicacaoEvento.ObterPorId(id));
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region GetByTheme
        [HttpGet, Route("GetByTheme/{tema}")]
        public ActionResult GetByTheme(string tema)
        {
            return Ok(_servicoAplicacaoEvento.ObterPorTema(tema));
        }
        #endregion

        #region GetByDate
        [HttpGet, Route("GetByDate")]
        public ActionResult GetByDate([FromQuery] DateTime data)
        {
            return Ok(_servicoAplicacaoEvento.ObterPorData(data));
        }
        #endregion

        #region GetByCep
        [HttpGet, Route("GetByCep")]
        public ActionResult GetByCep([FromQuery] string cep)
        {
            try
            {
                if (cep.Length < 8 && cep.Length > 9)
                    return BadRequest(new { message = "Cep inválido!" });

                return Ok(_servicoAplicacaoEvento.ObterEnderecoPorCep(cep));
            }

            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        public ActionResult Delete([FromBody] EventoDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Evento inválido!" });

                _servicoAplicacaoEvento.Deletar(model);
                return Ok("Evento deletado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Put
        [HttpPut]
        public ActionResult Put([FromBody] EventoDTO model)
        {
            try
            {               
                if (string.IsNullOrEmpty(model.Endereco))
                    return NotFound(new { message = "Endereço inválido!" });

                if (string.IsNullOrEmpty(model.Tema))
                    return NotFound(new { message = "Tema inválido!" });

                if (string.IsNullOrEmpty(model.ImagemUrl))
                    return NotFound(new { message = "Url inválida!" });

                if (model.DataEvento < DateTime.Today)
                    return NotFound(new { message = "DataEvento inválida!" });

                if (model.QtdPessoas < 0)
                    return NotFound(new { message = "Qtd pessoas inválida!" });

                _servicoAplicacaoEvento.Alterar(model);
                return Ok("Evento alterado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Post([FromBody] EventoDTO model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Endereco))
                    return NotFound(new { message = "Endereço inválido!" });

                if (string.IsNullOrEmpty(model.Tema))
                    return NotFound(new { message = "Tema inválido!" });

                if (string.IsNullOrEmpty(model.ImagemUrl))
                    return NotFound(new { message = "Url inválida!" });

                if (model.DataEvento < DateTime.Today)
                    return NotFound(new { message = "DataEvento inválida!" });

                if (model.QtdPessoas < 0)
                    return NotFound(new { message = "Qtd pessoas inválida!" });

                _servicoAplicacaoEvento.Adicionar(model);
                return Ok("Evento adicionado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion
    }
}
