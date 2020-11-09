using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RedeSocialAPIController : ControllerBase
    {
        private readonly IServicoAplicacaoRedeSocial _servicoAplicacaoRedeSocial;

        #region Construtor
        public RedeSocialAPIController(IServicoAplicacaoRedeSocial servicoAplicacaoRedeSocial)
        {
            _servicoAplicacaoRedeSocial = servicoAplicacaoRedeSocial;
        }
        #endregion

        #region GetAll
        [HttpGet, Route("")]
        public ActionResult Get()
        {
            try
            {
                return Ok(_servicoAplicacaoRedeSocial.ObterTodos());
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
                return Ok(_servicoAplicacaoRedeSocial.ObterPorId(id));
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region GetByGroupId
        [HttpGet, Route("GetByGroupId")]
        public ActionResult ObterPorGrupoId([FromQuery] int id)
        {
            try
            {
                if (id != 1 && id != 2)
                    return NotFound(new { message = "O GrupoId informado não existe!" });

                return Ok(_servicoAplicacaoRedeSocial.ObterPorGrupoId(id));
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        public ActionResult Delete([FromBody] RedeSocialDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Rede social inválida!" });

                _servicoAplicacaoRedeSocial.Deletar(model);
                return Ok("Rede social deletada com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Post([FromBody] RedeSocialDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Rede social inválida!" });

                if (string.IsNullOrEmpty(model.Nome))
                    return NotFound(new { message = "Nome inválido!" });

                if (string.IsNullOrEmpty(model.Url))
                    return NotFound(new { message = "Url inválida!" });

                _servicoAplicacaoRedeSocial.Adicionar(model);
                return Ok("Rede social adicionada com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Put
        [HttpPut]
        public ActionResult Put([FromBody] RedeSocialDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Rede social inválida!" });

                if (string.IsNullOrEmpty(model.Nome))
                    return NotFound(new { message = "Nome inválido!" });

                if (string.IsNullOrEmpty(model.Url))
                    return NotFound(new { message = "Url inválida!" });

                _servicoAplicacaoRedeSocial.Alterar(model);
                return Ok("Rede social alterada com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion
    }
}
