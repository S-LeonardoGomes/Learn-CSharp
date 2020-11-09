using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PalestranteEventoAPIController : ControllerBase
    {
        private readonly IServicoAplicacaoPalestranteEvento _servicoAplicacaoPalestranteEvento;

        #region Construtor
        public PalestranteEventoAPIController(IServicoAplicacaoPalestranteEvento servicoAplicacaoPalestranteEvento)
        {
            _servicoAplicacaoPalestranteEvento = servicoAplicacaoPalestranteEvento;
        }
        #endregion

        #region GetAll
        [HttpGet, Route("")]
        public ActionResult Get()
        {
            try
            {
                return Ok(_servicoAplicacaoPalestranteEvento.ObterTodos());
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
                return Ok(_servicoAplicacaoPalestranteEvento.ObterPorId(id));
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        public ActionResult Delete([FromBody] PalestranteEventoDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Palestrante inválido!" });

                _servicoAplicacaoPalestranteEvento.Deletar(model);
                return Ok("PalestranteEvento deletado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Post([FromBody] PalestranteEventoDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "PalestranteEvento inválido!" });

                _servicoAplicacaoPalestranteEvento.Adicionar(model);
                return Ok("PalestranteEvento adicionado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Put
        [HttpPut]
        public ActionResult Put([FromBody] PalestranteEventoDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "PalestranteEvento inválido!" });

                _servicoAplicacaoPalestranteEvento.Alterar(model);
                return Ok("PalestranteEvento alterado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion
    }
}
