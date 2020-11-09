using EventosAPI.Aplicacao.Interfaces;
using EventosAPI.Aplicacao.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace EventosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoteAPIController : ControllerBase
    {
        private readonly IServicoAplicacaoLote _servicoAplicacaoLote;

        #region Construtor
        public LoteAPIController(IServicoAplicacaoLote servicoAplicacaoLote)
        {
            _servicoAplicacaoLote = servicoAplicacaoLote;
        }
        #endregion

        #region GetAll
        [HttpGet, Route("")]
        public ActionResult Get()
        {
            try
            {
                return Ok(_servicoAplicacaoLote.ObterTodos());
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
                return Ok(_servicoAplicacaoLote.ObterPorId(id));
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Put
        [HttpPut]
        public ActionResult Put([FromBody] LoteDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Lote inválido!" });

                if (string.IsNullOrEmpty(model.Nome))
                    return NotFound(new { message = "Nome inválido!" });

                if (model.Preco < 2.00)
                    return NotFound(new { message = "Preço inválido!" });

                if (model.Quantidade <= 0)
                    return NotFound(new { message = "Quantidade inválida!" });

                if (model.DataInicio < DateTime.Today)
                    return NotFound(new { message = "Data inicial inválida!" });

                if (model.DataFim < model.DataInicio)
                    return NotFound(new { message = "Data final inválida!" });

                _servicoAplicacaoLote.Alterar(model);
                return Ok("Lote alterado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        public ActionResult Delete([FromBody] LoteDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Lote invalido!" });

                _servicoAplicacaoLote.Deletar(model);
                return Ok("Lote deletado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Post([FromBody] LoteDTO model)
        {
            try
            {
                if (model == null)
                    return NotFound(new { message = "Lote inválido!" });

                if (string.IsNullOrEmpty(model.Nome))
                    return NotFound(new { message = "Nome inválido!" });

                if (model.Preco < 2.00)
                    return NotFound(new { message = "Preço inválido!" });

                if (model.Quantidade <= 0)
                    return NotFound(new { message = "Quantidade inválida!" });

                if (model.DataInicio < DateTime.Today)
                    return NotFound(new { message = "Data inicial inválida!" });

                if (model.DataFim < model.DataInicio)
                    return NotFound(new { message = "Data final inválida!" });

                _servicoAplicacaoLote.Adicionar(model);
                return Ok("Lote adicionado com sucesso!");
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco: {e.Message}");
            }
        }
        #endregion
    }
}
