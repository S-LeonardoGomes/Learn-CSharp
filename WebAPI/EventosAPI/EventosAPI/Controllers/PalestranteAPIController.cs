using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PalestranteAPIController : ControllerBase
    {
        private readonly IServicoAplicacaoPalestrante _servicoAplicacaoPalestrante;

        #region Construtor
        public PalestranteAPIController(IServicoAplicacaoPalestrante servicoAplicacaoPalestrante)
        {
            _servicoAplicacaoPalestrante = servicoAplicacaoPalestrante;
        }
        #endregion

        #region GetAll
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_servicoAplicacaoPalestrante.ObterTodos());
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
                return Ok(_servicoAplicacaoPalestrante.ObterPorId(id));
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        public ActionResult Delete([FromBody] PalestranteDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Palestrante inválido!" });

                _servicoAplicacaoPalestrante.Deletar(model);
                return Ok("Palestrante deletado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Post([FromBody] PalestranteDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Palestrante inválido!" });

                if (string.IsNullOrEmpty(model.Nome))
                    return NotFound(new { message = "Nome inválido!" });

                if (string.IsNullOrEmpty(model.Email))
                    return NotFound(new { message = "Email inválido!" });

                _servicoAplicacaoPalestrante.Adicionar(model);
                return Ok("Palestrante adicionado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Put
        [HttpPut]
        public ActionResult Put([FromBody] PalestranteDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Palestrante inválido!" });

                if (string.IsNullOrEmpty(model.Nome))
                    return NotFound(new { message = "Nome inválido!" });

                if (string.IsNullOrEmpty(model.Email))
                    return NotFound(new { message = "Email inválido!" });

                _servicoAplicacaoPalestrante.Alterar(model);
                return Ok("Palestrante alterado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion
    }
}
