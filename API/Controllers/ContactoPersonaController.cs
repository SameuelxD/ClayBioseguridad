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
    public class ContactoPersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactoPersonaDto>>> Get()
        {
            var ContactoPersonas = await _unitOfWork.ContactoPersonas.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<ContactoPersonaDto>>(ContactoPersonas);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPersonaDto>> Post(ContactoPersonaDto contactoPersonaDto)
        {
            var contactoPersona = _mapper.Map<Contactopersona>(contactoPersonaDto);
            this._unitOfWork.ContactoPersonas.Add(contactoPersona);
            await _unitOfWork.SaveAsync();
            if (contactoPersona == null)
            {
                return BadRequest();
            }
            contactoPersonaDto.Id = contactoPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = contactoPersonaDto.Id }, contactoPersonaDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoPersonaDto>> Get(int id)
        {
            var ContactoPersona = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);
            if (ContactoPersona == null)
            {
                return NotFound();
            }
            return _mapper.Map<ContactoPersonaDto>(ContactoPersona);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPersonaDto>> Put(int id, [FromBody] ContactoPersonaDto ContactoPersonaDto)
        {
            if (ContactoPersonaDto == null)
            {
                return NotFound();
            }
            var contactoPersona = _mapper.Map<Contactopersona>(ContactoPersonaDto);
            _unitOfWork.ContactoPersonas.Update(contactoPersona);
            await _unitOfWork.SaveAsync();
            return ContactoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var ContactoPersona = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);
            if (ContactoPersona == null)
            {
                return NotFound();
            }
            _unitOfWork.ContactoPersonas.Remove(ContactoPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}