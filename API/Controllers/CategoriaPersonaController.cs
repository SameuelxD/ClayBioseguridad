using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriaPersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaPersonaDto>>> Get()
        {
            var categoriapersonas = await _unitOfWork.CategoriaPersonas.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<CategoriaPersonaDto>>(categoriapersonas);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersonaDto>> Post(CategoriaPersonaDto categoriaPersonaDto)
        {
            var categoriapersona = _mapper.Map<Categoriapersona>(categoriaPersonaDto);
            this._unitOfWork.CategoriaPersonas.Add(categoriapersona);
            await _unitOfWork.SaveAsync();
            if (categoriapersona == null)
            {
                return BadRequest();
            }
            categoriaPersonaDto.Id = categoriapersona.Id;
            return CreatedAtAction(nameof(Post), new { id = categoriaPersonaDto.Id }, categoriaPersonaDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaPersonaDto>> Get(int id)
        {
            var categoriapersona = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);
            if (categoriapersona == null)
            {
                return NotFound();
            }
            return _mapper.Map<CategoriaPersonaDto>(categoriapersona);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersonaDto>> Put(int id, [FromBody] CategoriaPersonaDto categoriaPersonaDto)
        {
            if (categoriaPersonaDto == null)
            {
                return NotFound();
            }
            var categoriaspersonas = _mapper.Map<Categoriapersona>(categoriaPersonaDto);
            _unitOfWork.CategoriaPersonas.Update(categoriaspersonas);
            await _unitOfWork.SaveAsync();
            return categoriaPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var categoriapersona = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);
            if (categoriapersona == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoriaPersonas.Remove(categoriapersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}