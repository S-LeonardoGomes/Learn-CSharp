using APICatalogo.Context;
using APICatalogo.DTOs;
using APICatalogo.Models;
using APICatalogo.Pagination;
using APICatalogo.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public CategoriasController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<CategoriaDTO>> GetCategoriasProdutos()
        {
            List<Categoria> categoria = _uof.CategoriaRepository.GetCategoriasProdutos().ToList();
            List<CategoriaDTO> categoriaDTO = _mapper.Map<List<CategoriaDTO>>(categoria);
            return categoriaDTO;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaDTO>> Get([FromQuery] CategoriasParameters categoriasParameters)
        {
            PagedList<Categoria> categorias = _uof.CategoriaRepository.GetCategorias(categoriasParameters);

            var metadata = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            List<CategoriaDTO> categoriaDTO = _mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriaDTO;
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<CategoriaDTO> Get(int id)
        {
            Categoria categoria = _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);
            if (categoria == null)
                return NotFound($"A categoria com id = {id} não foi encontrada");

            CategoriaDTO categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return categoriaDTO;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CategoriaDTO categoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _uof.CategoriaRepository.Add(categoria);
            _uof.Commit();

            CategoriaDTO categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoriaDTO);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Put(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (id != categoriaDto.CategoriaId)
                return BadRequest($"Não foi possível alterar a categoria com id = {id}");

            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _uof.CategoriaRepository.Update(categoria);
            _uof.Commit();
            return Ok($"Categoria com id = {id} atualizada com sucesso");
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<CategoriaDTO> Delete(int id)
        {
            Categoria categoria = _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);
            if (categoria == null)
                return NotFound($"A categoria com id = {id} não foi encontrada");

            _uof.CategoriaRepository.Delete(categoria);
            _uof.Commit();

            CategoriaDTO categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return categoriaDTO;
        }
    }
}
