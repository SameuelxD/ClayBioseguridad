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
    public class TipoPersonaController : BaseController
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
        
            public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
            {
                var TipoPersonas = await _unitOfWork.TipoPersonas.GetAllAsync();
        
                //var paises = await _unitOfWork.Paises.GetAllAsync();
                return _mapper.Map<List<TipoPersonaDto>>(TipoPersonas);
            }
        
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<TipoPersonaDto>> Post(TipoPersonaDto TipoPersonaDto)
            {
                var TipoPersona = _mapper.Map<Tipopersona>(TipoPersonaDto);
                this._unitOfWork.TipoPersonas.Add(TipoPersona);
                await _unitOfWork.SaveAsync();
                if (TipoPersona == null)
                {
                    return BadRequest();
                }
                TipoPersonaDto.Id = TipoPersona.Id;
                return CreatedAtAction(nameof(Post), new { id = TipoPersonaDto.Id }, TipoPersonaDto);
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<TipoPersonaDto>> Get(int id)
            {
                var TipoPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);
                if (TipoPersona == null){
                    return NotFound();
                }
                return _mapper.Map<TipoPersonaDto>(TipoPersona);
            }
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto TipoPersonaDto)
            {
                if (TipoPersonaDto == null)
                {
                    return NotFound();
                }
                var TipoPersonas = _mapper.Map<Tipopersona>(TipoPersonaDto);
                _unitOfWork.TipoPersonas.Update(TipoPersonas);
                await _unitOfWork.SaveAsync();
                return TipoPersonaDto;
            }
        
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id)
            {
                var TipoPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);
                if (TipoPersona == null)
                {
                    return NotFound();
                }
                _unitOfWork.TipoPersonas.Remove(TipoPersona);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
        }
}