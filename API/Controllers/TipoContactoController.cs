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
    public class TipoContactoController : BaseController
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
        
            public TipoContactoController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IEnumerable<TipoContactoDto>>> Get()
            {
                var TipoContactos = await _unitOfWork.TipoContactos.GetAllAsync();
        
                //var paises = await _unitOfWork.Paises.GetAllAsync();
                return _mapper.Map<List<TipoContactoDto>>(TipoContactos);
            }
        
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<TipoContactoDto>> Post(TipoContactoDto TipoContactoDto)
            {
                var TipoContacto = _mapper.Map<Tipocontacto>(TipoContactoDto);
                this._unitOfWork.TipoContactos.Add(TipoContacto);
                await _unitOfWork.SaveAsync();
                if (TipoContacto == null)
                {
                    return BadRequest();
                }
                TipoContactoDto.Id = TipoContacto.Id;
                return CreatedAtAction(nameof(Post), new { id = TipoContactoDto.Id }, TipoContactoDto);
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<TipoContactoDto>> Get(int id)
            {
                var TipoContacto = await _unitOfWork.TipoContactos.GetByIdAsync(id);
                if (TipoContacto == null){
                    return NotFound();
                }
                return _mapper.Map<TipoContactoDto>(TipoContacto);
            }
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<TipoContactoDto>> Put(int id, [FromBody] TipoContactoDto TipoContactoDto)
            {
                if (TipoContactoDto == null)
                {
                    return NotFound();
                }
                var TipoContactos = _mapper.Map<Tipocontacto>(TipoContactoDto);
                _unitOfWork.TipoContactos.Update(TipoContactos);
                await _unitOfWork.SaveAsync();
                return TipoContactoDto;
            }
        
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id)
            {
                var TipoContacto = await _unitOfWork.TipoContactos.GetByIdAsync(id);
                if (TipoContacto == null)
                {
                    return NotFound();
                }
                _unitOfWork.TipoContactos.Remove(TipoContacto);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
        }

}