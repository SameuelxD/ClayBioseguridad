using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
    using global::API.Dtos;
    using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonaController : BaseController
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
        
            public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
            {
                var Personas = await _unitOfWork.Personas.GetAllAsync();
        
                //var paises = await _unitOfWork.Paises.GetAllAsync();
                return _mapper.Map<List<PersonaDto>>(Personas);
            }
        
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<PersonaDto>> Post(PersonaDto PersonaDto)
            {
                var Persona = _mapper.Map<Persona>(PersonaDto);
                this._unitOfWork.Personas.Add(Persona);
                await _unitOfWork.SaveAsync();
                if (Persona == null)
                {
                    return BadRequest();
                }
                PersonaDto.Id = Persona.Id;
                return CreatedAtAction(nameof(Post), new { id = PersonaDto.Id }, PersonaDto);
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<PersonaDto>> Get(int id)
            {
                var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
                if (Persona == null){
                    return NotFound();
                }
                return _mapper.Map<PersonaDto>(Persona);
            }
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto PersonaDto)
            {
                if (PersonaDto == null)
                {
                    return NotFound();
                }
                var Personas = _mapper.Map<Persona>(PersonaDto);
                _unitOfWork.Personas.Update(Personas);
                await _unitOfWork.SaveAsync();
                return PersonaDto;
            }
        
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id)
            {
                var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
                if (Persona == null)
                {
                    return NotFound();
                }
                _unitOfWork.Personas.Remove(Persona);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
        }
}
}