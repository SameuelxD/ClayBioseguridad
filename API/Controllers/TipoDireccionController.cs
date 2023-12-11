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
    public class TipoDireccionController : BaseController
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
        
            public TipoDireccionController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IEnumerable<TipoDireccionDto>>> Get()
            {
                var TipoDirecciones = await _unitOfWork.TipoDirecciones.GetAllAsync();
        
                //var paises = await _unitOfWork.Paises.GetAllAsync();
                return _mapper.Map<List<TipoDireccionDto>>(TipoDirecciones);
            }
        
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<TipoDireccionDto>> Post(TipoDireccionDto TipoDireccionDto)
            {
                var TipoDireccion = _mapper.Map<Tipodireccion>(TipoDireccionDto);
                this._unitOfWork.TipoDirecciones.Add(TipoDireccion);
                await _unitOfWork.SaveAsync();
                if (TipoDireccion == null)
                {
                    return BadRequest();
                }
                TipoDireccionDto.Id = TipoDireccion.Id;
                return CreatedAtAction(nameof(Post), new { id = TipoDireccionDto.Id }, TipoDireccionDto);
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<TipoDireccionDto>> Get(int id)
            {
                var TipoDireccion = await _unitOfWork.TipoDirecciones.GetByIdAsync(id);
                if (TipoDireccion == null){
                    return NotFound();
                }
                return _mapper.Map<TipoDireccionDto>(TipoDireccion);
            }
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<TipoDireccionDto>> Put(int id, [FromBody] TipoDireccionDto TipoDireccionDto)
            {
                if (TipoDireccionDto == null)
                {
                    return NotFound();
                }
                var TipoDirecciones = _mapper.Map<Tipodireccion>(TipoDireccionDto);
                _unitOfWork.TipoDirecciones.Update(TipoDirecciones);
                await _unitOfWork.SaveAsync();
                return TipoDireccionDto;
            }
        
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id)
            {
                var TipoDireccion = await _unitOfWork.TipoDirecciones.GetByIdAsync(id);
                if (TipoDireccion == null)
                {
                    return NotFound();
                }
                _unitOfWork.TipoDirecciones.Remove(TipoDireccion);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
        }
}