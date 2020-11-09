using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConvidadoAPIController : ControllerBase
    {
        private readonly IServicoAplicacaoConvidado _servicoAplicacaoConvidado;

        #region Construtor
        public ConvidadoAPIController(IServicoAplicacaoConvidado servicoAplicacaoConvidado)
        {
            _servicoAplicacaoConvidado = servicoAplicacaoConvidado;
        }
        #endregion

        #region GetAll
        [HttpGet, Route("")]
        public ActionResult Get()
        {
            try
            {
                return Ok(_servicoAplicacaoConvidado.ObterTodos());
            }

            catch (Exception e)
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
                return Ok(_servicoAplicacaoConvidado.ObterPorId(id));
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region GetByName
        [HttpGet, Route("GetByName")]
        public ActionResult GetByName([FromQuery] string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                    return NotFound(new { message = "O campo 'nome' não pode estar vazio!" });

                return Ok(_servicoAplicacaoConvidado.ObterPorNome(nome));
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Put
        [HttpPut]
        public ActionResult Put([FromBody] ConvidadoDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Convidado inválido!" });

                if (string.IsNullOrEmpty(model.EmailConvidado))
                    return NotFound(new { message = "Email inválido!" });

                if (string.IsNullOrEmpty(model.NomeConvidado))
                    return NotFound(new { message = "Nome inválido!" });

                _servicoAplicacaoConvidado.Alterar(model);
                return Ok("Convidado alterado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        public ActionResult Delete([FromBody] ConvidadoDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Convidado inválido!" });

                _servicoAplicacaoConvidado.Deletar(model);
                return Ok("Convidado deletado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Post([FromBody] ConvidadoDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Convidado inválido!" });

                if (string.IsNullOrEmpty(model.EmailConvidado))
                    return NotFound(new { message = "Email inválido!" });

                if (string.IsNullOrEmpty(model.NomeConvidado))
                    return NotFound(new { message = "Nome inválido!" });

                _servicoAplicacaoConvidado.Adicionar(model);
                return Ok("Convidado adicionado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion
    }
}
