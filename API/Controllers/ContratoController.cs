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
    public class contratoController : BaseController
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
        
            public contratoController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IEnumerable<ContratoDto>>> Get()
            {
                var contratos = await _unitOfWork.Contratos.GetAllAsync();
        
                //var paises = await _unitOfWork.Paises.GetAllAsync();
                return _mapper.Map<List<ContratoDto>>(contratos);
            }
        
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<ContratoDto>> Post(ContratoDto contratoDto)
            {
                var contrato = _mapper.Map<Contrato>(contratoDto);
                this._unitOfWork.Contratos.Add(contrato);
                await _unitOfWork.SaveAsync();
                if (contrato == null)
                {
                    return BadRequest();
                }
                contratoDto.Id = contrato.Id;
                return CreatedAtAction(nameof(Post), new { id = contratoDto.Id }, contratoDto);
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<ContratoDto>> Get(int id)
            {
                var contrato = await _unitOfWork.Contratos.GetByIdAsync(id);
                if (contrato == null){
                    return NotFound();
                }
                return _mapper.Map<ContratoDto>(contrato);
            }
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<ContratoDto>> Put(int id, [FromBody] ContratoDto ContratoDto)
            {
                if (ContratoDto == null)
                {
                    return NotFound();
                }
                var contratos = _mapper.Map<Contrato>(ContratoDto);
                _unitOfWork.Contratos.Update(contratos);
                await _unitOfWork.SaveAsync();
                return ContratoDto;
            }
        
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id)
            {
                var contrato = await _unitOfWork.Contratos.GetByIdAsync(id);
                if (contrato == null)
                {
                    return NotFound();
                }
                _unitOfWork.Contratos.Remove(contrato);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
        }
}