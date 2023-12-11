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
    public class TurnoController : BaseController
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
        
            public TurnoController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IEnumerable<TurnoDto>>> Get()
            {
                var Turnos = await _unitOfWork.Turnos.GetAllAsync();
        
                //var paises = await _unitOfWork.Paises.GetAllAsync();
                return _mapper.Map<List<TurnoDto>>(Turnos);
            }
        
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<TurnoDto>> Post(TurnoDto TurnoDto)
            {
                var Turno = _mapper.Map<Turno>(TurnoDto);
                this._unitOfWork.Turnos.Add(Turno);
                await _unitOfWork.SaveAsync();
                if (Turno == null)
                {
                    return BadRequest();
                }
                TurnoDto.Id = Turno.Id;
                return CreatedAtAction(nameof(Post), new { id = TurnoDto.Id }, TurnoDto);
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<TurnoDto>> Get(int id)
            {
                var Turno = await _unitOfWork.Turnos.GetByIdAsync(id);
                if (Turno == null){
                    return NotFound();
                }
                return _mapper.Map<TurnoDto>(Turno);
            }
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<TurnoDto>> Put(int id, [FromBody] TurnoDto TurnoDto)
            {
                if (TurnoDto == null)
                {
                    return NotFound();
                }
                var Turnos = _mapper.Map<Turno>(TurnoDto);
                _unitOfWork.Turnos.Update(Turnos);
                await _unitOfWork.SaveAsync();
                return TurnoDto;
            }
        
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id)
            {
                var Turno = await _unitOfWork.Turnos.GetByIdAsync(id);
                if (Turno == null)
                {
                    return NotFound();
                }
                _unitOfWork.Turnos.Remove(Turno);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
        }
}