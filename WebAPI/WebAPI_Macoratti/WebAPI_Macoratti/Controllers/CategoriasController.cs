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
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProdutos()
        {
            IEnumerable<Categoria> categoria = await _uof.CategoriaRepository.GetCategoriasProdutos();
            List<CategoriaDTO> categoriaDTO = _mapper.Map<List<CategoriaDTO>>(categoria);
            return categoriaDTO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get([FromQuery] CategoriasParameters categoriasParameters)
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
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            Categoria categoria = await _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);
            if (categoria == null)
                return NotFound($"A categoria com id = {id} não foi encontrada");

            CategoriaDTO categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return categoriaDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _uof.CategoriaRepository.Add(categoria);
            await _uof.Commit();

            CategoriaDTO categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoriaDTO);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (id != categoriaDto.CategoriaId)
                return BadRequest($"Não foi possível alterar a categoria com id = {id}");

            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _uof.CategoriaRepository.Update(categoria);
            await _uof.Commit();
            return Ok($"Categoria com id = {id} atualizada com sucesso");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            Categoria categoria = await _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);
            if (categoria == null)
                return NotFound($"A categoria com id = {id} não foi encontrada");

            _uof.CategoriaRepository.Delete(categoria);
            await _uof.Commit();

            CategoriaDTO categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return categoriaDTO;
        }
    }
}
