using System.Runtime.InteropServices.ComTypes;
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
    public class DireccionPersonaController : BaseController
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
        
            public DireccionPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IEnumerable<DireccionPersonaDto>>> Get()
            {
                var DireccionPersonas = await _unitOfWork.DireccionPersonas.GetAllAsync();
        
                //var paises = await _unitOfWork.Paises.GetAllAsync();
                return _mapper.Map<List<DireccionPersonaDto>>(DireccionPersonas);
            }
        
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<DireccionPersonaDto>> Post(DireccionPersonaDto DireccionPersonaDto)
            {
                var DireccionPersona = _mapper.Map<Direccionpersona>(DireccionPersonaDto);
                this._unitOfWork.DireccionPersonas.Add(DireccionPersona);
                await _unitOfWork.SaveAsync();
                if (DireccionPersona == null)
                {
                    return BadRequest();
                }
                DireccionPersonaDto.Id = DireccionPersona.Id;
                return CreatedAtAction(nameof(Post), new { id = DireccionPersonaDto.Id }, DireccionPersonaDto);
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<DireccionPersonaDto>> Get(int id)
            {
                var DireccionPersona = await _unitOfWork.DireccionPersonas.GetByIdAsync(id);
                if (DireccionPersona == null){
                    return NotFound();
                }
                return _mapper.Map<DireccionPersonaDto>(DireccionPersona);
            }
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<DireccionPersonaDto>> Put(int id, [FromBody] DireccionPersonaDto DireccionPersonaDto)
            {
                if (DireccionPersonaDto == null)
                {
                    return NotFound();
                }
                var DireccionPersonas = _mapper.Map<Direccionpersona>(DireccionPersonaDto);
                _unitOfWork.DireccionPersonas.Update(DireccionPersonas);
                await _unitOfWork.SaveAsync();
                return DireccionPersonaDto;
            }
        
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id)
            {
                var DireccionPersona = await _unitOfWork.DireccionPersonas.GetByIdAsync(id);
                if (DireccionPersona == null)
                {
                    return NotFound();
                }
                _unitOfWork.DireccionPersonas.Remove(DireccionPersona);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
        }
}