using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                return _context.Categorias.Include(x => x.Produtos).ToList();
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Erro ao tentar obter as categorias do banco de dados");
            }
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            try
            {
                Categoria categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id);
                if (categoria == null)
                    return NotFound($"A categoria com id = {id} não foi encontrada");

                return categoria;
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar obter a categoria do banco de dados");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar criar uma nova categoria");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId)
                    return BadRequest($"Não foi possível alterar a categoria com id = {id}");

                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok($"Categoria com id = {id} atualizada com sucesso");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar categoria com id = {id}");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            try
            {
                Categoria categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
                if (categoria == null)
                    return NotFound($"A categoria com id = {id} não foi encontrada");

                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
                return categoria;
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir a categoria de id = {id}");
            }
        }
    }
}
